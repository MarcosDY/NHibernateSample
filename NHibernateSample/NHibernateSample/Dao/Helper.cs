using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace NHibernateSample.Dao
{
    public class Helper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;
        private static HbmMapping _mapping;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = Configuration.BuildSessionFactory()); }
        }

        public static Configuration Configuration
        {
            get { return _configuration ?? (_configuration = CreateConfiguration()); }
        }

        public static HbmMapping Mapping
        {
            get { return _mapping ?? (_mapping = CreateMapping()); }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new List<System.Type> { typeof(PersonMap), typeof(AddressMap) });

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}

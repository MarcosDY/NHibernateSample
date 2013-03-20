using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateSample.Model;

namespace NHibernateSample.Dao
{
    public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id, map =>
            {
               map.Generator(Generators.GuidComb);
               map.Column("PersonId");
            });
            Property(x => x.FirstName, m => m.NotNullable(true));
            Property(x => x.LastName, m => m.NotNullable(true));
            Property(x => x.BirthDate, map => map.Type(NHibernateUtil.Date));
            
            Bag(x => x.Address, m =>
                {
                    m.Inverse(true);
                    m.Key(k => k.Column("PersonId"));
                    m.Cascade(Cascade.All);
                    m.Lazy(CollectionLazy.NoLazy);
                }, rel => rel.OneToMany());

        }
    }
}

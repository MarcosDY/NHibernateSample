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
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.BirthDate, map => map.Type(NHibernateUtil.Date));
            OneToOne(x => x.Address,
                     map =>
                     {
                         map.PropertyReference(typeof(Address).GetProperty("Person"));
                         map.Cascade(Cascade.All);
                     });
        }
    }
}

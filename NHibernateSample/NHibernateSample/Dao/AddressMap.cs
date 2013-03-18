using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateSample.Model;

namespace NHibernateSample.Dao
{
    public class AddressMap : ClassMapping<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id, map =>
            {
               map.Generator(Generators.GuidComb);
               map.Column("AddressId");
            });
            Property(x=> x.Name);
            Property(x=> x.Number);
            Property(x => x.State);
            Property(x=> x.City);

            ManyToOne(x => x.Person, m => m.Column("PersonId"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateSample.Model
{
    public class Person : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Address> Address { get; set; }
        public virtual DateTime BirthDate { get; set; }
       
        public override string ToString()
        {
            return string.Format("Id: {0},\n FirstName: {1},\n LastName: {2},\n BirthDate{3},\n Address:{4}", Id, FirstName,
                                 LastName, BirthDate, Address);

        }
    }
}

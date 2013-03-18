using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateSample.Model
{
    public class Address : Entity
    {
        public virtual String Name { get; set; }
        public virtual int Number { get; set; }
        public virtual String City { get; set; }
        public virtual String State { get; set; }
        public virtual Person Person { get; set; }
    }
}

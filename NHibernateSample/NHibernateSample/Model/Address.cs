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
        public override string ToString()
        {
            return string.Format("Address ---- \n Id: {0},\n Name: {1},\n Number: {2},\n City{3},\n State:{4}", Id, Name,
                                 Number, City, State);

        }
    }

}

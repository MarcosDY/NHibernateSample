using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateSample.Model;

namespace NHibernateSample.Dao
{
    public interface IPersonRepository
    {
        Person Get(Guid id);
        void Save(Person person);
        void Update(Person person);
        void Delete(Person person);
        long RowCount();
    }
}

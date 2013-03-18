using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernateSample.Model;

namespace NHibernateSample.Dao
{
    public class NHibernatePersonRepository : IPersonRepository
    {

        public void Save(Person person)
        {
            using (var session = Helper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(person);
                transaction.Commit();
            }
        }

        public Person Get(Guid id)
        {
            using (var session = Helper.OpenSession())
                return session.Get<Person>(id);
        }

        public void Update(Person person)
        {
            using (var session = Helper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(person);
                transaction.Commit();
            }
        }

        public void Delete(Person person)
        {
            using (var session = Helper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(person);
                transaction.Commit();
            }
        }

        public long RowCount()
        {
            using (var session = Helper.OpenSession())
            {
                return session.QueryOver<Person>().RowCountInt64();
            }
        }
        
    }
}

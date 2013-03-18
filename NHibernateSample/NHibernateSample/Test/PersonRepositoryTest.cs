using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;
using NHibernateSample.Dao;
using NHibernateSample.Model;
using NUnit.Framework;

namespace NHibernateSample.Test
{
    [TestFixture]
    public class PersonRepositoryTest
    {
        private IPersonRepository _personRepo;
        
        [SetUp]
        public void CreateSchema()
        {
            DeleteDatabaseIfExists();

            var schemaUpdate = new SchemaUpdate(Helper.Configuration);
            schemaUpdate.Execute(false, true);

            _personRepo = new NHibernatePersonRepository();
        }

        [Test]
        public void CanSavePerson()
        {
            var person = new Person
                {
                    FirstName = "Marcos",
                    LastName = "yacob",
                    BirthDate = new DateTime(1983, 5, 2),
                    Address = new Address {State = "Entre Ríos", City = "Paraná", Name = "Blass Parera", Number = 748}
                };

            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());
        }

        [Test]
        public void CanGetPerson()
        {
            var person = new Person
            {
                FirstName = "Marcos",
                LastName = "yacob",
                BirthDate = new DateTime(1983, 5, 2),
                Address = new Address { State = "Entre Ríos", City = "Paraná", Name = "Blass Parera", Number = 748 }
            }; 
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            person = _personRepo.Get(person.Id);
            Assert.IsNotNull(person);
        }

        [Test]
        public void CanUpdatePerson()
        {
            var person = new Person
            {
                FirstName = "Marcos",
                LastName = "yacob",
                BirthDate = new DateTime(1983, 5, 2),
                Address = new Address { State = "Entre Ríos", City = "Paraná", Name = "Blass Parera", Number = 748 }
            }; 
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            person = _personRepo.Get(person.Id);
            person.FirstName = "Damián";
            _personRepo.Update(person);

            Assert.AreEqual(1, _personRepo.RowCount());
            Assert.AreEqual("Damián", _personRepo.Get(person.Id).FirstName);
        }

        [Test]
        public void CanDeletePerson()
        {
            var person = new Person();
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            _personRepo.Delete(person);
            Assert.AreEqual(0, _personRepo.RowCount());
        }

        [TearDown]
        public void DeleteDatabaseIfExists()
        {
            if (File.Exists("sample.db"))
                File.Delete("sample.db");
        }
    }
}

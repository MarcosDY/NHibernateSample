using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;
using NHibernateSample.Dao;
using NHibernateSample.Model;

namespace NHibernateSample
{
    class NHibernateSample
    {
        private IPersonRepository _personRepo;
        
        public void CreateSchema()
        {
            DeleteDatabaseIfExists();

            var schemaUpdate = new SchemaUpdate(Helper.Configuration);
            schemaUpdate.Execute(false, true);

            _personRepo = new NHibernatePersonRepository();
        }


        static void Main(string[] args)
        {
            var sample = new NHibernateSample();
            sample.CreateSchema();
            var person = new Person
            {
                FirstName = "Marcos",
                LastName = "yacob",
                BirthDate = new DateTime(1983, 5, 2),
                Address = new List<Address>() { new Address { State = "Entre Ríos", City = "Paraná", Name = "Blass Parera", Number = 748 } }
            };

            Console.WriteLine("unsaved: "+person);
            
            sample.SavePerson(person);
            Console.WriteLine("postSave: " + person);
            Console.ReadKey();
            
            var savedPerson = sample.GetPersonById(person.Id);
            Console.WriteLine("saved: " + person);
            Console.ReadKey();

            savedPerson.FirstName = "Damián";
            sample.UpdatePerson(savedPerson);
            var updatedPerson = sample.GetPersonById(person.Id);
            Console.WriteLine("Updated: " + updatedPerson);
            Console.ReadKey();

            sample.DeletePerson(savedPerson);
            var deletedPerson = sample.GetPersonById(savedPerson.Id);
            Console.WriteLine("Deleted: " + deletedPerson);
            Console.ReadKey();

            sample.DeleteDatabaseIfExists();

        }

        public void SavePerson(Person pPerson)
        {
            _personRepo.Save(pPerson);
        }

        public Person GetPersonById(Guid pId)
        {
            return _personRepo.Get(pId);
       }

        public void UpdatePerson(Person pPerson)
        {
            _personRepo.Update(pPerson);
        }

        public void DeletePerson(Person pPerson)
        {
            _personRepo.Delete(pPerson);
        }

        public void DeleteDatabaseIfExists()
        {
            if (File.Exists("sample.db"))
                File.Delete("sample.db");
        }


    }
}

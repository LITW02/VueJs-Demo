using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJs.Data
{
    public class PersonRepo
    {
        private string _connectionString;

        public PersonRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var ctx = new PersonDbDataContext(_connectionString))
            {
                return ctx.Persons.ToList();
            }
        }

        public void AddPerson(Person person)
        {
            using (var ctx = new PersonDbDataContext(_connectionString))
            {
                ctx.Persons.InsertOnSubmit(person);
                ctx.SubmitChanges();
            }
        }

        public void Update(Person person)
        {
            using (var context = new PersonDbDataContext(_connectionString))
            {
                context.Persons.Attach(person);
                context.Refresh(RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PersonDbDataContext(_connectionString))
            {
                context.ExecuteCommand("DELETE FROM People WHERE Id = {0}", id);
            }
        }
    }
}

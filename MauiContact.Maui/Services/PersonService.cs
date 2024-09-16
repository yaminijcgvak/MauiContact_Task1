
#nullable disable
using MauiContact.Maui.Modals;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiContact.Maui.Services
{
    public class PersonService
    {

        private SQLiteAsyncConnection _database;
        public PersonService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "People.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetAllAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            return _database.Table<Person>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> AddAsync(Person person)
        {
            return _database.InsertAsync(person);
        }

        public Task<int> UpdateAsync(Person person)
        {
            return _database.UpdateAsync(person);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _database.DeleteAsync<Person>(id);
        }
    }
}

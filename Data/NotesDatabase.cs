using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayPlanner.Models;


namespace HolidayPlanner.Data
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Notes>().Wait();
        }
        public Task<List<Notes>> GetNotesAsync()
        {
            return _database.Table<Notes>().ToListAsync();
        }

        public Task<Notes> GetNotesAsync(int id)
        {
            return _database.Table<Notes>()
           .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveNotesAsync(Notes slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }

        }
        public Task<int> DeleteNotesAsync(Notes slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}

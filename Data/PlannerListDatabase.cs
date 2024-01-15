using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using HolidayPlanner.Models;
using System.Collections;

namespace HolidayPlanner.Data
{
    public class PlannerListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public PlannerListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PlannerList>().Wait();
        }

        public Task<List<PlannerList>> GetPlannerListAsync()
        {
            return _database.Table<PlannerList>().ToListAsync();
        }

        public Task<PlannerList> GetPlannerListAsync(int id)
        {
            return _database.Table<PlannerList>()
           .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SavePlannerListAsync(PlannerList slist)
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

        public Task<int> DeletePlannerListAsync(PlannerList slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}

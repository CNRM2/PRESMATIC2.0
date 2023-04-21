
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRESMATIC2;
using PRESMATIC2._0.Models;

namespace PRESMATIC2._0.Database
{
    public class LoginDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LoginDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserInfo>().Wait();
        }

        public Task<UserInfo> GetLoginDataAsync(string userName)
        {
            return database.Table<UserInfo>()
                            .Where(i => i.Username == userName)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginDataAsync(UserInfo loginData)
        {
            return database.InsertAsync(loginData);
        }
    }
}

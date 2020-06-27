using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
namespace PocketAssistant
{
   public class ExpenceRepository
    {
        SQLiteConnection database;
        public ExpenceRepository(string databasePath)
        {
            
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Expences>();
        }
        public List<Expences> GetItems()
        {
             List<Expences> expences = database.Table<Expences>().ToList();
           
           
            return expences;
        }
       
        public Expences GetItem(int id)
        {
            return database.Get<Expences>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Expences>(id);
        }
        public int SaveItem(Expences item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

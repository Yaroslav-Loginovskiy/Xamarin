using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PocketAssistant.DataRepositories
{
    public class LentRepository
    {
        SQLiteConnection Lentdatabase;
        public LentRepository(string databasePath)
        {

            Lentdatabase = new SQLiteConnection(databasePath);
            Lentdatabase.CreateTable<LentClass>();
        }
        public List<LentClass> GetItems()
        {
            List<LentClass> lents = Lentdatabase.Table<LentClass>().ToList();

            return lents;
        }
        public LentClass GetItem(int id)
        {
            return Lentdatabase.Get<LentClass>(id);
        }
        public int DeleteItem(int id)
        {
            return Lentdatabase.Delete<LentClass>(id);
        }
        public int SaveItem(LentClass item)
        {
            if (item.Id != 0)
            {
                Lentdatabase.Update(item);
                return item.Id;
            }
            else
            {
                return Lentdatabase.Insert(item);
            }
        }
    }
}

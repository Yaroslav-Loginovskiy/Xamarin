using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PocketAssistant.DataRepositories
{
    public class BorrowRepository
    {
        SQLiteConnection Borrowdatabase;
        public BorrowRepository(string databasePath)
        {

            Borrowdatabase = new SQLiteConnection(databasePath);
            Borrowdatabase.CreateTable<Borrow>();
        }
        public List<Borrow> GetItems()
        {
            List<Borrow> borrow = Borrowdatabase.Table<Borrow>().ToList();

            return borrow;
        }
        public Borrow GetItem(int id)
        {
            return Borrowdatabase.Get<Borrow>(id);
        }
        public int DeleteItem(int id)
        {
            return Borrowdatabase.Delete<Borrow>(id);
        }
        public int SaveItem(Borrow item)
        {
            if (item.Id != 0)
            {
                Borrowdatabase.Update(item);
                return item.Id;
            }
            else
            {
                return Borrowdatabase.Insert(item);
            }
        }
    }
}

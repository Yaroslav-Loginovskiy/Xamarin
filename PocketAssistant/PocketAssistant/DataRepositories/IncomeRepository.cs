using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace PocketAssistant
{
    public class IncomeRepository
    {
        SQLiteConnection Incdatabase;
        public IncomeRepository(string databasePath)
        {

            Incdatabase = new SQLiteConnection(databasePath);
            Incdatabase.CreateTable<Incomes>();
        }
        public List<Incomes> GetItems()
        {
            List<Incomes> incomes = Incdatabase.Table<Incomes>().ToList();

            return incomes;
        }
        public Incomes GetItem(int id)
        {
            return Incdatabase.Get<Incomes>(id);
        }
        public int DeleteItem(int id)
        {
            return Incdatabase.Delete<Incomes>(id);
        }
        public int SaveItem(Incomes item)
        {
            if (item.Id != 0)
            {
                Incdatabase.Update(item);
                return item.Id;
            }
            else
            {
                return Incdatabase.Insert(item);
            }
        }
    }
}

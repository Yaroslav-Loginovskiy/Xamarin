using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PocketAssistant
{
    [Table("Borrow")]
    public class Borrow
    {
        [PrimaryKey,AutoIncrement,Column("_id")]
        public int Id { get; set; }

        
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        public string Date { get; set; }
        public override string ToString()
        {
            return this.Name + " " + this.Amount + " BLR " + "    (" + this.Date + ")";


        }
    }
}

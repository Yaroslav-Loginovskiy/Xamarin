using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PocketAssistant
{
    [Table("Expences")]
    public class Expences
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string AmountExp { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return this.Id + ")" + " - " + this.AmountExp + " BLR " + "(" + this.Description +")";

         
        }
        
    }
}

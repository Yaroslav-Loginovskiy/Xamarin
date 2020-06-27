using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PocketAssistant
{
    [Table("Incomes")]
    public class Incomes
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

       
        public string AmountInc { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return this.Id + ")" + " + " + this.AmountInc + " BLR " + "    (" + this.Description + ")";


        }
        //public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PocketAssistant
{
   public  interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}

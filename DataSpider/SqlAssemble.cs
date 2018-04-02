using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSpider.Stock
{
    public static class SqlAssemble
    {
        public static string sqlCreateTable_StockInfo = @"
        CREATE TABLE ""StockInfo"" (
          ""Stock_Code"" text NOT NULL,
          ""Stock_Name"" TEXT,
          ""Stock_Type"" integer NOT NULL,
          ""Stock_Exchange"" TEXT,
          ""Stock_StartDate"" text,
          ""Stock_CreateDate"" TEXT,
          PRIMARY KEY(""Stock_Code"")
        );";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataSpider.Stock
{
    public class StockInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }

        private int _type;
        public int Type
        {
            get { return _type; } 
            set { _type = value;} 
        }
        public string Exchange { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }

    }
}

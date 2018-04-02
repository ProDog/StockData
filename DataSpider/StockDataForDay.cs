using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSpider.Stock
{
    public class JsonData
    {
        public StockDataForDay Json { get; set; }
    }
    public class StockDataForDay
    {
        public int Status { get; set; }
        public string HQ { get; set; }
        public string Code { get; set; }
    }

    public class HQ
    {
        public string Code;
        public DateTime StartDate { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public double ChangePrice { get; set; }
        public double ChangeRatio { get; set; }
        public double LowPrice { get; set; }
        public double HighPrice { get; set; }
        public int TotalHand { get; set; }
        public double TotalAmount { get; set; }
        public double ChangeHandRate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

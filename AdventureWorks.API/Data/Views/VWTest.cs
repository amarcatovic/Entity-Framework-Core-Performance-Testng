using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.API.Data.Views
{
    public class VWTest
    {
        public int SalesOrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public string SalesOrderNumber { get; set; }

        public Guid Rowguid { get; set; }

        public decimal UnitPrice { get; set; }

        public string Name { get; set; }
    }
}

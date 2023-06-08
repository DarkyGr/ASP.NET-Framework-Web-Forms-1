using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_EntityLayer
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public Department department { get; set; }
        public decimal salary { get; set; }
        public string contractDate { get; set; }
    }
}

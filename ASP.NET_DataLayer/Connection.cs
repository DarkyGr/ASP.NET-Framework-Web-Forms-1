using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_DataLayer
{
    public class Connection
    {
        // Connection from WebForms Layer
        public static string SQLString = ConfigurationManager.ConnectionStrings["SQLString"].ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ASP.NET_DataLayer;
using ASP.NET_EntityLayer;

namespace ASP.NET_BusinessLayer
{
    public class DepartmentBL
    {
        DepartmentDL departmentDL = new DepartmentDL();

        public List<Department> list()
        {
            try
            {
                return departmentDL.listDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

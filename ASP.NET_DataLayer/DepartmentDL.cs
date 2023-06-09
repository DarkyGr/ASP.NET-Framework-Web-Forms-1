using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ASP.NET_EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_DataLayer
{
    public class DepartmentDL
    {
        public List<Department> listDepartment() {
            List<Department> list = new List<Department>();

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("select * from fn_departments()", oConnection);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Department
                            {
                                departmentId = Convert.ToInt32(dr["departmentId"].ToString()),
                                departmentName = dr["departmentName"].ToString()
                            });
                        }
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
        }
    }
}

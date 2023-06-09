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
    public class EmployeeDL
    {
        public List<Employee> listEmployee()
        {
            List<Employee> list = new List<Employee>();

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("select * from fn_employees()", oConnection);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Employee
                            {
                                employeeId = Convert.ToInt32(dr["employeeId"].ToString()),
                                employeeName = dr["employeeName"].ToString(),
                                department = new Department
                                {
                                    departmentId = Convert.ToInt32(dr["departmentId"].ToString()),
                                    departmentName = dr["departmentName"].ToString()
                                },
                                salary = Convert.ToDecimal(dr["salary"]),
                                contractDate = dr["contractDate"].ToString()
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

        public Employee getEmployee(int employeeId)
        {
            Employee entity = new Employee();

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("select * from fn_employee(@employeeId)", oConnection);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entity.employeeId = Convert.ToInt32(dr["employeeId"].ToString());
                            entity.employeeName = dr["employeeName"].ToString();
                            entity.department = new Department
                            {
                                departmentId = Convert.ToInt32(dr["departmentId"].ToString()),
                                departmentName = dr["departmentName"].ToString()
                            };
                            entity.salary = Convert.ToDecimal(dr["salary"]);
                            entity.contractDate = dr["contractDate"].ToString();
                        }
                    }

                    return entity;
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool createEmployee(Employee entity)
        {
            bool response = false;

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("sp_CreateEmployee", oConnection);
                cmd.Parameters.AddWithValue("@employeeName", entity.employeeName);
                cmd.Parameters.AddWithValue("@departmentId", entity.department.departmentId);
                cmd.Parameters.AddWithValue("@salary", entity.salary);
                cmd.Parameters.AddWithValue("@contractDate", entity.contractDate);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        response = true;
                    }

                    return response;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool updateEmployee(Employee entity)
        {
            bool response = false;

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", oConnection);
                cmd.Parameters.AddWithValue("@employeeId", entity.employeeId);
                cmd.Parameters.AddWithValue("@employeeName", entity.employeeName);
                cmd.Parameters.AddWithValue("@departmentId", entity.department.departmentId);
                cmd.Parameters.AddWithValue("@salary", entity.salary);
                cmd.Parameters.AddWithValue("@contractDate", entity.contractDate);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        response = true;
                    }

                    return response;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool deleteEmployee(int employeeId)
        {
            bool response = false;

            // Create connection
            using (SqlConnection oConnection = new SqlConnection(Connection.SQLString))
            {
                // Create query with the function created
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", oConnection);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        response = true;
                    }

                    return response;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}

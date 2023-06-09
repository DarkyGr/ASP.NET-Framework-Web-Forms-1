using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ASP.NET_DataLayer;
using ASP.NET_EntityLayer;

namespace ASP.NET_BusinessLayer
{
    public class EmployeeBL
    {
        EmployeeDL employeeDL = new EmployeeDL();

        public List<Employee> list()
        {
            try
            {
                return employeeDL.listEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee getEmployee(int employeeId) {
            try
            {
                return employeeDL.getEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool createEmployee(Employee entity)
        {
            try
            {
                if (entity.employeeName == "")
                {
                    throw new OperationCanceledException("The name field cannot be empty");
                }

                return employeeDL.createEmployee(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateEmployee(Employee entity)
        {
            try
            {
                var found = employeeDL.getEmployee(entity.employeeId);

                if (found.employeeId == 0)
                {
                    throw new OperationCanceledException("The employee doesn't exist");
                }

                return employeeDL.updateEmployee(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteEmployee(int employeeId)
        {
            try
            {
                var found = employeeDL.getEmployee(employeeId);

                if (found.employeeId == 0)
                {
                    throw new OperationCanceledException("The employee doesn't exist");
                }

                return employeeDL.deleteEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

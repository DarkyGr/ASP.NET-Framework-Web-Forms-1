using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP.NET_EntityLayer;
using ASP.NET_BusinessLayer;

namespace ASP.NET_WebForm_1
{
    public partial class _Default : Page
    {

        EmployeeBL employeeBL = new EmployeeBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            showEmployees();
        }

        public void showEmployees()
        {
            List<Employee> list = employeeBL.list();

            GVEmployee.DataSource = list;
            GVEmployee.DataBind();
        }

        protected void New_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?employeeId=0");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            // Get Employee ID
            LinkButton btn = (LinkButton)sender;
            string employeeId = btn.CommandArgument;

            Response.Redirect($"~/Contact.aspx?employeeId={employeeId}");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            // Get Employee ID
            LinkButton btn = (LinkButton)sender;
            string employeeId = btn.CommandArgument;

            bool response = employeeBL.deleteEmployee(Convert.ToInt32(employeeId));

            // refresh list
            if (response)
            {
                showEmployees();
            }
        }
    }
}
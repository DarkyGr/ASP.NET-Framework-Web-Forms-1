using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP.NET_EntityLayer;
using ASP.NET_BusinessLayer;
using System.Globalization;

namespace ASP.NET_WebForm_1
{
    public partial class Contact : Page
    {
        private static int employeeId = 0;
        DepartmentBL departmentBL = new DepartmentBL();
        EmployeeBL employeeBL = new EmployeeBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load if not is a Post Back
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["employeeId"] != null)
                {
                    employeeId = Convert.ToInt32(Request.QueryString["employeeId"].ToString());

                    if (employeeId != 0)
                    {
                        LblTitle.Text = "Edit Employee";
                        BtnSubmit.Text = "Update";

                        Employee employee = employeeBL.getEmployee(employeeId);
                        TxtFullName.Text = employee.employeeName;
                        LoadDepartments(employee.department.departmentId.ToString());
                        
                        TxtSalary.Text = employee.salary.ToString();

                        TxtContractDate.Text = Convert.ToDateTime(employee.contractDate, new CultureInfo("es-MX")).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        LblTitle.Text = "New Employee";
                        BtnSubmit.Text = "Save";

                        LoadDepartments();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void LoadDepartments(string departmentId = "")
        {
            List<Department> list = departmentBL.list();

            DdlDepartments.DataTextField = "departmentName";
            DdlDepartments.DataValueField = "departmentId";

            DdlDepartments.DataSource = list;
            DdlDepartments.DataBind();

            if(departmentId != "")
            {
                DdlDepartments.SelectedValue = departmentId;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                employeeId = employeeId,
                employeeName = TxtFullName.Text,
                department = new Department() { 
                    departmentId = Convert.ToInt32(DdlDepartments.SelectedValue)
                },
                salary = Convert.ToDecimal(TxtSalary.Text, new CultureInfo("es-MX")),
                contractDate = TxtContractDate.Text
            };

            bool response;

            if(employeeId != 0) 
            {
                response = employeeBL.updateEmployee(employee);
            }
            else
            {
                response = employeeBL.createEmployee(employee);
            }

            if(response)
            {
                Response.Redirect("~/Defatult.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This operation couldn't be performed')", true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {

        List<Employee> employeeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide Employee location div 
            employee.Visible = false;
            var context = new HospitalDBEntities();

            employeeList = context.Employees.ToList();

            EmpDetails.DataSource = employeeList.ToList();
            EmpDetails.DataBind();
        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            employee.Visible = true;
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            employeeGrid.DataSource = employeeList.Where(x => x.EmployeeID == id).Select(x => x.Ward1).ToList();
            employeeGrid.DataBind();





        }

        protected override void OnPreInit(EventArgs e)
        {
            int position = 0;
            //Checks which user is entering the system and chooses the master pages for them
            //checks if the session is null or not
            if (Session.Count > 0)
            {
                position = ((Employee)Session["employee"]).EmployeeType.Value;
            }
            if (position == 5)
            {
                MasterPageFile = "~/Receptionist.Master";
            }
            else if (position == 4)
            {
                MasterPageFile = "~/Laboratory.Master";
            }
            else if (position == 3)
            {
                MasterPageFile = "~/Nurse.Master";
            }
            else if (position == 2)
            {
                MasterPageFile = "~/Pharmacist.Master";
            }
            else if (position == 1)
            {
                MasterPageFile = "~/Doctor.Master";
            }
            else
            {
                MasterPageFile = "~/Site1.Master";
            }
        }
    }
}
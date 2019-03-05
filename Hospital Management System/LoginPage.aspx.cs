using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idTxtBox.Text.ToString());
            String password = passwordTxtBox.Text.ToString();
            var context = new HospitalDBEntities();
            Employee employee = context.Employees.FirstOrDefault(x => (x.EmployeeID == id && x.Password == password));
            if (employee == null)
            {
                errorMessageDiv.Visible = true;
                errorMessage.Text = "UserId or Password is Inncorrect !!";
                errorMessage.Font.Bold = true;
            }
            else
            {
                Session["employee"] = employee;
                Response.Redirect("LoginPage.aspx");

            }
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
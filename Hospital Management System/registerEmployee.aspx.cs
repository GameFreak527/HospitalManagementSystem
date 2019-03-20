using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = new HospitalDBEntities();
                Employee emp = new Employee();
                emp.Ward = Convert.ToInt32(wardNumber.Text);
                emp.EmployeeType = Convert.ToInt32(employeeType.Text);
                emp.FirstName = firstName.Text;
                emp.LastName = lastName.Text;
                emp.PhoneNumber = contactNumber.Text;
                emp.Address = address.Text;
                emp.Email = emailID.Text;
                emp.Password = userPassword.Text;
                emp.SIN = sinNumber.Text;

                connectionString.Employees.Add(emp);
                connectionString.SaveChanges();

                wardNumber.Text = " ";
                employeeType.Text = " ";
                firstName.Text = " ";
                lastName.Text = " ";
                contactNumber.Text = " ";
                address.Text = " ";
                emailID.Text = " ";
                userPassword.Text = " ";
                sinNumber.Text = " ";
                registerLblSuccess.Text = "User Registered Successfully with login Employee ID " + emp.EmployeeID  ;
                registerLblError.Text = "";

            }
            catch
            {
                registerLblError.Text = "User is not registered";
            }
           



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            int position = 0;

            //Checks which user is entering the system and chooses the master pages for them
            //checks if the session is null or not
            if (Session["employee"] != null)

            {
                position = ((Employee)Session["employee"]).EmployeeType.Value;
            }
            if (position == 6)
            {
                MasterPageFile = "~/Admin.Master";
            }
            else if (position == 5)
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
        protected void Page_Load(object sender, EventArgs e)
        {
            usernameTxt.Text = ((Employee)Session["employee"]).Email.ToString();
        }



        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var ConnectionString = new HospitalDBEntities();
                string username = usernameTxt.Text;
                Employee emp = ConnectionString.Employees.FirstOrDefault(x => (x.Email == username));
                if (PasswordTxt.Text.Equals(emp.Password))
                {
                    if (changePasswordTxt2.Text != null)
                    {
                        emp.Password = changePasswordTxt2.Text;
                        ConnectionString.SaveChangesAsync();
                        passwordSuccess.Text = " Password changed successfully";
                        passwordFailure.Text = "";
                    }
                }
                else
                {
                    passwordFailure.Text = "Old Password is incorrect";
                    passwordSuccess.Text = "";
                }
            }catch
            {
                passwordFailure.Text = "password doesnot change";
            }



        }
    }
}
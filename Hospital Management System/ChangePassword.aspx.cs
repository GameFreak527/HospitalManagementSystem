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
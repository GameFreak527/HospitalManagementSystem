using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class Pharmacist : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["employee"];
            if (employee != null)
            {
                userName.InnerText = ((Employee)Session["employee"]).FirstName;
                Login.InnerText = "Logout";
            }
            else
            {
                userNameBlock.Visible = false;
                changePasswordBlock.Visible = false;
            }

        }
    }
}
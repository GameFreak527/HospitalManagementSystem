using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class UpdateReportSearchIDPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (int.TryParse(IDTextBox.Text, out i) == true)
            {
                try
                {
                   int found = ConnectionClass.IsRecordFound(i);


                    Session["ReportID"] = i;

                    errorLabel.ForeColor = System.Drawing.Color.Green;
                    errorLabel.Text = "Records Found";

                    if (found > 0) {

                        Response.Redirect("UpdateReportPage.aspx");
                        errorLabel.Text = "Records Found after Query";
                    }
                    
                }

                catch {
                    errorLabel.ForeColor = System.Drawing.Color.Red;
                    errorLabel.Text = "Search Failed";
                }
            }

            else {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "No Records Found";
            }




        }
    }
}
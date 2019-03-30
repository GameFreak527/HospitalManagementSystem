using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class UpdateReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Holds employee id from textbox
            int patientID = 0;

            //Holds patient id from textbox
            int employeeID = 0;

            int reportID = (int)Session["ReportID"];

            //the employee ID variable
            if (int.TryParse(EmployeeIDTextBox.Text, out employeeID) == true &&
                int.TryParse(PatientIDTextBox.Text, out patientID) &&
                String.IsNullOrWhiteSpace(PrescriptionTextBox.Text) == false &&
                  String.IsNullOrWhiteSpace(DiagnosisTextBox.Text) == false)
            {
                try
                {
                    ConnectionClass.UpdateReport(Convert.ToInt32(EmployeeIDTextBox.Text),
                       Convert.ToInt32(PatientIDTextBox.Text), DiagnosisTextBox.Text,
                       PrescriptionTextBox.Text, reportID);

                    errorLabel.ForeColor = System.Drawing.Color.Green;
                    errorLabel.Text = "Report Was Updated Successfully";
                }

                catch
                {
                    errorLabel.ForeColor = System.Drawing.Color.Red;
                    errorLabel.Text = "Report Could not Be Updated";
                }
            }

            else
            {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "Report Could not Be Updated, Please fill out all fields";
            }
        }
    }
}
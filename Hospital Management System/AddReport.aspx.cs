using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class AddReport : System.Web.UI.Page
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Holds employee id from textbox
            int patientID = 0;

            //Holds patient id from textbox
            int employeeID = 0;

            //the employee ID variable
            if (int.TryParse(EmployeeIDTextBox.Text, out employeeID) == true &&
                int.TryParse(PatientIDTextBox.Text, out patientID) && 
                String.IsNullOrWhiteSpace(PrescriptionTextBox.Text) == false &&
                  String.IsNullOrWhiteSpace(DiagnosisTextBox.Text) == false)
            {
                try
                {
                    ConnectionClass.AddReportWithoutAppointmentID(Convert.ToInt32(EmployeeIDTextBox.Text),
                       Convert.ToInt32(PatientIDTextBox.Text), DiagnosisTextBox.Text, 
                       PrescriptionTextBox.Text);

                    errorLabel.ForeColor = System.Drawing.Color.Green;
                    errorLabel.Text = "Report Was Added Successfully";
                }

                catch
                {
                    errorLabel.ForeColor = System.Drawing.Color.Red;
                    errorLabel.Text = "Report Could not Be Added";
                }
            }

            else {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "Report Could not Be Added, Please fill out all fields";
            }
        }


    }
}
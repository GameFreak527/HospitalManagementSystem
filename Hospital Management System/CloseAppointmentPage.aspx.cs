using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class CloseAppointmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DB context
            var context = new HospitalDBEntities();

            //Holds Appointment ID from Session State
            int appointmentID = (int)Session["AppointmentID"];
            

            //Holds patient id from database.
            int patientID = (int)Session["PatientID"];

            
            //the employee ID variable
            if (String.IsNullOrWhiteSpace(PrescriptionTextBox.Text) == false &&
                String.IsNullOrWhiteSpace(DiagnosisTextBox.Text) == false &&
                 End_Calendar.SelectedDate != DateTime.MinValue &&
                   String.IsNullOrWhiteSpace(EndTime.Text) == false)
            {


                try
                {

                    //Holds employee id from session state.
                    int employeeID = ConnectionClass.GetAppointmentEmployeeID(appointmentID);

                    string precription = PrescriptionTextBox.Text;
                    string diagnosis = DiagnosisTextBox.Text;

                    DateTime endCalendarValue = End_Calendar.SelectedDate;
                    string endTime = endCalendarValue.ToShortDateString() + " " + EndTime.Text;

                    ConnectionClass.UpdateAndCloseAppointment(appointmentID, endTime, diagnosis,
                        precription);
                    ConnectionClass.AddReportWithAppointmentID(employeeID, patientID, diagnosis, 
                        precription, appointmentID);


                    errorLabel.ForeColor = System.Drawing.Color.Green;
                    errorLabel.Text = "Appointment Closed Successfully";

                   

                       Response.Redirect("ViewPatientsAppointmentPage.aspx");
                       
                    

                }

                catch
                {
                    errorLabel.ForeColor = System.Drawing.Color.Red;
                    errorLabel.Text = "Closure Failed";
                }
            }

            else
            {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "Closure Failed";
            }

        }




        protected override void OnPreInit(EventArgs e)
        {
            int position = 0;

            //Checks which user is entering the system and chooses the master pages for them
            //checks if the session is null or not
            if (Session["employee"] != null)

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

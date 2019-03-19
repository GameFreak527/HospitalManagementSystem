using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class BookAppointmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nothing Here

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

        //Event handler for the create apointment button
        protected void Button1_Click(object sender, EventArgs e)
        {
            //DB context
            var context = new HospitalDBEntities();

            //Holds employee id from textbox
            int i = 0;

            //Holds patient id from textbox
            int p = 0;

            //the employee ID variable
            if (int.TryParse(EmployeeTextBox.Text, out i) == true &&
                int.TryParse(EmployeeTextBox.Text, out p) &&
                 Begin_Calendar.SelectedDate != DateTime.MinValue
                  && End_Calendar.SelectedDate != DateTime.MinValue &&
                  Begin_Calendar.SelectedDate <= End_Calendar.SelectedDate
                 )
            {
                i = Convert.ToInt32(EmployeeTextBox.Text);


                //the patient

                //One Appointment
                Appointment appointment = context.Appointments.FirstOrDefault(x => x.Employee == i);

                Employee employee1 = context.Employees.FirstOrDefault(x => x.EmployeeID == i);

                // Query for all appointments with names starting with employee ID
                var appoint = from b in context.Appointments
                              where b.Employee.Value.Equals(i)
                              select b;

                //gets patient
                Patient patient = context.Patients.FirstOrDefault(x => (x.PatientID == p));


                //converting all the appointments found to a list
                List<Appointment> listOfAppointments = appoint.ToList();

                DateTime startCalendarValue = Begin_Calendar.SelectedDate;
                DateTime endCalendarValue = End_Calendar.SelectedDate;

                Label2.Text = listOfAppointments.Count.ToString();


                //Value will be tue if appointment is valid
              

                if (appoint.Count() != 0 &&  patient != null)
                {

                    //Dispose of db Context
                    context.Dispose();

                    //Adds the appointment to the database
                    Appointment appointmentToBeAdded = new Appointment();

                    string start = startCalendarValue.ToShortDateString() + " " + BeginTime.Text;
                    string end = endCalendarValue.ToShortDateString() + " " + EndTime.Text;


                    appointmentToBeAdded.EndTime = end;
                    appointmentToBeAdded.StartTime = start;
                    appointmentToBeAdded.Patient = p;
                    appointmentToBeAdded.Employee = i;
                    appointmentToBeAdded.Diagnosis = " ";
                    appointmentToBeAdded.Prescription = " ";







                    try
                    {


                        ConnectionClass.AddSchedule(appointmentToBeAdded);
                        errorLabel.ForeColor = System.Drawing.Color.Green;
                        errorLabel.Text = "Appointment Added Successfully";
                    }

                    catch (Exception f)
                    {

                        errorLabel.ForeColor = System.Drawing.Color.Red;
                        errorLabel.Text = "Appointment Could not be Added";
                    }
                }




            }//End of if


            else
            {

                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "an error occurred";

            }
        }

       
    }
}

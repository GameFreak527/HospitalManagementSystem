using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class ViewPatientsAppointmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPatientDetails();
        }

        protected void searchPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["AppointmentID"] = searchPatient.SelectedDataKey.Value;
            Response.Redirect("CloseAppointmentPage.aspx");

        }

        private void BindPatientDetails()
        {

            // Obtain the value of the selected row
            int pId = (int)Session["PatientID"];


            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connstr = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connstr);

            comm = new SqlCommand(
                  "SELECT AppointmentID, Patient, StartTime, Employee, EndTime FROM Appointment where Patient=@pId", conn);

            comm.Parameters.Add("@pId", SqlDbType.Int);
            comm.Parameters["@pId"].Value = pId;


            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                searchPatient.DataSource = reader;
                searchPatient.DataKeyNames = new string[] { "AppointmentID" };
                searchPatient.DataBind();
                reader.Close();

            }
            finally
            {
                conn.Close();
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class ViewReport : System.Web.UI.Page
    {

        //static List<Employee> employeeList;
        HospitalDBEntities context = new HospitalDBEntities();
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPatientDetails();
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
                  "SELECT AppointmentID, Patient, Diagnosis, Employee, Appointment, Prescription FROM MedicalHistory where Patient=@pId", conn);

            comm.Parameters.Add("@pId", SqlDbType.Int);
            comm.Parameters["@pId"].Value = pId;


            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                searchPatient.DataSource = reader;
               //^ searchPatient.DataKeyNames = new string[] { "PatientID" };
                searchPatient.DataBind();
                reader.Close();

            }
            finally
            {
                conn.Close();
            }
        }

        }
    }

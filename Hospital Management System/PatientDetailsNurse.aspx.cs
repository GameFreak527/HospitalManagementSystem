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
    public partial class PatientDetailsNurse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the previous selected patient details to this page
                BindPatientDetails();


            }
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
        private void BindPatientDetails()
        {

            // Obtain the value of the selected row
            int pId;
            if (Request.QueryString["PatientID"] != null)
            {
                string patientid = Request.QueryString["PatientID"];
                pId = Convert.ToInt32(patientid);
                SqlConnection conn;
                SqlCommand comm;
                DataTable dt = new DataTable();
                string connstr = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
                conn = new SqlConnection(connstr);
                // Create command
                comm = new SqlCommand(
                    "SELECT PatientID,Ward,FirstName,LastName,PhoneNumber,Address FROM Patient where PatientID=@pId", conn);
                comm.Parameters.Add("@pId", SqlDbType.Int);
                comm.Parameters["@pId"].Value = pId;

                SqlDataAdapter dadapter = new SqlDataAdapter(comm);
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    //  dadapter.SelectCommand = comm;
                    dadapter.Fill(dt);
                    patientDetails.DataSource = dt;
                    patientDetails.DataBind();
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class SearchPatientInfoDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
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
        private void BindGrid()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connstr = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connstr);
            comm = new SqlCommand("select PatientID,FirstName from Patient", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                searchPatient.DataSource = reader;
                searchPatient.DataKeyNames = new string[] { "PatientID" };
                searchPatient.DataBind();
                reader.Close();

            }
            finally
            {
                conn.Close();
            }

        }

        protected void searchPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("PatientDetailsDoc.aspx?PatientID=" + searchPatient.SelectedDataKey.Value.ToString());

        }
    }
}
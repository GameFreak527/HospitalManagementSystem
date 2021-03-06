﻿using System;
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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPatients();
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

        private void BindPatients()
        {

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connstr = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connstr);
            comm = new SqlCommand("select PatientID,FirstName,PhoneNumber from Patient", conn);
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
            Response.Redirect("patientDetailsReceptionist.aspx?PatientID=" + searchPatient.SelectedDataKey.Value.ToString());
        }

        protected void searchText_TextChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT PatientID,FirstName,PhoneNumber from Patient";
                    if (!string.IsNullOrEmpty(searchText.Text.Trim()))
                    {
                        sql += " WHERE PatientID LIKE @PatientID + '%'";
                        cmd.Parameters.AddWithValue("@PatientID", searchText.Text.Trim());
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        searchPatient.DataSource = dt;
                        searchPatient.DataBind();
                    }
                }
            }
        }
    }
}
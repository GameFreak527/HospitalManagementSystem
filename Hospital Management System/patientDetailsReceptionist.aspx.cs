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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPatientDetails();
        }

        private void BindPatientDetails()
        {
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
                    patientDetailsView.DataSource = dt;
                    patientDetailsView.DataBind();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void patientDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (patientDetailsView.CurrentMode == DetailsViewMode.ReadOnly)
            {
                patientDetailsView.ChangeMode(DetailsViewMode.Edit);
                BindPatientDetails();
            }
            else if (patientDetailsView.CurrentMode == DetailsViewMode.Edit)
            {

                patientDetailsView.ChangeMode(DetailsViewMode.ReadOnly);
                BindPatientDetails();
            }
        }

        protected void patientDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            /* int idd = Convert.ToInt32(patientDetailsView.Rows[0].Cells[1].Text);
             TextBox ward = patientDetailsView.Rows[1].Cells[1].Controls[0] as TextBox;
             TextBox firstName = patientDetailsView.Rows[2].Cells[1].Controls[0] as TextBox;
             TextBox lastName = patientDetailsView.Rows[3].Cells[1].Controls[0] as TextBox;
             TextBox phoneNumber = patientDetailsView.Rows[4].Cells[1].Controls[0] as TextBox;
             TextBox address = patientDetailsView.Rows[5].Cells[1].Controls[0] as TextBox;

             SqlConnection conn;
             SqlCommand comm;
             DataTable dt = new DataTable();
             string connstr = ConfigurationManager.ConnectionStrings["Hospital_ManagementDBConnectionString"].ConnectionString;
             conn = new SqlConnection(connstr);
             // Create command
             comm = new SqlCommand(
                 "Update Patient set Ward = ward, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Address = address where PatientID = @pid", conn);

             comm.Parameters.Add("@pId", SqlDbType.Int);
             comm.Parameters["@pId"].Value = idd;
             SqlDataAdapter SQLAdapter = new SqlDataAdapter(comm);
             DataTable DT = new DataTable();
             SQLAdapter.Fill(DT);

             patientDetailsView.ChangeMode(DetailsViewMode.ReadOnly);
             BindPatientDetails();*/

            for (int i = 0; i < e.NewValues.Count; i++)
            {
                if (e.NewValues[i] != null)
                {
                    e.NewValues[i] = Server.HtmlEncode(e.NewValues[i].ToString());
                }
            }
        }

        protected void patientDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            patientDetailsView.DataBind();
        }
    }
}
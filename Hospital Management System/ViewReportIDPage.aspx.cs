﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class ViewReportIDPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (int.TryParse(IDTextBox.Text, out i) == true)
            {
                try
                {
                    int found = ConnectionClass.IsPatientRecordFound(i);


                    Session["PatientID"] = i;

                    errorLabel.ForeColor = System.Drawing.Color.Green;
                    errorLabel.Text = "Records Found";

                    if (found > 0)
                    {

                        Response.Redirect("ViewReport.aspx");
                        errorLabel.Text = "Records Found after Query";
                    }

                }

                catch
                {
                    errorLabel.ForeColor = System.Drawing.Color.Red;
                    errorLabel.Text = "Search Failed";
                }
            }

            else
            {
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Text = "No Records Found";
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
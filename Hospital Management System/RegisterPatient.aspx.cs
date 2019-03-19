using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class RegisterPatient : System.Web.UI.Page
    {
        HospitalDBEntities context = new HospitalDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            Hospital hospital = context.Hospitals.FirstOrDefault(x => x.HospitalID == 1);
            List<int> wards = (from a in hospital.Wards
                               select a.WardID).ToList();
            wardList.DataSource = wards;
            wardList.DataBind();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String firstName = firstNameTxtBox.Text;
            String lastName = lastNameTxtBox.Text;
            String address = addressTxtBox.Text;
            String phoneNumber = phoneTxtBox.Text;
            int wardId = int.Parse(wardList.SelectedValue);

           //Tried using Entity Framework but didnt worked
            //Ward ward = context.Wards.FirstOrDefault(x => x.WardID == wardId);
            //ward.Patients.Add(new Patient
            //{
            //    FirstName = firstName,
            //    LastName = lastName,
            //    Address = address,
            //    PhoneNumber = phoneNumber
            //});

            Patient newPatient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNumber,
                Ward = wardId
            };

            try
            {
                //Means the insertion is done
                if (ConnectionClass.addPatient(newPatient) == 1)
                {
                    errorMessageDiv.Visible = true;
                    errorMessageDiv.Attributes["class"] = "alert alert-success";
                    errorMessage.Text = "Patient Is Registered";
                }
                    
            }
            catch (NullReferenceException ex)
            {
                errorMessageDiv.Visible = true;
                errorMessage.Text = ex.Message;
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            int position = 0;
            string variable = "Login to continue";
            //Checks which user is entering the system and chooses the master pages for them
            //checks if the session is null or not
            if (Session.Count > 0)
            {
                position = ((Employee)Session["employee"]).EmployeeType.Value;
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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + variable + "');", true);
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}
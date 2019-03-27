using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        HospitalDBEntities context = new HospitalDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Hospital hospital = context.Hospitals.FirstOrDefault(x => x.HospitalID == 1);
            List<int> inventories = (from a in hospital.Inventories
                               select a.InventoryID).ToList();
            inventoryIDList.DataSource = inventories;
            inventoryIDList.DataBind();

        }

        protected void placeOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = new HospitalDBEntities();
                MedicalItem1 medicalItem1 = new MedicalItem1();
                medicalItem1.Inventory = Convert.ToInt32(inventoryIDList.SelectedValue);
                medicalItem1.Name = nameTxt.Text;
                medicalItem1.Supplier = supplierTxt.Text;
                medicalItem1.Description = descriptionTxt.Text;
                medicalItem1.Price = Convert.ToDecimal(priceTxt.Text);
                medicalItem1.Quantity = Convert.ToInt32(quantityTxt.Text);

                connectionString.MedicalItems1.Add(medicalItem1);
                connectionString.SaveChanges();
                errorLabel.Text = "Order Placed successfully";

                nameTxt.Text = "";
                supplierTxt.Text = "";
                descriptionTxt.Text = "";
                priceTxt.Text = "";
                quantityTxt.Text = "";
            }
            catch(NullReferenceException ex)
            {
                errorLabel.Text = ex.Message ;
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
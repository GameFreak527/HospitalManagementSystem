using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_Management_System
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {

        static List<Employee> employeeList;
        HospitalDBEntities context = new HospitalDBEntities();
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hide Employee location div 
                employee.Visible = false;

                //Hide Employee details div because it is just for admin to view
                editEmployee.Visible = false;

                employeeList = context.Employees.ToList();

                docDetails.DataSource = context.Employees.Where(x => x.EmployeeType == 1).ToList();
                docDetails.DataBind();

                nurseDetails.DataSource = context.Employees.Where(x => x.EmployeeType == 3).ToList();
                nurseDetails.DataBind();
            }


        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            Employee currentEmployee = (Employee)Session["employee"];
            id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            //If user is admin
            if (currentEmployee.EmployeeType == 6)
            {
                //Show edit div to edit employee details
                editEmployee.Visible = true;
                editEmployeeGrid.DataSource = employeeList.Where(x => x.EmployeeID == id).ToList();
                editEmployeeGrid.DataBind();

            }
            else
            {
                //Ward detail div is active
                employee.Visible = true;

            employeeGrid.DataSource = employeeList.Where(x => x.EmployeeID == id).Select(x => x.Ward1).ToList();
            employeeGrid.DataBind();

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

        protected void employeeDelete(object sender, GridViewDeleteEventArgs e)
        {
            Employee emp = context.Employees.FirstOrDefault(x => x.EmployeeID == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            Response.Redirect("EmployeeDetails.aspx");

        }

        protected void employeeUpdate(object sender, GridViewUpdateEventArgs e)
        {
            //Fetching value from controls to the variables
            int wardNum = int.Parse((editEmployeeGrid.Rows[0].FindControl("wardList") as DropDownList).SelectedValue);
            int jobTitle = (editEmployeeGrid.Rows[0].FindControl("empTypeList") as DropDownList).SelectedIndex +1;
            String firstName = (editEmployeeGrid.Rows[0].FindControl("firstNameTxtBox") as TextBox).Text;
            String lastName = (editEmployeeGrid.Rows[0].FindControl("lastNameTxtBox") as TextBox).Text;
            String address = (editEmployeeGrid.Rows[0].FindControl("addressTxtBox") as TextBox).Text;
            String phoneNumber = (editEmployeeGrid.Rows[0].FindControl("phoneNumberTxtBox") as TextBox).Text;
            String sin = (editEmployeeGrid.Rows[0].FindControl("sinTxtBox") as TextBox).Text;
            String email = (editEmployeeGrid.Rows[0].FindControl("emailTxtBox") as TextBox).Text;

            //Updating employee
            Employee emp = context.Employees.FirstOrDefault(x => x.EmployeeID == id);
            emp.FirstName = firstName;
            emp.LastName = lastName;
            emp.Address = address;
            emp.PhoneNumber = phoneNumber;
            emp.SIN = sin;
            emp.Email = email;

            //If successful then redirect else show error
            try
            {
                context.SaveChanges();
                Response.Redirect("EmployeeDetails.aspx");
            }
            catch(Exception ex)
            {
                errorMessageDiv.Visible = true;
                errorMessage.Text = ex.Message;
            }
        }

        protected void editEmployeeGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            editEmployeeGrid.EditIndex = e.NewEditIndex;
            editEmployeeGrid.DataSource = employeeList.Where(x => x.EmployeeID == id).ToList();
            editEmployeeGrid.DataBind();

            //Getting data of Ward from database
            Hospital hospital = context.Hospitals.FirstOrDefault(x => x.HospitalID == 1);
            List<int> wards = (from a in hospital.Wards
                               select a.WardID).ToList();

            GridViewRow row = editEmployeeGrid.Rows[e.NewEditIndex];

            //Adding ward's value
            DropDownList wardList = row.Cells[1].FindControl("wardList") as DropDownList;
            wardList.DataSource = wards;

            //Adding EmployeeType to list
            List<EmployeeType> employeeType = context.EmployeeTypes.ToList();
            DropDownList empTypeList = row.Cells[2].FindControl("empTypeList") as DropDownList;
            empTypeList.DataSource = employeeType.Select(x => x.Name);


            //Binding the datasource
            wardList.DataBind();
            empTypeList.DataBind();

        }

        protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            editEmployeeGrid.EditIndex = -1;

            //Bind data to the GridView control.
            editEmployeeGrid.DataSource = employeeList.Where(x => x.EmployeeID == id).ToList();
            editEmployeeGrid.DataBind();
        }
    }
}
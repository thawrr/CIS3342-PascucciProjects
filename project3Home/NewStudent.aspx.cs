using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using StudentLibrary;

namespace project3Home
{
    public partial class NewStudent : System.Web.UI.Page
    {
        DataValidation dv = new DataValidation();
        StudentMethods sm = new StudentMethods();
        DBConnect dbObj = new DBConnect();
        Student stud = new Student();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitCreStud_Click(object sender, EventArgs e)
        {//object NewStudent(string fn, string ln, string sa, string email, string major)

            if (dv.IsPresentAndText(txtFirstName) && dv.IsPresentAndText(txtLastName) && dv.IsPresentAndText(txtAddress) && dv.IsValidEmail(txtEmail) == true)
            {
                errorLable.Visible = false;//hide error
                
                stud.FirstName = txtFirstName.Text;//add properties to object
                stud.LastName = txtLastName.Text;
                stud.Address = txtAddress.Text;
                stud.Email = txtEmail.Text;
                stud.Major = ddlMajorID.SelectedValue;
                
                sm.NewStudent(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtEmail.Text, ddlMajorID.SelectedValue);//add stud to DB, get 
                int studCount = sm.GetStudentCount();
                int newStudID = sm.ReturnNewStudentID(studCount);//get new student id

                lblStudMessage.Visible = true;
                lblNewStudentInfo.Visible = true;
                lblNewStudentInfo.Text = newStudID.ToString() + " ," + stud.FirstName.ToString()+" ,"+ stud.LastName.ToString();
                
            }
            else
            {
                errorLable.Visible = true;
                errorLable.Text = "One or more of your inputs are incorrect. Please check them over again.";
            }

        }

        
    }//end class
}//end nameSpace
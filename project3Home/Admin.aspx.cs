using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using StudentLibrary;
using System.Data.SqlClient;
using System.Data;

namespace project3Home
{
    public partial class Admin : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        StudentMethods sm = new StudentMethods();
        DataValidation dv = new DataValidation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                ShowCourses();
        }

        public void ShowCourses()
        {
            DataSet myDataSet = sm.DisplayALLCourses();
            gvCourses.DataSource = myDataSet;
            gvCourses.DataBind();
        }
     
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string cn = txtCN.Text;
            double ch = Convert.ToDouble(txtCR.Text);
            string pr = txtPR.Text;
            string dID = txtDepID.Text;

            if (dv.IsPresentAndText(txtCN) && dv.IsDecimal(txtCR) && dv.IsText(txtPR)&& dv.IsPresentAndText(txtDepID) == true)
            {
                sm.AddCourse(cn, ch, pr, dID);
            }
            else
               
            lblCourseEventDis.Visible = true;
            lblCourseEventDis.Text = "Something went wrong at ADDCOURSE...";
        }
        
        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            int courseID = int.Parse(gvCourses.Rows[index].Cells[0].Text);

            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode
            
            TextBox TBox1 = (TextBox)gvCourses.Rows[index].Cells[1].Controls[0];
            string cn = TBox1.Text;

            TextBox TBox2 = (TextBox)gvCourses.Rows[index].Cells[2].Controls[0];
            double ch = double.Parse(TBox2.Text);
            
            TextBox TBox5 = (TextBox)gvCourses.Rows[index].Cells[3].Controls[0];
            string pr = TBox5.Text;

            TextBox TBox6 = (TextBox)gvCourses.Rows[index].Cells[4].Controls[0];
            string dID = TBox6.Text;//check if this is CIS,ENG,MAT or just a number

            if (dv.IsPresentAndText(txtCN) && dv.IsDecimal(txtCR) && dv.IsText(txtPR) && dv.IsPresentAndText(txtDepID) == true)
            {
                sm.UpdateCourse(index, cn, ch, pr, dID);

            }
            else
            {

                lblCourseEventDis.Visible = true;
                lblCourseEventDis.Text = "Something went wrong at EDIT...";
            }
            gvCourses.EditIndex = -1;
            ShowCourses();
        }

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int courseID = Convert.ToInt32(gvCourses.Rows[rowIndex].Cells[0].Text);
            
            sm.DeleteCourse(courseID);
            gvCourses.EditIndex = -1;
            ShowCourses();
        }

        protected void gvCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {//works
            gvCourses.EditIndex = -1;
            ShowCourses();
        }

        protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCourses.EditIndex = e.NewEditIndex;// Set the row to edit-mode in the GridView
            ShowCourses();
        }

        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//end class
}//end nameSpace
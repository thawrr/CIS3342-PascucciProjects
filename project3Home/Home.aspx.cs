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
    public partial class Home : System.Web.UI.Page
    {
       
        StudentMethods sm = new StudentMethods();
        DataValidation dv = new DataValidation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                DBConnect objDB = new DBConnect();

                //stored procedure select all the course info

                // Set the datasource of the Repeater control and bind the data
                //rptCourses.DataSource = objDB.GetDataSet(strSQL);

                //rptCourses.DataBind();

            }
        }
        
        protected void getCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fires when something is selected from DDL
            DataSet myDataSet = sm.DisplayCourses(ddlDepartmentID.SelectedItem.Value);
            
            gvModCourseID.DataSource = myDataSet;
            gvModCourseID.DataBind();
            //bind to repeater
        }

    }
}
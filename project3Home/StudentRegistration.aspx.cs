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
    public partial class StudentRegistration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        StudentMethods sm = new StudentMethods();
        DataValidation dv = new DataValidation();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        
    

        protected void btnSearch_Click(object sender, EventArgs e)
        { 
            lblNotFound.Visible = false;

            //get student ID from TextBox
            int studID = Convert.ToInt32(txtStudentID.Text);

            //get selected values from DropDown Lists
            string dID = ddlDdepartment.SelectedItem.Value.ToString();
            string sID = ddlSemester.SelectedItem.Value.ToString();

            lblSemester.Visible = true;

            //Semester at top of Repeater
            lblSemester.Text = ddlSemester.SelectedItem.Value.ToString();

            //check if StudentID is there, need total count and check for that ID
            int currentCount = sm.GetStudentCount();
            int foundStudID = sm.CheckForStudent(currentCount,studID);
            if(foundStudID == 0)
            {
                //error Will Robbinson
                lblNotFound.Visible = true;
                lblNotFound.Text = "STUDENT NOT FOUND. PLEASE TRY AGAIN";
            }
            else
            {
                // Set the datasource of the Repeater 
                //is a class aval seat is 0, hide select button
                ////bind the data to repeater
                DataSet myDataSet = sm.GetRegCourseInfo(sID, dID);
                rptCourses.DataSource = myDataSet;
                rptCourses.DataBind(); 
            }

           
            //read the values and output them
            foreach (RepeaterItem i in rptCourses.Items)
            {
                
                Label litResults = i.FindControl("litResults") as Label;//get the label you want to conditionally change

                Label CellId = (Label)i.FindControl("idSeatsOpen");//seats Aval value from DB
                int idSeatsOpen = Convert.ToInt32(CellId.Text);//convert it to so you can use it

                if (idSeatsOpen == 0)
                {
                    litResults.Text = "Closed";


                }
                else
                {
                    litResults.Text = "Open";
                }
                   
            }
        }//end submit method

        protected void btnRegister_Click(object sender, EventArgs e)
        {//Register button with selected courses
         //FIRST
         //check if the course the student is registering for, if the already registered for it in "Register" table
         //when a student registers for a course, you add their StudID and that Course's SectionID to the Registration table
         //check PreReqs in registered course against student's previous course Student Table
         
            //need section from selected row 
            int studID = Convert.ToInt32(txtStudentID.Text);//has the student's ID
            List<string> selectedCRNs = new List<string>();//empty
            List<string> selectedCourses = new List<string>();//empty
            List<int> courseIDs = new List<int>();//empty

            Label placeHold;
            Label placeHold2;
            Label placeHold3;
            Label placeHold4;

            int classCount = 0;
            double creditHours = 0;

            foreach (RepeaterItem i in rptCourses.Items)//get selected chkBox, save CRN to list
            {
                
                var selectedControlIndex = (CheckBox)i.FindControl("btnSelect");

                placeHold = selectedControlIndex.FindControl("idSection") as Label;
                selectedCRNs.Add(placeHold.Text);//load CRNs into list

                placeHold2 = selectedControlIndex.FindControl("idCourseName") as Label;
                selectedCourses.Add(placeHold2.Text);//load courses NAME into list

                placeHold3 = selectedControlIndex.FindControl("idCourseID") as Label;
                courseIDs.Add(Convert.ToInt32(placeHold3.Text));//load courses into list

                placeHold4 = selectedControlIndex.FindControl("idCreditHour") as Label;
                creditHours += (Convert.ToDouble(placeHold4.Text));//load redit hr into list

                classCount++;//for later ;)
            }

            lblPreviousCourse.Visible = false;
            lblCourse.Visible = false;

            //check the crnS with previous courses, if retun 0, no previous courses were found
            Tuple<int,int> lol = sm.CheckPreviousSections(selectedCRNs, selectedCourses, studID);

            int resultPrev = lol.Item1;
            int resultPreReq = lol.Item2;

            if (resultPrev == 0)
            {
                //you're ok
                //go ahead and save to registration table
                lblNotFound.Visible = true;
                var result = String.Join(", ", selectedCRNs.ToArray());
                lblNotFound.Text = "you registered for "+result;

                //compare previous courses to preReq of course

                if (resultPreReq == 0)
                {
                    //you have PreReqs 
                    //go ahead and save to registration table
                    lblPreReq.Visible = true;
                    var result2 = String.Join(", ", selectedCourses.ToArray());
                    lblPreReq.Text = "you registered for " + result2;

                    //UPDATE TIME

                    //num seats is -1 for each course 
                    //tuition owed is $100.00 * all CreditHOurs
                    //add tuition to "tuitionOwed" in student Table
                    //save registration in registration table 

                    //new gridView in Registration page
                    string cr1 = null;
                    string cr2 = null;
                    string cr3 = null;
                    string cr4 = null;
                    string cr5 = null;
                    string cr6 = null;
                    string cr7 = null;
                    int i = 0;
                       
                    //seperate the list b/c i suck at programming

                    //update seats
                        cr1 = selectedCourses.ElementAt(i);
                    if (cr1 != null)
                        sm.UpdateSection(cr1);
                    else
                    i++;

                    cr2 = selectedCourses.ElementAt(i);
                    if (cr2 != null)
                        sm.UpdateSection(cr2);
                    else
                    i++;

                    cr3 = selectedCourses.ElementAt(i);
                    if (cr3 != null)
                        sm.UpdateSection(cr3);
                    else
                    i++;

                    cr4 = selectedCourses.ElementAt(i);
                    if (cr4 != null)
                        sm.UpdateSection(cr4);
                    else
                    i++;

                    cr5 = selectedCourses.ElementAt(i);
                    if (cr5 != null)
                        sm.UpdateSection(cr5);
                    else
                    i++;

                    cr6 = selectedCourses.ElementAt(i);
                    if (cr6 != null)
                        sm.UpdateSection(cr6);
                    else
                    i++;

                    cr7 = selectedCourses.ElementAt(i);
                    if (cr7 != null)
                        sm.UpdateSection(cr1);
                    else
                        i = i + 0;

                    //update $
                    double tuit = creditHours * 1500.00;
                    sm.UpdateTuition(tuit, studID);

                    //record Reg
                    sm.UpdateRegister(cr1,cr2,cr3,cr4,cr5,cr6,cr7, studID);

                    lblTuitionOwed.Text = tuit.ToString();
                    
                }
                else
                {
                    //you have a enough preReq course s
                    //can't register
                    lblCourse.Visible = true;
                    lblCourse.Text = "You don't have " + resultPreReq + " courses as PreReqs";
                }
            }
            else
            {
                //you have a previoous course 
                //can't register
                lblPreviousCourse.Visible = true;
                lblPreviousCourse.Text = "You have " + resultPrev + " previous courses registerd";
            }
            
        }//end Register Event

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }//end class
}//end namespace
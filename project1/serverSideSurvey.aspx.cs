using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project1
{
    public partial class serverSideSurvey : System.Web.UI.Page
    {
        /*
        a.	The ASPX page only needs to contain a simple ASPX label or labels (WFC) to display the
            necessary output to the user.
        b.	Retrieve the values for all form controls using the Request object.
        c.	Display the results for each question.
        d.	Calculate and display a grade for the course and the professor.
            i.	You should assign values to the ratings (strongly agree, agree, neutral, etc …)
                and the questions that are related to the course. Then, use these values to calculate an 
                average, assign the average a grade letter, and display the grade letter.
            ii.	Do the same for the ratings and questions related to the professor.

        */
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFullName.Text = Request["firstname"].ToString() + " " + Request["lastname"].ToString();
            txtStudentNum.Text = Request["studentId"].ToString();
            txtClassName.Text = Request["courses"].ToString();

            double[] surveyScores = { 
            //course score
            Convert.ToDouble(Request["course1"]),
            Convert.ToDouble(Request["course2"]),
            Convert.ToDouble(Request["course3"]),
            Convert.ToDouble(Request["course4"]),
            Convert.ToDouble(Request["course5"]),
            Convert.ToDouble(Request["course6"]),
            Convert.ToDouble(Request["course7"]),
            Convert.ToDouble(Request["course8"]),
            Convert.ToDouble(Request["course9"]),
            Convert.ToDouble(Request["course10"]),
            Convert.ToDouble(Request["course11"]),
            Convert.ToDouble(Request["course12"]),
            //Professor score
            Convert.ToDouble(Request["prof13"]),
            Convert.ToDouble(Request["prof14"]),
            Convert.ToDouble(Request["prof15"]),
            Convert.ToDouble(Request["prof16"]),
            Convert.ToDouble(Request["prof17"]),
            Convert.ToDouble(Request["prof18"]),
            Convert.ToDouble(Request["prof19"]),
            Convert.ToDouble(Request["prof20"]) };
            displayClass(surveyScores);
            calculatorClass(surveyScores);
        }//end load class

        //taking everything out of load and into their own classes

        public void calculatorClass(double[] surveyScores)
        {
            double cScore = 0;
            double pScore = 0;

            /************************************************/
            for (int i = 0; i < 12; i++)
            {
                cScore += surveyScores[i];

            }//adding all course scores together

            double avgCScore = ((cScore / 48) * 100);
           
            if (cScore != 0)
                TextBox1.Text = avgCScore.ToString() + "%";
            else
                TextBox1.Text = ("your value is null");
            
            /************************************************/

            for (int j = 12; j < 20; j++)
            {
                 pScore += surveyScores[j];

            }//adding all prof scores together
           
            double avgPScore = ((pScore / 32) * 100);

            if (pScore != 0)
                TextBox2.Text = avgPScore.ToString() + "%";
            else
                TextBox2.Text = ("your value is null");
            /************************************************/
            if (avgCScore <= 50)
                TextBox3.Text = ("F");
            else if (avgCScore <= 64)
                TextBox3.Text = ("D-");
            else if (avgCScore <= 67)
                TextBox3.Text = ("D");
            else if (avgCScore <= 69)
                TextBox3.Text = ("D+");
            else if (avgCScore <= 74)
                TextBox3.Text = ("C-");
            else if (avgCScore <= 77)
                TextBox3.Text = ("C");
            else if (avgCScore <= 79)
                TextBox3.Text = ("C+");
            else if (avgCScore <= 84)
                TextBox3.Text = ("B-");
            else if (avgCScore <= 87)
                TextBox3.Text = ("B");
            else if (avgCScore <= 89)
                TextBox3.Text = ("B+");
            else if (avgCScore <= 94)
                TextBox3.Text = ("A-");
            else if (avgCScore <= 97)
                TextBox3.Text = ("A");
            else
                TextBox3.Text = ("A");

            if (avgPScore <= 50)
                TextBox4.Text = ("F");
            else if (avgPScore <= 64)
                TextBox4.Text = ("D-");
            else if (avgPScore <= 67)
                TextBox4.Text = ("D");
            else if (avgPScore <= 69)
                TextBox4.Text = ("D+");
            else if (avgPScore <= 74)
                TextBox4.Text = ("C-");
            else if (avgPScore <= 77)
                TextBox4.Text = ("C");
            else if (avgPScore <= 79)
                TextBox4.Text = ("C+");
            else if (avgPScore <= 84)
                TextBox4.Text = ("B-");
            else if (avgPScore <= 87)
                TextBox4.Text = ("B");
            else if (avgPScore <= 89)
                TextBox4.Text = ("B+");
            else if (avgPScore <= 94)
                TextBox4.Text = ("A-");
            else if (avgPScore <= 97)
                TextBox4.Text = ("A");
            else
                TextBox4.Text = ("A");
        } //end calculator class

        public void displayClass(double[] surveyScores)
        {
           
            try
            {
                int j = 1;
                for (int i = 0; i <= 19; i++)
                {
                    if (i == 0)
                    {
                        lbScoreResult.Items.Add("");
                        lbScoreResult.Items.Add("Course Review Questions ");
                        lbScoreResult.Items.Add("");
                        if (surveyScores[i] == 1)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Disagree");
                        else if (surveyScores[i] == 2)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Disagree");
                        else if (surveyScores[i] == 3)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Netural");
                        else if (surveyScores[i] == 4)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Agree");
                        else
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Agree");
                    }
                    else if (i == 11)
                    {
                        lbScoreResult.Items.Add("");
                        lbScoreResult.Items.Add("Professor Surevey Questions ");
                        lbScoreResult.Items.Add("");
                        if (surveyScores[i] == 1)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Disagree");
                        else if (surveyScores[i] == 2)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Disagree");
                        else if (surveyScores[i] == 3)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Netural");
                        else if (surveyScores[i] == 4)
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Agree");
                        else
                            lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Agree");
                    }
                    else
                       if (surveyScores[i] == 1)
                        lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Disagree");
                    else if (surveyScores[i] == 2)
                        lbScoreResult.Items.Add("Question Number " + j + ": " + "Disagree");
                    else if (surveyScores[i] == 3)
                        lbScoreResult.Items.Add("Question Number " + j + ": " + "Netural");
                    else if (surveyScores[i] == 4)
                        lbScoreResult.Items.Add("Question Number " + j + ": " + "Agree");
                    else
                        lbScoreResult.Items.Add("Question Number " + j + ": " + "Strongly Agree");
                    j++;
                }

                if (lbScoreResult.Text == "")
                    throw new Exception();

            }
            catch (Exception err)
            {
                Console.Write(err.Message, "error");
            }
            //listBox1.Items.Add(string.Format("{0} | {1}", first_name.Text, last_name.Text));

        }//end displayClass

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
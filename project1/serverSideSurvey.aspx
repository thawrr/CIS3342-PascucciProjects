<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="serverSideSurvey.aspx.cs" Inherits="project1.serverSideSurvey" %>

<!DOCTYPE html>
<!-- Retrieve the values for all form controls using the Request object.
     Display the results for each question. -->

<!--
    a.The ASPX page only needs to contain a simple ASPX label or labels (WFC) to display the necessary output to the user.
    b.Retrieve the values for all form controls using the Request object, to get info from web page
    c.Display the results for each question. use lables of text boxes
    d.Calculate and display a grade for the course and the professor.
      
        i.You should assign values to the ratings (strongly agree, agree, neutral, etc …) and the questions that 
        are related to the course.Then, use these values to calculate an average, assign the average a grade letter, 
        and display the grade letter.

        ii.Do the same for the ratings and questions related to the professor. 
    -->


<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Class Survey</title>
        <link href="project1Styles.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <br />
            Your Name: <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <br />
            Your Student ID:
            <asp:TextBox ID="txtStudentNum" runat="server"></asp:TextBox>
            <br />
            Class Title:
            <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
            <br />
            Results for Each question:<br />
            <asp:ListBox ID="lbScoreResult" runat="server" Width="258px" Height="135px"></asp:ListBox>
            <br />
            <br />
            Course Score: <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged">
        </asp:TextBox>
          

            <br />
            Professor Score: <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            Course Letter Grade:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Professor Letter Grade:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
          

        </form>
    </body>
</html>

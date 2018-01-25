<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="project3Home.StudentRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
        .auto-style2 {
            width: 80px;
        }
        .auto-style3 {
            width: 123px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Register for a class</h2><br />
    <h3>Please Enter your Student ID in the lext box, select a Department and Semester</h3>
    <asp:TextBox ID="txtStudentID" runat="server" Width="72px"></asp:TextBox>
&nbsp;
    <asp:DropDownList ID="ddlSemester" runat="server" Width="154px">
        <asp:ListItem Value="FA16" Selected="True">Fall 2016</asp:ListItem>
        <asp:ListItem Value="SP17">Spring 2017</asp:ListItem>
    </asp:DropDownList>
&nbsp;
    <asp:DropDownList ID="ddlDdepartment" runat="server" Height="25px" Width="158px">
        <asp:ListItem Value="MAT" Selected="True">Math Department</asp:ListItem>
        <asp:ListItem Value="CIS">Computer Science and Technology</asp:ListItem>
        <asp:ListItem Value="ENG">Engineering Department</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Classes" Width="110px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNotFound" runat="server" Text="Label" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPreReq" runat="server" Text="Label" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblCourse" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblSemester" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Label" Visible="False"></asp:Label>
    <br />
    <table>
        <tr style="color: #CC3300;">
            <td>Course ID</td>
            <th>Section</th>
            <th>Course Name</th>
            <th>Description</th>
            <th>Number of Seats Aval</th>
            <th>Max Seats</th>
            <th>Credit Hours</th>
            <th>Time Start</th>
            <th>Time End</th>
            <th>Days</th>
            <th class="auto-style3">Prof</th>
            <th class="auto-style1">Department</th>
            <th class="auto-style2">Class Status</th>
            <th>Select Course</th>
        </tr>
        <asp:Repeater ID="rptCourses" runat="server">
            <ItemTemplate>
            <tr>

            <td>
            <asp:Label ID="idCourseID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CourseID") %>'></asp:Label>
            </td>

            <td>
            <asp:Label ID="idSection" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CRN") %>'></asp:Label>
            </td>

            <td>
            <asp:Label ID="idCourseName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CourseName") %>'></asp:Label>
            </td>

            <td>
                <asp:Label ID="idPreReqs" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PreReqs") %>'></asp:Label>
            </td>

            <td>
                <asp:Label ID="idSeatsOpen" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SeatsAvailable") %>'></asp:Label>
            </td>

            <td>
            <asp:Label ID="idMaxSeats" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MaxSeats") %>'></asp:Label>
            </td>

            <td>
            <asp:Label ID="idCreditHour" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreditHours") %>'></asp:Label>
            </td>

             <td>
            <asp:Label ID="idStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TimeStart") %>'></asp:Label>
            </td>

             <td>
            <asp:Label ID="idEndtime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TimeEnd") %>'></asp:Label>
            </td>

            <td>
                <asp:Label ID="idDayCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DayCode") %>'></asp:Label>
            </td>

            <td>
                <asp:Label ID="idProf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
            </td>
                &nbsp;&nbsp;&nbsp;&nbsp;
            <td>
                <asp:Label ID="idDepName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "departmentName") %>'></asp:Label>
            </td>
            
            <td>
                <asp:Label ID="litResults" runat="server" Text=""></asp:Label>
            </td>

            <td>
                <asp:CheckBox ID="btnSelect" runat="server" Visable="true"/>
            </td>

            </tr> 
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <asp:Label ID="lblPreviousCourse" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Bill and Drop Course"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Tuition Owed is: "></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblTuitionOwed" runat="server"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    

    <asp:Repeater ID="rptReportDrop" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                <asp:Label ID="idCourseID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CourseID") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Courses" />
    <br /><br />
   
</asp:Content>

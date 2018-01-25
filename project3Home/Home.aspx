<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="project3Home.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Search for classes based on a department</h2><br /><br />

    <asp:DropDownList ID="ddlDepartmentID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="getCourses_SelectedIndexChanged" datakeynames="CourseID" >
        <asp:ListItem Value="MAT" Selected="True">Math Department</asp:ListItem>
        <asp:ListItem Value="CIS">Computer Science and Technology</asp:ListItem>
        <asp:ListItem Value="ENG">Engineering Department</asp:ListItem>
    </asp:DropDownList><br /><br />

     <asp:GridView ID="gvModCourseID" runat="server">
        <Columns>
                 
                <asp:BoundField DataField="CourseId" HeaderText="Course ID" />
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
                <asp:BoundField DataField="PreReqs" HeaderText="Prerequsits" />
        </Columns>
    </asp:GridView>

</asp:Content>

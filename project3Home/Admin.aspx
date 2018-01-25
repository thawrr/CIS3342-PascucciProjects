<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="project3Home.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Admin Page</h2>
    <h3>where you can perform administrative options, such as Add/Drop and modify a course.</h3>

    <asp:Label ID="lblCourseEventDis" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
   
        
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvCourses_RowCancelingEdit" OnRowDeleting="gvCourses_RowDeleting" OnRowEditing="gvCourses_RowEditing" OnRowUpdating="gvCourses_RowUpdating" OnSelectedIndexChanged="gvCourses_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="Course ID" ReadOnly="True" />
            <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
            <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
            <asp:BoundField DataField="PreReqs" HeaderText="Prerequsits" />
            <asp:BoundField DataField="FK_DepartmentID" HeaderText="Department ID" />
            <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText="Edit" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
   
        
    <br />
    <asp:Label ID="Label6" runat="server" Text="Modify Here"></asp:Label>
    <br />
    <br />

    <asp:Label ID="Label1" runat="server" Text="Insert Course Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text="Credit Hours"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Prerequisites"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Department ID"></asp:Label>
    <br />

<asp:TextBox ID="txtCN" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCR" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPR" runat="server"></asp:TextBox>
    &nbsp;
    <asp:TextBox ID="txtDepID" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnAddCourse" runat="server" OnClick="btnAddCourse_Click" Text="Click to Add Course" Width="145px" />
</asp:Content>

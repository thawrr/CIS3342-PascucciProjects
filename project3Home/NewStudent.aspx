<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewStudent.aspx.cs" Inherits="project3Home.NewStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>If you are a new student, please create a profile by filling out the form below.</h2><br />
    
    &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="errorLable" runat="server" Text="Label" Visible="False"></asp:Label>
     <br />
    <h3>Be sure to remember your newly created student ID!</h3>
    
    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>&nbsp;
    
    <asp:TextBox ID="txtFirstName" runat="server" Width="171px"></asp:TextBox>&nbsp;

    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>&nbsp;

    <asp:TextBox ID="txtLastName" runat="server" Width="172px"></asp:TextBox><br /><br />

    <asp:Label ID="Label3" runat="server" Text="Address (home)"></asp:Label>&nbsp;

    <asp:TextBox ID="txtAddress" runat="server" Width="413px"></asp:TextBox><br /><br />

    <asp:Label ID="Label4" runat="server" Text="Email Address"></asp:Label>&nbsp;

    <asp:TextBox ID="txtEmail" runat="server" Width="259px"></asp:TextBox><br /><br />

    <asp:Label ID="Label5" runat="server" Text="Pick a Major"></asp:Label>&nbsp;

    <asp:DropDownList ID="ddlMajorID" runat="server" Width="200px">
        <asp:ListItem Text="Mathematics" Value="Mathematics" Selected="True" />
        <asp:ListItem Text="Mechanical Engineering" Value="Mechanical Engineering" />
        <asp:ListItem Text="Chemistry" Value="Chemistry" />
        <asp:ListItem Text="Biology" Value="Biology" />
    </asp:DropDownList><br />
     <br />
&nbsp;&nbsp;&nbsp;
     <asp:Label ID="lblStudMessage" runat="server" Text="Here is your newly created StudentID. DON'T LOSE THIS" Visible="False"></asp:Label>
     <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="lblNewStudentInfo" runat="server" Text="Label" Visible="False"></asp:Label>
     <br />
     <br />

    <asp:Button ID="btnSubmitCreStud" runat="server" Text="Submit (create a student)" Width="190px" OnClick="btnSubmitCreStud_Click" />
    <br />

</asp:Content>

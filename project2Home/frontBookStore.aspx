<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frontBookStore.aspx.cs" Inherits="project2Home.frontBookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Welcome to the Student Run "][" Book Store</h1>
    <h3>Please enter your StudentID, name, address, and phone number below</h3>
    <br /><br />
    <form id="bookInputForm" runat="server" visible="true">
        <div>
            
        Studen&#39;s ID: 1234567&nbsp;
        <asp:TextBox ID="txtStudentId" runat="server" OnTextChanged="txtStudentId_TextChanged" Visible="true" type="Int"></asp:TextBox>  
            <br />

        Full Name: John Doe <asp:TextBox ID="txtName" runat="server" Visible="true" type="Text"></asp:TextBox>
            
            <br />
          
        Address: 123 North Elm Street, Philadelphia PA 19991&nbsp; <asp:TextBox ID="txtAddress" runat="server" Visible="true" type="Text"></asp:TextBox>
           
        <br /> 

        Phone Number: xxx-xxx-xxxx <asp:TextBox ID="txtPhoneNumber" runat="server" Visible="true" type="Int"></asp:TextBox>
           
        <br /> 
        
        <!--b.	Add a control for selecting a campus (Main, TUCC, Ambler, Tokyo, Rome, etc…)-->
        <h2>Please select your Campus</h2>
            
            <asp:DropDownList ID="ddlCampus" runat="server" Visible="true">
                
                <asp:ListItem Value="main">Philadelphia Main Campus</asp:ListItem>
                <asp:ListItem Value="tucc">TUCC</asp:ListItem>
                <asp:ListItem Value="ambler">Ambler</asp:ListItem>
                <asp:ListItem Value="tokyo">Tokyo</asp:ListItem>
                <asp:ListItem Value="rome">Rome</asp:ListItem>
            </asp:DropDownList>
            <br /><br />
        <!--Put a GridView control on your form that will be used to order books. This input GridView 
            display will be dynamic with columns. Each row in the GridView will correspond to a Book stored in the database.-->
        <br />
            <!--The user must select at least one Book before completing the order. This means they 
                    need to add a checkmark to at least one row in the GridView for a Book .-->
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvBooks_SelectedIndexChanged" Width="1084px">
            <Columns>

                <asp:TemplateField HeaderText="Select Product">
                    
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Title" HeaderText="Title" />

                <asp:BoundField DataField="Author" HeaderText="Author's Name" />

                <asp:BoundField DataField="ISBN" HeaderText="Book ISBN Number" />

                <asp:TemplateField HeaderText="Book Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlBookType" runat="server" >
                                <asp:ListItem Text="Hard Cover" Value="hardCover"/>
                                <asp:ListItem Text="Paper-Back Cover" Value="softCover"/>
                                <asp:ListItem Text="E-Book text" Value="eBook"/>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Rent or Buy">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" type="Text">
                            <asp:ListItem Value="Rent">Rent</asp:ListItem>
                            <asp:ListItem Value="Buy">Buy</asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantityBook" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
           </Columns>
        </asp:GridView>

            <!--Can't use SqlDataSource-->

        <asp:Button ID="btnSubmitOrder" runat="server" Text="Order" Width="136px" type="submit" OnClick="btnSubmitOrder_Click"/>
            <asp:Button ID="btnViewreport" runat="server" OnClick="btnViewreport_Click" Text="View Manager Report" Width="184px" />
            <asp:Button ID="btnBackToOrder" runat="server" Text="Go Back Too Order Page" Width="197px" OnClick="btnBackToOrder_Click" />
            <br />
            <br /><!--For Totalcost: calculated with Quantity x Price-->
            <asp:Label ID="lblCustomerInfo" runat="server" Visible="False"></asp:Label>

            <asp:GridView ID="gvDisplayOrder" runat="server" AutoGenerateColumns ="False" showfooter="True" Width="1090px">
                <Columns>

                    <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" />

                    <asp:BoundField DataField="isbn" HeaderText="ISBN" ReadOnly="True"  />

                    <asp:BoundField DataField="bookType" HeaderText="Type" ReadOnly="True"  />

                    <asp:BoundField DataField="purchaseOption" HeaderText="Buy/Rent" ReadOnly="True" />

                    <asp:BoundField DataField="price" HeaderText="Price" ReadOnly="True"  DataFormatString="{0:c}"/>

                    <asp:BoundField DataField="quantity" HeaderText="Quantity" ReadOnly="True" />

                    <asp:BoundField DataField="totalCost" HeaderText="Total Cost" ReadOnly="True" DataFormatString="{0:c}"/>

                </Columns>
            </asp:GridView>

            <br />

            <asp:GridView ID="gvManager" runat="server" AutoGenerateColumns ="False" Width="834px" Visible="false">
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Book Title" ReadOnly="True"/>
                    <asp:BoundField DataField="totalSales" HeaderText="Total Cost" ReadOnly="True"/>
                    <asp:BoundField DataField="totalQuantityRented" HeaderText="Total Quantity Rented" ReadOnly="True"/>
                    <asp:BoundField DataField="totalQuantitySold"  HeaderText="Total Quantity Sold" ReadOnly="True"/>
                </Columns>
            </asp:GridView>
        <br />
        </div><!--form div-->
    </form>
</body>
</html>

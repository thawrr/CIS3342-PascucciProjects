using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//for using db
using System.Collections;//for array list
using BookLibrary;//use my book class libray like a boss
using Utilities;//using class where student connections 
using System.Data.SqlClient;

namespace project2Home
{
    public partial class frontBookStore : System.Web.UI.Page
    {
        double totalOrderSale = 0;

        List<Book> bookOrderList = new List<Book>();//new book array list

        public static DBConnect GetConnection()
        {
            return new DBConnect();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;//necessary for asp validators... or else

            BookDb objBookData = new BookDb();

            gvBooks.Visible = true;
            if (IsPostBack == false)
            {
                BookDb bDB = new BookDb();
                gvBooks.DataSource = bDB.getBookData();
                gvBooks.DataBind();
            }
            //bind the arrayList to the 2nd GridView
            
        }//page load class

        public bool validatorEmpty()
        {
            bool result = true;
            if (String.IsNullOrEmpty(txtName.Text))
            {

                result = false;
                
            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {

                result = false;
                
            }
            if (String.IsNullOrEmpty(txtPhoneNumber.Text))
            {

                result = false;

            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {

                result = false;

            }
            return result;
        }


        protected void gvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            double count = 0;//total book sale count
           

            foreach (GridViewRow row in gvBooks.Rows)//adding whatever was selected to the arrayList
            {
                // Access the CheckBox
                //CheckBox cb = (CheckBox)row.FindControl("gvBooks");
                BookProcessing bPross = new BookProcessing();//book processing object
                Book objBook = new Book();
                
                
                    if (((CheckBox)row.FindControl("chkSelect")).Checked)
                    {

                    string tbTitle = row.Cells[1].Text;
                    string tbAuthor = row.Cells[2].Text;
                    string tbISBN = row.Cells[3].Text;
                    DropDownList ddlBookType = (DropDownList)row.Cells[4].FindControl("ddlBookType");
                    RadioButtonList rblBookType = (RadioButtonList)row.Cells[5].FindControl("RadioButtonList1");
                    TextBox tbQuantityBook = (TextBox)row.Cells[6].FindControl("txtQuantityBook");
                    
                    string strBookType = Convert.ToString(ddlBookType.Text);
                    string strRadioButtonList1 = Convert.ToString(rblBookType.Text);
                    int dbTxtQuantityBook = Convert.ToInt32(tbQuantityBook.Text);

                        objBook.Title = tbTitle;
                        objBook.Author = tbAuthor;
                        objBook.ISBN = tbISBN;
                        objBook.BookType = strBookType;
                        objBook.PurchaseOption = strRadioButtonList1;
                        objBook.Quantity = dbTxtQuantityBook;

                        objBook.Price = bPross.saleCalculator(tbISBN, strBookType, strRadioButtonList1);//adjust price

                        objBook.TotalCost = objBook.Price * objBook.Quantity;

                        bookOrderList.Add(objBook);//add book to arrayList bookOrderList

                        count += objBook.Quantity;//total books purchased

                    totalOrderSale = objBook.TotalCost + totalOrderSale;//calculate the the amount of money generated from this book sale

                    bPross.updateBookQuant(tbISBN, objBook.Quantity, objBook.PurchaseOption, objBook.TotalCost);//update sales and quant in DB

                }//end if
                
                
                }//end for   
                  
                   //display time
            lblCustomerInfo.Text = txtStudentId.Text + " " + txtName.Text + " " + txtAddress.Text + " " + txtPhoneNumber.Text;

                    txtStudentId.Visible = false;
                    txtName.Visible = false;
                    txtAddress.Visible = false;
                    txtPhoneNumber.Visible = false; 
                    lblCustomerInfo.Visible = true;
                    ddlCampus.Visible = true;
                    gvBooks.Visible = false;

            gvManager.Visible = false;

            gvDisplayOrder.Visible = true;

            gvDisplayOrder.Columns[0].FooterText = "Totals:";
            gvDisplayOrder.Columns[5].FooterText = count.ToString();
            gvDisplayOrder.Columns[6].FooterText = totalOrderSale.ToString("C2");//footer totalCost


            SortDirection direction = SortDirection.Ascending;

            gvDisplayOrder.DataSource = bookOrderList;
            gvDisplayOrder.DataBind();
        }//end btnSubmitOrder_Click

        protected void btnViewreport_Click(object sender, EventArgs e)
        {
            txtStudentId.Visible = false;
            txtName.Visible = false;
            txtAddress.Visible = false;
            txtPhoneNumber.Visible = false;
            lblCustomerInfo.Visible = false;
            ddlCampus.Visible = false;

            gvBooks.Visible = false;

            gvDisplayOrder.Visible = false;

            gvManager.Visible = true;

            BookDb bDB = new BookDb();
            gvManager.DataSource = bDB.getBookData();
            gvManager.DataBind();

            SortDirection direction = SortDirection.Descending;
        
    }

        protected void btnBackToOrder_Click(object sender, EventArgs e)
        {
            txtStudentId.Visible = true;
            txtName.Visible = true;
            txtAddress.Visible = true;
            txtPhoneNumber.Visible = true;
            lblCustomerInfo.Visible = true;
            ddlCampus.Visible = true;

            gvBooks.Visible = true;

            gvDisplayOrder.Visible = false;

            gvManager.Visible = false;

             totalOrderSale = 0;
            
            BookDb bDB = new BookDb();
            gvBooks.DataSource = bDB.getBookData();
            gvBooks.DataBind();
        }
    }//end class
}//end nameSpace
 
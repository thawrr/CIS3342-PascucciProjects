using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using Utilities;//using class where student connections 
using System.Data.OleDb;//Represents an SQL statement or stored procedure to execute against a data source
//prevent SQL injection

namespace BookLibrary
{
   public class BookProcessing
    {
        public static DBConnect GetConnection()
        {
            return new DBConnect();
        }

        //for the assignment 
        /*i.	One function receives a Book’s ISBN, BookType (e-book, hardcover, paperback), 
         *      preference for purchase/rent option, and it computes the Price, which is based on the BasePrice 
         *     (from the database), Book Type, and whether it’s a rental or purchase
         */

        
        public double saleCalculator(string isbn, string bookType, string buyOption)
        {
            DBConnect objDB = GetConnection();//make a new object within the method
            SqlConnection conStr = objDB.GetConnection();//connection string from Student_Connection class method
            conStr.Open(); //openConnection 
            
            string str = "SELECT BasePrice FROM Books WHERE ISBN = '" + isbn + "'";//query string to get basePrice from DB
            var strCommand = new SqlCommand(str,conStr);
            //DataSet getDS = new DataSet(str);
            //double basePrice = Convert.ToInt32(getDS.Tables[0].Rows[]["BasePrice"].ToString());
            double basePrice = (double)objDB.ExecuteScalarFunction(strCommand);//get the basePrice from the DPB
            double adjustedPrice = basePrice;

            if (CompareTo(bookType, "eBook") == true)
            {
                adjustedPrice = adjustedPrice * .2 + adjustedPrice;
            }
            else if (CompareTo(bookType, "softCover") == true)
            {
                adjustedPrice = adjustedPrice * .4 + adjustedPrice;
            }

            else
            {
                adjustedPrice = adjustedPrice * .6 + adjustedPrice;
            }

            if (CompareTo(buyOption, "Rent"))
            {
                adjustedPrice = adjustedPrice - adjustedPrice * .5;
            }
            //pg 147 text book
            objDB.CloseConnection();
            return adjustedPrice;
        }

        private static bool CompareTo(string str1, string str2)
        {
            // Compare the values, using the CompareTo method on the first string.
            int cmpVal = str1.CompareTo(str2);

            if (cmpVal == 0) // The strings are the same.
                return true;//"The strings occur in the same position in the sort order.";
            else if (cmpVal < 0)
                return false;//"The first string precedes the second in the sort order.";
            else
                return false;//"The first string follows the second in the sort order.";
        }

        public void updateBookQuant(string isbn, int quant, string bookType, double sale)
        {
            DBConnect objDB = GetConnection();//make a new object within the method
            //SqlConnection conStr = objDB.GetConnection();//connection string from Student_Connection class method
            //conStr.Open(); //openConnection 

            string tsStr = "SELECT TotalSales FROM Books WHERE ISBN = '" + isbn + "'";//query string to get basePrice from DB
            //var strCommand1 = new SqlCommand(tsStr, conStr);
            objDB.GetDataSet(tsStr);
            double totalSales = (double)objDB.GetField("TotalSales", 0);
            //ExecuteScalarFunction(strCommand1);//get the totalSales from the DPB

            //sale = sale + totalSales;//update sales with lots of money
            string strr = "UPDATE Books SET TotalSales = '" + (sale + totalSales) + "' WHERE ISBN = '" + isbn + "'";
            objDB.DoUpdate(strr);


            if (CompareTo(bookType, "Buy") == true)
            {
                string tqsStr = "SELECT TotalQuantitySold FROM Books WHERE ISBN = '" + isbn + "'";
                objDB.GetDataSet(tqsStr);
                //var strCommand2 = new SqlCommand(tqsStr, conStr);
                int dbQuant = (int)objDB.GetField("TotalQuantitySold",0);

                //dbQuant =  quant + dbQuant;
                string str = "UPDATE Books SET TotalQuantitySold = '"+(dbQuant + quant)+ "'WHERE ISBN = '" + isbn + "'";
               
                //ar strCommand3 = new SqlCommand(str, conStr);
                objDB.DoUpdate(str);
            }
            else
            {
                string tqrStr = "SELECT TotalQuantityRented FROM Books WHERE ISBN = '" + isbn + "'";
                objDB.GetDataSet(tqrStr);
                //var strCommand4 = new SqlCommand(tqrStr, conStr);
                int dbQuant1 = (int)objDB.GetField("TotalQuantityRented", 0);
                //ExecuteScalarFunction(strCommand4);

                //dbQuant1 = dbQuant1 + quant;
                string str1 = "UPDATE Books SET TotalQuantityRented = '"+ (dbQuant1 + quant) + "' WHERE ISBN = '" + isbn + "'";
                
                //var strCommand5 = new SqlCommand(str1, conStr);
                objDB.DoUpdate(str1);
            }

            
            //conStr.Close();
        }

    }//end BookProessing class
}//end nameSpace
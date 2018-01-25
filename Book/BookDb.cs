using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;

namespace BookLibrary
{
    public class BookDb
    {
        public static DBConnect GetConnection()
        {
            return new DBConnect();
        }

        public object getBookData()
        {
            DBConnect objDB = GetConnection();//make a new object within the method
            SqlConnection conStr = objDB.GetConnection();//connection string from Student_Connection class method

            string str = "SELECT * FROM Books";//query string to get basePrice from DB
            
            conStr.Open(); //openConnection 

            objDB.GetDataSet(str);

            objDB.CloseConnection();

            return objDB.GetDataSet(str);
        }

        
    }//end class
}//end nameSpace

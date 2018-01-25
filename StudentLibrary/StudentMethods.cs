using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace StudentLibrary
{
    public class StudentMethods
    {

        DataValidation dv = new DataValidation();
        // Code used to connect to a SQL Server database and execute a Stored Procedure
        SqlCommand objCommand = new SqlCommand();

       

        public void NewStudent(string fn, string ln, string ad, string email, string ma)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "NewStudent"; // name of the Stored Procedure 

            // Pass an input parameter value to the Stored Procedure that is used for the 
            // @theName built-in parameter
            
            objCommand.Parameters.AddWithValue("@FirstName", fn);
            objCommand.Parameters.AddWithValue("@LastName", ln);
            objCommand.Parameters.AddWithValue("@StudentAddress", ad);
            objCommand.Parameters.AddWithValue("@Email", email);
            objCommand.Parameters.AddWithValue("@major", ma);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
            //could also use [commandObject.ExecuteNonQuery()] to get the new StudentID
        }

        public int GetStudentCount()
        {

            SqlConnection conn = new SqlConnection("server=cis-mssql1.temple.edu;Database=sp17_3342_tuc45491;User id=tuc45491;Password=iiVi1omo");
            SqlCommand objCommand = new SqlCommand("dbo.GetStudCount", conn);

            objCommand.CommandType = CommandType.StoredProcedure;
            
            objCommand.Parameters.Add("@theCount", SqlDbType.Int).Direction = ParameterDirection.Output;
            
            conn.Open();
            objCommand.ExecuteNonQuery();

            int count = Convert.ToInt32(objCommand.Parameters["@theCount"].Value);
            conn.Close();
            return count;
        }

        public int ReturnNewStudentID(int sc)
        {//get the new ID for newly made student record

            SqlConnection conn = new SqlConnection("server=cis-mssql1.temple.edu;Database=sp17_3342_tuc45491;User id=tuc45491;Password=iiVi1omo");
            SqlCommand objCommand = new SqlCommand("dbo.GetNewStudID", conn);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetNewStudID"; // name of the Stored Procedure

            objCommand.Parameters.Add("@count", SqlDbType.Int, 7);
            objCommand.Parameters.Add("@newNum", SqlDbType.Int).Direction = ParameterDirection.Output;

            //set command
            objCommand.Parameters["@count"].Value = sc;

            // Execute stored procedure using DBConnect object and the SQLCommand object
            conn.Open();
            objCommand.ExecuteNonQuery();
            conn.Close();
            int myNewID = -1;
            try
            {
                myNewID = Convert.ToInt32(objCommand.Parameters["@NewNum"].Value);

            }
            catch (OverflowException ez)
            {
                Console.WriteLine("OverflowException "+ez);
            }
            catch (FormatException ey)
            {
                Console.WriteLine("FormatException "+ey);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("InvalidCastException "+ex);

            }
            
            return myNewID;//returns an object, must parse to an int

        }

        public int CheckForStudent(int count, int studID)
        {
            SqlConnection conn = new SqlConnection("server=cis-mssql1.temple.edu;Database=sp17_3342_tuc45491;User id=tuc45491;Password=iiVi1omo");
            SqlCommand objCommand = new SqlCommand("dbo.CheckForStudent", conn);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckForStudent"; // name of the Stored Procedure

            objCommand.Parameters.Add("@count", SqlDbType.Int, 7);
            objCommand.Parameters.Add("@studID", SqlDbType.Int, 7);

            objCommand.Parameters.Add("@newNum", SqlDbType.Int).Direction = ParameterDirection.Output;

            //set command
            objCommand.Parameters["@count"].Value = count;
            objCommand.Parameters["@studID"].Value = studID;

            // Execute stored procedure using DBConnect object and the SQLCommand object
            conn.Open();
            objCommand.ExecuteNonQuery();
            conn.Close();

            int result = -1;
            try
            {
                result = Convert.ToInt32(objCommand.Parameters["@newNum"].Value);

            }
            catch (OverflowException ez)
            {
                Console.WriteLine("OverflowException " + ez);
            }
            catch (FormatException ey)
            {
                Console.WriteLine("FormatException " + ey);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("InvalidCastException " + ex);

            }

            return result;//returns an object, must parse to an int
        }

    
        public DataSet DisplayALLCourses()
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetALLCourses"; // name of the Stored Procedure

            objDB.GetConnection();
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            objDB.CloseConnection();

            if (dv.CheckForData(ds) == true)
                return ds;
            else
            {
                Console.WriteLine("we have NO NO NO NO NO data");
                return ds;
            }
        }

        public DataSet DisplayCourses(string depID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCoursesByID"; // name of the Stored Procedure

            // Pass an input parameter value to the Stored Procedure that is used for the 
            // @theName built-in parameter
            SqlParameter inputParameter = new SqlParameter("@depID", depID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;

            objCommand.Parameters.Add(inputParameter);

            objDB.GetConnection();
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            objDB.CloseConnection();

            if (dv.CheckForData(ds) == true)
                return ds;
            else
            {
                Console.WriteLine("we have NO NO NO NO NO data");
                return ds;
            }

        }

        public DataSet UpdateCourse(int upStr, string cn, double ch, string pr, string dID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateCourse"; // name of the Stored Procedure

            objCommand.Parameters.AddWithValue("@cID", upStr);
            objCommand.Parameters.AddWithValue ("@cn", cn);
            objCommand.Parameters.AddWithValue("@ch", ch);
            objCommand.Parameters.AddWithValue("@pr", pr);
            objCommand.Parameters.AddWithValue("@dID", dID);

            objDB.GetConnection();
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            objDB.CloseConnection();

            if (dv.CheckForData(ds) == true)
                return ds;
            else
            {
                Console.WriteLine("we have NO NO NO NO NO data");
                return ds;
            }
        }

        public void DeleteCourse(int delStr)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteCourse";
            SqlParameter cid = new SqlParameter("@CourseID", delStr);
            objCommand.Parameters.Add(cid);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
        }

        public void AddCourse(string cn, double ch, string pr, string dID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddCourse"; // name of the Stored Procedure
            
            objCommand.Parameters.AddWithValue("@cn", cn);
            objCommand.Parameters.AddWithValue("@ch", ch);
            objCommand.Parameters.AddWithValue("@pr", pr);
            objCommand.Parameters.AddWithValue("@dID", dID);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
        }

        public DataSet GetRegCourseInfo(string sID, string dID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "MegaSelect"; // name of the Stored Procedure
            // Pass an input parameter value to the Stored Procedure that is used for the 
            // @theName built-in parameter
            objCommand.Parameters.AddWithValue("@sID", sID);
            objCommand.Parameters.AddWithValue("@dID", dID);

            objDB.GetConnection();
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            objDB.CloseConnection();
            if (dv.CheckForData(ds) == true)
                return ds;
            else
            {
                Console.WriteLine("we have NO NO NO NO NO data");
                return ds;
            }
        }

        

        public Tuple<int, int> CheckPreviousSections(List <string> crnList, List <string> newCourses, int studID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCoursesForCheck"; // old DATA
            objCommand.Parameters.AddWithValue("@studentID", studID);

            objDB.GetConnection();
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);//get all sections. will contain nulls
            objDB.CloseConnection();

            //convert the dataSet retrieved from DB into Section obj
            Section secObj = new Section();
            List<Section> dbList = new List<Section>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
              dbList.Add(new Section{ CRN1 = Convert.ToString(dr["crn1"]), CRN2 = Convert.ToString(dr["crn2"]), CRN3 = Convert.ToString(dr["crn3"]),
                CRN4 = Convert.ToString(dr["crn4"]), CRN5 = Convert.ToString(dr["crn5"]), CRN6 = Convert.ToString(dr["crn6"]),
                CRN7 = Convert.ToString(dr["crn7"]) });
            }

           
            int errorCheck = 0;//check preReq
            int errorCheck2 = 0;//check already registered
            foreach (var singleCourse in dbList.AsEnumerable())//compare both lists
            {
                if (newCourses.Contains(singleCourse.ToString()) == false)
                {
                    errorCheck = errorCheck + 0; ;//move on
                }
                else
                {
                    errorCheck = errorCheck + 1;//we have a violation
                }

               
                foreach (var singleCRN in dbList.AsEnumerable())//compare both lists
                {
                    if (crnList.Contains(singleCRN.ToString()) == false)
                    {
                        errorCheck2 = errorCheck2 + 0; ;//move on
                    }
                    else
                    {
                        errorCheck2 = errorCheck2 + 1;//we have a violation
                    }
                }
            }
            return Tuple.Create(errorCheck, errorCheck2);
        }

        public void UpdateSection(string crn)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateSection"; 
            objCommand.Parameters.AddWithValue("@crn", crn);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
        }

        public void UpdateTuition(double tuit, int studID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateTuitionNoDrop";
            objCommand.Parameters.AddWithValue("@tuition", tuit);
            objCommand.Parameters.AddWithValue("@studentID", studID);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
        }

        public void UpdateRegister(string crn1, string crn2, string crn3, 
                                string crn4, string crn5, string crn6, string crn7, int studID)
        {
            DBConnect objDB = new DBConnect();
            objCommand.Parameters.Clear();//use this before executing a stored procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRegister";
            objCommand.Parameters.AddWithValue("@studentID", studID);
            objCommand.Parameters.AddWithValue("@crn1", crn1);
            objCommand.Parameters.AddWithValue("@crn2", crn2);
            objCommand.Parameters.AddWithValue("@crn3", crn3);
            objCommand.Parameters.AddWithValue("@crn4", crn4);
            objCommand.Parameters.AddWithValue("@crn5", crn5);
            objCommand.Parameters.AddWithValue("@crn6", crn6);
            objCommand.Parameters.AddWithValue("@crn7", crn7);

            objDB.GetConnection();
            objDB.DoUpdateUsingCmdObj(objCommand);
            objDB.CloseConnection();
        }

    }//end class
}//end nameSpace

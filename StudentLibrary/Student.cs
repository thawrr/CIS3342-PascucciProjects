using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class Student
    {
        private int studentID;
        private int departmentID;
        private string firstName;
        private string lastName;
        private string address;
        private double tuitionOwed;
        private string email;
        private string major;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public int DepartmentID
        {
            get { return departmentID; }
            set {departmentID = value;}
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value;}
        }

        public double TuitionOwed
        {
            get { return tuitionOwed; }
            set {tuitionOwed = value;}
        }

        public string Email
        {
            get { return email; }
            set {email = value;}
        }

        public string Major
        {
            get { return major; }
            set {major = value;}
        }

    }//end class
}//end nameSpace

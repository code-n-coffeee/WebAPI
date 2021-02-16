using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebAPI.Models
{
    public class Student
    { //Define all the properties of table with get and set

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public int ContactNumber { get; set; }
    }

    //Creating an object of Student class
    public class createStudent : Student
    {

    }

    public class ReadStudent: Student 
    {
       public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            FullName = row["FullName"].ToString();
            Course = row["Course"].ToString();
            ContactNumber= Convert.ToInt32(row["ContactNumber"]);

        }


    }
}
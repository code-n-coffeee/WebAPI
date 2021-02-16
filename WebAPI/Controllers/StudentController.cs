using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>

        //Declare sql connection and command objects here

        private SqlConnection conn;
        private SqlDataAdapter adapter;
        public IEnumerable<Student> Get()
        {
            conn = new SqlConnection("data source=DESKTOP-3CTJ57L\\SQLEXPRESS; Initial catalog=SampleDB; user id=sa; password=orangejuice;");
            DataTable dt = new DataTable();
            var query = "select * from Student";
            adapter = new SqlDataAdapter

            { SelectCommand = new SqlCommand(query, conn)
              };

            adapter.Fill(dt);
            List<Student> st = new List<Models.Student>(dt.Rows.Count);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow studentrecord in dt.Rows)
                {
                    st.Add(new ReadStudent(studentrecord));
                }
            }

            return st;
        }

        // GET api/<controller>/5
      public IEnumerable<Student> Get(int id)
        {
            conn = new SqlConnection("data source=DESKTOP-3CTJ57L\\SQLEXPRESS; Initial catalog=SampleDB; user id=sa; password=orangejuice;");
            DataTable dt = new DataTable();
            var query = $"select * from Student where id={id}";
            adapter = new SqlDataAdapter

            {
                SelectCommand = new SqlCommand(query, conn)
            };

            adapter.Fill(dt);
            List<Student> st = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in dt.Rows)
                {
                    st.Add(new ReadStudent(studentrecord));
                }
            }

            return st;
        }


        // POST api/<controller>
        public string Post([FromBody] createStudent value)
        {
            conn = new SqlConnection("data source=DESKTOP-3CTJ57L\\SQLEXPRESS; Initial catalog=SampleDB; user id=sa; password=orangejuice;");
            var query = "insert into Student(Id,FullName,Course,ContactNumber) values(@Id,@FullName,@Course,@ContactNumber)";
            SqlCommand insertCommand = new SqlCommand(query, conn);

            insertCommand.Parameters.AddWithValue("@Id", value.Id);
            insertCommand.Parameters.AddWithValue("@FullName", value.FullName);
            insertCommand.Parameters.AddWithValue("@Course", value.Course);
            insertCommand.Parameters.AddWithValue("@ContactNumber", value.ContactNumber);
            conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if(result>0)
            {
                return "Inserted ";
            }

            else
            {
                return "Not Inserted";
            }

         }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] createStudent value)
        {

            conn = new SqlConnection("data source=DESKTOP-3CTJ57L\\SQLEXPRESS; Initial catalog=SampleDB; user id=sa; password=orangejuice;");
            var query = "Update Student set Id=@Id,FullName=@FullName,Course=@Course,ContactNumber=@ContactNumber where Id=" + id;
            SqlCommand insertCommand = new SqlCommand(query, conn);

            insertCommand.Parameters.AddWithValue("@Id", value.Id);
            insertCommand.Parameters.AddWithValue("@FullName", value.FullName);
            insertCommand.Parameters.AddWithValue("@Course", value.Course);
            insertCommand.Parameters.AddWithValue("@ContactNumber", value.ContactNumber);
            conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "True";
            }

            else
            {
                return "False";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            conn = new SqlConnection("data source=DESKTOP-3CTJ57L\\SQLEXPRESS; Initial catalog=SampleDB; user id=sa; password=orangejuice;");
            var query = "Delete from Student where Id="+ id;
            SqlCommand insertCommand = new SqlCommand(query, conn);

            conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "True";
            }

            else
            {
                return "False";
            }
        }
    }
}
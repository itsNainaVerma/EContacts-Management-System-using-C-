using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.econtactClasses
{
    class ContactClass
    {
        //Getter scatter properties
        //Acts as data carrier in our application
        public int ContactID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        
        //selecting database from the database
        public DataTable Select()
        {
            //1 Database connection
            SqlConnection conn = new SqlConnection(myconstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from contact";
                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //creating sql Dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        //insert data into database
        public bool Insert(ContactClass c)
        {
            //creating a default return type and selecting its value to false
            
            bool isSuccess= false;

            //1 connext database
            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                //2 create a sql query to insert data
                string sql = "INSERT INTO contact (FirstName,LastName,ContactNo,Address,Gender) VALUES (@FirstName,@LastName,@ContactNo,@Address,@Gender)";
                //creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql,conn);
                //create parameters yo add data
                cmd.Parameters.AddWithValue( "@FirstName", c.Firstname);
                cmd.Parameters.AddWithValue( "@LastName",c.Lastname );
                cmd.Parameters.AddWithValue( "@ContactNo", c.ContactNo );
                cmd.Parameters.AddWithValue( "@Address", c.Address );
                cmd.Parameters.AddWithValue( "@Gender", c.Gender );

                //connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query row successfullt then the value of row will be greater then zero else its value will be zero

                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }
        public bool Update(ContactClass c)
        {
            //create s default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                //sql to update data
                string sql = "UPDATE contact SET Firstname=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender Where ContactID=@ContactID";

                //sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //parameters to add values
                cmd.Parameters.AddWithValue("@FirstName", c.Firstname);
                cmd.Parameters.AddWithValue("@LastName", c.Lastname);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //open database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query row successfullt then the value of row will be greater then zero else its value will be zero

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Delete(ContactClass c)
        {
            //create s default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                //sql to update data
                string sql = "DELETE FROM contact where ContactID=@ContactID";

                //sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //parameters to add values
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //open database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfullt then the value of row will be greater then zero else its value will be zero

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        
         }
    }
}

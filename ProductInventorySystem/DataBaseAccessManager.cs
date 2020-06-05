using ProductInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProductInventorySystem
{
    class DatabaseAccessManager
    {

        private string _dBConnectionString = "Data Source=DESKTOP-LJGFC9F;Integrated Security=True;Initial Catalog=PartsStoreDB";
        private SqlConnection _connection;


        private bool ConnectToDB()
        {
            bool connectionSuccessful = false;
            try
            {
                _connection = new SqlConnection(_dBConnectionString);
                _connection.Open();
                connectionSuccessful = true;
            }
            catch (Exception e)
            {
                //error has occurred while trying to connect to DB.
                MessageBox.Show(e.Message);
            }

            return connectionSuccessful;

        }


        //public List<Note> GetNotes(Int64 userId)
        //{
        //    List<Note> notes = new List<Note>();

        //    var connectionSuccessful = ConnectToDB();

        //    if (connectionSuccessful == true)
        //    {
        //        SqlCommand sqlCmd = new SqlCommand($"Select * from Notes where USER_ID = {userId}", _connection);
        //        sqlCmd.CommandType = CommandType.Text; //for using in-code sql

        //        try
        //        {
        //            SqlDataReader reader = sqlCmd.ExecuteReader();

        //            while (reader.Read() == true)
        //            {
        //                Note note = new Note();
        //                note.NoteBody = (string)reader["NOTE_BODY"];
        //                note.NoteDate = (DateTime)reader["DATE"];
        //                note.NoteId = (Int64)reader["NOTE_ID"];

        //                notes.Add(note);
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            //error has occurred while trying to read User's notes.
        //            MessageBox.Show(e.Message);
        //        }
        //    }

        //    return notes;
        //}

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            var connectionSuccessful = ConnectToDB();

            if (connectionSuccessful == true)
            {
                SqlCommand sqlCmd = new SqlCommand("Select * from Customers", _connection);
                sqlCmd.CommandType = CommandType.Text; //for using in-code sql

                try
                {
                    SqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Customer customer = new Customer();
                        customer.CustId = (Int64)reader["CUST_ID"];
                        customer.Lname = (string)reader["LNAME"];
                        customer.Fname = (string)reader["FNAME"];
                        customer.AddressCity = (string)reader["Address_City"];
                        customer.AddressState = (string)reader["Address_State"];
                        customer.AddressStreet = (string)reader["Address_Street"];
                        customer.ZipCode = (string)reader["Zip_Code"];

                        customers.Add(customer);
                    }

                }
                catch (Exception e)
                {
                    //error has occurred while trying to get Users.
                    MessageBox.Show(e.Message);
                }
            }

            return customers;

        }
    }
}

//This one is for 'Employees'

//public List<Employee> GetEmployees()
//{
//    List<Customer> customers = new List<Customer>();

//    var connectionSuccessful = ConnectToDB();

//    if (connectionSuccessful == true)
//    {
//        SqlCommand sqlCmd = new SqlCommand("Select * from Customers", _connection);
//        sqlCmd.CommandType = CommandType.Text; //for using in-code sql

//        try
//        {
//            SqlDataReader reader = sqlCmd.ExecuteReader();

//            while (reader.Read() == true)
//            {
//                Customer customer = new Customer();
//                customer.CustId = (Int64)reader["CUST_ID"];
//                customer.Lname = (string)reader["LNAME"];
//                customer.Fname = (string)reader["FNAME"];
//                customer.AddressCity = (string)reader["Address_City"];
//                customer.AddressState = (string)reader["Address_State"];
//                customer.AddressStreet = (string)reader["Address_Street"];
//                customer.ZipCode = (string)reader["Zip_Code"];

//                customers.Add(customer);
//            }

//        }
//        catch (Exception e)
//        {
//            //error has occurred while trying to get Users.
//            MessageBox.Show(e.Message);
//        }
//    }

//    return customers;
//}

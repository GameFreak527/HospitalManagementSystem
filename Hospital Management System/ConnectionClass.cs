using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_Management_System
{
    public static class ConnectionClass
    {

        private static SqlConnection cn;
        private static SqlCommand cmd;


        static ConnectionClass()
        {
            //This is my connection string
            //Comment mine out and add yours to use this classes methods

            //Gab's
           // cn = new SqlConnection(@"Data Source=LAPTOP-47BNNCUR\COMP229_SQL;Initial Catalog=Hospital_ManagementDB;Integrated Security=True");
            //cn = new SqlConnection(@"Data Source=GameFreak;Initial Catalog=Hospital_ManagementDB;Integrated Security=True");
          //  cn = new SqlConnection(@"Data Source=DESKTOP-CL4P1VF\SQL;Initial Catalog=Hospital_ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }




        public static void AddSchedule(Appointment appointment)
        {

            SqlCommand cmd = new SqlCommand(@"insert into [Appointment] (Patient, Employee, StartTime, EndTime) values(@patientId, @employeeId, @startTime, @endTime)", cn);

            cmd.Parameters.Add("@patientId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@startTime", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@endTime", System.Data.SqlDbType.VarChar);

            cmd.Parameters["@employeeId"].Value = appointment.Employee;
            cmd.Parameters["@patientId"].Value = appointment.Patient;
            cmd.Parameters["@startTime"].Value = appointment.StartTime;
            cmd.Parameters["@endTime"].Value = appointment.EndTime;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static int addPatient(Patient patient)
        {
            int result =0;
            SqlCommand cmd = new SqlCommand(@"insert into [Patient] (Ward, FirstName, LastName, PhoneNumber, Address) values(@wardId, @firstName, @lastName, @phoneNumber, @address)", cn);

            cmd.Parameters.Add("@wardId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar);

            cmd.Parameters["@wardId"].Value = patient.Ward;
            cmd.Parameters["@firstName"].Value = patient.FirstName;
            cmd.Parameters["@lastName"].Value = patient.LastName;
            cmd.Parameters["@phoneNumber"].Value = patient.PhoneNumber;
            cmd.Parameters["@address"].Value = patient.Address;

            try
            {
                cn.Open();
                result = cmd.ExecuteNonQuery();


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                new Exception("ERROR : " + e.Message);
            }
            finally
            {
                cn.Close();
            }
            return result;
        }
    }
}
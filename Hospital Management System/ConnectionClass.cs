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

            cn = new SqlConnection(@"Data Source=LAPTOP-47BNNCUR\COMP229_SQL;Initial Catalog=Hospital_ManagementDB;Integrated Security=True");
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
    }
}
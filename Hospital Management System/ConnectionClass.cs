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
           //cn = new SqlConnection(@"Data Source=LAPTOP-47BNNCUR\COMP229_SQL;Initial Catalog=Hospital_ManagementDB;Integrated Security=True");
            cn = new SqlConnection(@"Data Source=GameFreak;Initial Catalog=Hospital_ManagementDB;Integrated Security=True");
            //  cn = new SqlConnection(@"Data Source=DESKTOP-CL4P1VF\SQL;Initial Catalog=Hospital_ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //DESKTOP-R7AG3IR

        }




        public static void AddSchedule(Appointment appointment)
        {

            SqlCommand cmd = new SqlCommand(@"insert into [Appointment] (Patient, Employee, StartTime) values(@patientId, @employeeId, @startTime)", cn);

            cmd.Parameters.Add("@patientId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@startTime", System.Data.SqlDbType.VarChar);
            

            cmd.Parameters["@employeeId"].Value = appointment.Employee;
            cmd.Parameters["@patientId"].Value = appointment.Patient;
            cmd.Parameters["@startTime"].Value = appointment.StartTime;
            

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




        public static void AddReportWithoutAppointmentID(int empID, int patientID, string diagnosis, string prescription)
        {
            
            SqlCommand cmd = new SqlCommand(@"insert into [MedicalHistory] (Patient, Diagnosis, Employee, Prescription) values(@patientId, @diagnosis, @employeeId, @prescription)", cn);

            cmd.Parameters.Add("@patientId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@diagnosis", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@prescription", System.Data.SqlDbType.VarChar);

            cmd.Parameters["@employeeId"].Value = empID;
            cmd.Parameters["@patientId"].Value = patientID;
            cmd.Parameters["@diagnosis"].Value = diagnosis;
            cmd.Parameters["@prescription"].Value = prescription;

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


        public static int IsRecordFound(int id) {

           int value = 0;
            SqlCommand cmd = new SqlCommand(@"select * from [MedicalHistory]  where AppointmentID = @Id", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);



            cmd.Parameters["@Id"].Value = id;
           


            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }


            finally
            {
                cn.Close();
            }

            return value;

        }



        public static void UpdateReport(int empID, int patientID, string diagnosis, string prescription, int id)
        {

            SqlCommand cmd = new SqlCommand(@"update [MedicalHistory] set Patient = @patientId, Diagnosis = @diagnosis, Employee = @employeeId, Prescription = @prescription where AppointmentID = @Id ", cn);

            cmd.Parameters.Add("@patientId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@diagnosis", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@prescription", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);



            cmd.Parameters["@Id"].Value = id;
            cmd.Parameters["@employeeId"].Value = empID;
            cmd.Parameters["@patientId"].Value = patientID;
            cmd.Parameters["@diagnosis"].Value = diagnosis;
            cmd.Parameters["@prescription"].Value = prescription;

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

        public static int IsPatientRecordFound(int id)
        {

            int value = 0;
            SqlCommand cmd = new SqlCommand(@"select * from [MedicalHistory]  where Patient = @Id", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);



            cmd.Parameters["@Id"].Value = id;



            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }


            finally
            {
                cn.Close();
            }

            return value;

        }





        public static int IsPatientAppointmentFound(int id)
        {

            int value = 0;
            SqlCommand cmd = new SqlCommand(@"select * from [Appointment]  where Patient = @Id", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);



            cmd.Parameters["@Id"].Value = id;



            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }


            finally
            {
                cn.Close();
            }

            return value;

        }

        /// <summary>
        /// method returns the ID number of the employee for the 
        /// specific appointment record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetAppointmentEmployeeID(int id)
        {

            int value = 0;
            SqlCommand cmd = new SqlCommand(@"select employee from [Appointment]  where AppointmentID = @Id", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);



            cmd.Parameters["@Id"].Value = id;



            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }


            finally
            {
                cn.Close();
            }

            return value;

        }

        /// <summary>
        /// a method that updates a created appointment to clossed
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="patientID"></param>
        /// <param name="diagnosis"></param>
        /// <param name="prescription"></param>
        /// <param name="id"></param>
        public static void UpdateAndCloseAppointment(int appID, string endTime, string diagnosis, string prescription)
        {

            SqlCommand cmd = new SqlCommand(@"update [Appointment] set Diagnosis = @diagnosis, Prescription = @prescription, EndTime = @endTime where AppointmentID = @Id ", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@endTime", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@diagnosis", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@prescription", System.Data.SqlDbType.VarChar);
            



           
            cmd.Parameters["@endTime"].Value = endTime;
            cmd.Parameters["@Id"].Value = appID;
            cmd.Parameters["@diagnosis"].Value = diagnosis;
            cmd.Parameters["@prescription"].Value = prescription;

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




        /// <summary>
        /// This adds a report record with an appointment ID 
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="patientID"></param>
        /// <param name="diagnosis"></param>
        /// <param name="prescription"></param>
        /// <param name="appoint"></param>
        public static void AddReportWithAppointmentID(int empID, int patientID, string diagnosis, string prescription, int appoint)
        {

            SqlCommand cmd = new SqlCommand(@"insert into [MedicalHistory] (Patient, Diagnosis, Employee, Prescription, Appointment ) values(@patientId, @diagnosis, @employeeId, @prescription, @Id)", cn);

            cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@patientId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@diagnosis", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@prescription", System.Data.SqlDbType.VarChar);

            cmd.Parameters["@Id"].Value = appoint;
            cmd.Parameters["@employeeId"].Value = empID;
            cmd.Parameters["@patientId"].Value = patientID;
            cmd.Parameters["@diagnosis"].Value = diagnosis;
            cmd.Parameters["@prescription"].Value = prescription;

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
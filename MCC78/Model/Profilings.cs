using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC78.Context;

namespace MCC78.Model
{
    public class Profilings
    {

        
        public string EmployeeId { get; set; }
        public int EducationId { get; set; }



        public List<Profilings> GetProfilings()
        {
            var pro = new List<Profilings>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profillings";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var prof = new Profilings();
                        prof.EmployeeId = reader.GetGuid(0).ToString();
                        prof.EducationId = reader.GetInt32(1);

                        pro.Add(prof);
                    }
                    return pro;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Profilings>();
        }

        public static int InsertProfiling(Profilings profiling)
        {

            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();
            var employee = new Employees();
            var education = new Educations();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profillings(employee_id, education_id) VALUES (@Employee_Id, @Education_Id)";
                command.Transaction = transaction;

                var pEmpId = new SqlParameter();
                pEmpId.ParameterName = "@Employee_Id";
                pEmpId.Value = profiling.EmployeeId;
                command.Parameters.Add(pEmpId);

                var pEduId = new SqlParameter();
                pEduId.ParameterName = "@Education_Id";
                pEduId.Value = profiling.EducationId;
                command.Parameters.Add(pEduId);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }

            catch 
            {
               
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }



        public static void CreateProfilings()
        {
            var profilings = new Profilings();
            Console.Write("Masukkan Employee : ");
            profilings.EmployeeId = Console.ReadLine();
            var result = InsertProfiling(profilings);
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

        }

        public static string GetEmpId(string NIK)
        {
            using var connection = MyConnection.Get();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT id FROM tb_m_employees WHERE nik=(@NIK)", connection);

            var niks = new SqlParameter();
            niks.ParameterName = "@NIK";
            niks.Value = NIK;
            command.Parameters.Add(niks);

            string lastEmpId = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return lastEmpId;
        }


    }
}


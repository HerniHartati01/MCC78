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
    public class Employees
    {

        // Employee Atribut
        public string Id { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }



        // INSERT : Employee
        public int InsertDataEmployee(Employees employees)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_employees(nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id) VALUES (@nik, @first_name, @last_name, @birthdate, @gender, @hiring_date, @email, @phone_number, @department_id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pNik = new SqlParameter();
                pNik.ParameterName = "@nik";
                pNik.SqlDbType = SqlDbType.VarChar;
                pNik.Size = 6;
                pNik.Value = employees.Nik;

                var pFname = new SqlParameter();
                pFname.ParameterName = "@first_name";
                pFname.SqlDbType = SqlDbType.VarChar;
                pFname.Size = 50;
                pFname.Value = employees.FirstName;

                var pLname = new SqlParameter();
                pLname.ParameterName = "@last_name";
                pLname.SqlDbType = SqlDbType.VarChar;
                pLname.Size = 50;
                pLname.Value = employees.LastName;

                var pBdate = new SqlParameter();
                pBdate.ParameterName = "@birthdate";
                pBdate.SqlDbType = SqlDbType.DateTime;
                pBdate.Value = employees.BirthDate;

                var pGender = new SqlParameter();
                pGender.ParameterName = "@gender";
                pGender.SqlDbType = SqlDbType.VarChar;
                pGender.Size = 10;
                pGender.Value = employees.Gender;

                var pHdate = new SqlParameter();
                pHdate.ParameterName = "@hiring_date";
                pHdate.SqlDbType = SqlDbType.DateTime;
                pHdate.Value = employees.HiringDate;

                var pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Size = 50;
                pEmail.Value = employees.Email;

                var pPnumber = new SqlParameter();
                pPnumber.ParameterName = "@phone_number";
                pPnumber.SqlDbType = SqlDbType.VarChar;
                pPnumber.Size = 50;
                pPnumber.Value = employees.PhoneNumber;

                var pDid = new SqlParameter();
                pDid.ParameterName = "@department_id";
                pDid.SqlDbType = SqlDbType.Int;
                pDid.Size = 4;
                pDid.Value = employees.DepartmentId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pNik);
                command.Parameters.Add(pFname);
                command.Parameters.Add(pLname);
                command.Parameters.Add(pBdate);
                command.Parameters.Add(pGender);
                command.Parameters.Add(pHdate);
                command.Parameters.Add(pEmail);
                command.Parameters.Add(pPnumber);
                command.Parameters.Add(pDid);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        // GET : Employee(All)
        public List<Employees> GetEmployees()
        {
            var employees = new List<Employees>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employees();
                        employee.Id = reader.GetGuid(0).ToString();
                        employee.Nik = reader.GetString(1);
                        employee.FirstName = reader.GetString(2);
                        employee.LastName = reader.GetString(3);
                        employee.BirthDate = reader.GetDateTime(4);
                        employee.Gender = reader.GetString(5);
                        employee.HiringDate = reader.GetDateTime(6);
                        employee.Email = reader.GetString(7);
                        employee.PhoneNumber = reader.GetString(8);
                        employee.DepartmentId = reader.GetString(9);

                        employees.Add(employee);
                    }

                    return employees;
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
            return new List<Employees>();
        }

    }

}

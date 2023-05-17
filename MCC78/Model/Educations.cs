using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MCC78.Context;

namespace MCC78.Model
{
    public class Educations
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string Gpa { get; set; }
        public int UniversityId { get; set; }

        // GET : Educations(All)
        public List<Educations> GetEducation()
        {
            var Education = new List<Educations>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Educations();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(1);
                        education.Gpa = reader.GetString(1);
                        education.UniversityId = reader.GetInt32(0);

                        Education.Add(education);
                    }

                    return Education;
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
            return new List<Educations>();
        }

        // GET : Educations(5)
        public int GetByIdUniversities(Educations educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations where Id = @Id";


                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = educations.Id;

                command.Parameters.Add(pId);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("===========================================");
                        Console.WriteLine("                   CRUD ");
                        Console.WriteLine("       Get Table Educations By Id");
                        Console.WriteLine("===========================================");
                        Console.WriteLine("ID     :" + reader.GetInt32(0));
                        Console.WriteLine("Name   :" + reader.GetString(1));
                        Console.WriteLine("===========================================");
                        Console.WriteLine("                Herni Hartati");
                        Console.WriteLine("===========================================");

                    }
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

            return result;
        }


        // INSERT : Educations
        public int InsertEducations(Educations educations)
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
                command.CommandText = "INSERT INTO tb_m_educations(major, degree, gpa, university_id) VALUES (@major, @degree, @gpa, @university_id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 100;
                pMajor.Value = educations.Major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 10;
                pDegree.Value = educations.Degree;

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@gpa";
                pGpa.SqlDbType = SqlDbType.VarChar;
                pGpa.Size = 5;
                pGpa.Value = educations.Gpa;

                var pUid = new SqlParameter();
                pUid.ParameterName = "@university_id";
                pUid.SqlDbType = SqlDbType.Int;
                pUid.Size = 5;
                pUid.Value = educations.UniversityId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGpa);
                command.Parameters.Add(pUid);

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

        public int GetUnivEduId(int choice)
        {
            using var connection = MyConnection.Get();
            connection.Open();
            if (choice == 1)
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_universities ORDER BY id DESC", connection);

                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return id;
            }
            else
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return id;
            }
        }




        // UPDATE : Educations(obj)
        public int UpdateEducations(Educations educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_educations SET major = @major, degree = @degree, gpa = @gpa, university_id =  @university_id  WHERE id = (@id)";
                command.Transaction = transaction;

                var pName = new SqlParameter();
                var pId = new SqlParameter();
                var pDegree = new SqlParameter();
                var pGpa = new SqlParameter();
                var pUid = new SqlParameter();

                pName.ParameterName = "@major";
                pDegree.ParameterName = "@degree";
                pGpa.ParameterName = "@gpa";
                pUid.ParameterName = "@university_id";
                pId.ParameterName = "@id";
                pName.Value = educations.Major;
                pDegree.Value = educations.Degree;
                pGpa.Value = educations.Gpa;
                pUid.Value = educations.UniversityId;
                pId.Value = educations.Id;

                command.Parameters.Add(pName);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGpa);
                command.Parameters.Add(pUid);
                command.Parameters.Add(pId);

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

        // DELETE : Universities(5)

        public int DeleteEducations(Educations educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan Delete
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete from tb_m_educations where Id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Size = 20;
                pId.Value = educations.Id;


                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

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

        // CEK NAME : University Id
        /*public static int CekName(Universities universities)
        {
            int result = 0;
            var university = new List<Universities>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * from tb_m_universities where name = @name";


                // Membuat parameter
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 100;
                pName.Value = universities.Name;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

                var universiti = new Universities();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Console.WriteLine("Data University Sudah Ada");
                    while (reader.Read())
                    {
                        var unv = new Universities();
                        unv.Id = reader.GetInt32(0);
                        //unv.Name = reader.GetString(1);

                        university.Add(unv);
                        Console.WriteLine("Data University Sudah Ada " + unv.Id);
                    }
                   
                   

                }

               
               *//* else
                {
                    Console.WriteLine("Data University Belum Ada");
                    while (reader.Read())
                    {
                        var unv = new Universities();
                        var edct = new Educations();
                        unv.Id = reader.GetInt32(0);
                        edct.Id = unv.Id;
                        unv.Name = reader.GetString(1);

                        Console.WriteLine(" Id Data University Baru  " + edct.Id);
                        Console.WriteLine(" Name Data University Baru  " + unv.Name);

                    }
                    Universities.InsertUniversity(universities);
                }*//*
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }*/

        // CEK NAME : University Id (New Name)
        /*public static int getIdUniversityEdu(Universities universities)
        {

            using var connection = new SqlConnection(connectionString);

            // Command melakukan insert
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from tb_m_employee where nama = @nama";

                connection.Open();
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 100;
                pName.Value = universities.Name;

                command.ExecuteNonQuery();
                //int id = Convert.ToInt32(command.ExecuteScalar());
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader[0].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
        }*/

    }

}


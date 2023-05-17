using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Model
{

    public class Universities
    {
        private static readonly string connectionString =
        "Data Source=DESKTOP-T05CUER;Database=db_booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public int Id { get; set; }
        public string Name { get; set; }



        // GET : Universities(All)
        public List<Universities> GetUniversities()
        {
            var universities = new List<Universities>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university = new Universities();
                        university.Id = reader.GetInt32(0);
                        university.Name = reader.GetString(1);

                        universities.Add(university);
                    }

                    return universities;
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
            return new List<Universities>();
        }

        // GET : Universities(5)
        public int GetByIdUniversities(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities where Id = @Id";


                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = university.Id;

                command.Parameters.Add(pId);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("===========================================");
                        Console.WriteLine("                   CRUD ");
                        Console.WriteLine("       Get Table Universities By Id");
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


        // INSERT : Universities
        public int InsertUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_universities(name) VALUES (@name)";
                command.Transaction = transaction;

                // Membuat parameter
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Size = 100;
                pName.Value = university.Name;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

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


        // UPDATE : Universities(obj)
        public int UpdateUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_universities SET name = (@name) WHERE id = (@id)";
                command.Transaction = transaction;

                var pName = new SqlParameter();
                var pId = new SqlParameter();

                pName.ParameterName = "@name";
                pId.ParameterName = "@id";
                pName.Value = university.Name;
                pId.Value = university.Id;

                command.Parameters.Add(pName);
                command.Parameters.Add(pId);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        // DELETE : Universities(5)

        public int DeleteUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete from tb_m_universities where Id=@id";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Size = 20;
                pId.Value = university.Id;


                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }


}

using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Wyporzyczalnia_Gier
{
    public class Database
    {
        private readonly string connectionString;

        public Database()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                ?.ConnectionString
                ?? throw new InvalidOperationException("Brak connection stringa w App.config");
        }

        public DataTable Query(string sql, MySqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int Execute(string sql, MySqlParameter[] parameters = null)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public bool LoginUser(string login, string password, out int userId, out bool isAdmin)
        {
            userId = 0;
            isAdmin = false;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id, is_admin FROM uzytkownicy WHERE login = @Login AND haslo = SHA2(@Password, 256)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetInt32("id");
                                isAdmin = reader.GetBoolean("is_admin");
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd podczas logowania", ex);
            }

            return false;
        }

        public object ExecuteScalar(string sql, MySqlParameter[] parameters = null)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
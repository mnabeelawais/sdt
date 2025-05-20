using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Database helper class for database operations
/// </summary>
public class Database
{
    // Get connection string from web.config
    private static string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    /// <summary>
    /// Execute a query that returns a DataTable
    /// </summary>
    public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
        }

        return dt;
    }

    /// <summary>
    /// Execute a non-query command (INSERT, UPDATE, DELETE)
    /// </summary>
    public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        int result = 0;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
        }

        return result;
    }

    /// <summary>
    /// Execute a scalar query that returns a single value
    /// </summary>
    public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
    {
        object result = null;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                result = cmd.ExecuteScalar();
            }
        }

        return result;
    }
}
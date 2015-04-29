using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DatabaseConnection
/// </summary>
public class DatabaseManager
{
    public DatabaseManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet ExecSQL(string sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["IEBConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("COMN_ExecSQL", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SQL", sql);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }
}
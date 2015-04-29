using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlComn_StatusProvider:DataAccessObject
{
	public SqlComn_StatusProvider()
    {
    }


    public bool DeleteComn_Status(int comn_StatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Status", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = comn_StatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Status> GetAllComn_Statuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Statuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_StatussFromReader(reader);
        }
    }
    public List<Comn_Status> GetComn_StatussFromReader(IDataReader reader)
    {
        List<Comn_Status> comn_Statuss = new List<Comn_Status>();

        while (reader.Read())
        {
            comn_Statuss.Add(GetComn_StatusFromReader(reader));
        }
        return comn_Statuss;
    }

    public Comn_Status GetComn_StatusFromReader(IDataReader reader)
    {
        try
        {
            Comn_Status comn_Status = new Comn_Status
                (
                    (int)reader["Comn_StatusID"],
                    reader["Comn_StatusName"].ToString()
                );
             return comn_Status;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Status GetComn_StatusByID(int comn_StatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_StatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = comn_StatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_StatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Status(Comn_Status comn_Status)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Status", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_StatusName", SqlDbType.NVarChar).Value = comn_Status.Comn_StatusName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_StatusID"].Value;
        }
    }

    public bool UpdateComn_Status(Comn_Status comn_Status)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Status", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = comn_Status.Comn_StatusID;
            cmd.Parameters.Add("@Comn_StatusName", SqlDbType.NVarChar).Value = comn_Status.Comn_StatusName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

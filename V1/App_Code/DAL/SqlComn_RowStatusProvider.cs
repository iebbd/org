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

public class SqlComn_RowStatusProvider:DataAccessObject
{
	public SqlComn_RowStatusProvider()
    {
    }


    public bool DeleteComn_RowStatus(int comn_RowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_RowStatus> GetAllComn_RowStatuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_RowStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_RowStatussFromReader(reader);
        }
    }
    public List<Comn_RowStatus> GetComn_RowStatussFromReader(IDataReader reader)
    {
        List<Comn_RowStatus> comn_RowStatuss = new List<Comn_RowStatus>();

        while (reader.Read())
        {
            comn_RowStatuss.Add(GetComn_RowStatusFromReader(reader));
        }
        return comn_RowStatuss;
    }

    public Comn_RowStatus GetComn_RowStatusFromReader(IDataReader reader)
    {
        try
        {
            Comn_RowStatus comn_RowStatus = new Comn_RowStatus
                (
                    (int)reader["Comn_RowStatusID"],
                    reader["Comn_RowStatusName"].ToString()
                );
             return comn_RowStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_RowStatus GetComn_RowStatusByID(int comn_RowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_RowStatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = comn_RowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_RowStatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_RowStatus(Comn_RowStatus comn_RowStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_RowStatusName", SqlDbType.NVarChar).Value = comn_RowStatus.Comn_RowStatusName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_RowStatusID"].Value;
        }
    }

    public bool UpdateComn_RowStatus(Comn_RowStatus comn_RowStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_RowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = comn_RowStatus.Comn_RowStatusID;
            cmd.Parameters.Add("@Comn_RowStatusName", SqlDbType.NVarChar).Value = comn_RowStatus.Comn_RowStatusName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

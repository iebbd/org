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

public class SqlWeb_EventTypeProvider:DataAccessObject
{
	public SqlWeb_EventTypeProvider()
    {
    }


    public bool DeleteWeb_EventType(int web_EventTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteWeb_EventType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Value = web_EventTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Web_EventType> GetAllWeb_EventTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllWeb_EventTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetWeb_EventTypesFromReader(reader);
        }
    }
    public List<Web_EventType> GetWeb_EventTypesFromReader(IDataReader reader)
    {
        List<Web_EventType> web_EventTypes = new List<Web_EventType>();

        while (reader.Read())
        {
            web_EventTypes.Add(GetWeb_EventTypeFromReader(reader));
        }
        return web_EventTypes;
    }

    public Web_EventType GetWeb_EventTypeFromReader(IDataReader reader)
    {
        try
        {
            Web_EventType web_EventType = new Web_EventType
                (
                    (int)reader["Web_EventTypeID"],
                    reader["Web_EventTypeName"].ToString()
                );
             return web_EventType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Web_EventType GetWeb_EventTypeByID(int web_EventTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetWeb_EventTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Value = web_EventTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetWeb_EventTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertWeb_EventType(Web_EventType web_EventType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertWeb_EventType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Web_EventTypeName", SqlDbType.NVarChar).Value = web_EventType.Web_EventTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Web_EventTypeID"].Value;
        }
    }

    public bool UpdateWeb_EventType(Web_EventType web_EventType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateWeb_EventType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Value = web_EventType.Web_EventTypeID;
            cmd.Parameters.Add("@Web_EventTypeName", SqlDbType.NVarChar).Value = web_EventType.Web_EventTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

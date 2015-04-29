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

public class SqlComn_ResultTypeProvider:DataAccessObject
{
	public SqlComn_ResultTypeProvider()
    {
    }


    public bool DeleteComn_ResultType(int comn_ResultTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_ResultType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = comn_ResultTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_ResultType> GetAllComn_ResultTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_ResultTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_ResultTypesFromReader(reader);
        }
    }
    public List<Comn_ResultType> GetComn_ResultTypesFromReader(IDataReader reader)
    {
        List<Comn_ResultType> comn_ResultTypes = new List<Comn_ResultType>();

        while (reader.Read())
        {
            comn_ResultTypes.Add(GetComn_ResultTypeFromReader(reader));
        }
        return comn_ResultTypes;
    }

    public Comn_ResultType GetComn_ResultTypeFromReader(IDataReader reader)
    {
        try
        {
            Comn_ResultType comn_ResultType = new Comn_ResultType
                (
                    (int)reader["Comn_ResultTypeID"],
                    reader["Comn_ResultTypeName"].ToString()
                );
             return comn_ResultType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_ResultType GetComn_ResultTypeByID(int comn_ResultTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_ResultTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = comn_ResultTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_ResultTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_ResultType(Comn_ResultType comn_ResultType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_ResultType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_ResultTypeName", SqlDbType.NVarChar).Value = comn_ResultType.Comn_ResultTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_ResultTypeID"].Value;
        }
    }

    public bool UpdateComn_ResultType(Comn_ResultType comn_ResultType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_ResultType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = comn_ResultType.Comn_ResultTypeID;
            cmd.Parameters.Add("@Comn_ResultTypeName", SqlDbType.NVarChar).Value = comn_ResultType.Comn_ResultTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

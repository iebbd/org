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

public class SqlComn_OfficeTypeProvider:DataAccessObject
{
	public SqlComn_OfficeTypeProvider()
    {
    }


    public bool DeleteComn_OfficeType(int comn_OfficeTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_OfficeType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeTypeID", SqlDbType.Int).Value = comn_OfficeTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_OfficeType> GetAllComn_OfficeTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_OfficeTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_OfficeTypesFromReader(reader);
        }
    }
    public List<Comn_OfficeType> GetComn_OfficeTypesFromReader(IDataReader reader)
    {
        List<Comn_OfficeType> comn_OfficeTypes = new List<Comn_OfficeType>();

        while (reader.Read())
        {
            comn_OfficeTypes.Add(GetComn_OfficeTypeFromReader(reader));
        }
        return comn_OfficeTypes;
    }

    public Comn_OfficeType GetComn_OfficeTypeFromReader(IDataReader reader)
    {
        try
        {
            Comn_OfficeType comn_OfficeType = new Comn_OfficeType
                (
                    (int)reader["Comn_OfficeTypeID"],
                    reader["Comn_OfficeTypeName"].ToString()
                );
             return comn_OfficeType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_OfficeType GetComn_OfficeTypeByID(int comn_OfficeTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_OfficeTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_OfficeTypeID", SqlDbType.Int).Value = comn_OfficeTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_OfficeTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_OfficeType(Comn_OfficeType comn_OfficeType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_OfficeType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_OfficeTypeName", SqlDbType.NVarChar).Value = comn_OfficeType.Comn_OfficeTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_OfficeTypeID"].Value;
        }
    }

    public bool UpdateComn_OfficeType(Comn_OfficeType comn_OfficeType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_OfficeType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeTypeID", SqlDbType.Int).Value = comn_OfficeType.Comn_OfficeTypeID;
            cmd.Parameters.Add("@Comn_OfficeTypeName", SqlDbType.NVarChar).Value = comn_OfficeType.Comn_OfficeTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

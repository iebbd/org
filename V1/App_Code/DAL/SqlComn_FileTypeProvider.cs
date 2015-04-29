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

public class SqlComn_FileTypeProvider:DataAccessObject
{
	public SqlComn_FileTypeProvider()
    {
    }


    public bool DeleteComn_FileType(int comn_FileTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_FileType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Value = comn_FileTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_FileType> GetAllComn_FileTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_FileTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_FileTypesFromReader(reader);
        }
    }
    public List<Comn_FileType> GetComn_FileTypesFromReader(IDataReader reader)
    {
        List<Comn_FileType> comn_FileTypes = new List<Comn_FileType>();

        while (reader.Read())
        {
            comn_FileTypes.Add(GetComn_FileTypeFromReader(reader));
        }
        return comn_FileTypes;
    }

    public Comn_FileType GetComn_FileTypeFromReader(IDataReader reader)
    {
        try
        {
            Comn_FileType comn_FileType = new Comn_FileType
                (
                    (int)reader["Comn_FileTypeID"],
                    reader["Comn_FileTypeName"].ToString()
                );
             return comn_FileType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_FileType GetComn_FileTypeByID(int comn_FileTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_FileTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Value = comn_FileTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_FileTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_FileType(Comn_FileType comn_FileType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_FileType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_FileTypeName", SqlDbType.NVarChar).Value = comn_FileType.Comn_FileTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_FileTypeID"].Value;
        }
    }

    public bool UpdateComn_FileType(Comn_FileType comn_FileType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_FileType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Value = comn_FileType.Comn_FileTypeID;
            cmd.Parameters.Add("@Comn_FileTypeName", SqlDbType.NVarChar).Value = comn_FileType.Comn_FileTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

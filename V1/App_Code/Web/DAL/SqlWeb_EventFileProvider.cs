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

public class SqlWeb_EventFileProvider:DataAccessObject
{
	public SqlWeb_EventFileProvider()
    {
    }


    public bool DeleteWeb_EventFile(int web_EventFileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteWeb_EventFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventFileID", SqlDbType.Int).Value = web_EventFileID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Web_EventFile> GetAllWeb_EventFiles()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllWeb_EventFiles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetWeb_EventFilesFromReader(reader);
        }
    }
    public List<Web_EventFile> GetWeb_EventFilesFromReader(IDataReader reader)
    {
        List<Web_EventFile> web_EventFiles = new List<Web_EventFile>();

        while (reader.Read())
        {
            web_EventFiles.Add(GetWeb_EventFileFromReader(reader));
        }
        return web_EventFiles;
    }

    public Web_EventFile GetWeb_EventFileFromReader(IDataReader reader)
    {
        try
        {
            Web_EventFile web_EventFile = new Web_EventFile
                (
                    (int)reader["Web_EventFileID"],
                    (int)reader["Web_EventID"],
                    reader["EventFileName"].ToString(),
                    (bool)reader["Visibility"],
                    (decimal)reader["Ordering"],
                    (int)reader["RowStatusID"],
                    reader["AlterTag"].ToString(),
                    reader["Details"].ToString(),
                    reader["ExtraField1"].ToString(),
                    reader["ExtraField2"].ToString(),
                    reader["ExtraField3"].ToString()
                );
             return web_EventFile;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Web_EventFile GetWeb_EventFileByID(int web_EventFileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetWeb_EventFileByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Web_EventFileID", SqlDbType.Int).Value = web_EventFileID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetWeb_EventFileFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertWeb_EventFile(Web_EventFile web_EventFile)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertWeb_EventFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventFileID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Web_EventID", SqlDbType.Int).Value = web_EventFile.Web_EventID;
            cmd.Parameters.Add("@EventFileName", SqlDbType.NVarChar).Value = web_EventFile.EventFileName;
            cmd.Parameters.Add("@Visibility", SqlDbType.Bit).Value = web_EventFile.Visibility;
            cmd.Parameters.Add("@Ordering", SqlDbType.Decimal).Value = web_EventFile.Ordering;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = web_EventFile.RowStatusID;
            cmd.Parameters.Add("@AlterTag", SqlDbType.NVarChar).Value = web_EventFile.AlterTag;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = web_EventFile.Details;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = web_EventFile.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = web_EventFile.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = web_EventFile.ExtraField3;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Web_EventFileID"].Value;
        }
    }

    public bool UpdateWeb_EventFile(Web_EventFile web_EventFile)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateWeb_EventFile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventFileID", SqlDbType.Int).Value = web_EventFile.Web_EventFileID;
            cmd.Parameters.Add("@Web_EventID", SqlDbType.Int).Value = web_EventFile.Web_EventID;
            cmd.Parameters.Add("@EventFileName", SqlDbType.NVarChar).Value = web_EventFile.EventFileName;
            cmd.Parameters.Add("@Visibility", SqlDbType.Bit).Value = web_EventFile.Visibility;
            cmd.Parameters.Add("@Ordering", SqlDbType.Decimal).Value = web_EventFile.Ordering;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = web_EventFile.RowStatusID;
            cmd.Parameters.Add("@AlterTag", SqlDbType.NVarChar).Value = web_EventFile.AlterTag;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = web_EventFile.Details;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = web_EventFile.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = web_EventFile.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = web_EventFile.ExtraField3;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

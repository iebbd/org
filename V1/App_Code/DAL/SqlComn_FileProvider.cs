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

public class SqlComn_FileProvider:DataAccessObject
{
	public SqlComn_FileProvider()
    {
    }


    public bool DeleteComn_File(int comn_FileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_File", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileID", SqlDbType.Int).Value = comn_FileID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_File> GetAllComn_Files()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Files", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_FilesFromReader(reader);
        }
    }
    public List<Comn_File> GetComn_FilesFromReader(IDataReader reader)
    {
        List<Comn_File> comn_Files = new List<Comn_File>();

        while (reader.Read())
        {
            comn_Files.Add(GetComn_FileFromReader(reader));
        }
        return comn_Files;
    }

    public Comn_File GetComn_FileFromReader(IDataReader reader)
    {
        try
        {
            Comn_File comn_File = new Comn_File
                (
                    (int)reader["Comn_FileID"],
                    (int)reader["Comn_FileTypeID"],
                    reader["FileName"].ToString(),
                    (int)reader["AddedBy"],
                    (DateTime)reader["AddedDate"],
                    (int)reader["UpdatedBy"],
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["Comn_RowStatusID"]
                );
             return comn_File;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_File GetComn_FileByID(int comn_FileID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_FileByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_FileID", SqlDbType.Int).Value = comn_FileID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_FileFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_File(Comn_File comn_File)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_File", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Value = comn_File.Comn_FileTypeID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = comn_File.FileName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = comn_File.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = comn_File.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = comn_File.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = comn_File.UpdatedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = comn_File.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_FileID"].Value;
        }
    }

    public bool UpdateComn_File(Comn_File comn_File)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_File", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_FileID", SqlDbType.Int).Value = comn_File.Comn_FileID;
            cmd.Parameters.Add("@Comn_FileTypeID", SqlDbType.Int).Value = comn_File.Comn_FileTypeID;
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = comn_File.FileName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = comn_File.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = comn_File.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = comn_File.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = comn_File.UpdatedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = comn_File.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

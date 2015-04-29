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

public class SqlComn_GegreeProvider:DataAccessObject
{
	public SqlComn_GegreeProvider()
    {
    }


    public bool DeleteComn_Gegree(int comn_GegreeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Gegree", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = comn_GegreeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Gegree> GetAllComn_Gegrees()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Gegrees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_GegreesFromReader(reader);
        }
    }
    public List<Comn_Gegree> GetComn_GegreesFromReader(IDataReader reader)
    {
        List<Comn_Gegree> comn_Gegrees = new List<Comn_Gegree>();

        while (reader.Read())
        {
            comn_Gegrees.Add(GetComn_GegreeFromReader(reader));
        }
        return comn_Gegrees;
    }

    public Comn_Gegree GetComn_GegreeFromReader(IDataReader reader)
    {
        try
        {
            Comn_Gegree comn_Gegree = new Comn_Gegree
                (
                    (int)reader["Comn_GegreeID"],
                    reader["Comn_GegreeName"].ToString()
                );
             return comn_Gegree;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Gegree GetComn_GegreeByID(int comn_GegreeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_GegreeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = comn_GegreeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_GegreeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Gegree(Comn_Gegree comn_Gegree)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Gegree", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_GegreeName", SqlDbType.NVarChar).Value = comn_Gegree.Comn_GegreeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_GegreeID"].Value;
        }
    }

    public bool UpdateComn_Gegree(Comn_Gegree comn_Gegree)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Gegree", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = comn_Gegree.Comn_GegreeID;
            cmd.Parameters.Add("@Comn_GegreeName", SqlDbType.NVarChar).Value = comn_Gegree.Comn_GegreeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

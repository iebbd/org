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

public class SqlComn_GenderProvider:DataAccessObject
{
	public SqlComn_GenderProvider()
    {
    }


    public bool DeleteComn_Gender(int comn_GenderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = comn_GenderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Gender> GetAllComn_Genders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Genders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_GendersFromReader(reader);
        }
    }
    public List<Comn_Gender> GetComn_GendersFromReader(IDataReader reader)
    {
        List<Comn_Gender> comn_Genders = new List<Comn_Gender>();

        while (reader.Read())
        {
            comn_Genders.Add(GetComn_GenderFromReader(reader));
        }
        return comn_Genders;
    }

    public Comn_Gender GetComn_GenderFromReader(IDataReader reader)
    {
        try
        {
            Comn_Gender comn_Gender = new Comn_Gender
                (
                    (int)reader["Comn_GenderID"],
                    reader["Comn_GenderName"].ToString()
                );
             return comn_Gender;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Gender GetComn_GenderByID(int comn_GenderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_GenderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = comn_GenderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_GenderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Gender(Comn_Gender comn_Gender)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_GenderName", SqlDbType.NVarChar).Value = comn_Gender.Comn_GenderName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_GenderID"].Value;
        }
    }

    public bool UpdateComn_Gender(Comn_Gender comn_Gender)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = comn_Gender.Comn_GenderID;
            cmd.Parameters.Add("@Comn_GenderName", SqlDbType.NVarChar).Value = comn_Gender.Comn_GenderName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

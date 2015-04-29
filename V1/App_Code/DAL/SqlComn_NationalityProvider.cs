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

public class SqlComn_NationalityProvider:DataAccessObject
{
	public SqlComn_NationalityProvider()
    {
    }


    public bool DeleteComn_Nationality(int comn_NationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = comn_NationalityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Nationality> GetAllComn_Nationalities()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Nationalities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_NationalitiesFromReader(reader);
        }
    }
    public List<Comn_Nationality> GetComn_NationalitiesFromReader(IDataReader reader)
    {
        List<Comn_Nationality> comn_Nationalities = new List<Comn_Nationality>();

        while (reader.Read())
        {
            comn_Nationalities.Add(GetComn_NationalityFromReader(reader));
        }
        return comn_Nationalities;
    }

    public Comn_Nationality GetComn_NationalityFromReader(IDataReader reader)
    {
        try
        {
            Comn_Nationality comn_Nationality = new Comn_Nationality
                (
                    (int)reader["Comn_NationalityID"],
                    reader["Comn_NationalityName"].ToString()
                );
             return comn_Nationality;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Nationality GetComn_NationalityByID(int comn_NationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_NationalityByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = comn_NationalityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_NationalityFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Nationality(Comn_Nationality comn_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_NationalityName", SqlDbType.NVarChar).Value = comn_Nationality.Comn_NationalityName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_NationalityID"].Value;
        }
    }

    public bool UpdateComn_Nationality(Comn_Nationality comn_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = comn_Nationality.Comn_NationalityID;
            cmd.Parameters.Add("@Comn_NationalityName", SqlDbType.NVarChar).Value = comn_Nationality.Comn_NationalityName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

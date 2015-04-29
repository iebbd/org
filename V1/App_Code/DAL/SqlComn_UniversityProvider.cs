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

public class SqlComn_UniversityProvider:DataAccessObject
{
	public SqlComn_UniversityProvider()
    {
    }


    public bool DeleteComn_University(int comn_UniversityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_University", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = comn_UniversityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_University> GetAllComn_Universities()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Universities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_UniversitiesFromReader(reader);
        }
    }
    public List<Comn_University> GetComn_UniversitiesFromReader(IDataReader reader)
    {
        List<Comn_University> comn_Universities = new List<Comn_University>();

        while (reader.Read())
        {
            comn_Universities.Add(GetComn_UniversityFromReader(reader));
        }
        return comn_Universities;
    }

    public Comn_University GetComn_UniversityFromReader(IDataReader reader)
    {
        try
        {
            Comn_University comn_University = new Comn_University
                (
                    (int)reader["Comn_UniversityID"],
                    reader["Comn_UniversityName"].ToString(),
                    reader["Website"].ToString(),
                    reader["Phone"].ToString(),
                    reader["Fax"].ToString(),
                    (int)reader["Type"],
                    reader["Details"].ToString(),
                    reader["OldName"].ToString()
                );
             return comn_University;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_University GetComn_UniversityByID(int comn_UniversityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_UniversityByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = comn_UniversityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_UniversityFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_University(Comn_University comn_University)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_University", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_UniversityName", SqlDbType.NVarChar).Value = comn_University.Comn_UniversityName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_University.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_University.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_University.Fax;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = comn_University.Type;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_University.Details;
            cmd.Parameters.Add("@OldName", SqlDbType.NText).Value = comn_University.OldName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_UniversityID"].Value;
        }
    }

    public bool UpdateComn_University(Comn_University comn_University)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_University", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = comn_University.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_UniversityName", SqlDbType.NVarChar).Value = comn_University.Comn_UniversityName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_University.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_University.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_University.Fax;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = comn_University.Type;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_University.Details;
            cmd.Parameters.Add("@OldName", SqlDbType.NText).Value = comn_University.OldName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

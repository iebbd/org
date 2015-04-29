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

public class SqlComn_OfficeProvider:DataAccessObject
{
	public SqlComn_OfficeProvider()
    {
    }


    public bool DeleteComn_Office(int comn_OfficeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Office", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = comn_OfficeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Office> GetAllComn_Offices()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Offices", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_OfficesFromReader(reader);
        }
    }
    public List<Comn_Office> GetComn_OfficesFromReader(IDataReader reader)
    {
        List<Comn_Office> comn_Offices = new List<Comn_Office>();

        while (reader.Read())
        {
            comn_Offices.Add(GetComn_OfficeFromReader(reader));
        }
        return comn_Offices;
    }

    public Comn_Office GetComn_OfficeFromReader(IDataReader reader)
    {
        try
        {
            Comn_Office comn_Office = new Comn_Office
                (
                    (int)reader["Comn_OfficeID"],
                    reader["Comn_OfficeName"].ToString(),
                    (int)reader["Comm_OfficeTypeID"],
                    (int)reader["UpperLabelOfficeID"],
                    reader["Website"].ToString(),
                    reader["Phone"].ToString(),
                    reader["Fax"].ToString(),
                    reader["Details"].ToString()
                );
             return comn_Office;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Office GetComn_OfficeByID(int comn_OfficeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_OfficeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = comn_OfficeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_OfficeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Office(Comn_Office comn_Office)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Office", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_OfficeName", SqlDbType.NVarChar).Value = comn_Office.Comn_OfficeName;
            cmd.Parameters.Add("@Comm_OfficeTypeID", SqlDbType.Int).Value = comn_Office.Comm_OfficeTypeID;
            cmd.Parameters.Add("@UpperLabelOfficeID", SqlDbType.Int).Value = comn_Office.UpperLabelOfficeID;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_Office.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_Office.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_Office.Fax;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_Office.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_OfficeID"].Value;
        }
    }

    public bool UpdateComn_Office(Comn_Office comn_Office)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Office", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = comn_Office.Comn_OfficeID;
            cmd.Parameters.Add("@Comn_OfficeName", SqlDbType.NVarChar).Value = comn_Office.Comn_OfficeName;
            cmd.Parameters.Add("@Comm_OfficeTypeID", SqlDbType.Int).Value = comn_Office.Comm_OfficeTypeID;
            cmd.Parameters.Add("@UpperLabelOfficeID", SqlDbType.Int).Value = comn_Office.UpperLabelOfficeID;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_Office.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_Office.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_Office.Fax;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_Office.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

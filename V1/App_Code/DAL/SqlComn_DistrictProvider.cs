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

public class SqlComn_DistrictProvider:DataAccessObject
{
	public SqlComn_DistrictProvider()
    {
    }


    public bool DeleteComn_District(int comn_DistrictID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DistrictID", SqlDbType.Int).Value = comn_DistrictID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_District> GetAllComn_Districts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Districts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_DistrictsFromReader(reader);
        }
    }
    public List<Comn_District> GetComn_DistrictsFromReader(IDataReader reader)
    {
        List<Comn_District> comn_Districts = new List<Comn_District>();

        while (reader.Read())
        {
            comn_Districts.Add(GetComn_DistrictFromReader(reader));
        }
        return comn_Districts;
    }

    public Comn_District GetComn_DistrictFromReader(IDataReader reader)
    {
        try
        {
            Comn_District comn_District = new Comn_District
                (
                    (int)reader["Comn_DistrictID"],
                    (int)reader["DistrictID"],
                    reader["DistrictName"].ToString(),
                    reader["BanglaName"].ToString(),
                    reader["Devision"].ToString()
                );
             return comn_District;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_District GetComn_DistrictByID(int comn_DistrictID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_DistrictByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_DistrictID", SqlDbType.Int).Value = comn_DistrictID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_DistrictFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_District(Comn_District comn_District)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DistrictID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = comn_District.DistrictID;
            cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = comn_District.DistrictName;
            cmd.Parameters.Add("@BanglaName", SqlDbType.NVarChar).Value = comn_District.BanglaName;
            cmd.Parameters.Add("@Devision", SqlDbType.NVarChar).Value = comn_District.Devision;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_DistrictID"].Value;
        }
    }

    public bool UpdateComn_District(Comn_District comn_District)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DistrictID", SqlDbType.Int).Value = comn_District.Comn_DistrictID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = comn_District.DistrictID;
            cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = comn_District.DistrictName;
            cmd.Parameters.Add("@BanglaName", SqlDbType.NVarChar).Value = comn_District.BanglaName;
            cmd.Parameters.Add("@Devision", SqlDbType.NVarChar).Value = comn_District.Devision;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

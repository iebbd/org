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

public class SqlMem_DivisionProvider:DataAccessObject
{
	public SqlMem_DivisionProvider()
    {
    }


    public bool DeleteMem_Division(int mem_DivisionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Value = mem_DivisionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_Division> GetAllMem_Divisions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_Divisions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_DivisionsFromReader(reader);
        }
    }
    public List<Mem_Division> GetMem_DivisionsFromReader(IDataReader reader)
    {
        List<Mem_Division> mem_Divisions = new List<Mem_Division>();

        while (reader.Read())
        {
            mem_Divisions.Add(GetMem_DivisionFromReader(reader));
        }
        return mem_Divisions;
    }

    public Mem_Division GetMem_DivisionFromReader(IDataReader reader)
    {
        try
        {
            Mem_Division mem_Division = new Mem_Division
                (
                    (int)reader["Mem_DivisionID"],
                    reader["Mem_DivisionName"].ToString(),
                    reader["Website"].ToString(),
                    reader["FullName"].ToString(),
                    reader["ContactInfo"].ToString(),
                    reader["Details"].ToString()
                );
             return mem_Division;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_Division GetMem_DivisionByID(int mem_DivisionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_DivisionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Value = mem_DivisionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_DivisionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_Division(Mem_Division mem_Division)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_DivisionName", SqlDbType.NVarChar).Value = mem_Division.Mem_DivisionName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = mem_Division.Website;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = mem_Division.FullName;
            cmd.Parameters.Add("@ContactInfo", SqlDbType.NText).Value = mem_Division.ContactInfo;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_Division.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_DivisionID"].Value;
        }
    }

    public bool UpdateMem_Division(Mem_Division mem_Division)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Value = mem_Division.Mem_DivisionID;
            cmd.Parameters.Add("@Mem_DivisionName", SqlDbType.NVarChar).Value = mem_Division.Mem_DivisionName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = mem_Division.Website;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = mem_Division.FullName;
            cmd.Parameters.Add("@ContactInfo", SqlDbType.NText).Value = mem_Division.ContactInfo;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_Division.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

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

public class SqlMem_SubDivisionProvider:DataAccessObject
{
	public SqlMem_SubDivisionProvider()
    {
    }


    public bool DeleteMem_SubDivision(int mem_SubDivisionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_SubDivision", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_SubDivisionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_SubDivision> GetAllMem_SubDivisions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_SubDivisions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_SubDivisionsFromReader(reader);
        }
    }
    public List<Mem_SubDivision> GetMem_SubDivisionsFromReader(IDataReader reader)
    {
        List<Mem_SubDivision> mem_SubDivisions = new List<Mem_SubDivision>();

        while (reader.Read())
        {
            mem_SubDivisions.Add(GetMem_SubDivisionFromReader(reader));
        }
        return mem_SubDivisions;
    }

    public Mem_SubDivision GetMem_SubDivisionFromReader(IDataReader reader)
    {
        try
        {
            Mem_SubDivision mem_SubDivision = new Mem_SubDivision
                (
                    (int)reader["Mem_SubDivisionID"],
                    reader["Mem_SubDivisionName"].ToString(),
                    (int)reader["Mem_DivisionID"],
                    reader["Website"].ToString(),
                    reader["FullName"].ToString(),
                    reader["ContactInfo"].ToString(),
                    reader["Details"].ToString()
                );
             return mem_SubDivision;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_SubDivision GetMem_SubDivisionByID(int mem_SubDivisionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_SubDivisionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_SubDivisionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_SubDivisionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_SubDivision(Mem_SubDivision mem_SubDivision)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_SubDivision", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_SubDivisionName", SqlDbType.NVarChar).Value = mem_SubDivision.Mem_SubDivisionName;
            cmd.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Value = mem_SubDivision.Mem_DivisionID;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = mem_SubDivision.Website;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = mem_SubDivision.FullName;
            cmd.Parameters.Add("@ContactInfo", SqlDbType.NText).Value = mem_SubDivision.ContactInfo;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_SubDivision.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_SubDivisionID"].Value;
        }
    }

    public bool UpdateMem_SubDivision(Mem_SubDivision mem_SubDivision)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_SubDivision", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_SubDivision.Mem_SubDivisionID;
            cmd.Parameters.Add("@Mem_SubDivisionName", SqlDbType.NVarChar).Value = mem_SubDivision.Mem_SubDivisionName;
            cmd.Parameters.Add("@Mem_DivisionID", SqlDbType.Int).Value = mem_SubDivision.Mem_DivisionID;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = mem_SubDivision.Website;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = mem_SubDivision.FullName;
            cmd.Parameters.Add("@ContactInfo", SqlDbType.NText).Value = mem_SubDivision.ContactInfo;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_SubDivision.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

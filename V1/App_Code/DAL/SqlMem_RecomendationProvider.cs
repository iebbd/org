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

public class SqlMem_RecomendationProvider:DataAccessObject
{
	public SqlMem_RecomendationProvider()
    {
    }


    public bool DeleteMem_Recomendation(int mem_RecomendationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_Recomendation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RecomendationID", SqlDbType.Int).Value = mem_RecomendationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_Recomendation> GetAllMem_Recomendations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_Recomendations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_RecomendationsFromReader(reader);
        }
    }
    public List<Mem_Recomendation> GetMem_RecomendationsFromReader(IDataReader reader)
    {
        List<Mem_Recomendation> mem_Recomendations = new List<Mem_Recomendation>();

        while (reader.Read())
        {
            mem_Recomendations.Add(GetMem_RecomendationFromReader(reader));
        }
        return mem_Recomendations;
    }

    public Mem_Recomendation GetMem_RecomendationFromReader(IDataReader reader)
    {
        try
        {
            Mem_Recomendation mem_Recomendation = new Mem_Recomendation
                (
                    (int)reader["Mem_RecomendationID"],
                    (DateTime)reader["RecomendationDate"],
                    (int)reader["Mem_MemberID"],
                    (int)reader["Comn_RowSatusID"]
                );
             return mem_Recomendation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_Recomendation GetMem_RecomendationByID(int mem_RecomendationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_RecomendationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_RecomendationID", SqlDbType.Int).Value = mem_RecomendationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_RecomendationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_Recomendation(Mem_Recomendation mem_Recomendation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Recomendation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RecomendationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RecomendationDate", SqlDbType.DateTime).Value = mem_Recomendation.RecomendationDate;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Recomendation.Mem_MemberID;
            cmd.Parameters.Add("@Comn_RowSatusID", SqlDbType.Int).Value = mem_Recomendation.Comn_RowSatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_RecomendationID"].Value;
        }
    }

    public bool UpdateMem_Recomendation(Mem_Recomendation mem_Recomendation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Recomendation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RecomendationID", SqlDbType.Int).Value = mem_Recomendation.Mem_RecomendationID;
            cmd.Parameters.Add("@RecomendationDate", SqlDbType.DateTime).Value = mem_Recomendation.RecomendationDate;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Recomendation.Mem_MemberID;
            cmd.Parameters.Add("@Comn_RowSatusID", SqlDbType.Int).Value = mem_Recomendation.Comn_RowSatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

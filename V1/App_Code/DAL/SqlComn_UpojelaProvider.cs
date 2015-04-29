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

public class SqlComn_UpojelaProvider:DataAccessObject
{
	public SqlComn_UpojelaProvider()
    {
    }


    public bool DeleteComn_Upojela(int comn_UpojelaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Upojela", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UpojelaID", SqlDbType.Int).Value = comn_UpojelaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Upojela> GetAllComn_Upojelas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Upojelas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_UpojelasFromReader(reader);
        }
    }
    public List<Comn_Upojela> GetComn_UpojelasFromReader(IDataReader reader)
    {
        List<Comn_Upojela> comn_Upojelas = new List<Comn_Upojela>();

        while (reader.Read())
        {
            comn_Upojelas.Add(GetComn_UpojelaFromReader(reader));
        }
        return comn_Upojelas;
    }

    public Comn_Upojela GetComn_UpojelaFromReader(IDataReader reader)
    {
        try
        {
            Comn_Upojela comn_Upojela = new Comn_Upojela
                (
                    (int)reader["Comn_UpojelaID"],
                    (int)reader["UpojelaID"],
                    reader["UpojelaName"].ToString(),
                    reader["DistrictName"].ToString(),
                    (int)reader["DistrictID"]
                );
             return comn_Upojela;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Upojela GetComn_UpojelaByID(int comn_UpojelaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_UpojelaByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_UpojelaID", SqlDbType.Int).Value = comn_UpojelaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_UpojelaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Upojela(Comn_Upojela comn_Upojela)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Upojela", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UpojelaID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UpojelaID", SqlDbType.Int).Value = comn_Upojela.UpojelaID;
            cmd.Parameters.Add("@UpojelaName", SqlDbType.NVarChar).Value = comn_Upojela.UpojelaName;
            cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = comn_Upojela.DistrictName;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = comn_Upojela.DistrictID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_UpojelaID"].Value;
        }
    }

    public bool UpdateComn_Upojela(Comn_Upojela comn_Upojela)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Upojela", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_UpojelaID", SqlDbType.Int).Value = comn_Upojela.Comn_UpojelaID;
            cmd.Parameters.Add("@UpojelaID", SqlDbType.Int).Value = comn_Upojela.UpojelaID;
            cmd.Parameters.Add("@UpojelaName", SqlDbType.NVarChar).Value = comn_Upojela.UpojelaName;
            cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = comn_Upojela.DistrictName;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = comn_Upojela.DistrictID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

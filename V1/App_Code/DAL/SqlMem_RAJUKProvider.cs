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

public class SqlMem_RAJUKProvider:DataAccessObject
{
	public SqlMem_RAJUKProvider()
    {
    }


    public bool DeleteMem_RAJUK(int mem_RAJUKID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_RAJUK", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RAJUKID", SqlDbType.Int).Value = mem_RAJUKID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_RAJUK> GetAllMem_RAJUKs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_RAJUKs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_RAJUKsFromReader(reader);
        }
    }
    public List<Mem_RAJUK> GetMem_RAJUKsFromReader(IDataReader reader)
    {
        List<Mem_RAJUK> mem_RAJUKs = new List<Mem_RAJUK>();

        while (reader.Read())
        {
            mem_RAJUKs.Add(GetMem_RAJUKFromReader(reader));
        }
        return mem_RAJUKs;
    }

    public Mem_RAJUK GetMem_RAJUKFromReader(IDataReader reader)
    {
        try
        {
            Mem_RAJUK mem_RAJUK = new Mem_RAJUK
                (
                    (int)reader["Mem_RAJUKID"],
                    (int)reader["Mem_MemberID"],
                    reader["MembershipNo"].ToString(),
                    reader["RAJUKRegistrationNo"].ToString(),
                    reader["Batch"].ToString(),
                    reader["ExamDate"].ToString(),
                    reader["Telephone"].ToString(),
                    reader["Email"].ToString(),
                    (char)reader["TypeOfMemeber"],
                    (int)reader["MembershipNoValue"],
                    reader["MembershipNoValueChar"].ToString()
                );
             return mem_RAJUK;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_RAJUK GetMem_RAJUKByID(int mem_RAJUKID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_RAJUKByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_RAJUKID", SqlDbType.Int).Value = mem_RAJUKID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_RAJUKFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_RAJUK(Mem_RAJUK mem_RAJUK)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_RAJUK", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RAJUKID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_RAJUK.Mem_MemberID;
            cmd.Parameters.Add("@MembershipNo", SqlDbType.NVarChar).Value = mem_RAJUK.MembershipNo;
            cmd.Parameters.Add("@RAJUKRegistrationNo", SqlDbType.NVarChar).Value = mem_RAJUK.RAJUKRegistrationNo;
            cmd.Parameters.Add("@Batch", SqlDbType.NChar).Value = mem_RAJUK.Batch;
            cmd.Parameters.Add("@ExamDate", SqlDbType.NVarChar).Value = mem_RAJUK.ExamDate;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = mem_RAJUK.Telephone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_RAJUK.Email;
            cmd.Parameters.Add("@TypeOfMemeber", SqlDbType.Char).Value = mem_RAJUK.TypeOfMemeber;
            cmd.Parameters.Add("@MembershipNoValue", SqlDbType.Int).Value = mem_RAJUK.MembershipNoValue;
            cmd.Parameters.Add("@MembershipNoValueChar", SqlDbType.NChar).Value = mem_RAJUK.MembershipNoValueChar;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_RAJUKID"].Value;
        }
    }

    public bool UpdateMem_RAJUK(Mem_RAJUK mem_RAJUK)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_RAJUK", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_RAJUKID", SqlDbType.Int).Value = mem_RAJUK.Mem_RAJUKID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_RAJUK.Mem_MemberID;
            cmd.Parameters.Add("@MembershipNo", SqlDbType.NVarChar).Value = mem_RAJUK.MembershipNo;
            cmd.Parameters.Add("@RAJUKRegistrationNo", SqlDbType.NVarChar).Value = mem_RAJUK.RAJUKRegistrationNo;
            cmd.Parameters.Add("@Batch", SqlDbType.NChar).Value = mem_RAJUK.Batch;
            cmd.Parameters.Add("@ExamDate", SqlDbType.NVarChar).Value = mem_RAJUK.ExamDate;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = mem_RAJUK.Telephone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_RAJUK.Email;
            cmd.Parameters.Add("@TypeOfMemeber", SqlDbType.Char).Value = mem_RAJUK.TypeOfMemeber;
            cmd.Parameters.Add("@MembershipNoValue", SqlDbType.Int).Value = mem_RAJUK.MembershipNoValue;
            cmd.Parameters.Add("@MembershipNoValueChar", SqlDbType.NChar).Value = mem_RAJUK.MembershipNoValueChar;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

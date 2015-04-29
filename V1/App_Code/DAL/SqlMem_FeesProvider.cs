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

public class SqlMem_FeesProvider:DataAccessObject
{
	public SqlMem_FeesProvider()
    {
    }


    public bool DeleteMem_Fees(int mem_FeesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_FeesID", SqlDbType.Int).Value = mem_FeesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_Fees> GetAllMem_Feess()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_Feess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_FeessFromReader(reader);
        }
    }
    public List<Mem_Fees> GetMem_FeessFromReader(IDataReader reader)
    {
        List<Mem_Fees> mem_Feess = new List<Mem_Fees>();

        while (reader.Read())
        {
            mem_Feess.Add(GetMem_FeesFromReader(reader));
        }
        return mem_Feess;
    }

    public Mem_Fees GetMem_FeesFromReader(IDataReader reader)
    {
        try
        {
            Mem_Fees mem_Fees = new Mem_Fees
                (
                    (int)reader["Mem_FeesID"],
                    (int)reader["Mem_MemberID"],
                    (decimal)reader["Amount"],
                    reader["DatePaid"].ToString(),
                    reader["PaidFor"].ToString(),
                    reader["ExtraField"].ToString(),
                    (DateTime)reader["AddedDate"],
                    (int)reader["AddedBy"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["Comn_RowStatusID"],
                    reader["RefferenceNo"].ToString(),
                    (int)reader["Comn_PaymentByID"]
                );
             return mem_Fees;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_Fees GetMem_FeesByID(int mem_FeesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_FeesByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_FeesID", SqlDbType.Int).Value = mem_FeesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_FeesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_Fees(Mem_Fees mem_Fees)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_FeesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Fees.Mem_MemberID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = mem_Fees.Amount;
            cmd.Parameters.Add("@DatePaid", SqlDbType.NVarChar).Value = mem_Fees.DatePaid;
            cmd.Parameters.Add("@PaidFor", SqlDbType.NVarChar).Value = mem_Fees.PaidFor;
            cmd.Parameters.Add("@ExtraField", SqlDbType.NVarChar).Value = mem_Fees.ExtraField;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Fees.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Fees.AddedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Fees.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Fees.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Fees.Comn_RowStatusID;
            cmd.Parameters.Add("@RefferenceNo", SqlDbType.NVarChar).Value = mem_Fees.RefferenceNo;
            cmd.Parameters.Add("@Comn_PaymentByID", SqlDbType.Int).Value = mem_Fees.Comn_PaymentByID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_FeesID"].Value;
        }
    }

    public bool UpdateMem_Fees(Mem_Fees mem_Fees)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_FeesID", SqlDbType.Int).Value = mem_Fees.Mem_FeesID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Fees.Mem_MemberID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = mem_Fees.Amount;
            cmd.Parameters.Add("@DatePaid", SqlDbType.NVarChar).Value = mem_Fees.DatePaid;
            cmd.Parameters.Add("@PaidFor", SqlDbType.NVarChar).Value = mem_Fees.PaidFor;
            cmd.Parameters.Add("@ExtraField", SqlDbType.NVarChar).Value = mem_Fees.ExtraField;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Fees.AddedDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Fees.AddedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Fees.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Fees.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Fees.Comn_RowStatusID;
            cmd.Parameters.Add("@RefferenceNo", SqlDbType.NVarChar).Value = mem_Fees.RefferenceNo;
            cmd.Parameters.Add("@Comn_PaymentByID", SqlDbType.Int).Value = mem_Fees.Comn_PaymentByID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

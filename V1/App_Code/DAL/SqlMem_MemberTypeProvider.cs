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

public class SqlMem_MemberTypeProvider:DataAccessObject
{
	public SqlMem_MemberTypeProvider()
    {
    }


    public bool DeleteMem_MemberType(int mem_MemberTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_MemberType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_MemberTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_MemberType> GetAllMem_MemberTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_MemberTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_MemberTypesFromReader(reader);
        }
    }
    public List<Mem_MemberType> GetMem_MemberTypesFromReader(IDataReader reader)
    {
        List<Mem_MemberType> mem_MemberTypes = new List<Mem_MemberType>();

        while (reader.Read())
        {
            mem_MemberTypes.Add(GetMem_MemberTypeFromReader(reader));
        }
        return mem_MemberTypes;
    }

    public Mem_MemberType GetMem_MemberTypeFromReader(IDataReader reader)
    {
        try
        {
            Mem_MemberType mem_MemberType = new Mem_MemberType
                (
                    (int)reader["Mem_MemberTypeID"],
                    reader["Mem_MemberTypeName"].ToString(),
                    (int)reader["Mem_MemberCategoryID"],
                    reader["Details"].ToString(),
                    (decimal)reader["EntranceFee"],
                    (decimal)reader["AnnaralSubscriptionFee"],
                    (decimal)reader["DiplomaFee"],
                    (int)reader["Age"],
                    reader["Experience"].ToString()
                );
             return mem_MemberType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_MemberType GetMem_MemberTypeByID(int mem_MemberTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_MemberTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_MemberTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_MemberTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_MemberType(Mem_MemberType mem_MemberType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_MemberType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberTypeName", SqlDbType.NVarChar).Value = mem_MemberType.Mem_MemberTypeName;
            cmd.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Value = mem_MemberType.Mem_MemberCategoryID;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_MemberType.Details;
            cmd.Parameters.Add("@EntranceFee", SqlDbType.Decimal).Value = mem_MemberType.EntranceFee;
            cmd.Parameters.Add("@AnnaralSubscriptionFee", SqlDbType.Decimal).Value = mem_MemberType.AnnaralSubscriptionFee;
            cmd.Parameters.Add("@DiplomaFee", SqlDbType.Decimal).Value = mem_MemberType.DiplomaFee;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_MemberType.Age;
            cmd.Parameters.Add("@Experience", SqlDbType.NVarChar).Value = mem_MemberType.Experience;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_MemberTypeID"].Value;
        }
    }

    public bool UpdateMem_MemberType(Mem_MemberType mem_MemberType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_MemberType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_MemberType.Mem_MemberTypeID;
            cmd.Parameters.Add("@Mem_MemberTypeName", SqlDbType.NVarChar).Value = mem_MemberType.Mem_MemberTypeName;
            cmd.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Value = mem_MemberType.Mem_MemberCategoryID;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_MemberType.Details;
            cmd.Parameters.Add("@EntranceFee", SqlDbType.Decimal).Value = mem_MemberType.EntranceFee;
            cmd.Parameters.Add("@AnnaralSubscriptionFee", SqlDbType.Decimal).Value = mem_MemberType.AnnaralSubscriptionFee;
            cmd.Parameters.Add("@DiplomaFee", SqlDbType.Decimal).Value = mem_MemberType.DiplomaFee;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_MemberType.Age;
            cmd.Parameters.Add("@Experience", SqlDbType.NVarChar).Value = mem_MemberType.Experience;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

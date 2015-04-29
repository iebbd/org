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

public class SqlConv_JobFairProvider:DataAccessObject
{
	public SqlConv_JobFairProvider()
    {
    }


    public bool DeleteConv_JobFair(int conv_JobFairID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteConv_JobFair", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_JobFairID", SqlDbType.Int).Value = conv_JobFairID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Conv_JobFair> GetAllConv_JobFairs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllConv_JobFairs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetConv_JobFairsFromReader(reader);
        }
    }
    public List<Conv_JobFair> GetConv_JobFairsFromReader(IDataReader reader)
    {
        List<Conv_JobFair> conv_JobFairs = new List<Conv_JobFair>();

        while (reader.Read())
        {
            conv_JobFairs.Add(GetConv_JobFairFromReader(reader));
        }
        return conv_JobFairs;
    }

    public Conv_JobFair GetConv_JobFairFromReader(IDataReader reader)
    {
        try
        {
            Conv_JobFair conv_JobFair = new Conv_JobFair
                (
                    (int)reader["Conv_JobFairID"],
                    reader["Name"].ToString(),
                    reader["IEBMembershipNo"].ToString(),
                    reader["Institution"].ToString(),
                    reader["Deprtment"].ToString(),
                    reader["PassingYear"].ToString(),
                    reader["Mobile"].ToString(),
                    reader["Email"].ToString(),
                    reader["Details"].ToString(),
                    reader["OfficeName"].ToString(),
                    reader["TrxID"].ToString(),
                    reader["ExtraField1"].ToString(),
                    reader["ExtraField2"].ToString(),
                    reader["ExtraField3"].ToString(),
                    reader["ExtraField4"].ToString(),
                    reader["ExtraField5"].ToString(),
                    (DateTime)reader["AddedDate"]
                );
             return conv_JobFair;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Conv_JobFair GetConv_JobFairByID(int conv_JobFairID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetConv_JobFairByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Conv_JobFairID", SqlDbType.Int).Value = conv_JobFairID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetConv_JobFairFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertConv_JobFair(Conv_JobFair conv_JobFair)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertConv_JobFair", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_JobFairID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = conv_JobFair.Name;
            cmd.Parameters.Add("@IEBMembershipNo", SqlDbType.NVarChar).Value = conv_JobFair.IEBMembershipNo;
            cmd.Parameters.Add("@Institution", SqlDbType.NVarChar).Value = conv_JobFair.Institution;
            cmd.Parameters.Add("@Deprtment", SqlDbType.NVarChar).Value = conv_JobFair.Deprtment;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = conv_JobFair.PassingYear;
            cmd.Parameters.Add("@Mobile", SqlDbType.Int).Value = conv_JobFair.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = conv_JobFair.Email;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = conv_JobFair.Details;
            cmd.Parameters.Add("@OfficeName", SqlDbType.NVarChar).Value = conv_JobFair.OfficeName;
            cmd.Parameters.Add("@TrxID", SqlDbType.NVarChar).Value = conv_JobFair.TrxID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField5;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = conv_JobFair.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Conv_JobFairID"].Value;
        }
    }

    public bool UpdateConv_JobFair(Conv_JobFair conv_JobFair)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateConv_JobFair", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_JobFairID", SqlDbType.Int).Value = conv_JobFair.Conv_JobFairID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = conv_JobFair.Name;
            cmd.Parameters.Add("@IEBMembershipNo", SqlDbType.NVarChar).Value = conv_JobFair.IEBMembershipNo;
            cmd.Parameters.Add("@Institution", SqlDbType.NVarChar).Value = conv_JobFair.Institution;
            cmd.Parameters.Add("@Deprtment", SqlDbType.NVarChar).Value = conv_JobFair.Deprtment;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = conv_JobFair.PassingYear;
            cmd.Parameters.Add("@Mobile", SqlDbType.Int).Value = conv_JobFair.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = conv_JobFair.Email;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = conv_JobFair.Details;
            cmd.Parameters.Add("@OfficeName", SqlDbType.NVarChar).Value = conv_JobFair.OfficeName;
            cmd.Parameters.Add("@TrxID", SqlDbType.NVarChar).Value = conv_JobFair.TrxID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = conv_JobFair.ExtraField5;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = conv_JobFair.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

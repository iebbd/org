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

public class SqlConv_RegistrationProvider:DataAccessObject
{
	public SqlConv_RegistrationProvider()
    {
    }


    public bool DeleteConv_Registration(int conv_RegistrationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteConv_Registration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_RegistrationID", SqlDbType.Int).Value = conv_RegistrationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Conv_Registration> GetAllConv_Registrations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllConv_Registrations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetConv_RegistrationsFromReader(reader);
        }
    }
    public List<Conv_Registration> GetConv_RegistrationsFromReader(IDataReader reader)
    {
        List<Conv_Registration> conv_Registrations = new List<Conv_Registration>();

        while (reader.Read())
        {
            conv_Registrations.Add(GetConv_RegistrationFromReader(reader));
        }
        return conv_Registrations;
    }

    public Conv_Registration GetConv_RegistrationFromReader(IDataReader reader)
    {
        try
        {
            Conv_Registration conv_Registration = new Conv_Registration
                (
                    (int)reader["Conv_RegistrationID"],
                    (int)reader["Conv_ConventionID"],
                    (int)reader["Mem_MemberID"],
                    (int)reader["RegistrationFee"],
                    (int)reader["Lunch1No"],
                    (int)reader["Lunch1Amount"],
                    (int)reader["Lunch2No"],
                    (int)reader["Lunch2Amount"],
                    (int)reader["Dinner1"],
                    (int)reader["Dinner2"],
                    (int)reader["LadiesBag"],
                    (int)reader["IEBTie"],
                    (int)reader["TotalIEBFee"],
                    (int)reader["BKashFees"],
                    (int)reader["TotalPayable"],
                    reader["TrxID"].ToString(),
                    (DateTime)reader["AddedDate"],
                    (int)reader["TypeID"],
                    (int)reader["StatusID"],
                    reader["ExtraField1"].ToString(),
                    reader["ExtraField2"].ToString(),
                    reader["ExtraField3"].ToString(),
                    reader["ExtraField4"].ToString(),
                    reader["ExtraField5"].ToString()
                );
             return conv_Registration;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Conv_Registration GetConv_RegistrationByID(int conv_RegistrationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetConv_RegistrationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Conv_RegistrationID", SqlDbType.Int).Value = conv_RegistrationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetConv_RegistrationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertConv_Registration(Conv_Registration conv_Registration)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertConv_Registration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_RegistrationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Conv_ConventionID", SqlDbType.Int).Value = conv_Registration.Conv_ConventionID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = conv_Registration.Mem_MemberID;
            cmd.Parameters.Add("@RegistrationFee", SqlDbType.Int).Value = conv_Registration.RegistrationFee;
            cmd.Parameters.Add("@Lunch1No", SqlDbType.Int).Value = conv_Registration.Lunch1No;
            cmd.Parameters.Add("@Lunch1Amount", SqlDbType.Int).Value = conv_Registration.Lunch1Amount;
            cmd.Parameters.Add("@Lunch2No", SqlDbType.Int).Value = conv_Registration.Lunch2No;
            cmd.Parameters.Add("@Lunch2Amount", SqlDbType.Int).Value = conv_Registration.Lunch2Amount;
            cmd.Parameters.Add("@Dinner1", SqlDbType.Int).Value = conv_Registration.Dinner1;
            cmd.Parameters.Add("@Dinner2", SqlDbType.Int).Value = conv_Registration.Dinner2;
            cmd.Parameters.Add("@LadiesBag", SqlDbType.Int).Value = conv_Registration.LadiesBag;
            cmd.Parameters.Add("@IEBTie", SqlDbType.Int).Value = conv_Registration.IEBTie;
            cmd.Parameters.Add("@TotalIEBFee", SqlDbType.Int).Value = conv_Registration.TotalIEBFee;
            cmd.Parameters.Add("@BKashFees", SqlDbType.Int).Value = conv_Registration.BKashFees;
            cmd.Parameters.Add("@TotalPayable", SqlDbType.Int).Value = conv_Registration.TotalPayable;
            cmd.Parameters.Add("@TrxID", SqlDbType.NVarChar).Value = conv_Registration.TrxID;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = conv_Registration.AddedDate;
            cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = conv_Registration.TypeID;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = conv_Registration.StatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = conv_Registration.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = conv_Registration.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = conv_Registration.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = conv_Registration.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = conv_Registration.ExtraField5;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Conv_RegistrationID"].Value;
        }
    }

    public bool UpdateConv_Registration(Conv_Registration conv_Registration)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateConv_Registration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Conv_RegistrationID", SqlDbType.Int).Value = conv_Registration.Conv_RegistrationID;
            cmd.Parameters.Add("@Conv_ConventionID", SqlDbType.Int).Value = conv_Registration.Conv_ConventionID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = conv_Registration.Mem_MemberID;
            cmd.Parameters.Add("@RegistrationFee", SqlDbType.Int).Value = conv_Registration.RegistrationFee;
            cmd.Parameters.Add("@Lunch1No", SqlDbType.Int).Value = conv_Registration.Lunch1No;
            cmd.Parameters.Add("@Lunch1Amount", SqlDbType.Int).Value = conv_Registration.Lunch1Amount;
            cmd.Parameters.Add("@Lunch2No", SqlDbType.Int).Value = conv_Registration.Lunch2No;
            cmd.Parameters.Add("@Lunch2Amount", SqlDbType.Int).Value = conv_Registration.Lunch2Amount;
            cmd.Parameters.Add("@Dinner1", SqlDbType.Int).Value = conv_Registration.Dinner1;
            cmd.Parameters.Add("@Dinner2", SqlDbType.Int).Value = conv_Registration.Dinner2;
            cmd.Parameters.Add("@LadiesBag", SqlDbType.Int).Value = conv_Registration.LadiesBag;
            cmd.Parameters.Add("@IEBTie", SqlDbType.Int).Value = conv_Registration.IEBTie;
            cmd.Parameters.Add("@TotalIEBFee", SqlDbType.Int).Value = conv_Registration.TotalIEBFee;
            cmd.Parameters.Add("@BKashFees", SqlDbType.Int).Value = conv_Registration.BKashFees;
            cmd.Parameters.Add("@TotalPayable", SqlDbType.Int).Value = conv_Registration.TotalPayable;
            cmd.Parameters.Add("@TrxID", SqlDbType.NVarChar).Value = conv_Registration.TrxID;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = conv_Registration.AddedDate;
            cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = conv_Registration.TypeID;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = conv_Registration.StatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = conv_Registration.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = conv_Registration.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = conv_Registration.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = conv_Registration.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = conv_Registration.ExtraField5;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

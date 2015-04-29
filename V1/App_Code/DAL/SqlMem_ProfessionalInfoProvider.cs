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

public class SqlMem_ProfessionalInfoProvider:DataAccessObject
{
	public SqlMem_ProfessionalInfoProvider()
    {
    }


    public bool DeleteMem_ProfessionalInfo(int mem_ProfessionalInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_ProfessionalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ProfessionalInfoID", SqlDbType.Int).Value = mem_ProfessionalInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_ProfessionalInfo> GetAllMem_ProfessionalInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_ProfessionalInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_ProfessionalInfosFromReader(reader);
        }
    }
    public List<Mem_ProfessionalInfo> GetMem_ProfessionalInfosFromReader(IDataReader reader)
    {
        List<Mem_ProfessionalInfo> mem_ProfessionalInfos = new List<Mem_ProfessionalInfo>();

        while (reader.Read())
        {
            mem_ProfessionalInfos.Add(GetMem_ProfessionalInfoFromReader(reader));
        }
        return mem_ProfessionalInfos;
    }

    public Mem_ProfessionalInfo GetMem_ProfessionalInfoFromReader(IDataReader reader)
    {
        try
        {
            Mem_ProfessionalInfo mem_ProfessionalInfo = new Mem_ProfessionalInfo
                (
                    (int)reader["Mem_ProfessionalInfoID"],
                    reader["FromDate"].ToString(),
                    reader["ToDate"].ToString(),
                    reader["Designation"].ToString(),
                    (int)reader["Comn_OfficeID"],
                    reader["Details"].ToString(),
                    (int)reader["AddedBy"],
                    (DateTime)reader["AddedDate"],
                    (int)reader["UpdatedBy"],
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["Comn_RowStatusID"]
                );
             return mem_ProfessionalInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_ProfessionalInfo GetMem_ProfessionalInfoByID(int mem_ProfessionalInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_ProfessionalInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_ProfessionalInfoID", SqlDbType.Int).Value = mem_ProfessionalInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_ProfessionalInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_ProfessionalInfo(Mem_ProfessionalInfo mem_ProfessionalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_ProfessionalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ProfessionalInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.ToDate;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.Designation;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_ProfessionalInfo.Comn_OfficeID;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_ProfessionalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_ProfessionalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_ProfessionalInfo.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = mem_ProfessionalInfo.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = mem_ProfessionalInfo.UpdatedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_ProfessionalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_ProfessionalInfoID"].Value;
        }
    }

    public bool UpdateMem_ProfessionalInfo(Mem_ProfessionalInfo mem_ProfessionalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_ProfessionalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ProfessionalInfoID", SqlDbType.Int).Value = mem_ProfessionalInfo.Mem_ProfessionalInfoID;
            cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.ToDate;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = mem_ProfessionalInfo.Designation;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_ProfessionalInfo.Comn_OfficeID;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_ProfessionalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_ProfessionalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_ProfessionalInfo.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = mem_ProfessionalInfo.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = mem_ProfessionalInfo.UpdatedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_ProfessionalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

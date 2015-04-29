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

public class SqlMem_EducationalInfoProvider:DataAccessObject
{
	public SqlMem_EducationalInfoProvider()
    {
    }


    public bool DeleteMem_EducationalInfo(int mem_EducationalInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Value = mem_EducationalInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteMem_Applied_EducationalInfo(int mem_EducationalInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_Applied_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Value = mem_EducationalInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public List<Mem_EducationalInfo> GetAllMem_EducationalInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_EducationalInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_EducationalInfosFromReader(reader);
        }
    }
    public List<Mem_EducationalInfo> GetMem_EducationalInfosFromReader(IDataReader reader)
    {
        List<Mem_EducationalInfo> mem_EducationalInfos = new List<Mem_EducationalInfo>();

        while (reader.Read())
        {
            mem_EducationalInfos.Add(GetMem_EducationalInfoFromReader(reader));
        }
        return mem_EducationalInfos;
    }

    public Mem_EducationalInfo GetMem_EducationalInfoFromReader(IDataReader reader)
    {
        try
        {
            Mem_EducationalInfo mem_EducationalInfo = new Mem_EducationalInfo
                (
                    (int)reader["Mem_EducationalInfoID"],
                    (int)reader["Mem_MemberID"],
                    (int)reader["Comn_GegreeID"],
                    reader["InstituteName"].ToString(),
                    (int)reader["Comn_UniversityID"],
                    (int)reader["Comn_DepartmentID"],
                    reader["DegreeTitle"].ToString(),
                    reader["YearOfPassing"].ToString(),
                    (int)reader["Comn_ResultTypeID"],
                    reader["Result"].ToString(),
                    reader["Details"].ToString(),
                    (int)reader["AddedBy"],
                    (DateTime)reader["AddedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["Comn_RowStatusID"]
                );
             return mem_EducationalInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_EducationalInfo GetMem_EducationalInfoByID(int mem_EducationalInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_EducationalInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Value = mem_EducationalInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_EducationalInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_MemberID;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_GegreeID;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = mem_EducationalInfo.InstituteName;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_DepartmentID;
            cmd.Parameters.Add("@DegreeTitle", SqlDbType.NVarChar).Value = mem_EducationalInfo.DegreeTitle;
            cmd.Parameters.Add("@YearOfPassing", SqlDbType.NVarChar).Value = mem_EducationalInfo.YearOfPassing;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_ResultTypeID;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = mem_EducationalInfo.Result;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_EducationalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_EducationalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_EducationalInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_EducationalInfoID"].Value;
        }
    }

    public bool UpdateMem_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_EducationalInfoID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_MemberID;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_GegreeID;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = mem_EducationalInfo.InstituteName;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_SubDivisionID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_DepartmentID;
            cmd.Parameters.Add("@DegreeTitle", SqlDbType.NVarChar).Value = mem_EducationalInfo.DegreeTitle;
            cmd.Parameters.Add("@YearOfPassing", SqlDbType.NVarChar).Value = mem_EducationalInfo.YearOfPassing;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_ResultTypeID;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = mem_EducationalInfo.Result;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_EducationalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_EducationalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_EducationalInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public int InsertMem_Applied_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Applied_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_MemberID;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_GegreeID;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = mem_EducationalInfo.InstituteName;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_DepartmentID;
            cmd.Parameters.Add("@DegreeTitle", SqlDbType.NVarChar).Value = mem_EducationalInfo.DegreeTitle;
            cmd.Parameters.Add("@YearOfPassing", SqlDbType.NVarChar).Value = mem_EducationalInfo.YearOfPassing;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_ResultTypeID;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = mem_EducationalInfo.Result;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_EducationalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_EducationalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_EducationalInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_EducationalInfoID"].Value;
        }
    }

    public bool UpdateMem_Applied_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Applied_EducationalInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_EducationalInfoID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_EducationalInfoID;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_EducationalInfo.Mem_MemberID;
            cmd.Parameters.Add("@Comn_GegreeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_GegreeID;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = mem_EducationalInfo.InstituteName;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_DepartmentID;
            cmd.Parameters.Add("@DegreeTitle", SqlDbType.NVarChar).Value = mem_EducationalInfo.DegreeTitle;
            cmd.Parameters.Add("@YearOfPassing", SqlDbType.NVarChar).Value = mem_EducationalInfo.YearOfPassing;
            cmd.Parameters.Add("@Comn_ResultTypeID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_ResultTypeID;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = mem_EducationalInfo.Result;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_EducationalInfo.Details;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_EducationalInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_EducationalInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_EducationalInfo.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_EducationalInfo.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

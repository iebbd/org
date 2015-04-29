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

public class SqlMem_MemberCategoryProvider:DataAccessObject
{
	public SqlMem_MemberCategoryProvider()
    {
    }


    public bool DeleteMem_MemberCategory(int mem_MemberCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_MemberCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Value = mem_MemberCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_MemberCategory> GetAllMem_MemberCategories()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_MemberCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_MemberCategoriesFromReader(reader);
        }
    }
    public List<Mem_MemberCategory> GetMem_MemberCategoriesFromReader(IDataReader reader)
    {
        List<Mem_MemberCategory> mem_MemberCategories = new List<Mem_MemberCategory>();

        while (reader.Read())
        {
            mem_MemberCategories.Add(GetMem_MemberCategoryFromReader(reader));
        }
        return mem_MemberCategories;
    }

    public Mem_MemberCategory GetMem_MemberCategoryFromReader(IDataReader reader)
    {
        try
        {
            Mem_MemberCategory mem_MemberCategory = new Mem_MemberCategory
                (
                    (int)reader["Mem_MemberCategoryID"],
                    reader["Mem_MemberCategoryName"].ToString(),
                    reader["Details"].ToString()
                );
             return mem_MemberCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_MemberCategory GetMem_MemberCategoryByID(int mem_MemberCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_MemberCategoryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Value = mem_MemberCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_MemberCategoryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_MemberCategory(Mem_MemberCategory mem_MemberCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_MemberCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_MemberCategoryName", SqlDbType.NVarChar).Value = mem_MemberCategory.Mem_MemberCategoryName;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_MemberCategory.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_MemberCategoryID"].Value;
        }
    }

    public bool UpdateMem_MemberCategory(Mem_MemberCategory mem_MemberCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_MemberCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberCategoryID", SqlDbType.Int).Value = mem_MemberCategory.Mem_MemberCategoryID;
            cmd.Parameters.Add("@Mem_MemberCategoryName", SqlDbType.NVarChar).Value = mem_MemberCategory.Mem_MemberCategoryName;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_MemberCategory.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

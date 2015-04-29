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

public class SqlComn_DepartmentProvider:DataAccessObject
{
	public SqlComn_DepartmentProvider()
    {
    }


    public bool DeleteComn_Department(int comn_DepartmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteComn_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = comn_DepartmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Comn_Department> GetAllComn_Departments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllComn_Departments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetComn_DepartmentsFromReader(reader);
        }
    }
    public List<Comn_Department> GetComn_DepartmentsFromReader(IDataReader reader)
    {
        List<Comn_Department> comn_Departments = new List<Comn_Department>();

        while (reader.Read())
        {
            comn_Departments.Add(GetComn_DepartmentFromReader(reader));
        }
        return comn_Departments;
    }

    public Comn_Department GetComn_DepartmentFromReader(IDataReader reader)
    {
        try
        {
            Comn_Department comn_Department = new Comn_Department
                (
                    (int)reader["Comn_DepartmentID"],
                    reader["Comn_DepartmentName"].ToString(),
                    reader["Website"].ToString(),
                    reader["Phone"].ToString(),
                    reader["Fax"].ToString(),
                    (int)reader["Type"],
                    reader["Details"].ToString(),
                    reader["OldName"].ToString()
                );
             return comn_Department;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Comn_Department GetComn_DepartmentByID(int comn_DepartmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetComn_DepartmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = comn_DepartmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetComn_DepartmentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertComn_Department(Comn_Department comn_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertComn_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Comn_DepartmentName", SqlDbType.NVarChar).Value = comn_Department.Comn_DepartmentName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_Department.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_Department.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_Department.Fax;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = comn_Department.Type;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_Department.Details;
            cmd.Parameters.Add("@OldName", SqlDbType.NText).Value = comn_Department.OldName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Comn_DepartmentID"].Value;
        }
    }

    public bool UpdateComn_Department(Comn_Department comn_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateComn_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = comn_Department.Comn_DepartmentID;
            cmd.Parameters.Add("@Comn_DepartmentName", SqlDbType.NVarChar).Value = comn_Department.Comn_DepartmentName;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = comn_Department.Website;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = comn_Department.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = comn_Department.Fax;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = comn_Department.Type;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = comn_Department.Details;
            cmd.Parameters.Add("@OldName", SqlDbType.NText).Value = comn_Department.OldName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

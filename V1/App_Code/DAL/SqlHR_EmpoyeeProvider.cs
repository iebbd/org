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

public class SqlHR_EmpoyeeProvider:DataAccessObject
{
	public SqlHR_EmpoyeeProvider()
    {
    }


    public bool DeleteHR_Empoyee(int hR_EmpoyeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteHR_Empoyee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HR_EmpoyeeID", SqlDbType.Int).Value = hR_EmpoyeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<HR_Empoyee> GetAllHR_Empoyees()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllHR_Empoyees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetHR_EmpoyeesFromReader(reader);
        }
    }
    public List<HR_Empoyee> GetHR_EmpoyeesFromReader(IDataReader reader)
    {
        List<HR_Empoyee> hR_Empoyees = new List<HR_Empoyee>();

        while (reader.Read())
        {
            hR_Empoyees.Add(GetHR_EmpoyeeFromReader(reader));
        }
        return hR_Empoyees;
    }

    public HR_Empoyee GetHR_EmpoyeeFromReader(IDataReader reader)
    {
        try
        {
            HR_Empoyee hR_Empoyee = new HR_Empoyee
                (
                    (int)reader["HR_EmpoyeeID"],
                    reader["HR_EmpoyeeName"].ToString()
                );
             return hR_Empoyee;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Empoyee GetHR_EmpoyeeByID(int hR_EmpoyeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetHR_EmpoyeeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HR_EmpoyeeID", SqlDbType.Int).Value = hR_EmpoyeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetHR_EmpoyeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertHR_Empoyee(HR_Empoyee hR_Empoyee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertHR_Empoyee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HR_EmpoyeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HR_EmpoyeeName", SqlDbType.NVarChar).Value = hR_Empoyee.HR_EmpoyeeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@HR_EmpoyeeID"].Value;
        }
    }

    public bool UpdateHR_Empoyee(HR_Empoyee hR_Empoyee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateHR_Empoyee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HR_EmpoyeeID", SqlDbType.Int).Value = hR_Empoyee.HR_EmpoyeeID;
            cmd.Parameters.Add("@HR_EmpoyeeName", SqlDbType.NVarChar).Value = hR_Empoyee.HR_EmpoyeeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

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

public class SqlMem_ApprovedCouncilMeetingProvider:DataAccessObject
{
	public SqlMem_ApprovedCouncilMeetingProvider()
    {
    }


    public bool DeleteMem_ApprovedCouncilMeeting(int mem_ApprovedCouncilMeetingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_ApprovedCouncilMeeting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_ApprovedCouncilMeetingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_ApprovedCouncilMeeting> GetAllMem_ApprovedCouncilMeetings()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_ApprovedCouncilMeetings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_ApprovedCouncilMeetingsFromReader(reader);
        }
    }
    public List<Mem_ApprovedCouncilMeeting> GetMem_ApprovedCouncilMeetingsFromReader(IDataReader reader)
    {
        List<Mem_ApprovedCouncilMeeting> mem_ApprovedCouncilMeetings = new List<Mem_ApprovedCouncilMeeting>();

        while (reader.Read())
        {
            mem_ApprovedCouncilMeetings.Add(GetMem_ApprovedCouncilMeetingFromReader(reader));
        }
        return mem_ApprovedCouncilMeetings;
    }

    public Mem_ApprovedCouncilMeeting GetMem_ApprovedCouncilMeetingFromReader(IDataReader reader)
    {
        try
        {
            Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting = new Mem_ApprovedCouncilMeeting
                (
                    (int)reader["Mem_ApprovedCouncilMeetingID"],
                    reader["Mem_ApprovedCouncilMeetingName"].ToString(),
                    (DateTime)reader["MeetingDate"],
                    reader["Chairman"].ToString(),
                    reader["MembershipCommittee"].ToString(),
                    reader["MemberSecretary"].ToString(),
                    reader["Details"].ToString()
                );
             return mem_ApprovedCouncilMeeting;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Mem_ApprovedCouncilMeeting GetMem_ApprovedCouncilMeetingByID(int mem_ApprovedCouncilMeetingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_ApprovedCouncilMeetingByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_ApprovedCouncilMeetingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_ApprovedCouncilMeetingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMem_ApprovedCouncilMeeting(Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_ApprovedCouncilMeeting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingName", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingName;
            cmd.Parameters.Add("@MeetingDate", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MeetingDate;
            cmd.Parameters.Add("@Chairman", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.Chairman;
            cmd.Parameters.Add("@MembershipCommittee", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MembershipCommittee;
            cmd.Parameters.Add("@MemberSecretary", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MemberSecretary;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_ApprovedCouncilMeeting.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_ApprovedCouncilMeetingID"].Value;
        }
    }

    public bool UpdateMem_ApprovedCouncilMeeting(Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_ApprovedCouncilMeeting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingID;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingName", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingName;
            cmd.Parameters.Add("@MeetingDate", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MeetingDate;
            cmd.Parameters.Add("@Chairman", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.Chairman;
            cmd.Parameters.Add("@MembershipCommittee", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MembershipCommittee;
            cmd.Parameters.Add("@MemberSecretary", SqlDbType.NVarChar).Value = mem_ApprovedCouncilMeeting.MemberSecretary;
            cmd.Parameters.Add("@Details", SqlDbType.NText).Value = mem_ApprovedCouncilMeeting.Details;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

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

public class SqlWeb_EventProvider:DataAccessObject
{
	public SqlWeb_EventProvider()
    {
    }


    public bool DeleteWeb_Event(int web_EventID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteWeb_Event", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventID", SqlDbType.Int).Value = web_EventID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Web_Event> GetAllWeb_Events()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllWeb_Events", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetWeb_EventsFromReader(reader);
        }
    }
    public List<Web_Event> GetWeb_EventsFromReader(IDataReader reader)
    {
        List<Web_Event> web_Events = new List<Web_Event>();

        while (reader.Read())
        {
            web_Events.Add(GetWeb_EventFromReader(reader));
        }
        return web_Events;
    }

    public Web_Event GetWeb_EventFromReader(IDataReader reader)
    {
        try
        {
            Web_Event web_Event = new Web_Event
                (
                    (int)reader["Web_EventID"],
                    reader["EventTitle"].ToString(),
                    reader["EventBoardMessage"].ToString(),
                    reader["BreakingNews"].ToString(),
                    reader["NoticeBoardMessage"].ToString(),
                    reader["EventDetails"].ToString(),
                    (DateTime)reader["EventDate"],
                    (DateTime)reader["NoticeStartDate"],
                    (DateTime)reader["NoticeEndDate"],
                    reader["SmallPictureURL"].ToString(),
                    reader["DetailsPictureURL"].ToString(),
                    (int)reader["Web_EventTypeID"],
                    (bool)reader["TopMarque"],
                    (bool)reader["NoticeBoard"],
                    (bool)reader["EventBoard"],
                    (bool)reader["EventArcrive"],
                    (bool)reader["EventArcriveFrontPage"],
                    (decimal)reader["Ordering"],
                    reader["ExtraField1"].ToString(),
                    reader["ExtraField2"].ToString(),
                    reader["ExtraField3"].ToString(),
                    (int)reader["AddedBy"],
                    (DateTime)reader["AddedDate"],
                    (int)reader["UpdatedBy"],
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["RowStatusID"]
                );
             return web_Event;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Web_Event GetWeb_EventByID(int web_EventID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetWeb_EventByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Web_EventID", SqlDbType.Int).Value = web_EventID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetWeb_EventFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertWeb_Event(Web_Event web_Event)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertWeb_Event", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EventTitle", SqlDbType.NVarChar).Value = web_Event.EventTitle;
            cmd.Parameters.Add("@EventBoardMessage", SqlDbType.NVarChar).Value = web_Event.EventBoardMessage;
            cmd.Parameters.Add("@BreakingNews", SqlDbType.NVarChar).Value = web_Event.BreakingNews;
            cmd.Parameters.Add("@NoticeBoardMessage", SqlDbType.NVarChar).Value = web_Event.NoticeBoardMessage;
            cmd.Parameters.Add("@EventDetails", SqlDbType.NVarChar).Value = web_Event.EventDetails;
            cmd.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = web_Event.EventDate;
            cmd.Parameters.Add("@NoticeStartDate", SqlDbType.DateTime).Value = web_Event.NoticeStartDate;
            cmd.Parameters.Add("@NoticeEndDate", SqlDbType.DateTime).Value = web_Event.NoticeEndDate;
            cmd.Parameters.Add("@SmallPictureURL", SqlDbType.NVarChar).Value = web_Event.SmallPictureURL;
            cmd.Parameters.Add("@DetailsPictureURL", SqlDbType.NVarChar).Value = web_Event.DetailsPictureURL;
            cmd.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Value = web_Event.Web_EventTypeID;
            cmd.Parameters.Add("@TopMarque", SqlDbType.Bit).Value = web_Event.TopMarque;
            cmd.Parameters.Add("@NoticeBoard", SqlDbType.Bit).Value = web_Event.NoticeBoard;
            cmd.Parameters.Add("@EventBoard", SqlDbType.Bit).Value = web_Event.EventBoard;
            cmd.Parameters.Add("@EventArcrive", SqlDbType.Bit).Value = web_Event.EventArcrive;
            cmd.Parameters.Add("@EventArcriveFrontPage", SqlDbType.Bit).Value = web_Event.EventArcriveFrontPage;
            cmd.Parameters.Add("@Ordering", SqlDbType.Decimal).Value = web_Event.Ordering;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = web_Event.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = web_Event.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = web_Event.ExtraField3;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = web_Event.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = web_Event.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = web_Event.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = web_Event.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = web_Event.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Web_EventID"].Value;
        }
    }

    public bool UpdateWeb_Event(Web_Event web_Event)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateWeb_Event", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Web_EventID", SqlDbType.Int).Value = web_Event.Web_EventID;
            cmd.Parameters.Add("@EventTitle", SqlDbType.NVarChar).Value = web_Event.EventTitle;
            cmd.Parameters.Add("@EventBoardMessage", SqlDbType.NVarChar).Value = web_Event.EventBoardMessage;
            cmd.Parameters.Add("@BreakingNews", SqlDbType.NVarChar).Value = web_Event.BreakingNews;
            cmd.Parameters.Add("@NoticeBoardMessage", SqlDbType.NVarChar).Value = web_Event.NoticeBoardMessage;
            cmd.Parameters.Add("@EventDetails", SqlDbType.NVarChar).Value = web_Event.EventDetails;
            cmd.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = web_Event.EventDate;
            cmd.Parameters.Add("@NoticeStartDate", SqlDbType.DateTime).Value = web_Event.NoticeStartDate;
            cmd.Parameters.Add("@NoticeEndDate", SqlDbType.DateTime).Value = web_Event.NoticeEndDate;
            cmd.Parameters.Add("@SmallPictureURL", SqlDbType.NVarChar).Value = web_Event.SmallPictureURL;
            cmd.Parameters.Add("@DetailsPictureURL", SqlDbType.NVarChar).Value = web_Event.DetailsPictureURL;
            cmd.Parameters.Add("@Web_EventTypeID", SqlDbType.Int).Value = web_Event.Web_EventTypeID;
            cmd.Parameters.Add("@TopMarque", SqlDbType.Bit).Value = web_Event.TopMarque;
            cmd.Parameters.Add("@NoticeBoard", SqlDbType.Bit).Value = web_Event.NoticeBoard;
            cmd.Parameters.Add("@EventBoard", SqlDbType.Bit).Value = web_Event.EventBoard;
            cmd.Parameters.Add("@EventArcrive", SqlDbType.Bit).Value = web_Event.EventArcrive;
            cmd.Parameters.Add("@EventArcriveFrontPage", SqlDbType.Bit).Value = web_Event.EventArcriveFrontPage;
            cmd.Parameters.Add("@Ordering", SqlDbType.Decimal).Value = web_Event.Ordering;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = web_Event.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = web_Event.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = web_Event.ExtraField3;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = web_Event.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = web_Event.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = web_Event.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = web_Event.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = web_Event.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class Mem_ApprovedCouncilMeetingManager
{
	public Mem_ApprovedCouncilMeetingManager()
	{
	}

    public static List<Mem_ApprovedCouncilMeeting> GetAllMem_ApprovedCouncilMeetings()
    {
        List<Mem_ApprovedCouncilMeeting> mem_ApprovedCouncilMeetings = new List<Mem_ApprovedCouncilMeeting>();
        SqlMem_ApprovedCouncilMeetingProvider sqlMem_ApprovedCouncilMeetingProvider = new SqlMem_ApprovedCouncilMeetingProvider();
        mem_ApprovedCouncilMeetings = sqlMem_ApprovedCouncilMeetingProvider.GetAllMem_ApprovedCouncilMeetings();
        return mem_ApprovedCouncilMeetings;
    }


    public static Mem_ApprovedCouncilMeeting GetMem_ApprovedCouncilMeetingByID(int id)
    {
        Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting = new Mem_ApprovedCouncilMeeting();
        SqlMem_ApprovedCouncilMeetingProvider sqlMem_ApprovedCouncilMeetingProvider = new SqlMem_ApprovedCouncilMeetingProvider();
        mem_ApprovedCouncilMeeting = sqlMem_ApprovedCouncilMeetingProvider.GetMem_ApprovedCouncilMeetingByID(id);
        return mem_ApprovedCouncilMeeting;
    }


    public static int InsertMem_ApprovedCouncilMeeting(Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting)
    {
        SqlMem_ApprovedCouncilMeetingProvider sqlMem_ApprovedCouncilMeetingProvider = new SqlMem_ApprovedCouncilMeetingProvider();
        return sqlMem_ApprovedCouncilMeetingProvider.InsertMem_ApprovedCouncilMeeting(mem_ApprovedCouncilMeeting);
    }


    public static bool UpdateMem_ApprovedCouncilMeeting(Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting)
    {
        SqlMem_ApprovedCouncilMeetingProvider sqlMem_ApprovedCouncilMeetingProvider = new SqlMem_ApprovedCouncilMeetingProvider();
        return sqlMem_ApprovedCouncilMeetingProvider.UpdateMem_ApprovedCouncilMeeting(mem_ApprovedCouncilMeeting);
    }

    public static bool DeleteMem_ApprovedCouncilMeeting(int mem_ApprovedCouncilMeetingID)
    {
        SqlMem_ApprovedCouncilMeetingProvider sqlMem_ApprovedCouncilMeetingProvider = new SqlMem_ApprovedCouncilMeetingProvider();
        return sqlMem_ApprovedCouncilMeetingProvider.DeleteMem_ApprovedCouncilMeeting(mem_ApprovedCouncilMeetingID);
    }
}

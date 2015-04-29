using System;
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

public class Mem_ApprovedCouncilMeeting
{
    public Mem_ApprovedCouncilMeeting()
    {
    }

    public Mem_ApprovedCouncilMeeting
        (
        int mem_ApprovedCouncilMeetingID, 
        string mem_ApprovedCouncilMeetingName, 
        DateTime meetingDate, 
        string chairman, 
        string membershipCommittee, 
        string memberSecretary, 
        string details
        )
    {
        this.Mem_ApprovedCouncilMeetingID = mem_ApprovedCouncilMeetingID;
        this.Mem_ApprovedCouncilMeetingName = mem_ApprovedCouncilMeetingName;
        this.MeetingDate = meetingDate;
        this.Chairman = chairman;
        this.MembershipCommittee = membershipCommittee;
        this.MemberSecretary = memberSecretary;
        this.Details = details;
    }


    private int _mem_ApprovedCouncilMeetingID;
    public int Mem_ApprovedCouncilMeetingID
    {
        get { return _mem_ApprovedCouncilMeetingID; }
        set { _mem_ApprovedCouncilMeetingID = value; }
    }

    private string _mem_ApprovedCouncilMeetingName;
    public string Mem_ApprovedCouncilMeetingName
    {
        get { return _mem_ApprovedCouncilMeetingName; }
        set { _mem_ApprovedCouncilMeetingName = value; }
    }

    private DateTime _meetingDate;
    public DateTime MeetingDate
    {
        get { return _meetingDate; }
        set { _meetingDate = value; }
    }

    private string _chairman;
    public string Chairman
    {
        get { return _chairman; }
        set { _chairman = value; }
    }

    private string _membershipCommittee;
    public string MembershipCommittee
    {
        get { return _membershipCommittee; }
        set { _membershipCommittee = value; }
    }

    private string _memberSecretary;
    public string MemberSecretary
    {
        get { return _memberSecretary; }
        set { _memberSecretary = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }
}

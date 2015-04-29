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

public class Web_Event
{
    public Web_Event()
    {
    }

    public Web_Event
        (
        int web_EventID, 
        string eventTitle, 
        string eventBoardMessage, 
        string breakingNews, 
        string noticeBoardMessage, 
        string eventDetails, 
        DateTime eventDate, 
        DateTime noticeStartDate, 
        DateTime noticeEndDate, 
        string smallPictureURL, 
        string detailsPictureURL, 
        int web_EventTypeID, 
        bool topMarque, 
        bool noticeBoard, 
        bool eventBoard, 
        bool eventArcrive, 
        bool eventArcriveFrontPage, 
        decimal ordering, 
        string extraField1, 
        string extraField2, 
        string extraField3, 
        int addedBy, 
        DateTime addedDate, 
        int updatedBy, 
        DateTime updatedDate, 
        int rowStatusID
        )
    {
        this.Web_EventID = web_EventID;
        this.EventTitle = eventTitle;
        this.EventBoardMessage = eventBoardMessage;
        this.BreakingNews = breakingNews;
        this.NoticeBoardMessage = noticeBoardMessage;
        this.EventDetails = eventDetails;
        this.EventDate = eventDate;
        this.NoticeStartDate = noticeStartDate;
        this.NoticeEndDate = noticeEndDate;
        this.SmallPictureURL = smallPictureURL;
        this.DetailsPictureURL = detailsPictureURL;
        this.Web_EventTypeID = web_EventTypeID;
        this.TopMarque = topMarque;
        this.NoticeBoard = noticeBoard;
        this.EventBoard = eventBoard;
        this.EventArcrive = eventArcrive;
        this.EventArcriveFrontPage = eventArcriveFrontPage;
        this.Ordering = ordering;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;
    }


    private int _web_EventID;
    public int Web_EventID
    {
        get { return _web_EventID; }
        set { _web_EventID = value; }
    }

    private string _eventTitle;
    public string EventTitle
    {
        get { return _eventTitle; }
        set { _eventTitle = value; }
    }

    private string _eventBoardMessage;
    public string EventBoardMessage
    {
        get { return _eventBoardMessage; }
        set { _eventBoardMessage = value; }
    }

    private string _breakingNews;
    public string BreakingNews
    {
        get { return _breakingNews; }
        set { _breakingNews = value; }
    }

    private string _noticeBoardMessage;
    public string NoticeBoardMessage
    {
        get { return _noticeBoardMessage; }
        set { _noticeBoardMessage = value; }
    }

    private string _eventDetails;
    public string EventDetails
    {
        get { return _eventDetails; }
        set { _eventDetails = value; }
    }

    private DateTime _eventDate;
    public DateTime EventDate
    {
        get { return _eventDate; }
        set { _eventDate = value; }
    }

    private DateTime _noticeStartDate;
    public DateTime NoticeStartDate
    {
        get { return _noticeStartDate; }
        set { _noticeStartDate = value; }
    }

    private DateTime _noticeEndDate;
    public DateTime NoticeEndDate
    {
        get { return _noticeEndDate; }
        set { _noticeEndDate = value; }
    }

    private string _smallPictureURL;
    public string SmallPictureURL
    {
        get { return _smallPictureURL; }
        set { _smallPictureURL = value; }
    }

    private string _detailsPictureURL;
    public string DetailsPictureURL
    {
        get { return _detailsPictureURL; }
        set { _detailsPictureURL = value; }
    }

    private int _web_EventTypeID;
    public int Web_EventTypeID
    {
        get { return _web_EventTypeID; }
        set { _web_EventTypeID = value; }
    }

    private bool _topMarque;
    public bool TopMarque
    {
        get { return _topMarque; }
        set { _topMarque = value; }
    }

    private bool _noticeBoard;
    public bool NoticeBoard
    {
        get { return _noticeBoard; }
        set { _noticeBoard = value; }
    }

    private bool _eventBoard;
    public bool EventBoard
    {
        get { return _eventBoard; }
        set { _eventBoard = value; }
    }

    private bool _eventArcrive;
    public bool EventArcrive
    {
        get { return _eventArcrive; }
        set { _eventArcrive = value; }
    }

    private bool _eventArcriveFrontPage;
    public bool EventArcriveFrontPage
    {
        get { return _eventArcriveFrontPage; }
        set { _eventArcriveFrontPage = value; }
    }

    private decimal _ordering;
    public decimal Ordering
    {
        get { return _ordering; }
        set { _ordering = value; }
    }

    private string _extraField1;
    public string ExtraField1
    {
        get { return _extraField1; }
        set { _extraField1 = value; }
    }

    private string _extraField2;
    public string ExtraField2
    {
        get { return _extraField2; }
        set { _extraField2 = value; }
    }

    private string _extraField3;
    public string ExtraField3
    {
        get { return _extraField3; }
        set { _extraField3 = value; }
    }

    private int _addedBy;
    public int AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private int _updatedBy;
    public int UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }
}

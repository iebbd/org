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

public class Web_EventFile
{
    public Web_EventFile()
    {
    }

    public Web_EventFile
        (
        int web_EventFileID, 
        int web_EventID, 
        string eventFileName, 
        bool visibility, 
        decimal ordering, 
        int rowStatusID, 
        string alterTag, 
        string details, 
        string extraField1, 
        string extraField2, 
        string extraField3
        )
    {
        this.Web_EventFileID = web_EventFileID;
        this.Web_EventID = web_EventID;
        this.EventFileName = eventFileName;
        this.Visibility = visibility;
        this.Ordering = ordering;
        this.RowStatusID = rowStatusID;
        this.AlterTag = alterTag;
        this.Details = details;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
    }


    private int _web_EventFileID;
    public int Web_EventFileID
    {
        get { return _web_EventFileID; }
        set { _web_EventFileID = value; }
    }

    private int _web_EventID;
    public int Web_EventID
    {
        get { return _web_EventID; }
        set { _web_EventID = value; }
    }

    private string _eventFileName;
    public string EventFileName
    {
        get { return _eventFileName; }
        set { _eventFileName = value; }
    }

    private bool _visibility;
    public bool Visibility
    {
        get { return _visibility; }
        set { _visibility = value; }
    }

    private decimal _ordering;
    public decimal Ordering
    {
        get { return _ordering; }
        set { _ordering = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    private string _alterTag;
    public string AlterTag
    {
        get { return _alterTag; }
        set { _alterTag = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
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
}

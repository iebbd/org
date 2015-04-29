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

public class Web_EventType
{
    public Web_EventType()
    {
    }

    public Web_EventType
        (
        int web_EventTypeID, 
        string web_EventTypeName
        )
    {
        this.Web_EventTypeID = web_EventTypeID;
        this.Web_EventTypeName = web_EventTypeName;
    }


    private int _web_EventTypeID;
    public int Web_EventTypeID
    {
        get { return _web_EventTypeID; }
        set { _web_EventTypeID = value; }
    }

    private string _web_EventTypeName;
    public string Web_EventTypeName
    {
        get { return _web_EventTypeName; }
        set { _web_EventTypeName = value; }
    }
}

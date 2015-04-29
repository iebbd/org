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

public class Web_EventManager
{
	public Web_EventManager()
	{
	}

    public static List<Web_Event> GetAllWeb_Events()
    {
        List<Web_Event> web_Events = new List<Web_Event>();
        SqlWeb_EventProvider sqlWeb_EventProvider = new SqlWeb_EventProvider();
        web_Events = sqlWeb_EventProvider.GetAllWeb_Events();
        return web_Events;
    }


    public static Web_Event GetWeb_EventByID(int id)
    {
        Web_Event web_Event = new Web_Event();
        SqlWeb_EventProvider sqlWeb_EventProvider = new SqlWeb_EventProvider();
        web_Event = sqlWeb_EventProvider.GetWeb_EventByID(id);
        return web_Event;
    }


    public static int InsertWeb_Event(Web_Event web_Event)
    {
        SqlWeb_EventProvider sqlWeb_EventProvider = new SqlWeb_EventProvider();
        return sqlWeb_EventProvider.InsertWeb_Event(web_Event);
    }


    public static bool UpdateWeb_Event(Web_Event web_Event)
    {
        SqlWeb_EventProvider sqlWeb_EventProvider = new SqlWeb_EventProvider();
        return sqlWeb_EventProvider.UpdateWeb_Event(web_Event);
    }

    public static bool DeleteWeb_Event(int web_EventID)
    {
        SqlWeb_EventProvider sqlWeb_EventProvider = new SqlWeb_EventProvider();
        return sqlWeb_EventProvider.DeleteWeb_Event(web_EventID);
    }
}

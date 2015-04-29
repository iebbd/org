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

public class Web_EventTypeManager
{
	public Web_EventTypeManager()
	{
	}

    public static List<Web_EventType> GetAllWeb_EventTypes()
    {
        List<Web_EventType> web_EventTypes = new List<Web_EventType>();
        SqlWeb_EventTypeProvider sqlWeb_EventTypeProvider = new SqlWeb_EventTypeProvider();
        web_EventTypes = sqlWeb_EventTypeProvider.GetAllWeb_EventTypes();
        return web_EventTypes;
    }


    public static Web_EventType GetWeb_EventTypeByID(int id)
    {
        Web_EventType web_EventType = new Web_EventType();
        SqlWeb_EventTypeProvider sqlWeb_EventTypeProvider = new SqlWeb_EventTypeProvider();
        web_EventType = sqlWeb_EventTypeProvider.GetWeb_EventTypeByID(id);
        return web_EventType;
    }


    public static int InsertWeb_EventType(Web_EventType web_EventType)
    {
        SqlWeb_EventTypeProvider sqlWeb_EventTypeProvider = new SqlWeb_EventTypeProvider();
        return sqlWeb_EventTypeProvider.InsertWeb_EventType(web_EventType);
    }


    public static bool UpdateWeb_EventType(Web_EventType web_EventType)
    {
        SqlWeb_EventTypeProvider sqlWeb_EventTypeProvider = new SqlWeb_EventTypeProvider();
        return sqlWeb_EventTypeProvider.UpdateWeb_EventType(web_EventType);
    }

    public static bool DeleteWeb_EventType(int web_EventTypeID)
    {
        SqlWeb_EventTypeProvider sqlWeb_EventTypeProvider = new SqlWeb_EventTypeProvider();
        return sqlWeb_EventTypeProvider.DeleteWeb_EventType(web_EventTypeID);
    }
}

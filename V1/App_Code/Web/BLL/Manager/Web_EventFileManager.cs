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

public class Web_EventFileManager
{
	public Web_EventFileManager()
	{
	}

    public static List<Web_EventFile> GetAllWeb_EventFiles()
    {
        List<Web_EventFile> web_EventFiles = new List<Web_EventFile>();
        SqlWeb_EventFileProvider sqlWeb_EventFileProvider = new SqlWeb_EventFileProvider();
        web_EventFiles = sqlWeb_EventFileProvider.GetAllWeb_EventFiles();
        return web_EventFiles;
    }


    public static Web_EventFile GetWeb_EventFileByID(int id)
    {
        Web_EventFile web_EventFile = new Web_EventFile();
        SqlWeb_EventFileProvider sqlWeb_EventFileProvider = new SqlWeb_EventFileProvider();
        web_EventFile = sqlWeb_EventFileProvider.GetWeb_EventFileByID(id);
        return web_EventFile;
    }


    public static int InsertWeb_EventFile(Web_EventFile web_EventFile)
    {
        SqlWeb_EventFileProvider sqlWeb_EventFileProvider = new SqlWeb_EventFileProvider();
        return sqlWeb_EventFileProvider.InsertWeb_EventFile(web_EventFile);
    }


    public static bool UpdateWeb_EventFile(Web_EventFile web_EventFile)
    {
        SqlWeb_EventFileProvider sqlWeb_EventFileProvider = new SqlWeb_EventFileProvider();
        return sqlWeb_EventFileProvider.UpdateWeb_EventFile(web_EventFile);
    }

    public static bool DeleteWeb_EventFile(int web_EventFileID)
    {
        SqlWeb_EventFileProvider sqlWeb_EventFileProvider = new SqlWeb_EventFileProvider();
        return sqlWeb_EventFileProvider.DeleteWeb_EventFile(web_EventFileID);
    }
}

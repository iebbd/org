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

public class Comn_FileManager
{
	public Comn_FileManager()
	{
	}

    public static List<Comn_File> GetAllComn_Files()
    {
        List<Comn_File> comn_Files = new List<Comn_File>();
        SqlComn_FileProvider sqlComn_FileProvider = new SqlComn_FileProvider();
        comn_Files = sqlComn_FileProvider.GetAllComn_Files();
        return comn_Files;
    }


    public static Comn_File GetComn_FileByID(int id)
    {
        Comn_File comn_File = new Comn_File();
        SqlComn_FileProvider sqlComn_FileProvider = new SqlComn_FileProvider();
        comn_File = sqlComn_FileProvider.GetComn_FileByID(id);
        return comn_File;
    }


    public static int InsertComn_File(Comn_File comn_File)
    {
        SqlComn_FileProvider sqlComn_FileProvider = new SqlComn_FileProvider();
        return sqlComn_FileProvider.InsertComn_File(comn_File);
    }


    public static bool UpdateComn_File(Comn_File comn_File)
    {
        SqlComn_FileProvider sqlComn_FileProvider = new SqlComn_FileProvider();
        return sqlComn_FileProvider.UpdateComn_File(comn_File);
    }

    public static bool DeleteComn_File(int comn_FileID)
    {
        SqlComn_FileProvider sqlComn_FileProvider = new SqlComn_FileProvider();
        return sqlComn_FileProvider.DeleteComn_File(comn_FileID);
    }
}

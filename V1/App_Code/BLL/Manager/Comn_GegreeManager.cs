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

public class Comn_GegreeManager
{
	public Comn_GegreeManager()
	{
	}

    public static List<Comn_Gegree> GetAllComn_Gegrees()
    {
        List<Comn_Gegree> comn_Gegrees = new List<Comn_Gegree>();
        SqlComn_GegreeProvider sqlComn_GegreeProvider = new SqlComn_GegreeProvider();
        comn_Gegrees = sqlComn_GegreeProvider.GetAllComn_Gegrees();
        return comn_Gegrees;
    }


    public static Comn_Gegree GetComn_GegreeByID(int id)
    {
        Comn_Gegree comn_Gegree = new Comn_Gegree();
        SqlComn_GegreeProvider sqlComn_GegreeProvider = new SqlComn_GegreeProvider();
        comn_Gegree = sqlComn_GegreeProvider.GetComn_GegreeByID(id);
        return comn_Gegree;
    }


    public static int InsertComn_Gegree(Comn_Gegree comn_Gegree)
    {
        SqlComn_GegreeProvider sqlComn_GegreeProvider = new SqlComn_GegreeProvider();
        return sqlComn_GegreeProvider.InsertComn_Gegree(comn_Gegree);
    }


    public static bool UpdateComn_Gegree(Comn_Gegree comn_Gegree)
    {
        SqlComn_GegreeProvider sqlComn_GegreeProvider = new SqlComn_GegreeProvider();
        return sqlComn_GegreeProvider.UpdateComn_Gegree(comn_Gegree);
    }

    public static bool DeleteComn_Gegree(int comn_GegreeID)
    {
        SqlComn_GegreeProvider sqlComn_GegreeProvider = new SqlComn_GegreeProvider();
        return sqlComn_GegreeProvider.DeleteComn_Gegree(comn_GegreeID);
    }
}

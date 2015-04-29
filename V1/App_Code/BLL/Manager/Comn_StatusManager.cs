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

public class Comn_StatusManager
{
	public Comn_StatusManager()
	{
	}

    public static List<Comn_Status> GetAllComn_Statuss()
    {
        List<Comn_Status> comn_Statuss = new List<Comn_Status>();
        SqlComn_StatusProvider sqlComn_StatusProvider = new SqlComn_StatusProvider();
        comn_Statuss = sqlComn_StatusProvider.GetAllComn_Statuss();
        return comn_Statuss;
    }


    public static Comn_Status GetComn_StatusByID(int id)
    {
        Comn_Status comn_Status = new Comn_Status();
        SqlComn_StatusProvider sqlComn_StatusProvider = new SqlComn_StatusProvider();
        comn_Status = sqlComn_StatusProvider.GetComn_StatusByID(id);
        return comn_Status;
    }


    public static int InsertComn_Status(Comn_Status comn_Status)
    {
        SqlComn_StatusProvider sqlComn_StatusProvider = new SqlComn_StatusProvider();
        return sqlComn_StatusProvider.InsertComn_Status(comn_Status);
    }


    public static bool UpdateComn_Status(Comn_Status comn_Status)
    {
        SqlComn_StatusProvider sqlComn_StatusProvider = new SqlComn_StatusProvider();
        return sqlComn_StatusProvider.UpdateComn_Status(comn_Status);
    }

    public static bool DeleteComn_Status(int comn_StatusID)
    {
        SqlComn_StatusProvider sqlComn_StatusProvider = new SqlComn_StatusProvider();
        return sqlComn_StatusProvider.DeleteComn_Status(comn_StatusID);
    }
}

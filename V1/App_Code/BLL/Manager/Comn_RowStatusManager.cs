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

public class Comn_RowStatusManager
{
	public Comn_RowStatusManager()
	{
	}

    public static List<Comn_RowStatus> GetAllComn_RowStatuss()
    {
        List<Comn_RowStatus> comn_RowStatuss = new List<Comn_RowStatus>();
        SqlComn_RowStatusProvider sqlComn_RowStatusProvider = new SqlComn_RowStatusProvider();
        comn_RowStatuss = sqlComn_RowStatusProvider.GetAllComn_RowStatuss();
        return comn_RowStatuss;
    }


    public static Comn_RowStatus GetComn_RowStatusByID(int id)
    {
        Comn_RowStatus comn_RowStatus = new Comn_RowStatus();
        SqlComn_RowStatusProvider sqlComn_RowStatusProvider = new SqlComn_RowStatusProvider();
        comn_RowStatus = sqlComn_RowStatusProvider.GetComn_RowStatusByID(id);
        return comn_RowStatus;
    }


    public static int InsertComn_RowStatus(Comn_RowStatus comn_RowStatus)
    {
        SqlComn_RowStatusProvider sqlComn_RowStatusProvider = new SqlComn_RowStatusProvider();
        return sqlComn_RowStatusProvider.InsertComn_RowStatus(comn_RowStatus);
    }


    public static bool UpdateComn_RowStatus(Comn_RowStatus comn_RowStatus)
    {
        SqlComn_RowStatusProvider sqlComn_RowStatusProvider = new SqlComn_RowStatusProvider();
        return sqlComn_RowStatusProvider.UpdateComn_RowStatus(comn_RowStatus);
    }

    public static bool DeleteComn_RowStatus(int comn_RowStatusID)
    {
        SqlComn_RowStatusProvider sqlComn_RowStatusProvider = new SqlComn_RowStatusProvider();
        return sqlComn_RowStatusProvider.DeleteComn_RowStatus(comn_RowStatusID);
    }
}

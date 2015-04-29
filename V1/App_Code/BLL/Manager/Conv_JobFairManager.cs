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

public class Conv_JobFairManager
{
	public Conv_JobFairManager()
	{
	}

    public static List<Conv_JobFair> GetAllConv_JobFairs()
    {
        List<Conv_JobFair> conv_JobFairs = new List<Conv_JobFair>();
        SqlConv_JobFairProvider sqlConv_JobFairProvider = new SqlConv_JobFairProvider();
        conv_JobFairs = sqlConv_JobFairProvider.GetAllConv_JobFairs();
        return conv_JobFairs;
    }


    public static Conv_JobFair GetConv_JobFairByID(int id)
    {
        Conv_JobFair conv_JobFair = new Conv_JobFair();
        SqlConv_JobFairProvider sqlConv_JobFairProvider = new SqlConv_JobFairProvider();
        conv_JobFair = sqlConv_JobFairProvider.GetConv_JobFairByID(id);
        return conv_JobFair;
    }


    public static int InsertConv_JobFair(Conv_JobFair conv_JobFair)
    {
        SqlConv_JobFairProvider sqlConv_JobFairProvider = new SqlConv_JobFairProvider();
        return sqlConv_JobFairProvider.InsertConv_JobFair(conv_JobFair);
    }


    public static bool UpdateConv_JobFair(Conv_JobFair conv_JobFair)
    {
        SqlConv_JobFairProvider sqlConv_JobFairProvider = new SqlConv_JobFairProvider();
        return sqlConv_JobFairProvider.UpdateConv_JobFair(conv_JobFair);
    }

    public static bool DeleteConv_JobFair(int conv_JobFairID)
    {
        SqlConv_JobFairProvider sqlConv_JobFairProvider = new SqlConv_JobFairProvider();
        return sqlConv_JobFairProvider.DeleteConv_JobFair(conv_JobFairID);
    }
}

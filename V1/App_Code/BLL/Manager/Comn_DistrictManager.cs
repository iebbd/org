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

public class Comn_DistrictManager
{
	public Comn_DistrictManager()
	{
	}

    public static List<Comn_District> GetAllComn_Districts()
    {
        List<Comn_District> comn_Districts = new List<Comn_District>();
        SqlComn_DistrictProvider sqlComn_DistrictProvider = new SqlComn_DistrictProvider();
        comn_Districts = sqlComn_DistrictProvider.GetAllComn_Districts();
        return comn_Districts;
    }


    public static Comn_District GetComn_DistrictByID(int id)
    {
        Comn_District comn_District = new Comn_District();
        SqlComn_DistrictProvider sqlComn_DistrictProvider = new SqlComn_DistrictProvider();
        comn_District = sqlComn_DistrictProvider.GetComn_DistrictByID(id);
        return comn_District;
    }


    public static int InsertComn_District(Comn_District comn_District)
    {
        SqlComn_DistrictProvider sqlComn_DistrictProvider = new SqlComn_DistrictProvider();
        return sqlComn_DistrictProvider.InsertComn_District(comn_District);
    }


    public static bool UpdateComn_District(Comn_District comn_District)
    {
        SqlComn_DistrictProvider sqlComn_DistrictProvider = new SqlComn_DistrictProvider();
        return sqlComn_DistrictProvider.UpdateComn_District(comn_District);
    }

    public static bool DeleteComn_District(int comn_DistrictID)
    {
        SqlComn_DistrictProvider sqlComn_DistrictProvider = new SqlComn_DistrictProvider();
        return sqlComn_DistrictProvider.DeleteComn_District(comn_DistrictID);
    }
}

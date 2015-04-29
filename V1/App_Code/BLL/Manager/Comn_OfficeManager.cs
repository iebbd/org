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

public class Comn_OfficeManager
{
	public Comn_OfficeManager()
	{
	}

    public static List<Comn_Office> GetAllComn_Offices()
    {
        List<Comn_Office> comn_Offices = new List<Comn_Office>();
        SqlComn_OfficeProvider sqlComn_OfficeProvider = new SqlComn_OfficeProvider();
        comn_Offices = sqlComn_OfficeProvider.GetAllComn_Offices();
        return comn_Offices;
    }


    public static Comn_Office GetComn_OfficeByID(int id)
    {
        Comn_Office comn_Office = new Comn_Office();
        SqlComn_OfficeProvider sqlComn_OfficeProvider = new SqlComn_OfficeProvider();
        comn_Office = sqlComn_OfficeProvider.GetComn_OfficeByID(id);
        return comn_Office;
    }


    public static int InsertComn_Office(Comn_Office comn_Office)
    {
        SqlComn_OfficeProvider sqlComn_OfficeProvider = new SqlComn_OfficeProvider();
        return sqlComn_OfficeProvider.InsertComn_Office(comn_Office);
    }


    public static bool UpdateComn_Office(Comn_Office comn_Office)
    {
        SqlComn_OfficeProvider sqlComn_OfficeProvider = new SqlComn_OfficeProvider();
        return sqlComn_OfficeProvider.UpdateComn_Office(comn_Office);
    }

    public static bool DeleteComn_Office(int comn_OfficeID)
    {
        SqlComn_OfficeProvider sqlComn_OfficeProvider = new SqlComn_OfficeProvider();
        return sqlComn_OfficeProvider.DeleteComn_Office(comn_OfficeID);
    }
}

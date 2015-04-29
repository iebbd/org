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

public class Comn_NationalityManager
{
	public Comn_NationalityManager()
	{
	}

    public static List<Comn_Nationality> GetAllComn_Nationalities()
    {
        List<Comn_Nationality> comn_Nationalities = new List<Comn_Nationality>();
        SqlComn_NationalityProvider sqlComn_NationalityProvider = new SqlComn_NationalityProvider();
        comn_Nationalities = sqlComn_NationalityProvider.GetAllComn_Nationalities();
        return comn_Nationalities;
    }


    public static Comn_Nationality GetComn_NationalityByID(int id)
    {
        Comn_Nationality comn_Nationality = new Comn_Nationality();
        SqlComn_NationalityProvider sqlComn_NationalityProvider = new SqlComn_NationalityProvider();
        comn_Nationality = sqlComn_NationalityProvider.GetComn_NationalityByID(id);
        return comn_Nationality;
    }


    public static int InsertComn_Nationality(Comn_Nationality comn_Nationality)
    {
        SqlComn_NationalityProvider sqlComn_NationalityProvider = new SqlComn_NationalityProvider();
        return sqlComn_NationalityProvider.InsertComn_Nationality(comn_Nationality);
    }


    public static bool UpdateComn_Nationality(Comn_Nationality comn_Nationality)
    {
        SqlComn_NationalityProvider sqlComn_NationalityProvider = new SqlComn_NationalityProvider();
        return sqlComn_NationalityProvider.UpdateComn_Nationality(comn_Nationality);
    }

    public static bool DeleteComn_Nationality(int comn_NationalityID)
    {
        SqlComn_NationalityProvider sqlComn_NationalityProvider = new SqlComn_NationalityProvider();
        return sqlComn_NationalityProvider.DeleteComn_Nationality(comn_NationalityID);
    }
}

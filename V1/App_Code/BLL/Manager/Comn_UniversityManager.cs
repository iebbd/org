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

public class Comn_UniversityManager
{
	public Comn_UniversityManager()
	{
	}

    public static List<Comn_University> GetAllComn_Universities()
    {
        List<Comn_University> comn_Universities = new List<Comn_University>();
        SqlComn_UniversityProvider sqlComn_UniversityProvider = new SqlComn_UniversityProvider();
        comn_Universities = sqlComn_UniversityProvider.GetAllComn_Universities();
        return comn_Universities;
    }


    public static Comn_University GetComn_UniversityByID(int id)
    {
        Comn_University comn_University = new Comn_University();
        SqlComn_UniversityProvider sqlComn_UniversityProvider = new SqlComn_UniversityProvider();
        comn_University = sqlComn_UniversityProvider.GetComn_UniversityByID(id);
        return comn_University;
    }


    public static int InsertComn_University(Comn_University comn_University)
    {
        SqlComn_UniversityProvider sqlComn_UniversityProvider = new SqlComn_UniversityProvider();
        return sqlComn_UniversityProvider.InsertComn_University(comn_University);
    }


    public static bool UpdateComn_University(Comn_University comn_University)
    {
        SqlComn_UniversityProvider sqlComn_UniversityProvider = new SqlComn_UniversityProvider();
        return sqlComn_UniversityProvider.UpdateComn_University(comn_University);
    }

    public static bool DeleteComn_University(int comn_UniversityID)
    {
        SqlComn_UniversityProvider sqlComn_UniversityProvider = new SqlComn_UniversityProvider();
        return sqlComn_UniversityProvider.DeleteComn_University(comn_UniversityID);
    }
}

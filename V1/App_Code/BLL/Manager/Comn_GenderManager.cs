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

public class Comn_GenderManager
{
	public Comn_GenderManager()
	{
	}

    public static List<Comn_Gender> GetAllComn_Genders()
    {
        List<Comn_Gender> comn_Genders = new List<Comn_Gender>();
        SqlComn_GenderProvider sqlComn_GenderProvider = new SqlComn_GenderProvider();
        comn_Genders = sqlComn_GenderProvider.GetAllComn_Genders();
        return comn_Genders;
    }


    public static Comn_Gender GetComn_GenderByID(int id)
    {
        Comn_Gender comn_Gender = new Comn_Gender();
        SqlComn_GenderProvider sqlComn_GenderProvider = new SqlComn_GenderProvider();
        comn_Gender = sqlComn_GenderProvider.GetComn_GenderByID(id);
        return comn_Gender;
    }


    public static int InsertComn_Gender(Comn_Gender comn_Gender)
    {
        SqlComn_GenderProvider sqlComn_GenderProvider = new SqlComn_GenderProvider();
        return sqlComn_GenderProvider.InsertComn_Gender(comn_Gender);
    }


    public static bool UpdateComn_Gender(Comn_Gender comn_Gender)
    {
        SqlComn_GenderProvider sqlComn_GenderProvider = new SqlComn_GenderProvider();
        return sqlComn_GenderProvider.UpdateComn_Gender(comn_Gender);
    }

    public static bool DeleteComn_Gender(int comn_GenderID)
    {
        SqlComn_GenderProvider sqlComn_GenderProvider = new SqlComn_GenderProvider();
        return sqlComn_GenderProvider.DeleteComn_Gender(comn_GenderID);
    }
}

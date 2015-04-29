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

public class Comn_OfficeTypeManager
{
	public Comn_OfficeTypeManager()
	{
	}

    public static List<Comn_OfficeType> GetAllComn_OfficeTypes()
    {
        List<Comn_OfficeType> comn_OfficeTypes = new List<Comn_OfficeType>();
        SqlComn_OfficeTypeProvider sqlComn_OfficeTypeProvider = new SqlComn_OfficeTypeProvider();
        comn_OfficeTypes = sqlComn_OfficeTypeProvider.GetAllComn_OfficeTypes();
        return comn_OfficeTypes;
    }


    public static Comn_OfficeType GetComn_OfficeTypeByID(int id)
    {
        Comn_OfficeType comn_OfficeType = new Comn_OfficeType();
        SqlComn_OfficeTypeProvider sqlComn_OfficeTypeProvider = new SqlComn_OfficeTypeProvider();
        comn_OfficeType = sqlComn_OfficeTypeProvider.GetComn_OfficeTypeByID(id);
        return comn_OfficeType;
    }


    public static int InsertComn_OfficeType(Comn_OfficeType comn_OfficeType)
    {
        SqlComn_OfficeTypeProvider sqlComn_OfficeTypeProvider = new SqlComn_OfficeTypeProvider();
        return sqlComn_OfficeTypeProvider.InsertComn_OfficeType(comn_OfficeType);
    }


    public static bool UpdateComn_OfficeType(Comn_OfficeType comn_OfficeType)
    {
        SqlComn_OfficeTypeProvider sqlComn_OfficeTypeProvider = new SqlComn_OfficeTypeProvider();
        return sqlComn_OfficeTypeProvider.UpdateComn_OfficeType(comn_OfficeType);
    }

    public static bool DeleteComn_OfficeType(int comn_OfficeTypeID)
    {
        SqlComn_OfficeTypeProvider sqlComn_OfficeTypeProvider = new SqlComn_OfficeTypeProvider();
        return sqlComn_OfficeTypeProvider.DeleteComn_OfficeType(comn_OfficeTypeID);
    }
}

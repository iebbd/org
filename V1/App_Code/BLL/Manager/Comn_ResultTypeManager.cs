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

public class Comn_ResultTypeManager
{
	public Comn_ResultTypeManager()
	{
	}

    public static List<Comn_ResultType> GetAllComn_ResultTypes()
    {
        List<Comn_ResultType> comn_ResultTypes = new List<Comn_ResultType>();
        SqlComn_ResultTypeProvider sqlComn_ResultTypeProvider = new SqlComn_ResultTypeProvider();
        comn_ResultTypes = sqlComn_ResultTypeProvider.GetAllComn_ResultTypes();
        return comn_ResultTypes;
    }


    public static Comn_ResultType GetComn_ResultTypeByID(int id)
    {
        Comn_ResultType comn_ResultType = new Comn_ResultType();
        SqlComn_ResultTypeProvider sqlComn_ResultTypeProvider = new SqlComn_ResultTypeProvider();
        comn_ResultType = sqlComn_ResultTypeProvider.GetComn_ResultTypeByID(id);
        return comn_ResultType;
    }


    public static int InsertComn_ResultType(Comn_ResultType comn_ResultType)
    {
        SqlComn_ResultTypeProvider sqlComn_ResultTypeProvider = new SqlComn_ResultTypeProvider();
        return sqlComn_ResultTypeProvider.InsertComn_ResultType(comn_ResultType);
    }


    public static bool UpdateComn_ResultType(Comn_ResultType comn_ResultType)
    {
        SqlComn_ResultTypeProvider sqlComn_ResultTypeProvider = new SqlComn_ResultTypeProvider();
        return sqlComn_ResultTypeProvider.UpdateComn_ResultType(comn_ResultType);
    }

    public static bool DeleteComn_ResultType(int comn_ResultTypeID)
    {
        SqlComn_ResultTypeProvider sqlComn_ResultTypeProvider = new SqlComn_ResultTypeProvider();
        return sqlComn_ResultTypeProvider.DeleteComn_ResultType(comn_ResultTypeID);
    }
}

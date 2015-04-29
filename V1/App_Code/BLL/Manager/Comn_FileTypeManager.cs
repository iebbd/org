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

public class Comn_FileTypeManager
{
	public Comn_FileTypeManager()
	{
	}

    public static List<Comn_FileType> GetAllComn_FileTypes()
    {
        List<Comn_FileType> comn_FileTypes = new List<Comn_FileType>();
        SqlComn_FileTypeProvider sqlComn_FileTypeProvider = new SqlComn_FileTypeProvider();
        comn_FileTypes = sqlComn_FileTypeProvider.GetAllComn_FileTypes();
        return comn_FileTypes;
    }


    public static Comn_FileType GetComn_FileTypeByID(int id)
    {
        Comn_FileType comn_FileType = new Comn_FileType();
        SqlComn_FileTypeProvider sqlComn_FileTypeProvider = new SqlComn_FileTypeProvider();
        comn_FileType = sqlComn_FileTypeProvider.GetComn_FileTypeByID(id);
        return comn_FileType;
    }


    public static int InsertComn_FileType(Comn_FileType comn_FileType)
    {
        SqlComn_FileTypeProvider sqlComn_FileTypeProvider = new SqlComn_FileTypeProvider();
        return sqlComn_FileTypeProvider.InsertComn_FileType(comn_FileType);
    }


    public static bool UpdateComn_FileType(Comn_FileType comn_FileType)
    {
        SqlComn_FileTypeProvider sqlComn_FileTypeProvider = new SqlComn_FileTypeProvider();
        return sqlComn_FileTypeProvider.UpdateComn_FileType(comn_FileType);
    }

    public static bool DeleteComn_FileType(int comn_FileTypeID)
    {
        SqlComn_FileTypeProvider sqlComn_FileTypeProvider = new SqlComn_FileTypeProvider();
        return sqlComn_FileTypeProvider.DeleteComn_FileType(comn_FileTypeID);
    }
}

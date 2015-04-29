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

public class Mem_MemberCategoryManager
{
	public Mem_MemberCategoryManager()
	{
	}

    public static List<Mem_MemberCategory> GetAllMem_MemberCategories()
    {
        List<Mem_MemberCategory> mem_MemberCategories = new List<Mem_MemberCategory>();
        SqlMem_MemberCategoryProvider sqlMem_MemberCategoryProvider = new SqlMem_MemberCategoryProvider();
        mem_MemberCategories = sqlMem_MemberCategoryProvider.GetAllMem_MemberCategories();
        return mem_MemberCategories;
    }


    public static Mem_MemberCategory GetMem_MemberCategoryByID(int id)
    {
        Mem_MemberCategory mem_MemberCategory = new Mem_MemberCategory();
        SqlMem_MemberCategoryProvider sqlMem_MemberCategoryProvider = new SqlMem_MemberCategoryProvider();
        mem_MemberCategory = sqlMem_MemberCategoryProvider.GetMem_MemberCategoryByID(id);
        return mem_MemberCategory;
    }


    public static int InsertMem_MemberCategory(Mem_MemberCategory mem_MemberCategory)
    {
        SqlMem_MemberCategoryProvider sqlMem_MemberCategoryProvider = new SqlMem_MemberCategoryProvider();
        return sqlMem_MemberCategoryProvider.InsertMem_MemberCategory(mem_MemberCategory);
    }


    public static bool UpdateMem_MemberCategory(Mem_MemberCategory mem_MemberCategory)
    {
        SqlMem_MemberCategoryProvider sqlMem_MemberCategoryProvider = new SqlMem_MemberCategoryProvider();
        return sqlMem_MemberCategoryProvider.UpdateMem_MemberCategory(mem_MemberCategory);
    }

    public static bool DeleteMem_MemberCategory(int mem_MemberCategoryID)
    {
        SqlMem_MemberCategoryProvider sqlMem_MemberCategoryProvider = new SqlMem_MemberCategoryProvider();
        return sqlMem_MemberCategoryProvider.DeleteMem_MemberCategory(mem_MemberCategoryID);
    }
}

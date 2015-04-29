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

public class Mem_MemberTypeManager
{
	public Mem_MemberTypeManager()
	{
	}

    public static List<Mem_MemberType> GetAllMem_MemberTypes()
    {
        List<Mem_MemberType> mem_MemberTypes = new List<Mem_MemberType>();
        SqlMem_MemberTypeProvider sqlMem_MemberTypeProvider = new SqlMem_MemberTypeProvider();
        mem_MemberTypes = sqlMem_MemberTypeProvider.GetAllMem_MemberTypes();
        return mem_MemberTypes;
    }


    public static Mem_MemberType GetMem_MemberTypeByID(int id)
    {
        Mem_MemberType mem_MemberType = new Mem_MemberType();
        SqlMem_MemberTypeProvider sqlMem_MemberTypeProvider = new SqlMem_MemberTypeProvider();
        mem_MemberType = sqlMem_MemberTypeProvider.GetMem_MemberTypeByID(id);
        return mem_MemberType;
    }


    public static int InsertMem_MemberType(Mem_MemberType mem_MemberType)
    {
        SqlMem_MemberTypeProvider sqlMem_MemberTypeProvider = new SqlMem_MemberTypeProvider();
        return sqlMem_MemberTypeProvider.InsertMem_MemberType(mem_MemberType);
    }


    public static bool UpdateMem_MemberType(Mem_MemberType mem_MemberType)
    {
        SqlMem_MemberTypeProvider sqlMem_MemberTypeProvider = new SqlMem_MemberTypeProvider();
        return sqlMem_MemberTypeProvider.UpdateMem_MemberType(mem_MemberType);
    }

    public static bool DeleteMem_MemberType(int mem_MemberTypeID)
    {
        SqlMem_MemberTypeProvider sqlMem_MemberTypeProvider = new SqlMem_MemberTypeProvider();
        return sqlMem_MemberTypeProvider.DeleteMem_MemberType(mem_MemberTypeID);
    }
}

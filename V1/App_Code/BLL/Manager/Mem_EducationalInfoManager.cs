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

public class Mem_EducationalInfoManager
{
	public Mem_EducationalInfoManager()
	{
	}

    public static List<Mem_EducationalInfo> GetAllMem_EducationalInfos()
    {
        List<Mem_EducationalInfo> mem_EducationalInfos = new List<Mem_EducationalInfo>();
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        mem_EducationalInfos = sqlMem_EducationalInfoProvider.GetAllMem_EducationalInfos();
        return mem_EducationalInfos;
    }


    public static Mem_EducationalInfo GetMem_EducationalInfoByID(int id)
    {
        Mem_EducationalInfo mem_EducationalInfo = new Mem_EducationalInfo();
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        mem_EducationalInfo = sqlMem_EducationalInfoProvider.GetMem_EducationalInfoByID(id);
        return mem_EducationalInfo;
    }


    public static int InsertMem_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.InsertMem_EducationalInfo(mem_EducationalInfo);
    }


    public static bool UpdateMem_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.UpdateMem_EducationalInfo(mem_EducationalInfo);
    }

    public static bool DeleteMem_EducationalInfo(int mem_EducationalInfoID)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.DeleteMem_EducationalInfo(mem_EducationalInfoID);
    }


    public static int InsertMem_Applied_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.InsertMem_Applied_EducationalInfo(mem_EducationalInfo);
    }


    public static bool UpdateMem_Applied_EducationalInfo(Mem_EducationalInfo mem_EducationalInfo)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.UpdateMem_Applied_EducationalInfo(mem_EducationalInfo);
    }

    public static bool DeleteMem_Applied_EducationalInfo(int mem_EducationalInfoID)
    {
        SqlMem_EducationalInfoProvider sqlMem_EducationalInfoProvider = new SqlMem_EducationalInfoProvider();
        return sqlMem_EducationalInfoProvider.DeleteMem_Applied_EducationalInfo(mem_EducationalInfoID);
    }
}

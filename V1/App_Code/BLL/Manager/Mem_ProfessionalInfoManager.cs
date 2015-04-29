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

public class Mem_ProfessionalInfoManager
{
	public Mem_ProfessionalInfoManager()
	{
	}

    public static List<Mem_ProfessionalInfo> GetAllMem_ProfessionalInfos()
    {
        List<Mem_ProfessionalInfo> mem_ProfessionalInfos = new List<Mem_ProfessionalInfo>();
        SqlMem_ProfessionalInfoProvider sqlMem_ProfessionalInfoProvider = new SqlMem_ProfessionalInfoProvider();
        mem_ProfessionalInfos = sqlMem_ProfessionalInfoProvider.GetAllMem_ProfessionalInfos();
        return mem_ProfessionalInfos;
    }


    public static Mem_ProfessionalInfo GetMem_ProfessionalInfoByID(int id)
    {
        Mem_ProfessionalInfo mem_ProfessionalInfo = new Mem_ProfessionalInfo();
        SqlMem_ProfessionalInfoProvider sqlMem_ProfessionalInfoProvider = new SqlMem_ProfessionalInfoProvider();
        mem_ProfessionalInfo = sqlMem_ProfessionalInfoProvider.GetMem_ProfessionalInfoByID(id);
        return mem_ProfessionalInfo;
    }


    public static int InsertMem_ProfessionalInfo(Mem_ProfessionalInfo mem_ProfessionalInfo)
    {
        SqlMem_ProfessionalInfoProvider sqlMem_ProfessionalInfoProvider = new SqlMem_ProfessionalInfoProvider();
        return sqlMem_ProfessionalInfoProvider.InsertMem_ProfessionalInfo(mem_ProfessionalInfo);
    }


    public static bool UpdateMem_ProfessionalInfo(Mem_ProfessionalInfo mem_ProfessionalInfo)
    {
        SqlMem_ProfessionalInfoProvider sqlMem_ProfessionalInfoProvider = new SqlMem_ProfessionalInfoProvider();
        return sqlMem_ProfessionalInfoProvider.UpdateMem_ProfessionalInfo(mem_ProfessionalInfo);
    }

    public static bool DeleteMem_ProfessionalInfo(int mem_ProfessionalInfoID)
    {
        SqlMem_ProfessionalInfoProvider sqlMem_ProfessionalInfoProvider = new SqlMem_ProfessionalInfoProvider();
        return sqlMem_ProfessionalInfoProvider.DeleteMem_ProfessionalInfo(mem_ProfessionalInfoID);
    }
}

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

public class Mem_FeesManager
{
	public Mem_FeesManager()
	{
	}

    public static List<Mem_Fees> GetAllMem_Feess()
    {
        List<Mem_Fees> mem_Feess = new List<Mem_Fees>();
        SqlMem_FeesProvider sqlMem_FeesProvider = new SqlMem_FeesProvider();
        mem_Feess = sqlMem_FeesProvider.GetAllMem_Feess();
        return mem_Feess;
    }


    public static Mem_Fees GetMem_FeesByID(int id)
    {
        Mem_Fees mem_Fees = new Mem_Fees();
        SqlMem_FeesProvider sqlMem_FeesProvider = new SqlMem_FeesProvider();
        mem_Fees = sqlMem_FeesProvider.GetMem_FeesByID(id);
        return mem_Fees;
    }


    public static int InsertMem_Fees(Mem_Fees mem_Fees)
    {
        SqlMem_FeesProvider sqlMem_FeesProvider = new SqlMem_FeesProvider();
        return sqlMem_FeesProvider.InsertMem_Fees(mem_Fees);
    }


    public static bool UpdateMem_Fees(Mem_Fees mem_Fees)
    {
        SqlMem_FeesProvider sqlMem_FeesProvider = new SqlMem_FeesProvider();
        return sqlMem_FeesProvider.UpdateMem_Fees(mem_Fees);
    }

    public static bool DeleteMem_Fees(int mem_FeesID)
    {
        SqlMem_FeesProvider sqlMem_FeesProvider = new SqlMem_FeesProvider();
        return sqlMem_FeesProvider.DeleteMem_Fees(mem_FeesID);
    }
}

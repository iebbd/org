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

public class Mem_RAJUKManager
{
	public Mem_RAJUKManager()
	{
	}

    public static List<Mem_RAJUK> GetAllMem_RAJUKs()
    {
        List<Mem_RAJUK> mem_RAJUKs = new List<Mem_RAJUK>();
        SqlMem_RAJUKProvider sqlMem_RAJUKProvider = new SqlMem_RAJUKProvider();
        mem_RAJUKs = sqlMem_RAJUKProvider.GetAllMem_RAJUKs();
        return mem_RAJUKs;
    }


    public static Mem_RAJUK GetMem_RAJUKByID(int id)
    {
        Mem_RAJUK mem_RAJUK = new Mem_RAJUK();
        SqlMem_RAJUKProvider sqlMem_RAJUKProvider = new SqlMem_RAJUKProvider();
        mem_RAJUK = sqlMem_RAJUKProvider.GetMem_RAJUKByID(id);
        return mem_RAJUK;
    }


    public static int InsertMem_RAJUK(Mem_RAJUK mem_RAJUK)
    {
        SqlMem_RAJUKProvider sqlMem_RAJUKProvider = new SqlMem_RAJUKProvider();
        return sqlMem_RAJUKProvider.InsertMem_RAJUK(mem_RAJUK);
    }


    public static bool UpdateMem_RAJUK(Mem_RAJUK mem_RAJUK)
    {
        SqlMem_RAJUKProvider sqlMem_RAJUKProvider = new SqlMem_RAJUKProvider();
        return sqlMem_RAJUKProvider.UpdateMem_RAJUK(mem_RAJUK);
    }

    public static bool DeleteMem_RAJUK(int mem_RAJUKID)
    {
        SqlMem_RAJUKProvider sqlMem_RAJUKProvider = new SqlMem_RAJUKProvider();
        return sqlMem_RAJUKProvider.DeleteMem_RAJUK(mem_RAJUKID);
    }
}

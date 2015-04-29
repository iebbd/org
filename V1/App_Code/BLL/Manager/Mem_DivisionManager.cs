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

public class Mem_DivisionManager
{
	public Mem_DivisionManager()
	{
	}

    public static List<Mem_Division> GetAllMem_Divisions()
    {
        List<Mem_Division> mem_Divisions = new List<Mem_Division>();
        SqlMem_DivisionProvider sqlMem_DivisionProvider = new SqlMem_DivisionProvider();
        mem_Divisions = sqlMem_DivisionProvider.GetAllMem_Divisions();
        return mem_Divisions;
    }


    public static Mem_Division GetMem_DivisionByID(int id)
    {
        Mem_Division mem_Division = new Mem_Division();
        SqlMem_DivisionProvider sqlMem_DivisionProvider = new SqlMem_DivisionProvider();
        mem_Division = sqlMem_DivisionProvider.GetMem_DivisionByID(id);
        return mem_Division;
    }


    public static int InsertMem_Division(Mem_Division mem_Division)
    {
        SqlMem_DivisionProvider sqlMem_DivisionProvider = new SqlMem_DivisionProvider();
        return sqlMem_DivisionProvider.InsertMem_Division(mem_Division);
    }


    public static bool UpdateMem_Division(Mem_Division mem_Division)
    {
        SqlMem_DivisionProvider sqlMem_DivisionProvider = new SqlMem_DivisionProvider();
        return sqlMem_DivisionProvider.UpdateMem_Division(mem_Division);
    }

    public static bool DeleteMem_Division(int mem_DivisionID)
    {
        SqlMem_DivisionProvider sqlMem_DivisionProvider = new SqlMem_DivisionProvider();
        return sqlMem_DivisionProvider.DeleteMem_Division(mem_DivisionID);
    }
}

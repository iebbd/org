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

public class Mem_SubDivisionManager
{
	public Mem_SubDivisionManager()
	{
	}

    public static List<Mem_SubDivision> GetAllMem_SubDivisions()
    {
        List<Mem_SubDivision> mem_SubDivisions = new List<Mem_SubDivision>();
        SqlMem_SubDivisionProvider sqlMem_SubDivisionProvider = new SqlMem_SubDivisionProvider();
        mem_SubDivisions = sqlMem_SubDivisionProvider.GetAllMem_SubDivisions();
        return mem_SubDivisions;
    }


    public static Mem_SubDivision GetMem_SubDivisionByID(int id)
    {
        Mem_SubDivision mem_SubDivision = new Mem_SubDivision();
        SqlMem_SubDivisionProvider sqlMem_SubDivisionProvider = new SqlMem_SubDivisionProvider();
        mem_SubDivision = sqlMem_SubDivisionProvider.GetMem_SubDivisionByID(id);
        return mem_SubDivision;
    }


    public static int InsertMem_SubDivision(Mem_SubDivision mem_SubDivision)
    {
        SqlMem_SubDivisionProvider sqlMem_SubDivisionProvider = new SqlMem_SubDivisionProvider();
        return sqlMem_SubDivisionProvider.InsertMem_SubDivision(mem_SubDivision);
    }


    public static bool UpdateMem_SubDivision(Mem_SubDivision mem_SubDivision)
    {
        SqlMem_SubDivisionProvider sqlMem_SubDivisionProvider = new SqlMem_SubDivisionProvider();
        return sqlMem_SubDivisionProvider.UpdateMem_SubDivision(mem_SubDivision);
    }

    public static bool DeleteMem_SubDivision(int mem_SubDivisionID)
    {
        SqlMem_SubDivisionProvider sqlMem_SubDivisionProvider = new SqlMem_SubDivisionProvider();
        return sqlMem_SubDivisionProvider.DeleteMem_SubDivision(mem_SubDivisionID);
    }
}

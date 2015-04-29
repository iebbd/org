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

public class Mem_RecomendationManager
{
	public Mem_RecomendationManager()
	{
	}

    public static List<Mem_Recomendation> GetAllMem_Recomendations()
    {
        List<Mem_Recomendation> mem_Recomendations = new List<Mem_Recomendation>();
        SqlMem_RecomendationProvider sqlMem_RecomendationProvider = new SqlMem_RecomendationProvider();
        mem_Recomendations = sqlMem_RecomendationProvider.GetAllMem_Recomendations();
        return mem_Recomendations;
    }


    public static Mem_Recomendation GetMem_RecomendationByID(int id)
    {
        Mem_Recomendation mem_Recomendation = new Mem_Recomendation();
        SqlMem_RecomendationProvider sqlMem_RecomendationProvider = new SqlMem_RecomendationProvider();
        mem_Recomendation = sqlMem_RecomendationProvider.GetMem_RecomendationByID(id);
        return mem_Recomendation;
    }


    public static int InsertMem_Recomendation(Mem_Recomendation mem_Recomendation)
    {
        SqlMem_RecomendationProvider sqlMem_RecomendationProvider = new SqlMem_RecomendationProvider();
        return sqlMem_RecomendationProvider.InsertMem_Recomendation(mem_Recomendation);
    }


    public static bool UpdateMem_Recomendation(Mem_Recomendation mem_Recomendation)
    {
        SqlMem_RecomendationProvider sqlMem_RecomendationProvider = new SqlMem_RecomendationProvider();
        return sqlMem_RecomendationProvider.UpdateMem_Recomendation(mem_Recomendation);
    }

    public static bool DeleteMem_Recomendation(int mem_RecomendationID)
    {
        SqlMem_RecomendationProvider sqlMem_RecomendationProvider = new SqlMem_RecomendationProvider();
        return sqlMem_RecomendationProvider.DeleteMem_Recomendation(mem_RecomendationID);
    }
}

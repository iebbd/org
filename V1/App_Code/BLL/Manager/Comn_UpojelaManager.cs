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

public class Comn_UpojelaManager
{
	public Comn_UpojelaManager()
	{
	}

    public static List<Comn_Upojela> GetAllComn_Upojelas()
    {
        List<Comn_Upojela> comn_Upojelas = new List<Comn_Upojela>();
        SqlComn_UpojelaProvider sqlComn_UpojelaProvider = new SqlComn_UpojelaProvider();
        comn_Upojelas = sqlComn_UpojelaProvider.GetAllComn_Upojelas();
        return comn_Upojelas;
    }


    public static Comn_Upojela GetComn_UpojelaByID(int id)
    {
        Comn_Upojela comn_Upojela = new Comn_Upojela();
        SqlComn_UpojelaProvider sqlComn_UpojelaProvider = new SqlComn_UpojelaProvider();
        comn_Upojela = sqlComn_UpojelaProvider.GetComn_UpojelaByID(id);
        return comn_Upojela;
    }


    public static int InsertComn_Upojela(Comn_Upojela comn_Upojela)
    {
        SqlComn_UpojelaProvider sqlComn_UpojelaProvider = new SqlComn_UpojelaProvider();
        return sqlComn_UpojelaProvider.InsertComn_Upojela(comn_Upojela);
    }


    public static bool UpdateComn_Upojela(Comn_Upojela comn_Upojela)
    {
        SqlComn_UpojelaProvider sqlComn_UpojelaProvider = new SqlComn_UpojelaProvider();
        return sqlComn_UpojelaProvider.UpdateComn_Upojela(comn_Upojela);
    }

    public static bool DeleteComn_Upojela(int comn_UpojelaID)
    {
        SqlComn_UpojelaProvider sqlComn_UpojelaProvider = new SqlComn_UpojelaProvider();
        return sqlComn_UpojelaProvider.DeleteComn_Upojela(comn_UpojelaID);
    }
}

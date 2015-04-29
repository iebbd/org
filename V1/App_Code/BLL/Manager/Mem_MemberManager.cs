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

public class Mem_MemberManager
{
	public Mem_MemberManager()
	{
	}

    public static List<Mem_Member> GetAllMem_Members()
    {
        List<Mem_Member> mem_Members = new List<Mem_Member>();
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        mem_Members = sqlMem_MemberProvider.GetAllMem_Members();
        return mem_Members;
    }


    public static Mem_Member GetMem_MemberByID(int id)
    {
        Mem_Member mem_Member = new Mem_Member();
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        mem_Member = sqlMem_MemberProvider.GetMem_MemberByID(id);
        return mem_Member;
    }

    public static Mem_Member GetMem_Applied_MemberByID(int id)
    {
        Mem_Member mem_Member = new Mem_Member();
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        mem_Member = sqlMem_MemberProvider.GetMem_Applied_MemberByID(id);
        return mem_Member;
    }


    public static int InsertMem_Member(Mem_Member mem_Member)
    {
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        return sqlMem_MemberProvider.InsertMem_Member(mem_Member);
    }

    public static int InsertMem_Applied_Member(Mem_Member mem_Member)
    {
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        return sqlMem_MemberProvider.InsertMem_Applied_Member(mem_Member);
    }


    public static bool UpdateMem_Member(Mem_Member mem_Member)
    {
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        return sqlMem_MemberProvider.UpdateMem_Member(mem_Member);
    }

    public static bool UpdateMem_Applied_Member(Mem_Member mem_Member)
    {
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        return sqlMem_MemberProvider.UpdateMem_Applied_Member(mem_Member);
    }


    public static bool DeleteMem_Member(int mem_MemberID)
    {
        SqlMem_MemberProvider sqlMem_MemberProvider = new SqlMem_MemberProvider();
        return sqlMem_MemberProvider.DeleteMem_Member(mem_MemberID);
    }
}

using System;
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

public class Mem_MemberCategory
{
    public Mem_MemberCategory()
    {
    }

    public Mem_MemberCategory
        (
        int mem_MemberCategoryID, 
        string mem_MemberCategoryName, 
        string details
        )
    {
        this.Mem_MemberCategoryID = mem_MemberCategoryID;
        this.Mem_MemberCategoryName = mem_MemberCategoryName;
        this.Details = details;
    }


    private int _mem_MemberCategoryID;
    public int Mem_MemberCategoryID
    {
        get { return _mem_MemberCategoryID; }
        set { _mem_MemberCategoryID = value; }
    }

    private string _mem_MemberCategoryName;
    public string Mem_MemberCategoryName
    {
        get { return _mem_MemberCategoryName; }
        set { _mem_MemberCategoryName = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }
}

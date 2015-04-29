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

public class Mem_SubDivision
{
    public Mem_SubDivision()
    {
    }

    public Mem_SubDivision
        (
        int mem_SubDivisionID, 
        string mem_SubDivisionName, 
        int mem_DivisionID, 
        string website, 
        string fullName, 
        string contactInfo, 
        string details
        )
    {
        this.Mem_SubDivisionID = mem_SubDivisionID;
        this.Mem_SubDivisionName = mem_SubDivisionName;
        this.Mem_DivisionID = mem_DivisionID;
        this.Website = website;
        this.FullName = fullName;
        this.ContactInfo = contactInfo;
        this.Details = details;
    }


    private int _mem_SubDivisionID;
    public int Mem_SubDivisionID
    {
        get { return _mem_SubDivisionID; }
        set { _mem_SubDivisionID = value; }
    }

    private string _mem_SubDivisionName;
    public string Mem_SubDivisionName
    {
        get { return _mem_SubDivisionName; }
        set { _mem_SubDivisionName = value; }
    }

    private int _mem_DivisionID;
    public int Mem_DivisionID
    {
        get { return _mem_DivisionID; }
        set { _mem_DivisionID = value; }
    }

    private string _website;
    public string Website
    {
        get { return _website; }
        set { _website = value; }
    }

    private string _fullName;
    public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }

    private string _contactInfo;
    public string ContactInfo
    {
        get { return _contactInfo; }
        set { _contactInfo = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }
}

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

public class Mem_Division
{
    public Mem_Division()
    {
    }

    public Mem_Division
        (
        int mem_DivisionID, 
        string mem_DivisionName, 
        string website, 
        string fullName, 
        string contactInfo, 
        string details
        )
    {
        this.Mem_DivisionID = mem_DivisionID;
        this.Mem_DivisionName = mem_DivisionName;
        this.Website = website;
        this.FullName = fullName;
        this.ContactInfo = contactInfo;
        this.Details = details;
    }


    private int _mem_DivisionID;
    public int Mem_DivisionID
    {
        get { return _mem_DivisionID; }
        set { _mem_DivisionID = value; }
    }

    private string _mem_DivisionName;
    public string Mem_DivisionName
    {
        get { return _mem_DivisionName; }
        set { _mem_DivisionName = value; }
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

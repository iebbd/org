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

public class Comn_University
{
    public Comn_University()
    {
    }

    public Comn_University
        (
        int comn_UniversityID, 
        string comn_UniversityName, 
        string website, 
        string phone, 
        string fax, 
        int type, 
        string details, 
        string oldName
        )
    {
        this.Comn_UniversityID = comn_UniversityID;
        this.Comn_UniversityName = comn_UniversityName;
        this.Website = website;
        this.Phone = phone;
        this.Fax = fax;
        this.Type = type;
        this.Details = details;
        this.OldName = oldName;
    }


    private int _comn_UniversityID;
    public int Comn_UniversityID
    {
        get { return _comn_UniversityID; }
        set { _comn_UniversityID = value; }
    }

    private string _comn_UniversityName;
    public string Comn_UniversityName
    {
        get { return _comn_UniversityName; }
        set { _comn_UniversityName = value; }
    }

    private string _website;
    public string Website
    {
        get { return _website; }
        set { _website = value; }
    }

    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    private string _fax;
    public string Fax
    {
        get { return _fax; }
        set { _fax = value; }
    }

    private int _type;
    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }

    private string _oldName;
    public string OldName
    {
        get { return _oldName; }
        set { _oldName = value; }
    }
}

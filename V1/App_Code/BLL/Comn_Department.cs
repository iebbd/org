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

public class Comn_Department
{
    public Comn_Department()
    {
    }

    public Comn_Department
        (
        int comn_DepartmentID, 
        string comn_DepartmentName, 
        string website, 
        string phone, 
        string fax, 
        int type, 
        string details, 
        string oldName
        )
    {
        this.Comn_DepartmentID = comn_DepartmentID;
        this.Comn_DepartmentName = comn_DepartmentName;
        this.Website = website;
        this.Phone = phone;
        this.Fax = fax;
        this.Type = type;
        this.Details = details;
        this.OldName = oldName;
    }


    private int _comn_DepartmentID;
    public int Comn_DepartmentID
    {
        get { return _comn_DepartmentID; }
        set { _comn_DepartmentID = value; }
    }

    private string _comn_DepartmentName;
    public string Comn_DepartmentName
    {
        get { return _comn_DepartmentName; }
        set { _comn_DepartmentName = value; }
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

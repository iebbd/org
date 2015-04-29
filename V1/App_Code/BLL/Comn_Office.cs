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

public class Comn_Office
{
    public Comn_Office()
    {
    }

    public Comn_Office
        (
        int comn_OfficeID, 
        string comn_OfficeName, 
        int comm_OfficeTypeID, 
        int upperLabelOfficeID, 
        string website, 
        string phone, 
        string fax, 
        string details
        )
    {
        this.Comn_OfficeID = comn_OfficeID;
        this.Comn_OfficeName = comn_OfficeName;
        this.Comm_OfficeTypeID = comm_OfficeTypeID;
        this.UpperLabelOfficeID = upperLabelOfficeID;
        this.Website = website;
        this.Phone = phone;
        this.Fax = fax;
        this.Details = details;
    }


    private int _comn_OfficeID;
    public int Comn_OfficeID
    {
        get { return _comn_OfficeID; }
        set { _comn_OfficeID = value; }
    }

    private string _comn_OfficeName;
    public string Comn_OfficeName
    {
        get { return _comn_OfficeName; }
        set { _comn_OfficeName = value; }
    }

    private int _comm_OfficeTypeID;
    public int Comm_OfficeTypeID
    {
        get { return _comm_OfficeTypeID; }
        set { _comm_OfficeTypeID = value; }
    }

    private int _upperLabelOfficeID;
    public int UpperLabelOfficeID
    {
        get { return _upperLabelOfficeID; }
        set { _upperLabelOfficeID = value; }
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

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }
}

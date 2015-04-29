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

public class Conv_JobFair
{
    public Conv_JobFair()
    {
    }

    public Conv_JobFair
        (
        int conv_JobFairID, 
        string name, 
        string iEBMembershipNo, 
        string institution, 
        string deprtment, 
        string passingYear, 
        string mobile, 
        string email, 
        string details, 
        string officeName, 
        string trxID, 
        string extraField1, 
        string extraField2, 
        string extraField3, 
        string extraField4, 
        string extraField5, 
        DateTime addedDate
        )
    {
        this.Conv_JobFairID = conv_JobFairID;
        this.Name = name;
        this.IEBMembershipNo = iEBMembershipNo;
        this.Institution = institution;
        this.Deprtment = deprtment;
        this.PassingYear = passingYear;
        this.Mobile = mobile;
        this.Email = email;
        this.Details = details;
        this.OfficeName = officeName;
        this.TrxID = trxID;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
        this.AddedDate = addedDate;
    }


    private int _conv_JobFairID;
    public int Conv_JobFairID
    {
        get { return _conv_JobFairID; }
        set { _conv_JobFairID = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _iEBMembershipNo;
    public string IEBMembershipNo
    {
        get { return _iEBMembershipNo; }
        set { _iEBMembershipNo = value; }
    }

    private string _institution;
    public string Institution
    {
        get { return _institution; }
        set { _institution = value; }
    }

    private string _deprtment;
    public string Deprtment
    {
        get { return _deprtment; }
        set { _deprtment = value; }
    }

    private string _passingYear;
    public string PassingYear
    {
        get { return _passingYear; }
        set { _passingYear = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }

    private string _officeName;
    public string OfficeName
    {
        get { return _officeName; }
        set { _officeName = value; }
    }

    private string _trxID;
    public string TrxID
    {
        get { return _trxID; }
        set { _trxID = value; }
    }

    private string _extraField1;
    public string ExtraField1
    {
        get { return _extraField1; }
        set { _extraField1 = value; }
    }

    private string _extraField2;
    public string ExtraField2
    {
        get { return _extraField2; }
        set { _extraField2 = value; }
    }

    private string _extraField3;
    public string ExtraField3
    {
        get { return _extraField3; }
        set { _extraField3 = value; }
    }

    private string _extraField4;
    public string ExtraField4
    {
        get { return _extraField4; }
        set { _extraField4 = value; }
    }

    private string _extraField5;
    public string ExtraField5
    {
        get { return _extraField5; }
        set { _extraField5 = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }
}

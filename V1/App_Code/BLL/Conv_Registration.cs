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

public class Conv_Registration
{
    public Conv_Registration()
    {
    }

    public Conv_Registration
        (
        int conv_RegistrationID, 
        int conv_ConventionID, 
        int mem_MemberID, 
        int registrationFee, 
        int lunch1No, 
        int lunch1Amount, 
        int lunch2No, 
        int lunch2Amount, 
        int dinner1, 
        int dinner2, 
        int ladiesBag, 
        int iEBTie, 
        int totalIEBFee, 
        int bKashFees, 
        int totalPayable, 
        string trxID, 
        DateTime addedDate, 
        int typeID, 
        int statusID, 
        string extraField1, 
        string extraField2, 
        string extraField3, 
        string extraField4, 
        string extraField5
        )
    {
        this.Conv_RegistrationID = conv_RegistrationID;
        this.Conv_ConventionID = conv_ConventionID;
        this.Mem_MemberID = mem_MemberID;
        this.RegistrationFee = registrationFee;
        this.Lunch1No = lunch1No;
        this.Lunch1Amount = lunch1Amount;
        this.Lunch2No = lunch2No;
        this.Lunch2Amount = lunch2Amount;
        this.Dinner1 = dinner1;
        this.Dinner2 = dinner2;
        this.LadiesBag = ladiesBag;
        this.IEBTie = iEBTie;
        this.TotalIEBFee = totalIEBFee;
        this.BKashFees = bKashFees;
        this.TotalPayable = totalPayable;
        this.TrxID = trxID;
        this.AddedDate = addedDate;
        this.TypeID = typeID;
        this.StatusID = statusID;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
    }


    private int _conv_RegistrationID;
    public int Conv_RegistrationID
    {
        get { return _conv_RegistrationID; }
        set { _conv_RegistrationID = value; }
    }

    private int _conv_ConventionID;
    public int Conv_ConventionID
    {
        get { return _conv_ConventionID; }
        set { _conv_ConventionID = value; }
    }

    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private int _registrationFee;
    public int RegistrationFee
    {
        get { return _registrationFee; }
        set { _registrationFee = value; }
    }

    private int _lunch1No;
    public int Lunch1No
    {
        get { return _lunch1No; }
        set { _lunch1No = value; }
    }

    private int _lunch1Amount;
    public int Lunch1Amount
    {
        get { return _lunch1Amount; }
        set { _lunch1Amount = value; }
    }

    private int _lunch2No;
    public int Lunch2No
    {
        get { return _lunch2No; }
        set { _lunch2No = value; }
    }

    private int _lunch2Amount;
    public int Lunch2Amount
    {
        get { return _lunch2Amount; }
        set { _lunch2Amount = value; }
    }

    private int _dinner1;
    public int Dinner1
    {
        get { return _dinner1; }
        set { _dinner1 = value; }
    }

    private int _dinner2;
    public int Dinner2
    {
        get { return _dinner2; }
        set { _dinner2 = value; }
    }

    private int _ladiesBag;
    public int LadiesBag
    {
        get { return _ladiesBag; }
        set { _ladiesBag = value; }
    }

    private int _iEBTie;
    public int IEBTie
    {
        get { return _iEBTie; }
        set { _iEBTie = value; }
    }

    private int _totalIEBFee;
    public int TotalIEBFee
    {
        get { return _totalIEBFee; }
        set { _totalIEBFee = value; }
    }

    private int _bKashFees;
    public int BKashFees
    {
        get { return _bKashFees; }
        set { _bKashFees = value; }
    }

    private int _totalPayable;
    public int TotalPayable
    {
        get { return _totalPayable; }
        set { _totalPayable = value; }
    }

    private string _trxID;
    public string TrxID
    {
        get { return _trxID; }
        set { _trxID = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private int _typeID;
    public int TypeID
    {
        get { return _typeID; }
        set { _typeID = value; }
    }

    private int _statusID;
    public int StatusID
    {
        get { return _statusID; }
        set { _statusID = value; }
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
}

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

public class Mem_Fees
{
    public Mem_Fees()
    {
    }

    public Mem_Fees
        (
        int mem_FeesID, 
        int mem_MemberID, 
        decimal amount, 
        string datePaid, 
        string paidFor, 
        string extraField, 
        DateTime addedDate, 
        int addedBy, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int comn_RowStatusID, 
        string refferenceNo, 
        int comn_PaymentByID
        )
    {
        this.Mem_FeesID = mem_FeesID;
        this.Mem_MemberID = mem_MemberID;
        this.Amount = amount;
        this.DatePaid = datePaid;
        this.PaidFor = paidFor;
        this.ExtraField = extraField;
        this.AddedDate = addedDate;
        this.AddedBy = addedBy;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Comn_RowStatusID = comn_RowStatusID;
        this.RefferenceNo = refferenceNo;
        this.Comn_PaymentByID = comn_PaymentByID;
    }


    private int _mem_FeesID;
    public int Mem_FeesID
    {
        get { return _mem_FeesID; }
        set { _mem_FeesID = value; }
    }

    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    private string _datePaid;
    public string DatePaid
    {
        get { return _datePaid; }
        set { _datePaid = value; }
    }

    private string _paidFor;
    public string PaidFor
    {
        get { return _paidFor; }
        set { _paidFor = value; }
    }

    private string _extraField;
    public string ExtraField
    {
        get { return _extraField; }
        set { _extraField = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private int _addedBy;
    public int AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _comn_RowStatusID;
    public int Comn_RowStatusID
    {
        get { return _comn_RowStatusID; }
        set { _comn_RowStatusID = value; }
    }

    private string _refferenceNo;
    public string RefferenceNo
    {
        get { return _refferenceNo; }
        set { _refferenceNo = value; }
    }

    private int _comn_PaymentByID;
    public int Comn_PaymentByID
    {
        get { return _comn_PaymentByID; }
        set { _comn_PaymentByID = value; }
    }
}

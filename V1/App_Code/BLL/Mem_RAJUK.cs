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

public class Mem_RAJUK
{
    public Mem_RAJUK()
    {
    }

    public Mem_RAJUK
        (
        int mem_RAJUKID, 
        int mem_MemberID, 
        string membershipNo, 
        string rAJUKRegistrationNo, 
        string batch, 
        string examDate, 
        string telephone, 
        string email, 
        char typeOfMemeber, 
        int membershipNoValue, 
        string membershipNoValueChar
        )
    {
        this.Mem_RAJUKID = mem_RAJUKID;
        this.Mem_MemberID = mem_MemberID;
        this.MembershipNo = membershipNo;
        this.RAJUKRegistrationNo = rAJUKRegistrationNo;
        this.Batch = batch;
        this.ExamDate = examDate;
        this.Telephone = telephone;
        this.Email = email;
        this.TypeOfMemeber = typeOfMemeber;
        this.MembershipNoValue = membershipNoValue;
        this.MembershipNoValueChar = membershipNoValueChar;
    }


    private int _mem_RAJUKID;
    public int Mem_RAJUKID
    {
        get { return _mem_RAJUKID; }
        set { _mem_RAJUKID = value; }
    }

    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private string _membershipNo;
    public string MembershipNo
    {
        get { return _membershipNo; }
        set { _membershipNo = value; }
    }

    private string _rAJUKRegistrationNo;
    public string RAJUKRegistrationNo
    {
        get { return _rAJUKRegistrationNo; }
        set { _rAJUKRegistrationNo = value; }
    }

    private string _batch;
    public string Batch
    {
        get { return _batch; }
        set { _batch = value; }
    }

    private string _examDate;
    public string ExamDate
    {
        get { return _examDate; }
        set { _examDate = value; }
    }

    private string _telephone;
    public string Telephone
    {
        get { return _telephone; }
        set { _telephone = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private char _typeOfMemeber;
    public char TypeOfMemeber
    {
        get { return _typeOfMemeber; }
        set { _typeOfMemeber = value; }
    }

    private int _membershipNoValue;
    public int MembershipNoValue
    {
        get { return _membershipNoValue; }
        set { _membershipNoValue = value; }
    }

    private string _membershipNoValueChar;
    public string MembershipNoValueChar
    {
        get { return _membershipNoValueChar; }
        set { _membershipNoValueChar = value; }
    }
}

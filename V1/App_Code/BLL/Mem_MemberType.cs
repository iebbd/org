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

public class Mem_MemberType
{
    public Mem_MemberType()
    {
    }

    public Mem_MemberType
        (
        int mem_MemberTypeID, 
        string mem_MemberTypeName, 
        int mem_MemberCategoryID, 
        string details, 
        decimal entranceFee, 
        decimal annaralSubscriptionFee, 
        decimal diplomaFee, 
        int age, 
        string experience
        )
    {
        this.Mem_MemberTypeID = mem_MemberTypeID;
        this.Mem_MemberTypeName = mem_MemberTypeName;
        this.Mem_MemberCategoryID = mem_MemberCategoryID;
        this.Details = details;
        this.EntranceFee = entranceFee;
        this.AnnaralSubscriptionFee = annaralSubscriptionFee;
        this.DiplomaFee = diplomaFee;
        this.Age = age;
        this.Experience = experience;
    }


    private int _mem_MemberTypeID;
    public int Mem_MemberTypeID
    {
        get { return _mem_MemberTypeID; }
        set { _mem_MemberTypeID = value; }
    }

    private string _mem_MemberTypeName;
    public string Mem_MemberTypeName
    {
        get { return _mem_MemberTypeName; }
        set { _mem_MemberTypeName = value; }
    }

    private int _mem_MemberCategoryID;
    public int Mem_MemberCategoryID
    {
        get { return _mem_MemberCategoryID; }
        set { _mem_MemberCategoryID = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }

    private decimal _entranceFee;
    public decimal EntranceFee
    {
        get { return _entranceFee; }
        set { _entranceFee = value; }
    }

    private decimal _annaralSubscriptionFee;
    public decimal AnnaralSubscriptionFee
    {
        get { return _annaralSubscriptionFee; }
        set { _annaralSubscriptionFee = value; }
    }

    private decimal _diplomaFee;
    public decimal DiplomaFee
    {
        get { return _diplomaFee; }
        set { _diplomaFee = value; }
    }

    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    private string _experience;
    public string Experience
    {
        get { return _experience; }
        set { _experience = value; }
    }
}

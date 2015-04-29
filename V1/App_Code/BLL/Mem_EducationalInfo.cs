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

public class Mem_EducationalInfo
{
    public Mem_EducationalInfo()
    {
    }

    public Mem_EducationalInfo
        (
        int mem_EducationalInfoID, 
        int mem_MemberID, 
        int comn_GegreeID, 
        string instituteName, 
        int comn_UniversityID, 
        int comn_DepartmentID, 
        string degreeTitle, 
        string yearOfPassing, 
        int comn_ResultTypeID, 
        string result, 
        string details, 
        int addedBy, 
        DateTime addedDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int comn_RowStatusID
        )
    {
        this.Mem_EducationalInfoID = mem_EducationalInfoID;
        this.Mem_MemberID = mem_MemberID;
        this.Comn_GegreeID = comn_GegreeID;
        this.InstituteName = instituteName;
        this.Comn_UniversityID = comn_UniversityID;
        this.Comn_DepartmentID = comn_DepartmentID;
        this.DegreeTitle = degreeTitle;
        this.YearOfPassing = yearOfPassing;
        this.Comn_ResultTypeID = comn_ResultTypeID;
        this.Result = result;
        this.Details = details;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Comn_RowStatusID = comn_RowStatusID;
    }


    private int _mem_EducationalInfoID;
    public int Mem_EducationalInfoID
    {
        get { return _mem_EducationalInfoID; }
        set { _mem_EducationalInfoID = value; }
    }

    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private int _comn_GegreeID;
    public int Comn_GegreeID
    {
        get { return _comn_GegreeID; }
        set { _comn_GegreeID = value; }
    }

    private string _instituteName;
    public string InstituteName
    {
        get { return _instituteName; }
        set { _instituteName = value; }
    }

    private int _comn_UniversityID;
    public int Comn_UniversityID
    {
        get { return _comn_UniversityID; }
        set { _comn_UniversityID = value; }
    }

    private int _comn_DepartmentID;
    public int Comn_DepartmentID
    {
        get { return _comn_DepartmentID; }
        set { _comn_DepartmentID = value; }
    }

    private string _degreeTitle;
    public string DegreeTitle
    {
        get { return _degreeTitle; }
        set { _degreeTitle = value; }
    }

    private string _yearOfPassing;
    public string YearOfPassing
    {
        get { return _yearOfPassing; }
        set { _yearOfPassing = value; }
    }

    private int _comn_ResultTypeID;
    public int Comn_ResultTypeID
    {
        get { return _comn_ResultTypeID; }
        set { _comn_ResultTypeID = value; }
    }

    private string _result;
    public string Result
    {
        get { return _result; }
        set { _result = value; }
    }

    private string _details;
    public string Details
    {
        get { return _details; }
        set { _details = value; }
    }

    private int _addedBy;
    public int AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
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
}

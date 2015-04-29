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

public class Mem_ProfessionalInfo
{
    public Mem_ProfessionalInfo()
    {
    }

    public Mem_ProfessionalInfo
        (
        int mem_ProfessionalInfoID, 
        string fromDate, 
        string toDate, 
        string designation, 
        int comn_OfficeID, 
        string details, 
        int addedBy, 
        DateTime addedDate, 
        int updatedBy, 
        DateTime updatedDate, 
        int comn_RowStatusID
        )
    {
        this.Mem_ProfessionalInfoID = mem_ProfessionalInfoID;
        this.FromDate = fromDate;
        this.ToDate = toDate;
        this.Designation = designation;
        this.Comn_OfficeID = comn_OfficeID;
        this.Details = details;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.Comn_RowStatusID = comn_RowStatusID;
    }


    private int _mem_ProfessionalInfoID;
    public int Mem_ProfessionalInfoID
    {
        get { return _mem_ProfessionalInfoID; }
        set { _mem_ProfessionalInfoID = value; }
    }

    private string _fromDate;
    public string FromDate
    {
        get { return _fromDate; }
        set { _fromDate = value; }
    }

    private string _toDate;
    public string ToDate
    {
        get { return _toDate; }
        set { _toDate = value; }
    }

    private string _designation;
    public string Designation
    {
        get { return _designation; }
        set { _designation = value; }
    }

    private int _comn_OfficeID;
    public int Comn_OfficeID
    {
        get { return _comn_OfficeID; }
        set { _comn_OfficeID = value; }
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

    private int _updatedBy;
    public int UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private int _comn_RowStatusID;
    public int Comn_RowStatusID
    {
        get { return _comn_RowStatusID; }
        set { _comn_RowStatusID = value; }
    }
}

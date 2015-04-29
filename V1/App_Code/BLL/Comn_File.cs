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

public class Comn_File
{
    public Comn_File()
    {
    }

    public Comn_File
        (
        int comn_FileID, 
        int comn_FileTypeID, 
        string fileName, 
        int addedBy, 
        DateTime addedDate, 
        int updatedBy, 
        DateTime updatedDate, 
        int comn_RowStatusID
        )
    {
        this.Comn_FileID = comn_FileID;
        this.Comn_FileTypeID = comn_FileTypeID;
        this.FileName = fileName;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.Comn_RowStatusID = comn_RowStatusID;
    }


    private int _comn_FileID;
    public int Comn_FileID
    {
        get { return _comn_FileID; }
        set { _comn_FileID = value; }
    }

    private int _comn_FileTypeID;
    public int Comn_FileTypeID
    {
        get { return _comn_FileTypeID; }
        set { _comn_FileTypeID = value; }
    }

    private string _fileName;
    public string FileName
    {
        get { return _fileName; }
        set { _fileName = value; }
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

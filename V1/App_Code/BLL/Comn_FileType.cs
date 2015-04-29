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

public class Comn_FileType
{
    public Comn_FileType()
    {
    }

    public Comn_FileType
        (
        int comn_FileTypeID, 
        string comn_FileTypeName
        )
    {
        this.Comn_FileTypeID = comn_FileTypeID;
        this.Comn_FileTypeName = comn_FileTypeName;
    }


    private int _comn_FileTypeID;
    public int Comn_FileTypeID
    {
        get { return _comn_FileTypeID; }
        set { _comn_FileTypeID = value; }
    }

    private string _comn_FileTypeName;
    public string Comn_FileTypeName
    {
        get { return _comn_FileTypeName; }
        set { _comn_FileTypeName = value; }
    }
}

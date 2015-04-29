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

public class Comn_OfficeType
{
    public Comn_OfficeType()
    {
    }

    public Comn_OfficeType
        (
        int comn_OfficeTypeID, 
        string comn_OfficeTypeName
        )
    {
        this.Comn_OfficeTypeID = comn_OfficeTypeID;
        this.Comn_OfficeTypeName = comn_OfficeTypeName;
    }


    private int _comn_OfficeTypeID;
    public int Comn_OfficeTypeID
    {
        get { return _comn_OfficeTypeID; }
        set { _comn_OfficeTypeID = value; }
    }

    private string _comn_OfficeTypeName;
    public string Comn_OfficeTypeName
    {
        get { return _comn_OfficeTypeName; }
        set { _comn_OfficeTypeName = value; }
    }
}

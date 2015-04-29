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

public class Comn_RowStatus
{
    public Comn_RowStatus()
    {
    }

    public Comn_RowStatus
        (
        int comn_RowStatusID, 
        string comn_RowStatusName
        )
    {
        this.Comn_RowStatusID = comn_RowStatusID;
        this.Comn_RowStatusName = comn_RowStatusName;
    }


    private int _comn_RowStatusID;
    public int Comn_RowStatusID
    {
        get { return _comn_RowStatusID; }
        set { _comn_RowStatusID = value; }
    }

    private string _comn_RowStatusName;
    public string Comn_RowStatusName
    {
        get { return _comn_RowStatusName; }
        set { _comn_RowStatusName = value; }
    }
}

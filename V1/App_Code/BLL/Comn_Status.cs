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

public class Comn_Status
{
    public Comn_Status()
    {
    }

    public Comn_Status
        (
        int comn_StatusID, 
        string comn_StatusName
        )
    {
        this.Comn_StatusID = comn_StatusID;
        this.Comn_StatusName = comn_StatusName;
    }


    private int _comn_StatusID;
    public int Comn_StatusID
    {
        get { return _comn_StatusID; }
        set { _comn_StatusID = value; }
    }

    private string _comn_StatusName;
    public string Comn_StatusName
    {
        get { return _comn_StatusName; }
        set { _comn_StatusName = value; }
    }
}

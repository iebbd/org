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

public class Comn_Gender
{
    public Comn_Gender()
    {
    }

    public Comn_Gender
        (
        int comn_GenderID, 
        string comn_GenderName
        )
    {
        this.Comn_GenderID = comn_GenderID;
        this.Comn_GenderName = comn_GenderName;
    }


    private int _comn_GenderID;
    public int Comn_GenderID
    {
        get { return _comn_GenderID; }
        set { _comn_GenderID = value; }
    }

    private string _comn_GenderName;
    public string Comn_GenderName
    {
        get { return _comn_GenderName; }
        set { _comn_GenderName = value; }
    }
}

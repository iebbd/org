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

public class Comn_Nationality
{
    public Comn_Nationality()
    {
    }

    public Comn_Nationality
        (
        int comn_NationalityID, 
        string comn_NationalityName
        )
    {
        this.Comn_NationalityID = comn_NationalityID;
        this.Comn_NationalityName = comn_NationalityName;
    }


    private int _comn_NationalityID;
    public int Comn_NationalityID
    {
        get { return _comn_NationalityID; }
        set { _comn_NationalityID = value; }
    }

    private string _comn_NationalityName;
    public string Comn_NationalityName
    {
        get { return _comn_NationalityName; }
        set { _comn_NationalityName = value; }
    }
}

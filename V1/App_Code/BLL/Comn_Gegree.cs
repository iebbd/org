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

public class Comn_Gegree
{
    public Comn_Gegree()
    {
    }

    public Comn_Gegree
        (
        int comn_GegreeID, 
        string comn_GegreeName
        )
    {
        this.Comn_GegreeID = comn_GegreeID;
        this.Comn_GegreeName = comn_GegreeName;
    }


    private int _comn_GegreeID;
    public int Comn_GegreeID
    {
        get { return _comn_GegreeID; }
        set { _comn_GegreeID = value; }
    }

    private string _comn_GegreeName;
    public string Comn_GegreeName
    {
        get { return _comn_GegreeName; }
        set { _comn_GegreeName = value; }
    }
}

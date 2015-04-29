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

public class Comn_ResultType
{
    public Comn_ResultType()
    {
    }

    public Comn_ResultType
        (
        int comn_ResultTypeID, 
        string comn_ResultTypeName
        )
    {
        this.Comn_ResultTypeID = comn_ResultTypeID;
        this.Comn_ResultTypeName = comn_ResultTypeName;
    }


    private int _comn_ResultTypeID;
    public int Comn_ResultTypeID
    {
        get { return _comn_ResultTypeID; }
        set { _comn_ResultTypeID = value; }
    }

    private string _comn_ResultTypeName;
    public string Comn_ResultTypeName
    {
        get { return _comn_ResultTypeName; }
        set { _comn_ResultTypeName = value; }
    }
}

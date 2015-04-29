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

public class HR_Empoyee
{
    public HR_Empoyee()
    {
    }

    public HR_Empoyee
        (
        int hR_EmpoyeeID, 
        string hR_EmpoyeeName
        )
    {
        this.HR_EmpoyeeID = hR_EmpoyeeID;
        this.HR_EmpoyeeName = hR_EmpoyeeName;
    }


    private int _hR_EmpoyeeID;
    public int HR_EmpoyeeID
    {
        get { return _hR_EmpoyeeID; }
        set { _hR_EmpoyeeID = value; }
    }

    private string _hR_EmpoyeeName;
    public string HR_EmpoyeeName
    {
        get { return _hR_EmpoyeeName; }
        set { _hR_EmpoyeeName = value; }
    }
}

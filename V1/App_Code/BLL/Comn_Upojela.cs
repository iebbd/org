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

public class Comn_Upojela
{
    public Comn_Upojela()
    {
    }

    public Comn_Upojela
        (
        int comn_UpojelaID, 
        int upojelaID, 
        string upojelaName, 
        string districtName, 
        int districtID
        )
    {
        this.Comn_UpojelaID = comn_UpojelaID;
        this.UpojelaID = upojelaID;
        this.UpojelaName = upojelaName;
        this.DistrictName = districtName;
        this.DistrictID = districtID;
    }


    private int _comn_UpojelaID;
    public int Comn_UpojelaID
    {
        get { return _comn_UpojelaID; }
        set { _comn_UpojelaID = value; }
    }

    private int _upojelaID;
    public int UpojelaID
    {
        get { return _upojelaID; }
        set { _upojelaID = value; }
    }

    private string _upojelaName;
    public string UpojelaName
    {
        get { return _upojelaName; }
        set { _upojelaName = value; }
    }

    private string _districtName;
    public string DistrictName
    {
        get { return _districtName; }
        set { _districtName = value; }
    }

    private int _districtID;
    public int DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }
}

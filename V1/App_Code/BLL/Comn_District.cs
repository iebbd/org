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

public class Comn_District
{
    public Comn_District()
    {
    }

    public Comn_District
        (
        int comn_DistrictID, 
        int districtID, 
        string districtName, 
        string banglaName, 
        string devision
        )
    {
        this.Comn_DistrictID = comn_DistrictID;
        this.DistrictID = districtID;
        this.DistrictName = districtName;
        this.BanglaName = banglaName;
        this.Devision = devision;
    }


    private int _comn_DistrictID;
    public int Comn_DistrictID
    {
        get { return _comn_DistrictID; }
        set { _comn_DistrictID = value; }
    }

    private int _districtID;
    public int DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }

    private string _districtName;
    public string DistrictName
    {
        get { return _districtName; }
        set { _districtName = value; }
    }

    private string _banglaName;
    public string BanglaName
    {
        get { return _banglaName; }
        set { _banglaName = value; }
    }

    private string _devision;
    public string Devision
    {
        get { return _devision; }
        set { _devision = value; }
    }
}

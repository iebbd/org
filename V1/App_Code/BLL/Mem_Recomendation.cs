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

public class Mem_Recomendation
{
    public Mem_Recomendation()
    {
    }

    public Mem_Recomendation
        (
        int mem_RecomendationID, 
        DateTime recomendationDate, 
        int mem_MemberID, 
        int comn_RowSatusID
        )
    {
        this.Mem_RecomendationID = mem_RecomendationID;
        this.RecomendationDate = recomendationDate;
        this.Mem_MemberID = mem_MemberID;
        this.Comn_RowSatusID = comn_RowSatusID;
    }


    private int _mem_RecomendationID;
    public int Mem_RecomendationID
    {
        get { return _mem_RecomendationID; }
        set { _mem_RecomendationID = value; }
    }

    private DateTime _recomendationDate;
    public DateTime RecomendationDate
    {
        get { return _recomendationDate; }
        set { _recomendationDate = value; }
    }

    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private int _comn_RowSatusID;
    public int Comn_RowSatusID
    {
        get { return _comn_RowSatusID; }
        set { _comn_RowSatusID = value; }
    }
}

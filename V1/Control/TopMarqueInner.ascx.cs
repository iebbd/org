using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Control_TopMarque : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadTopMarque();
            //loadTopMarqueStatic();
        }
    }

    private void loadTopMarque()
    {
        string sql = @"Select BreakingNews,Web_EventID from Web_Event where RowStatusID=1 and TopMarque=1
and Web_Event.NoticeEndDate >= GETDATE()
--order by Web_Event.EventDate asc
order by Ordering asc";

        DataSet ds = new DataSet();

        ds = DatabaseManager.ExecSQL(sql);
        string html = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            html += (html != "" ? "&nbsp;&nbsp;|&nbsp;&nbsp;" : "") + "<a href='../Page/EventDetails.aspx?eventID=" + dr["Web_EventID"].ToString() + "'>" + dr["BreakingNews"].ToString() + "</a>";
        }

        Literal1.Text = html;
    }
    private void loadTopMarqueStatic()
    {

        Literal1.Text = "<a href='http://www.iebbd.org/Voterlist/VoterList_2015_16.htm'>Draft Voters List for the term 2015 &amp; 2016</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='http://www.iebbd.org/Page/EventDetails.aspx?eventID=80'>ACECC 28th ECM on 27-29 March, 2015</a>";
    }
}
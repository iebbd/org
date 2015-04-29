using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EngineeringNews_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadArchrive();
        }
    }

    private void loadArchrive()
    {
        string sql= "select * from Web_Enews order by ENewsID desc";
        

        DataSet ds = DatabaseManager.ExecSQL(sql);
        string html = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            
            html += (html==""?"":"<hr/>")+ @"<a href='Default.aspx?ENewsID="+dr["ENewsID"].ToString()+@"'> 
         <img src='"+dr["Location"].ToString()+@"/01.jpg'  height='400px'/>
    <br /> "+dr["Title"].ToString()+@"
    </a>";
        }

        lblArchrive.Text = html;
    }
}
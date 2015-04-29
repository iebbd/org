using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EngineeringNews_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadValues();
            LoadImage();
        }
    }

    private void LoadValues()
    {
        string id = "";
        if (Request.QueryString["ENewsID"] != null)
        {
            id = Request.QueryString["ENewsID"];
        }

        string sql = "";
        if (id == "")
        {
            sql = "select top 1 * from Web_Enews order by ENewsID desc";
        }
        else
        {
            sql = "select top 1 * from Web_Enews where ENewsID ="+id;
        }

        DataSet ds = DatabaseManager.ExecSQL(sql);

        hfMaxPageNo.Value = ds.Tables[0].Rows[0]["MaxFile"].ToString();
        hfFileLocation.Value = ds.Tables[0].Rows[0]["Location"].ToString();
        string downloadFileicon = "<img src='../images/DownloadFile.jpg' />";
        if (ds.Tables[0].Rows[0]["SmallFileurl"].ToString().ToString() != "")
        {
            lblOthers.Text = @"
            Click here to download <a href='" + ds.Tables[0].Rows[0]["SmallFileurl"].ToString() + @"' target='_blank'>"+
                                              (ds.Tables[0].Rows[0]["LargeFileurl"].ToString().ToString().Trim() == "" ? downloadFileicon : "(Lower Quality)") + @"</a>";
        }

        if (ds.Tables[0].Rows[0]["LargeFileurl"].ToString().ToString() != "")
        {
            lblOthers.Text += (ds.Tables[0].Rows[0]["SmallFileurl"].ToString().ToString().Trim() == "" ? "Click here to download " : "&nbsp;|&nbsp; ") + @"
            <a href='" + ds.Tables[0].Rows[0]["LargeFileurl"].ToString() + @"' target='_blank'>" +
                                              (ds.Tables[0].Rows[0]["SmallFileurl"].ToString().ToString().Trim() == "" ? downloadFileicon : "(Better Quality)") + @"</a>
                        ";
        }
        

        lblTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
    }

    private void LoadImage()
    {
        if (hfPageNo.Value == hfMaxPageNo.Value)
        {
            imgPage.ImageUrl = hfFileLocation.Value + "/" + hfMaxPageNo.Value + ".jpg";
        }
        else
        {
            imgPage.ImageUrl = hfFileLocation.Value + "/" + decimal.Parse((int.Parse(hfPageNo.Value) % (int.Parse(hfMaxPageNo.Value))).ToString()).ToString("00") + ".jpg";
        }

        if (hfPageNo.Value == "1"
            || hfPageNo.Value == "2"
            || hfPageNo.Value == (int.Parse(hfMaxPageNo.Value)-1).ToString()
            || hfPageNo.Value == hfMaxPageNo.Value
            )
        {
            txtPageNo1.Text = "";
            txtPageNo2.Text = "";
        }
        else
        {
            txtPageNo1.Text = (int.Parse(hfPageNo.Value) - 2).ToString();
            txtPageNo2.Text = (int.Parse(hfPageNo.Value) - 2).ToString();
        }

        btnStart1.Enabled = true;
        btnPrevious1.Enabled = true;
        btnNext1.Enabled = true;
        btnLast1.Enabled = true;

        btnStart2.Enabled = true;
        btnPrevious2.Enabled = true;
        btnNext2.Enabled = true;
        btnLast2.Enabled = true;

        if(hfPageNo.Value=="1")
        {
                btnStart1.Enabled = false;
                btnPrevious1.Enabled = false;
                btnStart2.Enabled = false;
                btnPrevious2.Enabled = false;
        }
        else if(hfPageNo.Value==hfMaxPageNo.Value)
        {
                btnNext1.Enabled = false;
                btnLast1.Enabled = false;
                btnNext2.Enabled = false;
                btnLast2.Enabled = false;
        }

    }
    protected void btnStart_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = "1";
        LoadImage();
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = (int.Parse(hfPageNo.Value) - 1).ToString();
        LoadImage();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = (int.Parse(hfPageNo.Value) + 1).ToString();
        LoadImage();
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = hfMaxPageNo.Value;
        LoadImage();
    }
}
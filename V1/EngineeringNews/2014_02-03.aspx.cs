using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineering_News_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadImage();
        }
    }

    private void LoadImage()
    {
        if (hfPageNo.Value == "55")
        {
            imgPage.ImageUrl = "files/2014_02-03/55.jpg";
        }
        else
        {
            imgPage.ImageUrl = "files/2014_02-03/" + decimal.Parse((int.Parse(hfPageNo.Value) % 55).ToString()).ToString("00") + ".jpg";
        }
        
        if (hfPageNo.Value == "1"
            || hfPageNo.Value == "2"
            || hfPageNo.Value == "51"
            || hfPageNo.Value == "55"
            )
        {
            txtPageNo1.Text = "";
            txtPageNo2.Text = "";
        }
        else
        {
            txtPageNo1.Text = (int.Parse(hfPageNo.Value)-2).ToString();
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

        switch (hfPageNo.Value)
        {
            case "1":
                btnStart1.Enabled = false;
                btnPrevious1.Enabled = false;
                btnStart2.Enabled = false;
                btnPrevious2.Enabled = false;
                break;
            case "55":
                btnNext1.Enabled = false;
                btnLast1.Enabled = false;
                btnNext2.Enabled = false;
                btnLast2.Enabled = false;
                break;
            default:
                break;
        }
    }
    protected void btnStart_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = "1";
        LoadImage();
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = (int.Parse(hfPageNo.Value)-1).ToString();
        LoadImage();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = (int.Parse(hfPageNo.Value) + 1).ToString();
        LoadImage();
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        hfPageNo.Value = "55";
        LoadImage();
    }
}
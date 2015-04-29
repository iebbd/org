using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class AdminConv_JobFairDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showConv_JobFairGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminConv_JobFairInsertUpdate.aspx?conv_JobFairID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminConv_JobFairInsertUpdate.aspx?conv_JobFairID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = Conv_JobFairManager.DeleteConv_JobFair(Convert.ToInt32(linkButton.CommandArgument));
        showConv_JobFairGrid();
    }

    private void showConv_JobFairGrid()
    {
        List<Conv_JobFair> all = new List<Conv_JobFair>();

        all = Conv_JobFairManager.GetAllConv_JobFairs();

        if (rbtnlPyament.SelectedValue == "3")
        {
            gvConv_JobFair.DataSource = all;
        }
        else if (rbtnlPyament.SelectedValue == "2")
        {
            gvConv_JobFair.DataSource = all.FindAll(x=> x.TrxID.Trim() =="");
        }
        else if (rbtnlPyament.SelectedValue == "1")
        {
            gvConv_JobFair.DataSource = all.FindAll(x => x.TrxID.Trim() != "");
        }


        gvConv_JobFair.DataBind();
    }
    protected void chkPaid_CheckedChanged(object sender, EventArgs e)
    {
        showConv_JobFairGrid();
    }
}

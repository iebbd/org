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
        gvConv_JobFair.DataSource = Conv_JobFairManager.GetAllConv_JobFairs();
        gvConv_JobFair.DataBind();
    }
}

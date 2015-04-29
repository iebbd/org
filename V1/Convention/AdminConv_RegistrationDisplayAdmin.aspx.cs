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

public partial class AdminConv_RegistrationDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showConv_RegistrationGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminConv_RegistrationInsertUpdate.aspx?conv_RegistrationID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminConv_RegistrationInsertUpdate.aspx?conv_RegistrationID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = Conv_RegistrationManager.DeleteConv_Registration(Convert.ToInt32(linkButton.CommandArgument));
        showConv_RegistrationGrid();
    }

    private void showConv_RegistrationGrid()
    {
        List<Conv_Registration> conventionRegistrations = new List<Conv_Registration>();
        conventionRegistrations=Conv_RegistrationManager.GetAllConv_Registrations();

        foreach (Conv_Registration item in conventionRegistrations)
        {
            item.ExtraField5 = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + item.Conv_RegistrationID + "034438";
            item.ExtraField3 = "../MembersArea/ConventionPaymentPrint.aspx?Confirmation=1&Conv_RegistrationID=710307" + item.Conv_RegistrationID + "034438";
        }

        gvConv_Registration.DataSource = conventionRegistrations;
        gvConv_Registration.DataBind();
    }
}

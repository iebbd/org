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
        //bool result = Conv_RegistrationManager.DeleteConv_Registration(Convert.ToInt32(linkButton.CommandArgument));
        DatabaseManager.ExecSQL("Delete Conv_Registration_Offline where Conv_RegistrationID=" + linkButton.CommandArgument);
        showConv_RegistrationGrid();
    }

    private void showConv_RegistrationGrid()
    {
        List<Conv_Registration> conventionRegistrations = new List<Conv_Registration>();
        
            string sql = @"SELECT [Conv_Registration_Offline].[Conv_RegistrationID]
                      ,[Conv_Registration_Offline].[Conv_ConventionID]
                      ,[Conv_Registration_Offline].[Mem_MemberID]
                      ,[Conv_Registration_Offline].[RegistrationFee]
                      ,[Conv_Registration_Offline].[Lunch1No]
                      ,[Conv_Registration_Offline].[Lunch1Amount]
                      ,[Conv_Registration_Offline].[Lunch2No]
                      ,[Conv_Registration_Offline].[Lunch2Amount]
                      ,[Conv_Registration_Offline].[Dinner1]
                      ,[Conv_Registration_Offline].[Dinner2]
                      ,[Conv_Registration_Offline].[LadiesBag]
                      ,[Conv_Registration_Offline].[IEBTie]
                      ,[Conv_Registration_Offline].[TotalIEBFee]
                      ,[Conv_Registration_Offline].[bKashFees]
                      ,[Conv_Registration_Offline].[TotalPayable]
                      ,[Conv_Registration_Offline].[TrxID]
                      ,[Conv_Registration_Offline].[AddedDate]
                      ,[Conv_Registration_Offline].[TypeID]
                      ,[Conv_Registration_Offline].[StatusID]
                      ,[Conv_Registration_Offline].[ExtraField1]
                      ,[Conv_Registration_Offline].[ExtraField2]
                      ,[Conv_Registration_Offline].[ExtraField3]
                      ,Mem_Member.MemberShipNo as  [ExtraField4]
                      ,[Conv_Registration_Offline].[ExtraField5]
                      ,Mem_Member.Mobile
                  FROM [Conv_Registration_Offline]
                  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration_Offline.Mem_MemberID
                  order by [Conv_Registration_Offline].AddedDate desc
                ";
            DataSet ds = DatabaseManager.ExecSQL(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["ExtraField5"] = "../MembersArea/ConventionPaymentOfflinePrint.aspx?Conv_RegistrationID=710307" + dr["Conv_RegistrationID"].ToString() + "034438";
            }
            gvConv_Registration.DataSource = ds.Tables[0];
       
        gvConv_Registration.DataBind();
    }
    
    protected void rbtnlPyament_SelectedIndexChanged(object sender, EventArgs e)
    {
        showConv_RegistrationGrid();
    }
}

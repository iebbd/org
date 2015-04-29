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
        decimal total = 0;
            decimal totalbKash = 0;
        List<Conv_Registration> conventionRegistrations = new List<Conv_Registration>();
        if (rbtnlPyament.SelectedValue == "3")
        {
            conventionRegistrations = Conv_RegistrationManager.GetAllConv_Registrations();
            foreach (Conv_Registration item in conventionRegistrations)
            {
                item.ExtraField5 = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + item.Conv_RegistrationID + "034438";
            }
            return;
            gvConv_Registration.DataSource = conventionRegistrations;
        }
        else if (rbtnlPyament.SelectedValue == "2")
        {
            string sql = @"SELECT [Conv_Registration].[Conv_RegistrationID]
      ,[Conv_Registration].[Conv_ConventionID]
      ,[Conv_Registration].[Mem_MemberID]
      ,[Conv_Registration].[RegistrationFee]
      ,[Conv_Registration].[Lunch1No]
      ,[Conv_Registration].[Lunch1Amount]
      ,[Conv_Registration].[Lunch2No]
      ,[Conv_Registration].[Lunch2Amount]
      ,[Conv_Registration].[Dinner1]
      ,[Conv_Registration].[Dinner2]
      ,[Conv_Registration].[LadiesBag]
      ,[Conv_Registration].[IEBTie]
      ,[Conv_Registration].[TotalIEBFee]
      ,[Conv_Registration].[bKashFees]
      ,[Conv_Registration].[TotalPayable]
      ,[Conv_Registration].[TrxID]
      ,[Conv_Registration].[AddedDate]
      ,[Conv_Registration].[TypeID]
      ,[Conv_Registration].[StatusID]
      ,[Conv_Registration].[ExtraField1]
      ,[Conv_Registration].[ExtraField2]
      ,[Conv_Registration].[ExtraField3]
      ,Mem_Member.MemberShipNo as  [ExtraField4]
      ,[Conv_Registration].[ExtraField5]
      ,Mem_Member.Mobile
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
            where TrxID=''
  order by [Conv_Registration].AddedDate desc
";
            DataSet ds=DatabaseManager.ExecSQL(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["ExtraField5"] = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + dr["Conv_RegistrationID"].ToString() + "034438";
            }
            gvConv_Registration.DataSource = ds.Tables[0];

            //conventionRegistrations = Conv_RegistrationManager.GetAllConv_Registrations().FindAll(x => x.TrxID == "");
        }
        else if (rbtnlPyament.SelectedValue == "1")
        {
            string sql = @"SELECT [Conv_Registration].[Conv_RegistrationID]
      ,[Conv_Registration].[Conv_ConventionID]
      ,[Conv_Registration].[Mem_MemberID]
      ,[Conv_Registration].[RegistrationFee]
      ,[Conv_Registration].[Lunch1No]
      ,[Conv_Registration].[Lunch1Amount]
      ,[Conv_Registration].[Lunch2No]
      ,[Conv_Registration].[Lunch2Amount]
      ,[Conv_Registration].[Dinner1]
      ,[Conv_Registration].[Dinner2]
      ,[Conv_Registration].[LadiesBag]
      ,[Conv_Registration].[IEBTie]
      ,[Conv_Registration].[TotalIEBFee]
      ,[Conv_Registration].[bKashFees]
      ,[Conv_Registration].[TotalPayable]
      ,[Conv_Registration].[TrxID]
      ,[Conv_Registration].[AddedDate]
      ,[Conv_Registration].[TypeID]
      ,[Conv_Registration].[StatusID]
      ,[Conv_Registration].[ExtraField1]
      ,[Conv_Registration].[ExtraField2]
      ,[Conv_Registration].[ExtraField3]
      ,Mem_Member.MemberShipNo as  [ExtraField4]
      ,[Conv_Registration].[ExtraField5]
      ,Mem_Member.Mobile
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
 where TrxID <>''
  order by [Conv_Registration].AddedDate desc ";

            DataSet ds = DatabaseManager.ExecSQL(sql);
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                total += decimal.Parse(dr["TotalIEBFee"].ToString());
                totalbKash += decimal.Parse(dr["TotalPayable"].ToString());
                dr["ExtraField5"] = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + dr["Conv_RegistrationID"].ToString() + "034438";
            }
            gvConv_Registration.DataSource = ds.Tables[0];
        }

        
        gvConv_Registration.DataBind();
        ((Label)gvConv_Registration.FooterRow.FindControl("lblTotalFooter")).Text = total.ToString("0,0") + "+" + (totalbKash-total).ToString("0,0") + "=" + totalbKash.ToString("0,0");
    }
    
    protected void rbtnlPyament_SelectedIndexChanged(object sender, EventArgs e)
    {
        showConv_RegistrationGrid();
    }
}

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
        DatabaseManager.ExecSQL("Update Conv_Registration set StatusID=3 where Conv_RegistrationID=" + id.ToString());
        //Response.Redirect("AdminConv_RegistrationInsertUpdate.aspx?conv_RegistrationID=" + id);
        Response.Redirect("RegKitDistribution.aspx");
        //showConv_RegistrationGrid();
    }

    protected void lbUpdate_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        foreach (GridViewRow gvr in gvConv_Registration.Rows)
	    {
		    HiddenField hfConv_RegistrationID =(HiddenField)gvr.FindControl("hfConv_RegistrationID");
		    TextBox txtRemark =(TextBox)gvr.FindControl("txtRemark");
            DatabaseManager.ExecSQL("Update Conv_Registration set ExtraField3='" + txtRemark.Text + "' where Conv_RegistrationID=" + id.ToString());
            break;
        }
        
        //Response.Redirect("AdminConv_RegistrationInsertUpdate.aspx?conv_RegistrationID=" + id);
        Response.Redirect("RegKitDistribution.aspx");
//        showConv_RegistrationGrid();
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
        if (rbtnlPyament.SelectedValue == "3")
        {
            conventionRegistrations = Conv_RegistrationManager.GetAllConv_Registrations();
            foreach (Conv_Registration item in conventionRegistrations)
            {
                item.ExtraField5 = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + item.Conv_RegistrationID + "034438";
            }
            gvConv_Registration.DataSource = conventionRegistrations;
        }
        else if (rbtnlPyament.SelectedValue == "2")
        {
            string sql = @"
Declare @IsFalse bit
Declare @IsTrue bit
set @IsFalse=0
set @IsTrue=1
SELECT [Conv_Registration].[Conv_RegistrationID]
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
      
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
            where TrxID='' and  StatusID<>3
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
            string sql = @"
Declare @IsFalse bit
Declare @IsTrue bit
set @IsFalse=0
set @IsTrue=1
SELECT [Conv_Registration].[Conv_RegistrationID]
      ,[Conv_Registration].[Conv_ConventionID]
      ,[Conv_Registration].[Mem_MemberID]
      ,[Conv_Registration].[RegistrationFee]
      ,[Conv_Registration].[Lunch1No]
,Lunch1E=(CASE [Conv_Registration].[Lunch1No] WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
      ,[Conv_Registration].[Lunch1Amount]
      ,[Conv_Registration].[Lunch2No]
,Lunch2E=(CASE [Conv_Registration].[Lunch2No] WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
      ,[Conv_Registration].[Lunch2Amount]
      ,[Conv_Registration].[Dinner1]/500 as Dinner1
,Dinner1E=(CASE ([Conv_Registration].[Dinner1]/500) WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
      ,[Conv_Registration].[Dinner2]/800 as Dinner2
,Dinner2E=(CASE ([Conv_Registration].[Dinner2]/500) WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
      ,[Conv_Registration].[LadiesBag]/1200 as LadiesBag
,LadiesBagE=(CASE ([Conv_Registration].[LadiesBag]/500) WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
      ,[Conv_Registration].[IEBTie]/500 as IEBTie
,IEBTieE=(CASE ([Conv_Registration].[IEBTie]/500) WHEN 0 THEN @IsFalse  ELSE @IsTrue END)
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
      ,'' as PictureUrl
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
 where TrxID <>'' and  StatusID<>3 and Mem_Member.Mem_MemberID=" + Request.QueryString["Mem_MemberID"] + @"
  order by [Conv_Registration].AddedDate desc ";

            DataSet ds = DatabaseManager.ExecSQL(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["ExtraField5"] = "../MembersArea/ConventionPaymentPrint.aspx?Conv_RegistrationID=710307" + dr["Conv_RegistrationID"].ToString() + "034438";
                dr["PictureUrl"] = "../MembersArea/MemberPicture/" + dr["ExtraField4"].ToString().Split('/')[0] + "-" + dr["ExtraField4"].ToString().Split('/')[1] + ".jpg";
            }
            gvConv_Registration.DataSource = ds.Tables[0];
        }

        
        gvConv_Registration.DataBind();
    }
    
    protected void rbtnlPyament_SelectedIndexChanged(object sender, EventArgs e)
    {
        showConv_RegistrationGrid();
    }
}

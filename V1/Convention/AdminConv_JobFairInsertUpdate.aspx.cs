using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class AdminConv_JobFairInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["conv_JobFairID"] != null)
            {
                int conv_JobFairID = Int32.Parse(Request.QueryString["conv_JobFairID"]);
                if (conv_JobFairID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showConv_JobFairData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Conv_JobFair conv_JobFair = new Conv_JobFair();

        conv_JobFair.Name = txtName.Text;
        conv_JobFair.IEBMembershipNo = txtIEBMembershipNo.Text;
        conv_JobFair.Institution = txtInstitution.Text;
        conv_JobFair.Deprtment = txtDeprtment.Text;
        conv_JobFair.PassingYear = txtPassingYear.Text;
        conv_JobFair.Mobile = txtMobile.Text;
        conv_JobFair.Email = txtEmail.Text;
        conv_JobFair.Details = txtDetails.Text;
        conv_JobFair.OfficeName = txtOfficeName.Text;
        conv_JobFair.TrxID = txtTrx.Text;
        conv_JobFair.ExtraField1 = txtExtraField1.Text;
        conv_JobFair.ExtraField2 = txtExtraField2.Text;
        conv_JobFair.ExtraField3 = txtExtraField3.Text;
        conv_JobFair.ExtraField4 = txtExtraField4.Text;
        conv_JobFair.ExtraField5 = txtExtraField5.Text;
        conv_JobFair.AddedDate = DateTime.Now;
        int resutl = Conv_JobFairManager.InsertConv_JobFair(conv_JobFair);
        Response.Redirect("AdminConv_JobFairDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Conv_JobFair conv_JobFair = new Conv_JobFair();
        conv_JobFair = Conv_JobFairManager.GetConv_JobFairByID(Int32.Parse(Request.QueryString["conv_JobFairID"]));
        Conv_JobFair tempConv_JobFair = new Conv_JobFair();
        tempConv_JobFair.Conv_JobFairID = conv_JobFair.Conv_JobFairID;

        tempConv_JobFair.Name = txtName.Text;
        tempConv_JobFair.IEBMembershipNo = txtIEBMembershipNo.Text;
        tempConv_JobFair.Institution = txtInstitution.Text;
        tempConv_JobFair.Deprtment = txtDeprtment.Text;
        tempConv_JobFair.PassingYear = txtPassingYear.Text;
        tempConv_JobFair.Mobile = txtMobile.Text;
        tempConv_JobFair.Email = txtEmail.Text;
        tempConv_JobFair.Details = txtDetails.Text;
        tempConv_JobFair.OfficeName = txtOfficeName.Text;
        tempConv_JobFair.TrxID = txtTrx.Text;
        tempConv_JobFair.ExtraField1 = conv_JobFair.ExtraField1;
        tempConv_JobFair.ExtraField2 = conv_JobFair.ExtraField2;
        tempConv_JobFair.ExtraField3 = txtExtraField3.Text;
        tempConv_JobFair.ExtraField4 = txtExtraField4.Text;
        tempConv_JobFair.ExtraField5 = txtExtraField5.Text;
        tempConv_JobFair.AddedDate = conv_JobFair.AddedDate;
        bool result = Conv_JobFairManager.UpdateConv_JobFair(tempConv_JobFair);
        Response.Redirect("AdminConv_JobFairDisplayAdmin.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtIEBMembershipNo.Text = "";
        txtInstitution.Text = "";
        txtDeprtment.Text = "";
        txtPassingYear.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtDetails.Text = "";
        txtOfficeName.Text = "";
        //ddlTrx.SelectedIndex = 0;
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showConv_JobFairData()
    {
        Conv_JobFair conv_JobFair = new Conv_JobFair();
        conv_JobFair = Conv_JobFairManager.GetConv_JobFairByID(Int32.Parse(Request.QueryString["conv_JobFairID"]));

        txtName.Text = conv_JobFair.Name;
        txtIEBMembershipNo.Text = conv_JobFair.IEBMembershipNo;
        txtInstitution.Text = conv_JobFair.Institution;
        txtDeprtment.Text = conv_JobFair.Deprtment;
        txtPassingYear.Text = conv_JobFair.PassingYear.ToString();
        txtMobile.Text = conv_JobFair.Mobile.ToString();
        txtEmail.Text = conv_JobFair.Email;
        txtDetails.Text = conv_JobFair.Details;
        txtOfficeName.Text = conv_JobFair.OfficeName;
        txtTrx.Text = conv_JobFair.TrxID.ToString();
        //txtExtraField1.Text = conv_JobFair.ExtraField1;
        //txtExtraField2.Text = conv_JobFair.ExtraField2;
        txtExtraField3.Text = conv_JobFair.ExtraField3;
        txtExtraField4.Text = conv_JobFair.ExtraField4;
        txtExtraField5.Text = conv_JobFair.ExtraField5;
    }
   
}

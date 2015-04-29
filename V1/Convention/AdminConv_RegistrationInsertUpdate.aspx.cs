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

public partial class AdminConv_RegistrationInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadConv_Convention();
            //loadMem_Member();
            //loadTrx();
            //loadType();
            //loadStatus();
            if (Request.QueryString["conv_RegistrationID"] != null)
            {
                int conv_RegistrationID = Int32.Parse(Request.QueryString["conv_RegistrationID"]);
                if (conv_RegistrationID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showConv_RegistrationData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Conv_Registration conv_Registration = new Conv_Registration();

        conv_Registration.Conv_ConventionID = Int32.Parse(txtConv_ConventionID.Text);
        conv_Registration.Mem_MemberID = Int32.Parse(txtMem_Member.Text);
        conv_Registration.RegistrationFee = Int32.Parse(txtRegistrationFee.Text);
        conv_Registration.Lunch1No = Int32.Parse(txtLunch1No.Text);
        conv_Registration.Lunch1Amount = Int32.Parse(txtLunch1Amount.Text);
        conv_Registration.Lunch2No = Int32.Parse(txtLunch2No.Text);
        conv_Registration.Lunch2Amount = Int32.Parse(txtLunch2Amount.Text);
        conv_Registration.Dinner1 = Int32.Parse(txtDinner1.Text);
        conv_Registration.Dinner2 = Int32.Parse(txtDinner2.Text);
        conv_Registration.LadiesBag = Int32.Parse(txtLadiesBag.Text);
        conv_Registration.IEBTie = Int32.Parse(txtIEBTie.Text);
        conv_Registration.TotalIEBFee = Int32.Parse(txtTotalIEBFee.Text);
        conv_Registration.BKashFees = Int32.Parse(txtBKashFees.Text);
        conv_Registration.TotalPayable = Int32.Parse(txtTotalPayable.Text);
        conv_Registration.TrxID =txtTrx.Text;
        conv_Registration.AddedDate = DateTime.Now;
        conv_Registration.TypeID = Int32.Parse(txtType.Text);
        conv_Registration.StatusID = Int32.Parse(txtStatus.Text);
        conv_Registration.ExtraField1 = txtExtraField1.Text;
        conv_Registration.ExtraField2 = txtExtraField2.Text;
        conv_Registration.ExtraField3 = txtExtraField3.Text;
        conv_Registration.ExtraField4 = txtExtraField4.Text;
        conv_Registration.ExtraField5 = txtExtraField5.Text;
        int resutl = Conv_RegistrationManager.InsertConv_Registration(conv_Registration);
        Response.Redirect("AdminConv_RegistrationDisplayAdmin.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Conv_Registration tempConv_Registration = new Conv_Registration();
        tempConv_Registration = Conv_RegistrationManager.GetConv_RegistrationByID(Int32.Parse(Request.QueryString["conv_RegistrationID"]));
        Conv_Registration conv_Registration = new Conv_Registration();
        conv_Registration.Conv_RegistrationID = tempConv_Registration.Conv_RegistrationID;

        conv_Registration.Conv_ConventionID = Int32.Parse(txtConv_ConventionID.Text);
        conv_Registration.Mem_MemberID = Int32.Parse(txtMem_Member.Text);
        conv_Registration.RegistrationFee = Int32.Parse(txtRegistrationFee.Text);
        conv_Registration.Lunch1No = Int32.Parse(txtLunch1No.Text);
        conv_Registration.Lunch1Amount = Int32.Parse(txtLunch1Amount.Text);
        conv_Registration.Lunch2No = Int32.Parse(txtLunch2No.Text);
        conv_Registration.Lunch2Amount = Int32.Parse(txtLunch2Amount.Text);
        conv_Registration.Dinner1 = Int32.Parse(txtDinner1.Text);
        conv_Registration.Dinner2 = Int32.Parse(txtDinner2.Text);
        conv_Registration.LadiesBag = Int32.Parse(txtLadiesBag.Text);
        conv_Registration.IEBTie = Int32.Parse(txtIEBTie.Text);
        conv_Registration.TotalIEBFee = Int32.Parse(txtTotalIEBFee.Text);
        conv_Registration.BKashFees = Int32.Parse(txtBKashFees.Text);
        conv_Registration.TotalPayable = Int32.Parse(txtTotalPayable.Text);
        conv_Registration.TrxID = txtTrx.Text;
        conv_Registration.AddedDate = tempConv_Registration.AddedDate;
        conv_Registration.TypeID = Int32.Parse(txtType.Text);
        conv_Registration.StatusID = Int32.Parse(txtStatus.Text);
        conv_Registration.ExtraField1 = "";// tempConv_Registration.ExtraField1;
        if (tempConv_Registration.ExtraField2 != "")
            conv_Registration.ExtraField2 = tempConv_Registration.ExtraField2.Replace("EnterTrxID", conv_Registration.TrxID);
        else
        {
            conv_Registration.ExtraField2 = tempConv_Registration.ExtraField1.Replace(
                @"<tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Please write down here the Transaction ID(TraxID) which you will receive from bKash by SMS</td>
        <td style='border:1px solid black;' colspan='2'>&nbsp;</td>
    </tr>",
                "<td style='border:1px solid black; text-align:right;' colspan='3'>Transaction ID(TrxID)</td>          <td style='border:1px solid black;' colspan='2'>"+txtTrx.Text+"</td>").Replace(
                "<img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/>",
                "<img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/><br/>Money Receipt");
        }
        

        conv_Registration.ExtraField3 = txtExtraField3.Text;
        conv_Registration.ExtraField4 = txtExtraField4.Text;
        conv_Registration.ExtraField5 = txtExtraField5.Text;
        bool result = Conv_RegistrationManager.UpdateConv_Registration(conv_Registration);

        Response.Redirect("AdminConv_RegistrationDisplayAdmin.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }
    private void showConv_RegistrationData()
    {
        Conv_Registration conv_Registration = new Conv_Registration();
        conv_Registration = Conv_RegistrationManager.GetConv_RegistrationByID(Int32.Parse(Request.QueryString["conv_RegistrationID"]));

        txtConv_ConventionID.Text = conv_Registration.Conv_ConventionID.ToString();
        txtMem_Member.Text = conv_Registration.Mem_MemberID.ToString();
        txtRegistrationFee.Text = conv_Registration.RegistrationFee.ToString();
        txtLunch1No.Text = conv_Registration.Lunch1No.ToString();
        txtLunch1Amount.Text = conv_Registration.Lunch1Amount.ToString();
        txtLunch2No.Text = conv_Registration.Lunch2No.ToString();
        txtLunch2Amount.Text = conv_Registration.Lunch2Amount.ToString();
        txtDinner1.Text = conv_Registration.Dinner1.ToString();
        txtDinner2.Text = conv_Registration.Dinner2.ToString();
        txtLadiesBag.Text = conv_Registration.LadiesBag.ToString();
        txtIEBTie.Text = conv_Registration.IEBTie.ToString();
        txtTotalIEBFee.Text = conv_Registration.TotalIEBFee.ToString();
        txtBKashFees.Text = conv_Registration.BKashFees.ToString();
        txtTotalPayable.Text = conv_Registration.TotalPayable.ToString();
        txtTrx.Text = conv_Registration.TrxID.ToString();
        txtType.Text = conv_Registration.TypeID.ToString();
        txtStatus.Text = conv_Registration.StatusID.ToString();
        //txtExtraField1.Text = conv_Registration.ExtraField1;
        //txtExtraField2.Text = conv_Registration.ExtraField2;
        txtExtraField3.Text = conv_Registration.ExtraField3;
        txtExtraField4.Text = conv_Registration.ExtraField4;
        txtExtraField5.Text = conv_Registration.ExtraField5;
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class MembersArea_ConventionPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calculate(this, new EventArgs());
        }
    }

    private void sqlInjectionChecking()
    {
        CommonManager.isInjection(txtAmount0.Text);
        CommonManager.isInjection(txtAmount1.Text);
        CommonManager.isInjection(txtAmount2.Text);
        CommonManager.isInjection(txtAmount3.Text);
        CommonManager.isInjection(txtAmount4.Text);
        CommonManager.isInjection(txtAmount5.Text);
        CommonManager.isInjection(txtAmount6.Text);
        CommonManager.isInjection(txtEmail.Text);
        CommonManager.isInjection(txtMemeberShipNoSearch.Text);
        CommonManager.isInjection(txtMobileN0.Text);
        CommonManager.isInjection(txtQty1.Text);
        CommonManager.isInjection(txtQty2.Text);
        CommonManager.isInjection(txtTelephoneNo.Text);
    }
    protected void Calculate_Couple(object sender, EventArgs e)
    {
        //if (CheckBox2.Checked)
        //{
        //    CheckBox1.Checked = false;
        //}

        Calculate(this, new EventArgs());
    }


    protected void Calculate_Single(object sender, EventArgs e)
    {
        //if (CheckBox1.Checked)
        //{
        //    CheckBox2.Checked = false;
        //}

        Calculate(this, new EventArgs());
    }
    protected void Calculate(object sender, EventArgs e)
    {
        sqlInjectionChecking();
        decimal totalIEBFee = 0;

        totalIEBFee += decimal.Parse(txtAmount0.ToolTip);
        try
        {
            if (txtQty1.Text != "" && decimal.Parse(txtQty1.Text)!=0)
            {
                totalIEBFee += (decimal.Parse(txtQty1.Text) * decimal.Parse(txtAmount1.ToolTip));
                txtAmount1.Text = (decimal.Parse(txtQty1.Text) * decimal.Parse(txtAmount1.ToolTip)).ToString("0");
            }
        }
        catch (Exception ex)
        { }

        try
        {
            if (txtQty2.Text != "" && decimal.Parse(txtQty2.Text) != 0)
            {
                totalIEBFee += (decimal.Parse(txtQty2.Text) * decimal.Parse(txtAmount2.ToolTip));
                txtAmount2.Text = (decimal.Parse(txtQty2.Text) * decimal.Parse(txtAmount2.ToolTip)).ToString("0");
            }
            
        }
        catch (Exception ex)
        { }


        try
        {
            txtAmount3.Text = "";
            if (CheckBox1.Checked)
            {
                totalIEBFee += (decimal.Parse(txtAmount3.ToolTip));
                txtAmount3.Text = (decimal.Parse(txtAmount3.ToolTip)).ToString("0");
            }
        }
        catch (Exception ex)
        { }


        try
        {
            txtAmount4.Text = "";
            if (CheckBox2.Checked)
            {
                totalIEBFee += ( decimal.Parse(txtAmount4.ToolTip));
                txtAmount4.Text = (decimal.Parse(txtAmount4.ToolTip)).ToString("0");
            }
        }
        catch (Exception ex)
        { }


        try
        {
            txtAmount5.Text ="";
            if (CheckBox3.Checked || txtQty3.Text.Trim() != "")
            {
                if (txtQty3.Text.Trim() == "")
                {
                    totalIEBFee += (decimal.Parse(txtAmount5.ToolTip));
                    txtAmount5.Text = (decimal.Parse(txtAmount5.ToolTip)).ToString("0");
                }
                else
                {
                    totalIEBFee += (decimal.Parse(txtAmount5.ToolTip) * decimal.Parse(txtQty3.Text));
                    txtAmount5.Text = (decimal.Parse(txtAmount5.ToolTip) * decimal.Parse(txtQty3.Text)).ToString("0");
                }
            }
        }
        catch (Exception ex)
        { }

        try
        {
            txtAmount6.Text = "";

            if (CheckBox4.Checked || txtQty4.Text.Trim() != "")
            {
                if (txtQty4.Text.Trim() == "")
                {
                    totalIEBFee += (decimal.Parse(txtAmount6.ToolTip));
                    txtAmount6.Text = (decimal.Parse(txtAmount6.ToolTip)).ToString("0");
                }
                else
                {
                    totalIEBFee += (decimal.Parse(txtAmount6.ToolTip) * decimal.Parse(txtQty4.Text));
                    txtAmount6.Text = (decimal.Parse(txtAmount6.ToolTip) * decimal.Parse(txtQty4.Text)).ToString("0");
                }
            }
        }
        catch (Exception ex)
        { }

        lblTotal.Text = totalIEBFee.ToString("0");
        lblbKashFee.Text = Math.Ceiling(totalIEBFee * decimal.Parse("0.0125")).ToString("0");
        lbltotalPayable.Text = Math.Ceiling(totalIEBFee * decimal.Parse("1.0125")).ToString("0");
        //lblTotalFinal.Text = lbltotalPayable.Text;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (txtMemeberShipNoSearch.Text.Trim() == "")
            return;
        bool isSelection = false;
        foreach (ListItem item in rbtMemebershipNo.Items)
        {
            if (item.Selected)
            {
                isSelection = true;
                break;
            }
        }

        if (!isSelection) return;
        sqlInjectionChecking();
        if (txtMemeberShipNoSearch.Text.Contains("/"))
            txtMemeberShipNoSearch.Text = txtMemeberShipNoSearch.Text.Trim().Split('/')[1];

        if (txtMemeberShipNoSearch.Text.Contains("-"))
            txtMemeberShipNoSearch.Text = txtMemeberShipNoSearch.Text.Trim().Split('-')[1];
        
        string sql = @"
SELECT [Mem_MemberID]
      ,[MemberShipNo]
      ,[Name]
      ,[PhoneOffice]
      ,[PhoneResidence]
      ,[Mobile]
      ,[Email]
      ,[PictureURL]
      ,Comn_Office.Comn_OfficeName
  FROM [Mem_Member]
  inner join Comn_Office on Comn_Office.Comn_OfficeID =Mem_Member.Comn_OfficeID
  where [MemberShipNo]='"+rbtMemebershipNo.SelectedItem.Text+@"/" + decimal.Parse(txtMemeberShipNoSearch.Text).ToString("00000") + @"'

SELECT [Conv_RegistrationID]
  FROM [Conv_Registration_Offline]
  where Mem_MemberID =(select Mem_MemberID from Mem_Member where MemberShipNo='" + rbtMemebershipNo.SelectedItem.Text + @"/" + decimal.Parse(txtMemeberShipNoSearch.Text).ToString("00000") + @"')
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        tblCard.Visible = false;
        tblInfo.Visible = false;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                hlnkPreviousMoneyreceipt.NavigateUrl = "../MembersArea/ConventionPaymentofflinePrint.aspx?Conv_RegistrationID=710307" + ds.Tables[1].Rows[0][0].ToString() + "034438";
                hlnkPreviousMoneyreceipt.Visible = true;
            }
            else
            {
                hfMem_MemberID.Value = ds.Tables[0].Rows[0]["Mem_MemberID"].ToString();
                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblMembershipNo.Text = ds.Tables[0].Rows[0]["MemberShipNo"].ToString();
                lblCenter.Text = ds.Tables[0].Rows[0]["Comn_OfficeName"].ToString();
                txtTelephoneNo.Text = ds.Tables[0].Rows[0]["PhoneResidence"].ToString();
                txtMobileN0.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["PictureURL"].ToString() != "")
                {
                    Image1.ImageUrl = "../MembersArea/MemberPicture/" + ds.Tables[0].Rows[0]["PictureURL"].ToString();
                }
                else
                {
                    Image1.ImageUrl = "../MembersArea/MemberPicture/" + ds.Tables[0].Rows[0]["MemberShipNo"].ToString().Replace("/", "-") + ".jpg";
                   
                }
                tblInfo.Visible = true;

                if (loadFeesHistory() > 0)
                {
                    tblFessDetails.Visible = true;
                }
                tblCard.Visible = true;
                trConfirmation.Visible = false;
                lblBillNo.Text = lblMembershipNo.Text.Replace("/", "") + "CON";
                lblBillNo_afterPrint.Text = lblMembershipNo.Text.Replace("/", "") + "CON";
                lblReferenceNoSteps.Text = lblMembershipNo.Text.Replace("/", "") + "CON";
            }
        }
        else
        {
            hfMem_MemberID.Value = "";
        }
    }

    protected decimal  loadFeesHistory()
    {

        string sql = @"
                SELECT Mem_Fees.[Amount]
                      ,Mem_FeesYear.Mem_FeesYearName as [PaidFor]
                      ,Mem_Fees.[PaidDate]
                  FROM [Mem_Fees]
                  inner join Mem_Member on Mem_Member.Mem_MemberID=Mem_Fees.Mem_MemberID
                  inner join Mem_FeesYear on Mem_FeesYear.Mem_FeesYearID=Mem_Fees.Mem_FeesYearID
                  where  Mem_Fees.Comn_RowStatusID=1 and Mem_Member.Mem_MemberID=" + hfMem_MemberID.Value + @"
                   order by   Mem_FeesYear.Ordering  asc;
SELECT [AnnaralSubscriptionFee]
  FROM [Mem_MemberType] where Mem_MemberTypeID=" + rbtMemebershipNo.SelectedValue + @";
";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        lblDues.ForeColor = System.Drawing.Color.Red;
        lblDues.Text = "";
        decimal duesAmount = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMem_Fees.DataSource = ds.Tables[0];
            gvMem_Fees.DataBind();

            decimal total = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                total += decimal.Parse(dr["Amount"].ToString());
            }
            ((Label)gvMem_Fees.FooterRow.FindControl("lblTotalAmount")).Text = total.ToString("0,0.00");
            bool otherthanUnknown = false;
            bool unknown = false;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["PaidFor"].ToString() == "Unknown")
                {
                    unknown = true;
                }
                else
                {
                    otherthanUnknown = true;
                }
            }

            decimal max = 0;
            if (rbtMemebershipNo.SelectedValue == "1")
            {
                max = 1600;
            }
            else if (rbtMemebershipNo.SelectedValue == "2")
            {
                max = 950;
            }

            else if (rbtMemebershipNo.SelectedValue == "3")
            {
                max = 500;
            }

            try
            {
                if (
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() != "ABOVE 66"
                    &&
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() != "LIFE"
                    && (otherthanUnknown))
                {
                    int yearDiffirence = 2014 - int.Parse(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString().Split('-')[1]);
                    if (yearDiffirence > 0)
                    {
                        decimal amount = decimal.Parse(yearDiffirence.ToString()) * decimal.Parse(ds.Tables[1].Rows[0][0].ToString());
                        duesAmount = (amount >= max ? max : amount);
                        lblDues.Text = "<b style='color:green;'>Membership Subscription Paid Upto " + ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString()+"</a>";
                        lblDues.Text += "<br/><b  style='color:red;'>" + yearDiffirence + " year(s)(Incuding 2013-2014) fees total: <b>" + (amount >= max ? max : amount).ToString("0,0") + "/=</b> Dues</b>";
                        lblDues.Text += "<br/>Don't pay Convention & Membership Dues in single payment.<a href='http://iebbd.org/membersarea/MyProfile.aspx?Mem_MemberID=710307" + hfMem_MemberID.Value + "034438#ContentPlaceHolder1_MembershipInfo1_tr_Fees_title'>Please click here to know how you can pay though bKash</a>";
                    }
                }
                else if (unknown & !otherthanUnknown)
                {
                    lblDues.Text += "<br/>" + "Fees total: <b>" + max.ToString("0,0") + "/=</b> Dues (Incuding 2013-2014) ";
                    lblDues.Text += "<br/>Don't pay Convention & Membership Dues in single payment.<a href='http://iebbd.org/membersarea/MyProfile.aspx?Mem_MemberID=710307" + hfMem_MemberID.Value + "034438#ContentPlaceHolder1_MembershipInfo1_tr_Fees_title' >Please click here to know how you can pay though bKash</a>";
                    duesAmount = max;

                }
                else
                {
                    lblDues.Text = "You don't need to pay anymore";
                    lblDues.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            { }
        }
        else
        {
            lblDues.Text = "For Dues amount please call IEB office";
            duesAmount = -1;
        }

        return duesAmount;
    }

    private void showAlartMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
             "err_msg",
             "alert('" + message + "');",
             true);
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (txtSerialNo.Text.Trim() == "")
        {
            showAlartMessage("PLease enter the serial no");
            return;
        }

        sqlInjectionChecking();
        trConfirmation.Visible = true;
        btnConfirm.Visible = false;
        string html = @"
<div style='border:1px solid black;background-color:#FDFBE6;font-family:Arial;font-size:12px;padding:10px;width:408px;'>
<table border='0' cellspacing='0' cellpadding='2' >
    
    <tr>
        <td colspan='5' style='background-color:white;'>
            <img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/>
        </td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Engr.</td>
        <td colspan='4' style='border:1px solid black;'>" + lblName.Text.Replace("ENGR. ","") + @"</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Membership No.</td>
        <td colspan='4' style='border:1px solid black;'>"+lblMembershipNo.Text+@"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Center</td>
        <td colspan='4' style='border:1px solid black;'>"+lblCenter.Text+@"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Telephone No.</td>
        <td colspan='4' style='border:1px solid black;'>"+txtTelephoneNo.Text+@"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Mobile</td>
        <td colspan='4' style='border:1px solid black;'>" + txtMobileN0.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Email Address</td>
        <td colspan='4' style='border:1px solid black;'>" + txtEmail.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Registration</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Compulsory</td>
        <td style='border:1px solid black;text-align:right;' colspan='3'>Tk. 1000</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='3'>Lunch</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>03 May'14</td>
        <td style='border:1px solid black;text-align:center;'>" + txtQty1.Text + @"&nbsp;</td>
        <td style='border:1px solid black;width:70px;'><b style='color: #FF0000;'>x</b> Tk. 130=</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount1.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>04 May'14</td>
        <td style='border:1px solid black;' colspan='3'>Lunch Will be provided by IEB</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>05 May'14</td>
        <td style='border:1px solid black;text-align:center;'>" + txtQty2.Text + @"&nbsp;</td>
        <td style='border:1px solid black;'><b style='color: #FF0000;'>x</b> Tk. 130 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount2.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'><b style='color: #FF0000;'>*</b>Dinner</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Single</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox1.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount3.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>Couple</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox2.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 800 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount4.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'><b style='color: #FF0000;'>*</b>Only for Members &amp; Spouse</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'>Optional Items</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Ladies Bag</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox3.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") +txtQty3.Text+ @"</td>
        <td style='border:1px solid black;'>Tk. 1200 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount5.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>IEB Tie</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox4.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") +txtQty4.Text+ @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount6.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable(to IEB) =</td>
        <td style='border:1px solid black;' text-align:right;>" + lblTotal.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
   
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    
      <tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Serial No</td>
        <td style='border:1px solid black;' colspan='2'>'" + txtSerialNo.Text + @"'</td>
    </tr>
</table>
</div>
";
          
        string htmlConfirmation = @"
<div style='border:1px solid black;background-color:#FDFBE6;font-family:Arial;font-size:12px;padding:10px;width:408px;'>
<table border='0' cellspacing='0' cellpadding='2' >
    
    <tr>
        <td colspan='5' style='background-color:white;'>
            <img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/>
<br/>Money Receipt
        </td>
    </tr>

    <tr>
        <td style='border:1px solid black;'>Engr.</td>
        <td colspan='4' style='border:1px solid black;'>" + lblName.Text.Replace("ENGR. ", "") + @"</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Membership No.</td>
        <td colspan='4' style='border:1px solid black;'>" + lblMembershipNo.Text + @"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Center</td>
        <td colspan='4' style='border:1px solid black;'>" + lblCenter.Text + @"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Telephone No.</td>
        <td colspan='4' style='border:1px solid black;'>" + txtTelephoneNo.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Mobile</td>
        <td colspan='4' style='border:1px solid black;'>" + txtMobileN0.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Email Address</td>
        <td colspan='4' style='border:1px solid black;'>" + txtEmail.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Registration</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Compulsory</td>
        <td style='border:1px solid black;text-align:right;' colspan='3'>Tk. 1000</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='3'>Lunch</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>03 May'14</td>
        <td style='border:1px solid black;text-align:center;'>" + txtQty1.Text + @"&nbsp;</td>
        <td style='border:1px solid black;width:70px;'><b style='color: #FF0000;'>x</b> Tk. 130=</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount1.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>04 May'14</td>
        <td style='border:1px solid black;' colspan='3'>Lunch Will be provided by IEB</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>05 May'14</td>
        <td style='border:1px solid black;text-align:center;'>" + txtQty2.Text + @"&nbsp;</td>
        <td style='border:1px solid black;'><b style='color: #FF0000;'>x</b> Tk. 130 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount2.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'><b style='color: #FF0000;'>*</b>Dinner</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Single</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox1.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount3.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>Couple</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox2.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 800 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount4.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'><b style='color: #FF0000;'>*</b>Only for Members &amp; Spouse</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'>Optional Items</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Ladies Bag</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox3.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 1200 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount5.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>IEB Tie</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + (CheckBox4.Checked ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + txtAmount6.Text + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable(to IEB) =</td>
        <td style='border:1px solid black;' text-align:right;>" + lblTotal.Text + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
  <tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Serial No</td>
        <td style='border:1px solid black;' colspan='2'>'" + txtSerialNo.Text + @"'</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:left;' colspan='5'>Thanks for your payment through bKash. Your registration is confirmed.
</td>
    </tr>
    
   
  
</table>
</div>
";

        if (tblFessDetails.Visible)
        {
            html += "<div style='color:red;padding:10px; border:1px solid red;'>"+lblDues.Text+"</div>";
        }
        if (txtEmail.Text != "")
        {
            try
            {
            //Sendmail.sendEmail(txtEmail.Text, "55th Convention Registration", html);
            //lblConfirmationEmail.Text = @"<br/><ul style='padding-left:15px;color:black;'><li>The Receipt has sent to your email <b style='color:blue;'>" + txtEmail.Text + "</b>";
            }
            catch (Exception ex)
            {

            }
        }
        /*
        if (txtMobileN0.Text.Trim().Length == 11)
        {
            try
            {

                MyWebRequest myRequest1 = new MyWebRequest("https://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + txtMobileN0.Text.Substring(1, 10) + "&mask=IEB&sms=You have to Pay your IEB Convention Fee from (any)personal bKash Account.");
                XmlDocument doc1 = new XmlDocument();

                string successMessage1 = "";
                doc1.LoadXml(myRequest1.GetResponse());
                XmlNodeList nodesUrl1 = doc1.SelectNodes("response");
                if (!doc1.InnerText.ToString().Contains("Failed"))
                {
                    // lblConfirmationEmail.Text += " and a SMS to <b style='color:blue;'>" + txtMobileN0.Text + "</b>";
                }

                MyWebRequest myRequest = new MyWebRequest("https://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + txtMobileN0.Text.Substring(1, 10) + "&mask=IEB&sms=You IEB 55th Convention total payable fees :tk." + lbltotalPayable.Text + " [Merchant Acc. No.:01766674142][Reference No.: " + lblBillNo.Text + "][Counter:0]");
                XmlDocument doc = new XmlDocument();

                string successMessage = "";
                doc.LoadXml(myRequest.GetResponse());
                XmlNodeList nodesUrl = doc.SelectNodes("response");
                if (!doc.InnerText.ToString().Contains("Failed"))
                {
                    lblConfirmationEmail.Text += " and a SMS to <b style='color:blue;'>" + txtMobileN0.Text + "</b>";
                }

               
            }
            catch (Exception ex)
            {

            }
        }
         * */
        lblConfirmationEmail.Text += "";
        try
        {
            string sql = @"
        INSERT INTO [Conv_Registration_Offline]
           ([Conv_ConventionID]
           ,[Mem_MemberID]
           ,[RegistrationFee]
           ,[Lunch1No]
           ,[Lunch1Amount]
           ,[Lunch2No]
           ,[Lunch2Amount]
           ,[Dinner1]
           ,[Dinner2]
           ,[LadiesBag]
           ,[IEBTie]
           ,[TotalIEBFee]
           ,[bKashFees]
           ,[TotalPayable]
           ,[TrxID]
           ,[AddedDate]
           ,[TypeID]
           ,[StatusID]
           ,[ExtraField1]
           ,[ExtraField2]
           ,[ExtraField3]
           ,[ExtraField4]
           ,[ExtraField5])
     VALUES
           (55--<Conv_ConventionID, int,>
           ," + (hfMem_MemberID.Value ==""?"0":hfMem_MemberID.Value)+ @"--<Mem_MemberID, int,>
           ,1000--<RegistrationFee, int,>
           ," + (txtQty1.Text.Trim() == "" ? "0" : txtQty1.Text) + @"--<Lunch1No, int,>
           ," + (txtAmount1.Text.Trim() == "" ? "0" : txtAmount1.Text) + @"--<Lunch1Amount, int,>
           ," + (txtQty2.Text.Trim() == "" ? "0" : txtQty2.Text) + @"--<Lunch2No, int,>
           ," + (txtAmount2.Text.Trim() == "" ? "0" : txtAmount2.Text) + @"--<Lunch2Amount, int,>
           ," + (txtAmount3.Text.Trim() == "" ? "0" : txtAmount3.Text) + @"--<Dinner1, int,>
           ," + (txtAmount4.Text.Trim() == "" ? "0" : txtAmount4.Text) + @"--<Dinner2, int,>
           ," + (txtAmount5.Text.Trim() == "" ? "0" : txtAmount5.Text) + @"--<LadiesBag, int,>
           ," + (txtAmount6.Text.Trim() == "" ? "0" : txtAmount6.Text) + @"--<IEBTie, int,>
           ," + (lblTotal.Text.Trim() == "" ? "0" : lblTotal.Text) + @"--<TotalIEBFee, int,>
           ," + (lblbKashFee.Text.Trim() == "" ? "0" : lblbKashFee.Text) + @"--<bKashFees, int,>
           ," + (lbltotalPayable.Text.Trim() == "" ? "0" : lbltotalPayable.Text.Trim()) + @"--<TotalPayable, int,>
           ,'"+txtSerialNo.Text+@"'--<TrxID, nvarchar(256),>
           ,GETDATE()--<AddedDate, datetime,>
           ,1--<TypeID, int,>
           ,1--<StatusID, int,>
           ,'" + html.Replace("'","''") + @"'--<ExtraField1, nvarchar(max),>
           ,'" + htmlConfirmation.Replace("'", "''") + @"'--<ExtraField2, nvarchar(max),>
           ,''--<ExtraField3, nvarchar(max),>
           ,''--<ExtraField4, nvarchar(max),>
           ,''--<ExtraField5, nvarchar(max),>
);
Select SCOPE_IDENTITY();
        ";

            DataSet ds= DatabaseManager.ExecSQL(sql);
            //lblPrint.Text = html;
            //div_Print.Visible = false;
            //tblCard.Visible = false;
            //tblInfo.Visible = false;
            //tblMembershipNo.Visible = false;
            trConfirmation.Visible = true;
            //PrintSalesInvoice();
            a_print.HRef = "../MembersArea/ConventionPaymentOfflinePrint.aspx?Conv_RegistrationID=710307" + ds.Tables[0].Rows[0][0].ToString() + "034438";
            tr_ConfirmationEmail.Visible = true;

            //Response.Redirect("ConventionPayment.aspx");
        }
        catch (Exception ex)
        {
            Sendmail.sendEmail("anamuliut@gmail.com", "55th Convention Registration[Error]"+txtMemeberShipNoSearch.Text, ex.Message);
            
            Response.Redirect("../Page/CustomErrorPage.aspx");
        }
    }

    private void PrintSalesInvoice()
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
             "err_msg",
             "javascript:printIt(document.getElementById('printSalesVoucher').innerHTML);",
             true);
    }
    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        PrintSalesInvoice();
    }
}
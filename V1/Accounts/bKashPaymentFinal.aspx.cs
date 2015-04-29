using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class payment_bKashPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCount();
            loadPaymentYear();
            txtFrom.Text = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            txtTo.Text= DateTime.Today.ToString("yyyy-MM-dd");
        }
    }

    private void loadPaymentYear()
    {
        string sql = @"SELECT [Mem_FeesYearID]
      ,[Mem_FeesYearName]
  FROM [Mem_FeesYear] order by [Mem_FeesYearName] ";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        ddlPaidFor.Items.Clear();
        ddlPaidFor.Items.Add(new ListItem("Select", "0"));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string yearname = dr["Mem_FeesYearName"].ToString();

            //if (yearname.Contains("19") || yearname.Contains("20"))
            //{
            //    yearname = yearname.Split('-')[0].Substring(2, 2) + "-" + yearname.Split('-')[1].Substring(2, 2);
            //}
            ListItem li=new ListItem(yearname, dr["Mem_FeesYearID"].ToString());
            if (yearname == "2013-2014")
                li.Selected = true;
            else
                li.Selected = false;
            ddlPaidFor.Items.Add(li);
            
        }


    }

    private void loadCount()
    {
        string sql = @"Select Count(*) from Acc_bKash_Final;Select Count(Distinct TransactionID) from Acc_bKash_Final;";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        if (ds.Tables[0].Rows[0][0].ToString() != ds.Tables[0].Rows[0][0].ToString())
            lblCount.Text = "Problem";
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = @"SELECT [TransactionID]
      ,[Sender]
      ,[Amount]
      ,[ReferenceNo]
      ,[FeferenceNoFinal]
      ,[Counter]
      ,[TrancsactionTime]
      ,[Note]
      ,[ExtraField1]
      ,[ExtraField2]
      ,[ExtraField3]
      ,[ExtraField4]
      ,[ExtraField5]
  FROM [Acc_bKash_Final]
                        where 1=1
";
        if (!chkAll.Checked)
        {
            sql += " and Acc_bKash_Final.ExtraField1=''";
        }
        if (txtAmount.Text != "")
        {
            sql += " and Acc_bKash_Final.Amount=" + txtAmount.Text;
        }
        if (txtFrom.Text != "")
        {
            sql += " and Acc_bKash_Final.TrancsactionTime >= '" + txtFrom.Text + "'";
        }
        if (txtTo.Text != "")
        {
            sql += " and Acc_bKash_Final.TrancsactionTime <= '" + txtTo.Text + "'";
        }

        if (txtReferenceNo.Text != "")
        {
            sql += " and Acc_bKash_Final.ReferenceNo like '%" + txtReferenceNo.Text + "%'";
        }

        if (txtReferenceNoFinal.Text != "")
        {
            sql += " and Acc_bKash_Final.FeferenceNoFinal like '%" + txtReferenceNoFinal.Text + "%'";
        }

        if (txtSender.Text != "")
        {
            sql += " and Acc_bKash_Final.Sender=" + txtSender.Text;
        }

        if (txtTrxID.Text != "")
        {
            sql += " and Acc_bKash_Final.TransactionID=" + txtTrxID.Text;
        }

        sql += @"
                order by FeferenceNoFinal ";
        
        DataSet ds = DatabaseManager.ExecSQL(sql);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            dr["ExtraField1"] = dr["FeferenceNoFinal"].ToString().ToUpper().Trim().Replace("JOB", "").Replace("CON", "").Replace("DUE", "").Replace("A", "A/").Replace("F", "F/").Replace("M", "M/");

            if (dr["FeferenceNoFinal"].ToString().ToUpper().Trim().Contains("CON"))
            {
                
                try
                {
                    dr["ExtraField1"] = dr["ExtraField1"].ToString().Split('/')[0] + "/" + decimal.Parse(dr["ExtraField1"].ToString().Split('/')[1]).ToString("00000");

                    string tmp = @"
                Select Mobile,Email,Mem_MemberID from Mem_Member where MemberShipNo ='" + dr["ExtraField1"] + @"';
                SELECT Conv_RegistrationID
                    FROM [Conv_Registration]
                    where Mem_MemberID =(Select Mem_MemberID from Mem_Member where MemberShipNo='" + dr["ExtraField1"] + @"')
                ";

                    DataSet dstmp = DatabaseManager.ExecSQL(tmp);
                    dr["ExtraField2"] = dstmp.Tables[0].Rows[0][0].ToString();
                    dr["ExtraField3"] = dstmp.Tables[0].Rows[0][1].ToString();
                    dr["ExtraField4"] = dstmp.Tables[0].Rows[0][2].ToString();

                    if (dstmp.Tables[1].Rows.Count == 0)
                    { 
                        dr["ExtraField1"] = ""; 
                    }
                    else
                    {
                        dr["ExtraField5"] = dstmp.Tables[1].Rows[0][0].ToString();

                    }
                    
                }
                catch(Exception ex)
                {
                    dr["ExtraField1"] = "";
                }
            }
            else if (dr["FeferenceNoFinal"].ToString().ToUpper().Trim().Contains("DUE"))
            {
                dr["ExtraField1"] = dr["ExtraField1"].ToString().Split('/')[0] + "/" + decimal.Parse(dr["ExtraField1"].ToString().Split('/')[1]).ToString("00000");

                string tmp = @"
                Select Mobile,Email,Mem_MemberID from Mem_Member where MemberShipNo ='" + dr["ExtraField1"] + @"';
                ";

                DataSet dstmp = DatabaseManager.ExecSQL(tmp);
                dr["ExtraField2"] = dstmp.Tables[0].Rows[0][0].ToString();
                dr["ExtraField3"] = dstmp.Tables[0].Rows[0][1].ToString();
                dr["ExtraField4"] = dstmp.Tables[0].Rows[0][2].ToString();
            }
            else if (dr["FeferenceNoFinal"].ToString().ToUpper().Trim().Contains("JOB"))
            {

                string tmp = @"
                SELECT [Mobile]
      ,[Email]      
  FROM [Conv_JobFair]
  where Conv_JobFairID=" + dr["ExtraField1"] + @";
                ";

                DataSet dstmp = DatabaseManager.ExecSQL(tmp);
                dr["ExtraField2"] = dstmp.Tables[0].Rows[0][0].ToString();
                dr["ExtraField3"] = dstmp.Tables[0].Rows[0][1].ToString();
            }

        }

        lblCount.Text = ds.Tables[0].Rows.Count.ToString();

        gvbKash.DataSource = ds.Tables[0];
        gvbKash.DataBind();

        foreach (GridViewRow gvr in gvbKash.Rows)
        {
            DropDownList rbtnPaidUpto = (DropDownList)gvr.FindControl("rbtnPaidUpto");
            rbtnPaidUpto.Items.Clear();
            foreach (ListItem item in ddlPaidFor.Items)
            {
                rbtnPaidUpto.Items.Add(item);                
            }
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtTrxID.Text = "";
        txtSender.Text = "";
        txtAmount.Text = "";
        txtReferenceNo.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
    }

    protected void btnSaveInDBForMembershipFee_Click(object sender, EventArgs e)
    {
        string sql = "";
        foreach (GridViewRow gvr in gvbKash.Rows)
        {
            try
            {
                TextBox txtCorrctReferenceNo = (TextBox)gvr.FindControl("txtCorrctReferenceNo");
                TextBox txtMemberShipNo = (TextBox)gvr.FindControl("txtMemberShipNo");
                Label lblTransactionID = (Label)gvr.FindControl("lblTransactionID");
                Label lblAmount = (Label)gvr.FindControl("lblAmount");
                Label lblTrancsactionTime = (Label)gvr.FindControl("lblTrancsactionTime");
                Label lblMobile = (Label)gvr.FindControl("lblMobile");
                Label lblEmail = (Label)gvr.FindControl("lblEmail");
                CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
                DropDownList rbtnPaidUpto = (DropDownList)gvr.FindControl("rbtnPaidUpto");
                if (chkSelect.Checked)
                {
                    sql = @"

               INSERT INTO [Mem_Fees]
           ([Mem_MemberID]
           ,[Amount]
           ,[PaidFor]
           ,[ExtraField]
           ,[AddedDate]
           ,[AddedBy]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[Comn_RowStatusID]
           ,[RefferenceNo]
           ,[Comn_PaymentByID]
           ,[PaidDate]
           ,[Mem_FeesYearID])
     VALUES
           ((Select Mem_MemberID from Mem_Member where MemberShipNo ='" + txtMemberShipNo.Text + @"')--<Mem_MemberID, int,>
           ," + lblAmount.Text + @"--<Amount, decimal(10,2),>
           ,'" + rbtnPaidUpto.SelectedItem.Text + @"'--<PaidFor, nvarchar(50),>
           ,'New Database Entry'--<ExtraField, nvarchar(256),>
           ,GETDATE()--<AddedDate, datetime,>
           ,1--<AddedBy, int,>
           ,1--<ModifiedBy, int,>
           ,GETDATE()--<ModifiedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
           ,'" + lblTransactionID.Text + @"'--<RefferenceNo, nvarchar(50),>
           ,2--<Comn_PaymentByID, int,>
           ,'" + DateTime.Parse(lblTrancsactionTime.Text).ToString("yyyy-MM-dd hh:mm tt") + @"'--<PaidDate, datetime,>
           ," + rbtnPaidUpto.SelectedValue + @"--<Mem_FeesYearID, int,>
            );

update Acc_bKash_Final set ExtraField1=(Select cast(Mem_MemberID as nvarchar) from Mem_Member where MemberShipNo ='" + txtMemberShipNo.Text + @"') where TransactionID=" + lblTransactionID.Text + @"
                ";
                    DatabaseManager.ExecSQL(sql);

                    //SMS
                    if (lblMobile.Text.Trim() != "")
                    {
                        try
                        {
                            string SMS = "Thanks for bKash payment of your IEB membership fees paid upto " + rbtnPaidUpto.SelectedItem.Text + ". Your payment amount(" + lblAmount.Text + ") and trxID: " + lblTransactionID.Text;
                            MyWebRequest myRequest = new MyWebRequest("http://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + lblMobile.Text.Trim().Substring(1, 10) + "&mask=IEB&sms=" + SMS);
                            XmlDocument doc = new XmlDocument();

                            doc.LoadXml(myRequest.GetResponse());
                        }
                        catch (Exception ex)
                        { }

                    }

                    //Mail
                    if (lblEmail.Text.Trim() != "")
                    {
                        try
                        {
                            string mialMessage = "Dear Engr,<br/><br/>Thanks for bKash payment of your membership fees paid upto " + rbtnPaidUpto.SelectedItem.Text + ". Your payment amount(" + lblAmount.Text + ") & trxID: " + lblTransactionID.Text + "<br/>This is system generated payment confirmation mail.<hr/>With regards<br/>IT Section, IEB<br/>01766674142";
                            Sendmail.sendEmail(lblEmail.Text, "IEB Membership Fees payment confirmation", mialMessage);

                        }
                        catch (Exception ex)
                        { }
                    }
                     
                }
            }
            catch(Exception ex)
            {}
        }

        btnSearch_Click(this, new EventArgs());
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string sql = "update Acc_bKash_Final set " + ddlField.SelectedValue + " = '" + txtValue.Text + "' where TransactionID="+txtTrxIDUpdate.Text;
        DatabaseManager.ExecSQL(sql);
    }
    protected void btnConventionFee_Click(object sender, EventArgs e)
    {
        string sql = "";
        foreach (GridViewRow gvr in gvbKash.Rows)
        {
            try
            {
                TextBox txtCorrctReferenceNo = (TextBox)gvr.FindControl("txtCorrctReferenceNo");
                TextBox txtMemberShipNo = (TextBox)gvr.FindControl("txtMemberShipNo");
                Label lblTransactionID = (Label)gvr.FindControl("lblTransactionID");
                Label lblAmount = (Label)gvr.FindControl("lblAmount");
                Label lblTrancsactionTime = (Label)gvr.FindControl("lblTrancsactionTime");
                Label lblMobile = (Label)gvr.FindControl("lblMobile");
                Label lblEmail = (Label)gvr.FindControl("lblEmail");
                CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
                RadioButtonList rbtnPaidUpto = (RadioButtonList)gvr.FindControl("rbtnPaidUpto");
                if (chkSelect.Checked && txtMemberShipNo.Text.Trim()!="")
                {
                    sql = @"
update Acc_bKash_Final set ExtraField1=(Select cast(Mem_MemberID as nvarchar) from Mem_Member where MemberShipNo ='" + txtMemberShipNo.Text + @"') where TransactionID=" + lblTransactionID.Text + @"
               
SELECT Conv_RegistrationID
                    FROM [Conv_Registration]
                    where Mem_MemberID =(Select Mem_MemberID from Mem_Member where MemberShipNo='" + txtMemberShipNo.Text + @"')
";
                  DataSet dstmp=  DatabaseManager.ExecSQL(sql);
                    Conv_Registration tempConv_Registration = new Conv_Registration();
                    tempConv_Registration = Conv_RegistrationManager.GetConv_RegistrationByID(Int32.Parse(dstmp.Tables[0].Rows[0][0].ToString()));

                    if (tempConv_Registration.ExtraField2 != "")
                    {
                        if (!tempConv_Registration.TrxID.Contains(lblTransactionID.Text))
                        {
                            tempConv_Registration.TrxID += (tempConv_Registration.TrxID.Trim() == "" ? "" : ", ") + lblTransactionID.Text;
                        }
                        if (tempConv_Registration.ExtraField2.Contains("Money Receipt"))
                        {
                            tempConv_Registration.ExtraField2 = tempConv_Registration.ExtraField2.Replace("EnterTrxID", lblTransactionID.Text);
                        }
                        Conv_RegistrationManager.UpdateConv_Registration(tempConv_Registration);
                    }
                    else if (!tempConv_Registration.ExtraField2.Contains("Transaction ID(TrxID)</td>"))
                    {
                        if (!tempConv_Registration.TrxID.Contains(lblTransactionID.Text))
                        {
                            tempConv_Registration.TrxID += (tempConv_Registration.TrxID.Trim() == "" ? "" : ", ") + lblTransactionID.Text;
                        }

                        if (!tempConv_Registration.ExtraField2.Contains("Money Receipt"))
                        {
                            tempConv_Registration.ExtraField2 = tempConv_Registration.ExtraField1.Replace(
                                @"<tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Please write down here the Transaction ID(TraxID) which you will receive from bKash by SMS</td>
        <td style='border:1px solid black;' colspan='2'>&nbsp;</td>
    </tr>",
                                "<td style='border:1px solid black; text-align:right;' colspan='3'>Transaction ID(TrxID)</td>          <td style='border:1px solid black;' colspan='2'>" + lblTransactionID.Text + "</td>").Replace(
                                "<img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/>",
                                "<img src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/><br/>Money Receipt");
                        }
                        Conv_RegistrationManager.UpdateConv_Registration(tempConv_Registration);
                    }
                    //SMS
                    if (lblMobile.Text.Trim() != "")
                    {
                        try
                        {
                            string SMS = "Thanks for bKash payment to IEB.Your registration for Convention  55 is Confirmed. Your payment amount(" + lblAmount.Text + ") and trxID: " + lblTransactionID.Text;
                            MyWebRequest myRequest = new MyWebRequest("http://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + lblMobile.Text.Trim().Substring(1, 10) + "&mask=IEB&sms=" + SMS);
                            //MyWebRequest myRequest = new MyWebRequest("http://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=1818619647&mask=IEB&sms=" + SMS);
                            XmlDocument doc = new XmlDocument();

                            //doc.LoadXml(myRequest.GetResponse());
                        }
                        catch (Exception ex)
                        { }

                    }

                    //Mail
                    if (lblEmail.Text.Trim() != "")
                    {
                        try
                        {
                            string mialMessage = "Dear Engr,<br/><br/>Thanks for bKash payment.Your registration for Convention  55 is Confirmed.. Your payment amount(" + lblAmount.Text + ") and trxID: " + lblTransactionID.Text + "<br/>This is system generated payment confirmation mail.<hr/>We will send you the money receipt before 27th April<hr/>With regards<br/>IT Section, IEB<br/>01766674142";
                            //Sendmail.sendEmail(lblEmail.Text, "IEB Convention 55 Regsitration fee payment confirmation", mialMessage);

                        }
                        catch (Exception ex)
                        { }
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        btnSearch_Click(this, new EventArgs());
    }
    protected void btnJobFairFee_Click(object sender, EventArgs e)
    {
        string sql = "";
        foreach (GridViewRow gvr in gvbKash.Rows)
        {
            try
            {
                TextBox txtCorrctReferenceNo = (TextBox)gvr.FindControl("txtCorrctReferenceNo");
                TextBox txtMemberShipNo = (TextBox)gvr.FindControl("txtMemberShipNo");
                Label lblTransactionID = (Label)gvr.FindControl("lblTransactionID");
                Label lblAmount = (Label)gvr.FindControl("lblAmount");
                Label lblTrancsactionTime = (Label)gvr.FindControl("lblTrancsactionTime");
                Label lblMobile = (Label)gvr.FindControl("lblMobile");
                Label lblEmail = (Label)gvr.FindControl("lblEmail");
                CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
                RadioButtonList rbtnPaidUpto = (RadioButtonList)gvr.FindControl("rbtnPaidUpto");
                if (chkSelect.Checked && txtMemberShipNo.Text.Trim() != "")
                {
                    sql = @"
update Acc_bKash_Final set ExtraField1='" + txtMemberShipNo.Text + @"' where TransactionID=" + lblTransactionID.Text + @";
update Conv_JobFair set TrxID+=', " + lblTransactionID.Text + @"' where Conv_JobFairID=" + txtMemberShipNo.Text + @"
                ";
                    DatabaseManager.ExecSQL(sql);

                    //SMS
                    if (lblMobile.Text.Trim() != "")
                    {
                        try
                        {
                            string SMS = "Thanks for bKash payment.Your registration for Job Fair is Confirmed.. Your payment amount(" + lblAmount.Text + ") and trxID: " + lblTransactionID.Text;
                            MyWebRequest myRequest = new MyWebRequest("http://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + lblMobile.Text.Trim().Substring(1, 10) + "&mask=IEB&sms=" + SMS);
                            XmlDocument doc = new XmlDocument();

                            //doc.LoadXml(myRequest.GetResponse());
                        }
                        catch (Exception ex)
                        { }

                    }

                    //Mail
                    if (lblEmail.Text.Trim() != "")
                    {
                        try
                        {
                            string mialMessage = "Dear Engr,<br/><br/>Thanks for bKash payment.Your registration for Job Fair is Confirmed.. Your payment amount(" + lblAmount.Text + ") and trxID: " + lblTransactionID.Text + "<br/>This is system generated payment confirmation mail.<hr/>We will send you the money receipt before 27th April<hr/>With regards<br/>IT Section, IEB<br/>01766674142";
                            //Sendmail.sendEmail(lblEmail.Text, "IEB Job Fair Fees payment confirmation", mialMessage);

                        }
                        catch (Exception ex)
                        { }
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        btnSearch_Click(this, new EventArgs());
    }
}
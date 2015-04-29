using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class payment_bKashPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCount();

            txtFrom.Text = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            txtTo.Text= DateTime.Today.ToString("yyyy-MM-dd");
        }
    }

    private void loadCount()
    {
        string sql = @"Select Count(*) from Acc_bKash;Select Count(Distinct TransactionID) from Acc_bKash;";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        if (ds.Tables[0].Rows[0][0].ToString() != ds.Tables[0].Rows[0][0].ToString())
            lblCount.Text = "Problem";
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = @"SELECT Acc_bKash.[TransactionID]
                              ,Acc_bKash.[Service]
                              ,Acc_bKash.[Sender]
                              ,Acc_bKash.[Receiver]
                              ,Acc_bKash.[Amount]
                              ,Acc_bKash.[ReferenceNo]
                              ,Acc_bKash.[Counter]
                              ,Acc_bKash.[TrancsactionTime]
                          FROM [Acc_bKash]
                        where 1=1
";

        if (txtAmount.Text != "")
        {
            sql += " and Acc_bKash.Amount=" + txtAmount.Text;
        }
        if (txtFrom.Text != "")
        {
            sql += " and Acc_bKash.TrancsactionTime >= '" + txtFrom.Text + "'";
        }
        if (txtTo.Text != "")
        {
            sql += " and Acc_bKash.TrancsactionTime <= '" + txtTo.Text + "'";
        }

        if (txtReferenceNo.Text != "")
        {
            sql += " and Acc_bKash.ReferenceNo like '%" + txtReferenceNo.Text + "%'";
        }
        if (txtSender.Text != "")
        {
            sql += " and Acc_bKash.Sender=" + txtSender.Text;
        }

        if (txtTrxID.Text != "")
        {
            sql += " and Acc_bKash.TransactionID=" + txtTrxID.Text;
        }

        sql += @"
                order by Acc_bKash.TrancsactionTime desc";
        
        DataSet ds = DatabaseManager.ExecSQL(sql);

        lblCount.Text = ds.Tables[0].Rows.Count.ToString();

        gvbKash.DataSource = ds.Tables[0];
        gvbKash.DataBind();

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

    protected void btnSaveInDB_Click(object sender, EventArgs e)
    {
        string sql = "";
        foreach (GridViewRow gvr in gvbKash.Rows)
        {
            TextBox txtCorrctReferenceNo = (TextBox)gvr.FindControl("txtCorrctReferenceNo");
            Label lblTransactionID = (Label)gvr.FindControl("lblTransactionID");
            CheckBox chkSelect=(CheckBox)gvr.FindControl("chkSelect");
            
            if (chkSelect.Checked)
            { 
              sql+=@"
INSERT INTO [IEB].[dbo].[Acc_bKash_Final]
           ([TransactionID]
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
           ,[ExtraField5])
SELECT [TransactionID]
      ,[Sender]
      ,[Amount]
      ,[ReferenceNo]
      ,'"+txtCorrctReferenceNo.Text+@"'
      ,[Counter]
      ,[TrancsactionTime],'','','','','',''
  FROM [Acc_bKash]
   where  TransactionID =" + lblTransactionID.Text + @"
   
   if (select COUNT(*) from Acc_bKash_Final where  TransactionID = " + lblTransactionID.Text + @" ) =1
   BEGIN
	Delete Acc_bKash where  TransactionID = " + lblTransactionID.Text + @"
   END 
   ";
            }
        }

        DatabaseManager.ExecSQL(sql);
        btnSearch_Click(this, new EventArgs());
    }
}
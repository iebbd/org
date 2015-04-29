using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounts_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    private void loadData()
    {
        string sql = @"
SELECT Acc_bKash_Store.[TransactionID]
      ,Acc_bKash_Store.[Service]
      ,Acc_bKash_Store.[Sender]
      ,Acc_bKash_Store.[Receiver]
      ,Acc_bKash_Store.[Amount]
      ,Acc_bKash_Store.[ReferenceNo]
      ,Acc_bKash_Store.[Counter]
      ,Acc_bKash_Store.[TrancsactionTime]
      ,Acc_bKash_Final.FeferenceNoFinal
  FROM [Acc_bKash_Store]
left outer join Acc_bKash_Final on Acc_bKash_Final.TransactionID = Acc_bKash_Store.TransactionID
where FeferenceNoFinal like '%JOB%'
  order by [TrancsactionTime] asc

Select WithdrawalDate,Amount from Acc_BankBook
order by WithdrawalDate asc
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        string html = @"<table border='1' cellpadding='5' cellspacing='0' width='100%'>";
         string lastDate = DateTime.Parse(ds.Tables[0].Rows[0]["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd");
         int count_sub = 1;
         int count = 1;
         decimal subtotal = 0;

         decimal opeingBalance = 0;
         string header = "<tr style='background-color:#EFEFEF;font-weight:bold;'><td>S.I.</td><td></td><td>Time</td><td>Sender</td><td>Ref</td><td>TrxID</td><td>Amount</td><td>Total</td><td class='off'>IEB</td><td class='off'>Accumulated</td></tr>";
         html += header;
         //html += @"<tr><td></td><td></td><td>Opening Balance</td><td></td><td></td><td></td><td></td><td></td><td class='off'></td><td class='off'>" + opeingBalance.ToString("0,0.00") + @"</td></tr>";
         html += @"<tr><td></td><td></td><td>" + lastDate + "</td><td></td><td></td><td></td><td></td><td></td><td class='off'></td><td class='off'></td></tr>";
         decimal grandTotal = 0;
         decimal grandTotal_bKash = 0;
         decimal grandTotal_ieb = opeingBalance;
         foreach (DataRow dr in ds.Tables[0].Rows)
         {
             if (lastDate != DateTime.Parse(dr["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd"))
             {
                 decimal withDrawal = 0;
                 
                     grandTotal += subtotal;
                     grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0"));
                     grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0"));
                     html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + subtotal.ToString("0,0") + "</td><td class='off'>" + (subtotal * decimal.Parse("0.9875")).ToString("0,0") + "</td><td class='off'>" + (grandTotal_ieb).ToString("0,0.00") + "</td></tr>";
                    
                 subtotal = 0;
                 count_sub = 1;
                 lastDate = DateTime.Parse(dr["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd");
                 html += header + @"<tr><td></td><td></td><td>" + lastDate + "</td><td></td><td></td><td></td><td></td><td></td><td class='off'></td><td class='off'></td></tr>";
                
             }
             
             /*
              [TransactionID]
      ,[Service]
      ,[Sender]
      ,[Receiver]
      ,[Amount]
      ,[ReferenceNo]
              */

             html += @"<tr><td>" + (count++).ToString() + "</td><td>" + (count_sub++).ToString() + "</td><td>" + DateTime.Parse(dr["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd hh:mm tt")
                 + @"</td><td>" + dr["Sender"].ToString() + "</td><td>" + (dr["ReferenceNo"].ToString() == dr["FeferenceNoFinal"].ToString() ? dr["ReferenceNo"].ToString() : dr["ReferenceNo"].ToString() + " (" + dr["FeferenceNoFinal"].ToString() + ")") + "</td><td>" + dr["TransactionID"].ToString() + "</td><td>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0") + @"</td><td></td><td class='off'></td><td class='off'></td></tr>";
             subtotal += decimal.Parse(decimal.Parse(dr["Amount"].ToString()).ToString("0"));
             
         }
         grandTotal += subtotal;
         grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0"));
         grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0"));


         html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + subtotal.ToString("0,0") + "</td><td class='off'>" + (subtotal * decimal.Parse("0.9875")).ToString("0,0") + "</td><td class='off'>" + grandTotal_ieb.ToString("0,0.00") + "</td></tr>";
         html += @"<tr style='font-weight:bold;'><td></td><td></td><td></td><td></td><td></td><td></td><td>Total</td><td>" + grandTotal.ToString("0,0") + "</td><td class='off'>" + (grandTotal_bKash).ToString("0,0") + "</td><td class='off'>" + grandTotal_ieb.ToString("0,0.00") + "</td></tr></table>";

         lblAccount.Text = html;
    }
}
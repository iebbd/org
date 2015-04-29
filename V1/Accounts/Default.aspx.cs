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
  order by [TrancsactionTime] asc


Select WithdrawalDate,Amount
,Details ,'' as Added
from Acc_BankBook
order by WithdrawalDate asc
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        string html = @"<table border='1' cellpadding='5' cellspacing='0' width='100%'>";
         string lastDate = DateTime.Parse(ds.Tables[0].Rows[0]["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd");
         int count_sub = 1;
         int count = 1;
         decimal subtotal = 0;

         decimal opeingBalance = decimal.Parse(ds.Tables[1].Rows[0][1].ToString());
         ds.Tables[1].Rows[0]["Added"] = "added"; 
        
         string header = "<tr style='background-color:#EFEFEF;font-weight:bold;'><td>S.I.</td><td></td><td>Time</td><td>Sender</td><td>Ref</td><td>TrxID</td><td>Amount</td><td>bKash</td><td>IEB</td><td>Accumulated</td></tr>";
         html += header;
         html += @"<tr><td></td><td></td><td>Opening Balance</td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + opeingBalance.ToString("0,0.00") + @"</td></tr>";
        html += @"<tr><td></td><td></td><td>" + lastDate + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>";
         decimal grandTotal = 0;
         decimal grandTotal_bKash = 0;
         decimal grandTotal_ieb = opeingBalance;
        DataSet ds_bank=null;
         foreach (DataRow dr in ds.Tables[0].Rows)
         {
            
             if (lastDate != DateTime.Parse(dr["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd"))
             {



                 bool isBankTransaction = false;
                 decimal withDrawal = 0;
                 foreach (DataRow dr_BankBook in ds.Tables[1].Rows)
                 {
                     if (
                         DateTime.Parse(DateTime.Parse(dr_BankBook["WithdrawalDate"].ToString()).ToString("yyyy-MM-dd")) <= DateTime.Parse(DateTime.Parse(lastDate).ToString("yyyy-MM-dd"))
                         && dr_BankBook["Added"].ToString()==""

                         )
                     {
                         isBankTransaction = true;
                         withDrawal = decimal.Parse(dr_BankBook["Amount"].ToString());
                         html += @"<tr><td>" + (count++).ToString() + "</td><td>" + (count_sub++).ToString() + "</td><td>" + DateTime.Parse(dr_BankBook["WithdrawalDate"].ToString()).ToString("yyyy-MM-dd")
                         + @"</td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + ((-1)*withDrawal).ToString("0,0.00") + @"</td></tr>";
                         //grandTotal += subtotal;
                         //grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00")) - withDrawal;
                         grandTotal_ieb -= withDrawal;
                         //grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));
                         //html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + (grandTotal_ieb).ToString("0,0.00") + "</td></tr>";
                         dr_BankBook["Added"] = "added"; 
                        
                         //break;
                     }
                 }

                 //if (isBankTransaction)
                 //{
                 //    }

                 //if (DateTime.Parse(lastDate).ToString("yyyy-MM-dd") != "2014-04-16"
                 //    //&& !isBankTransaction
                 //    )
                 //{
                     grandTotal += subtotal;
                     grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));
                     grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));
                     html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + subtotal.ToString("0,0.00") + "</td><td>" + (subtotal * decimal.Parse("0.9875")).ToString("0,0.00") + "</td><td>" + (grandTotal_ieb).ToString("0,0.00") + "</td></tr>";
                    
                 //}
                 subtotal = 0;
                 count_sub = 1;
                 lastDate = DateTime.Parse(dr["TrancsactionTime"].ToString()).ToString("yyyy-MM-dd");
                 html +=header+ @"<tr><td></td><td></td><td>" + lastDate + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>";
                
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
                 + @"</td><td>" + dr["Sender"].ToString() + "</td><td>" + (dr["ReferenceNo"].ToString() == dr["FeferenceNoFinal"].ToString() ? dr["ReferenceNo"].ToString() : dr["ReferenceNo"].ToString() + " (" + dr["FeferenceNoFinal"].ToString() + ")") + "</td><td>" + dr["TransactionID"].ToString() + "</td><td>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0.00") + @"</td><td></td><td></td><td></td></tr>";
             subtotal += decimal.Parse(decimal.Parse(dr["Amount"].ToString()).ToString("0.00"));
             
         }

         foreach (DataRow dr_BankBook in ds.Tables[1].Rows)
         {
             if (dr_BankBook["Added"].ToString() == "")
             {
                 decimal withDrawal = 0;
                 withDrawal = decimal.Parse(dr_BankBook["Amount"].ToString());
                 html += @"<tr><td>" + (count++).ToString() + "</td><td>" + (count_sub++).ToString() + "</td><td>" + DateTime.Parse(dr_BankBook["WithdrawalDate"].ToString()).ToString("yyyy-MM-dd")
                 + @"</td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + ((-1) * withDrawal).ToString("0,0.00") + @"</td></tr>";
                 //grandTotal += subtotal;
                 //grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00")) - withDrawal;
                 grandTotal_ieb -= withDrawal;
                 //grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));
                 //html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + (grandTotal_ieb).ToString("0,0.00") + "</td></tr>";
                 dr_BankBook["Added"] = "added";

                 //break;
             }
         }
         grandTotal += subtotal;
         grandTotal_ieb += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));
         grandTotal_bKash += decimal.Parse((subtotal * decimal.Parse("0.9875")).ToString("0.00"));


         html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + subtotal.ToString("0,0.00") + "</td><td>" + (subtotal * decimal.Parse("0.9875")).ToString("0,0.00") + "</td><td>" + grandTotal_ieb.ToString("0,0.00") + "</td></tr>";
         html += @"<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + grandTotal.ToString("0,0.00") + "</td><td>" + (grandTotal_bKash).ToString("0,0.00") + "</td><td>" + grandTotal_ieb.ToString("0,0.00") + "</td></tr></table>";

         lblAccount.Text = html;
    }
}
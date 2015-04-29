using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Convention_RegKitDistribution : System.Web.UI.Page
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

SELECT [Conv_Registration].[Mem_MemberID]
      ,Mem_Member.MemberShipNo as  [ExtraField4]
      
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
 where TrxID <>'' and  StatusID<>3 and Conv_Registration.ExtraField3=''
order by Mem_Member.MemberShipNo desc

SELECT [Conv_Registration_Offline].[Mem_MemberID]
      ,Mem_Member.MemberShipNo as  [ExtraField4]
      
  FROM [Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration_Offline.Mem_MemberID
 where TrxID <>'' and  StatusID<>3  and Conv_Registration_Offline.ExtraField3=''
order by Mem_Member.MemberShipNo desc

SELECT Count([Conv_Registration_Offline].StatusID),StatusID
  FROM [Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration_Offline.Mem_MemberID
 where TrxID <>'' 
 Group by [Conv_Registration_Offline].StatusID
 order by  [Conv_Registration_Offline].StatusID
 
 
 SELECT Count([Conv_Registration].StatusID),StatusID
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
 where TrxID <>''
 Group by [Conv_Registration].StatusID
 order by  [Conv_Registration].StatusID

SELECT Count(*)
  FROM [Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration_Offline.Mem_MemberID
 where TrxID <>'' and StatusID=1 and [Conv_Registration_Offline].ExtraField3<>''
 
 SELECT Count(*)
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration.Mem_MemberID
 where TrxID <>'' and StatusID=1 and [Conv_Registration].ExtraField3<>''

";

        DataSet ds = DatabaseManager.ExecSQL(sql);

        DataList1.DataSource=ds.Tables[1];
        DataList1.DataBind();

        DataList2.DataSource = ds.Tables[0];
        DataList2.DataBind();
        decimal dueOffline = 0;//decimal.Parse(ds.Tables[4].Rows[0][0].ToString());
        decimal dueOnline = 0;//decimal.Parse(ds.Tables[5].Rows[0][0].ToString());

        lblOfflineDelivered.Text = (decimal.Parse(ds.Tables[2].Rows[1][0].ToString() )+ dueOffline).ToString("0,0");
        lblOnlineDelivered.Text = (decimal.Parse(ds.Tables[3].Rows[1][0].ToString() )+ dueOnline).ToString("0,0");

        lblOfflineRemaining.Text = (decimal.Parse(ds.Tables[2].Rows[0][0].ToString() )+ dueOffline ).ToString("0,0");
        lblOnlineRemaining.Text = (decimal.Parse(ds.Tables[3].Rows[0][0].ToString())+ dueOnline).ToString("0,0");

        lblOfflineTotal.Text = (decimal.Parse(lblOfflineDelivered.Text) + decimal.Parse(lblOfflineRemaining.Text)).ToString("0,0");
        lblOnlineTotal.Text = (decimal.Parse(lblOnlineDelivered.Text) + decimal.Parse(lblOnlineRemaining.Text)).ToString("0,0");
        decimal deliveredPer = ( (decimal.Parse(lblOnlineDelivered.Text) + decimal.Parse(lblOfflineDelivered.Text)) / (decimal.Parse(lblOnlineTotal.Text) + decimal.Parse(lblOfflineTotal.Text))) * 100;
        lblTotalDelivered.Text = (decimal.Parse(lblOnlineDelivered.Text) + decimal.Parse(lblOfflineDelivered.Text)).ToString("0,0");
        lblPer.Text = deliveredPer.ToString("0.00") + "%";
        lblTotalRemaining.Text = (decimal.Parse(lblOnlineRemaining.Text) + decimal.Parse(lblOfflineRemaining.Text)).ToString("0,0");
        //lblTotalRemaining.Text = (decimal.Parse(ds.Tables[3].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[2].Rows[0][0].ToString())).ToString("0,0");
        lblTotal.Text = (decimal.Parse(lblOfflineTotal.Text) + decimal.Parse(lblOnlineTotal.Text)).ToString("0,0");

         sql = @"select 1;select 1; select 1; select 1;
         --4
  SELECT SUM([LadiesBag])/1200 as [Total L. Bag Not Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline 
where TrxID <>'' and StatusID=1
 
 --5
  SELECT SUM([LadiesBag])/1200 as [Total L. Bag Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline 
where TrxID <>'' and StatusID=3

 --6
  SELECT SUM([LadiesBag])/1200 as [Total L. Bag Not Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=1 
 
 --7
  SELECT SUM([LadiesBag])/1200 as [Total L. Bag Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=3

--8
  SELECT SUM([IEBTie])/500 as [Total Tie Not Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=1
 
 --9
  SELECT SUM([IEBTie])/500 as [Total Tie Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=3
--10
  SELECT SUM([IEBTie])/500 as [Total Tie Not Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=1 
 
--11 
  SELECT SUM([IEBTie])/500 as [Total Tie Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=3

--12
SELECT COUNT(*) as [online Women  Delivered Online]
  FROM [IEB].[dbo].[Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID= Conv_Registration.Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2 and  TrxID <>'' and StatusID=1
  
--13
SELECT COUNT(*) as [online Women  Not Delivered Online]
  FROM [IEB].[dbo].[Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID= Conv_Registration.Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2 and TrxID <>'' and StatusID=3
  
--14
  SELECT COUNT(*) as [Offline Women  Delivered Offline]
  FROM [IEB].[dbo].[Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID= [Conv_Registration_Offline].Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2 and  TrxID <>'' and StatusID=1

--15
  SELECT COUNT(*) as [Offline Women Not Delivered Offline]
  FROM [IEB].[dbo].[Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID= [Conv_Registration_Offline].Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2 and TrxID <>'' and StatusID=3

--16
  SELECT (SUM([Dinner2])/800)*2 as [Total C. Dinner Not Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=1
 
 --17
  SELECT (SUM([Dinner2])/800)*2 as [Total C. Dinner Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=3
--18
  SELECT (SUM([Dinner2])/800)*2 as [Total C. Dinner Not Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=1 
 
--19 
  SELECT  (SUM([Dinner2])/800)*2 as [Total C. Dinner Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=3


--20
  SELECT SUM([Dinner1])/500 as [Total S. Dinner Not Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=1
 
 --21
  SELECT SUM([Dinner1])/500 as [Total S. Dinner Delivered(Offline)]
  FROM [IEB].[dbo].Conv_Registration_Offline  
where TrxID <>'' and StatusID=3
--22
  SELECT SUM([Dinner1])/500 as [Total S. Dinner Not Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=1 
 
--23 
  SELECT  SUM([Dinner1])/500 as [Total S. Dinner Delivered(Online)]
  FROM [IEB].[dbo].Conv_Registration 
where TrxID <>'' and StatusID=3
        
        ";

         ds = DatabaseManager.ExecSQL(sql);

         

         string html = @"
        <table border='1' cellpadding='2' cellspacing='0'>
<tr><td></td><td>Delivered</td><td>Not Delivered</td></tr>
<tr><td>L. Bag</td><td>" + (decimal.Parse(ds.Tables[5].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[7].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[12].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[14].Rows[0][0].ToString())).ToString("0") + @"</td><td>" + (decimal.Parse(ds.Tables[4].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[6].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[13].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[15].Rows[0][0].ToString())).ToString("0") + @"</td></tr>
<tr><td>Tie</td><td>" + (decimal.Parse(ds.Tables[9].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[11].Rows[0][0].ToString())).ToString("0") + @"</td><td>" + (decimal.Parse(ds.Tables[8].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[10].Rows[0][0].ToString())).ToString("0") + @"</td></tr>
<tr><td>Din</td><td>" + (decimal.Parse(ds.Tables[17].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[21].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[23].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[19].Rows[0][0].ToString())).ToString("0") + @"</td><td>" + (decimal.Parse(ds.Tables[22].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[16].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[18].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[20].Rows[0][0].ToString())).ToString("0") + @"</td></tr>
</table>
        ";

         lblSummary.Text = html;
    }
}
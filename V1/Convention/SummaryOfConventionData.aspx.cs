using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Convention_SummaryOfConventionData : System.Web.UI.Page
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
SELECT SUM(RegistrationFee)/1000 as [Total Registration]
		,SUM([Lunch1No]) as [Total Lunch (03/05)]
      ,SUM([Lunch2No]) as [Total Lunch (05/05)]
      ,SUM([Dinner1])/500 as [Total S. Dinner]
      ,SUM([Dinner2])/800 as [Total C. Dinner]
      ,SUM([LadiesBag])/1200 as [Total L. Bag]
      ,SUM([IEBTie])/500 as [Total Tie]
  FROM [IEB].[dbo].[Conv_Registration]
  where TrxID<>''
  
  SELECT SUM(RegistrationFee)/1000 as [Total Registration]
		,SUM([Lunch1No]) as [Total Lunch (03/05)]
      ,SUM([Lunch2No]) as [Total Lunch (05/05)]
      ,SUM([Dinner1])/500 as [Total S. Dinner]
      ,SUM([Dinner2])/800 as [Total C. Dinner]
      ,SUM([LadiesBag])/1200 as [Total L. Bag]
      ,SUM([IEBTie])/500 as [Total Tie]
  FROM [IEB].[dbo].Conv_Registration_Offline

SELECT COUNT(*) as [online Women]
  FROM [IEB].[dbo].[Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID= Conv_Registration.Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2
  
  SELECT COUNT(*) as [Offline Women]
  FROM [IEB].[dbo].[Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID= [Conv_Registration_Offline].Mem_MemberID
  inner join Comn_Gender on Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID
  where Comn_Gender.Comn_GenderID =2
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
";

        DataSet ds = DatabaseManager.ExecSQL(sql);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        GridView2.DataSource = ds.Tables[1];
        GridView2.DataBind();

        GridView3.DataSource = ds.Tables[2];
        GridView3.DataBind();
        GridView4.DataSource = ds.Tables[3];
        GridView4.DataBind();

        string html = @"
        <table border='1' cellpadding='2' cellspacing='0'>
<tr><td></td><td>Delivered</td><td>Not Delivered</td></tr>
<tr><td>L. Bag</td><td>" + (decimal.Parse(ds.Tables[5].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[7].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[12].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[14].Rows[0][0].ToString())).ToString("0") + @"</td><td>" + (decimal.Parse(ds.Tables[4].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[6].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[13].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[15].Rows[0][0].ToString())).ToString("0") + @"</td></tr>
<tr><td>Tie</td><td>" + (decimal.Parse(ds.Tables[9].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[11].Rows[0][0].ToString())).ToString("0") + @"</td><td>" + (decimal.Parse(ds.Tables[8].Rows[0][0].ToString()) + decimal.Parse(ds.Tables[10].Rows[0][0].ToString())).ToString("0") + @"</td></tr>
</table>
        ";

        lblSummary.Text = html;
    }
}
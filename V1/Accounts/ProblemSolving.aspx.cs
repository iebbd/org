using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounts_ProblemSolving : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadProblems();
        }
    }

    private void loadProblems()
    {
        string sql = @"
SELECT [Conv_Registration].[Mem_MemberID]
,Mem_Member.MemberShipNo
      ,cast([Conv_Registration].[TotalPayable] as decimal(18,2)) as TotalPayable
      ,[Conv_Registration].[TrxID]
      ,ieb.[dbo].[GetbKashPaidAmount_CON](CAST([Conv_Registration].Mem_MemberID as nvarchar(max)) ) as PaidAmount
      into #tmp
  FROM [Conv_Registration]
  inner join Mem_Member on Mem_Member.Mem_MemberID=[Conv_Registration].Mem_MemberID
  where TrxID<>''
  
  Select *,((PaidAmount-TotalPayable)*0.9875) as Refund from #tmp where PaidAmount<> TotalPayable
  drop table #tmp
";

        DataSet ds = DatabaseManager.ExecSQL(sql);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
}
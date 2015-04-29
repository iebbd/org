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
 where TrxID <>'' and  StatusID=3
order by Mem_Member.MemberShipNo desc

SELECT [Conv_Registration_Offline].[Mem_MemberID]
      ,Mem_Member.MemberShipNo as  [ExtraField4]
      
  FROM [Conv_Registration_Offline]
  inner join Mem_Member on Mem_Member.Mem_MemberID = Conv_Registration_Offline.Mem_MemberID
 where TrxID <>'' and  StatusID=3
order by Mem_Member.MemberShipNo desc


";

        DataSet ds = DatabaseManager.ExecSQL(sql);

        DataList1.DataSource=ds.Tables[1];
        DataList1.DataBind();

        DataList2.DataSource = ds.Tables[0];
        DataList2.DataBind();

        
    }
}
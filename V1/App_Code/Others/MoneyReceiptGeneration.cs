using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MoneyReceiptGeneration
/// </summary>
public class MoneyReceiptGeneration
{
	public MoneyReceiptGeneration()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string ConventionConfirmation(int id)
    {

        string html="";
        string sql = @"
SELECT     Conv_Registration.Conv_RegistrationID, Conv_Registration.Conv_ConventionID, Conv_Registration.Mem_MemberID, 
Conv_Registration.RegistrationFee, Conv_Registration.Lunch1No, Conv_Registration.Lunch1Amount,
Conv_Registration.Lunch2No, 
Conv_Registration.Lunch2Amount, Conv_Registration.Dinner1, Conv_Registration.Dinner2,
Conv_Registration.LadiesBag, 
Conv_Registration.IEBTie, Conv_Registration.TotalIEBFee, Conv_Registration.bKashFees,
Conv_Registration.TotalPayable, 
Conv_Registration.TrxID, Conv_Registration.AddedDate, Conv_Registration.TypeID, Conv_Registration.StatusID,
Conv_Registration.ExtraField1, 
Conv_Registration.ExtraField2, Conv_Registration.ExtraField3, Conv_Registration.ExtraField4,
Conv_Registration.ExtraField5, 
Mem_Member.MemberShipNo, Comn_Office.Comn_OfficeName, Mem_Member.Name, Mem_Member.Mobile, Mem_Member.Email, 
Mem_Member.PhoneOffice
FROM         Conv_Registration INNER JOIN
Mem_Member ON Conv_Registration.Mem_MemberID = Mem_Member.Mem_MemberID INNER JOIN
Comn_Office ON Mem_Member.Comn_OfficeID = Comn_Office.Comn_OfficeID

where Conv_Registration.TrxID<>'' and Conv_Registration.StatusID<>3 and Conv_Registration.Conv_RegistrationID=" + id + @"

";


        DataSet ds = DatabaseManager.ExecSQL(sql);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return "";
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];

            html = @"
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
        <td colspan='4' style='border:1px solid black;'>" + dr["Name"].ToString().Replace("ENGR. ", "") + @"</td>
    </tr>
<tr>
        <td style='border:1px solid black;'>PIN</td>
        <td colspan='4' style='border:1px solid black;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Membership No.</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["MemberShipNo"].ToString() + @"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Center</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Comn_OfficeName"].ToString() + @"</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Telephone No.</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["PhoneOffice"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Mobile</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Mobile"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Email Address</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Email"].ToString() + @"&nbsp;</td>
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
        <td style='border:1px solid black;text-align:center;'>" + dr["Lunch1No"].ToString() + @"&nbsp;</td>
        <td style='border:1px solid black;width:70px;'><b style='color: #FF0000;'>x</b> Tk. 130=</td>
        <td style='border:1px solid black;text-align:right;'>" + dr["Lunch1Amount"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>04 May'14</td>
        <td style='border:1px solid black;' colspan='3'>Lunch Will be provided by IEB</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>05 May'14</td>
        <td style='border:1px solid black;text-align:center;'>" + dr["Lunch2No"].ToString() + @"&nbsp;</td>
        <td style='border:1px solid black;'><b style='color: #FF0000;'>x</b> Tk. 130 =</td>
        <td style='border:1px solid black;text-align:right;'>" + dr["Lunch2Amount"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'><b style='color: #FF0000;'>*</b>Dinner</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Single</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + ((int.Parse(dr["Dinner1"].ToString())/500)!=0 ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + ((int.Parse(dr["Dinner1"].ToString()) / 500) != 0 ? "500" : "") + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>Couple</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + ((int.Parse(dr["Dinner2"].ToString()) / 800) != 0 ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 800 =</td>
        <td style='border:1px solid black;text-align:right;'>" + ((int.Parse(dr["Dinner2"].ToString()) / 800) != 0 ? "800" : "") + @"&nbsp;</td>
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
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + ((int.Parse(dr["LadiesBag"].ToString()) / 1200) != 0 ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 1200 =</td>
        <td style='border:1px solid black;text-align:right;'>" + ((int.Parse(dr["LadiesBag"].ToString()) / 1200) != 0 ?"1200":"") + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>IEB Tie</td>
        <td style='border:1px solid black;text-align:center;'>&nbsp;" + ((int.Parse(dr["IEBTie"].ToString()) / 500) != 0 ? "<img src='http://iebbd.org/images/Convention/check_mark.png' alt='tick_Mark'/>" : "") + @"</td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;text-align:right;'>" + ((int.Parse(dr["IEBTie"].ToString()) / 500) != 0 ? "500" : "") + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable(to IEB) =</td>
        <td style='border:1px solid black;' text-align:right;>" + dr["TotalIEBFee"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>bKash Fee(1.25%) =</td>
        <td style='border:1px solid black;' text-align:right;>" + dr["bKashFees"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable =</td>
        <td style='border:1px solid black;' text-align:right;>" + dr["TotalPayable"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:left;' colspan='5'>Thanks for your payment through bKash. Your registration is confirmed.
</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    
   
    <tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Transaction ID(TrxID)</td>
        <td style='border:1px solid black;' colspan='2'>" + dr["TrxID"].ToString() + @"</td>
    </tr>
</table>
</div>
";
        }


        return html;
    }

    public static string JobFairConfirmation(int id)
    {

        string html = "";
        string sql = @"

SELECT [Conv_JobFairID]
      ,[Name]
      ,[IEBMembershipNo]
      ,[Institution]
      ,[Deprtment]
      ,[PassingYear]
      ,[Mobile]
      ,[Email]
      ,[Details]
      ,[OfficeName]
      ,[TrxID]
      ,[ExtraField1]
      ,[ExtraField2]
      ,[ExtraField3]
      ,[ExtraField4]
      ,[ExtraField5]
      ,[AddedDate]
  FROM [Conv_JobFair]
  where TrxID<>'' and Conv_JobFairID=" + id + @"

";


        DataSet ds = DatabaseManager.ExecSQL(sql);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return "";
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];

            html = @"
<div style='border:1px solid black;background-color:#FDFBE6;font-family:Arial;font-size:12px;padding:10px;width:408px;'>
<table border='0' cellspacing='0' cellpadding='2' >
    
    <tr>
        <td colspan='5' style='background-color:white;'>
            <img src='http://iebbd.org/images/Convention/55/jobfairformheader.png' width='400px'/>
<br/>Money Receipt
        </td>
    </tr>
    <tr>
        <td style='border:1px solid black;' width='100px'>Name</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Name"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>IE Membership No.</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["IEBMembershipNo"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Institution</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Institution"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Department</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Deprtment"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Passing Year</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["PassingYear"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Mobile</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Mobile"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Email Address</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Email"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Experience (in year)</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["ExtraField4"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Special Skills</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["OfficeName"].ToString() + @"&nbsp;</td>
    </tr>
<tr>
        <td style='border:1px solid black;'>Other Details</td>
        <td colspan='4' style='border:1px solid black;'>" + dr["Details"].ToString() + @"&nbsp;</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Registration Fee</td>
        
        <td style='border:1px solid black;text-align:right;' colspan='4'>Tk. 100</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
   
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable(to IEB) =</td>
        <td style='border:1px solid black;' text-align:right;>100&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>bKash Fee(1.25%) =</td>
        <td style='border:1px solid black;' text-align:right;>2&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable =</td>
        <td style='border:1px solid black;' text-align:right;>102&nbsp;</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:center;' colspan='5'>Your Registration is confirmed</a>
</td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='3'>Reference No.</td>
        <td style='border:1px solid black;' colspan='2'>JOB" + dr["Conv_JobFairID"].ToString() + @"&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:left;' colspan='3'>Transaction ID(TraxID)</td>
        <td style='border:1px solid black;' colspan='2'>" + dr["TrxID"].ToString() + @"</td>
    </tr>
</table>
</div>
";
        }


        return html;
    }
}
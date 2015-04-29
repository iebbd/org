using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for DatabaseConnection
/// </summary>
public class CommonManager
{
    public CommonManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Int32 GetAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (a - b) / 10000;
    }

    public static string DateReform(string dateTextBox_Text)
    {
        string datePaid = "";
        if (dateTextBox_Text.Contains("-"))
        {
            datePaid = dateTextBox_Text.Split('-')[2] + "-" + dateTextBox_Text.Split('-')[1] + "-" + dateTextBox_Text.Split('-')[0];
        }
        else if (dateTextBox_Text.Contains("/"))
        {
            datePaid = dateTextBox_Text.Split('/')[2] + "-" + dateTextBox_Text.Split('/')[1] + "-" + dateTextBox_Text.Split('/')[0];
        }

        return datePaid;
    }

    public static string getPrictureFileName(string  path,string currentMembershipNo, string previousMembershipNo)
    { 
        string picture="";
        System.IO.FileInfo file;
        file = new FileInfo(path  + currentMembershipNo.Replace("/","-")+".jpg");
        if (!file.Exists)
        { 
            file = new FileInfo(path  + currentMembershipNo.Replace("/","-")+".gif");
            if (!file.Exists)
            {
                if (previousMembershipNo.Trim() != "")
                {
                    file = new FileInfo(path + previousMembershipNo.Replace("/", "-") + ".jpg");
                    if (!file.Exists)
                    {
                        file = new FileInfo(path + previousMembershipNo.Replace("/", "-") + ".gif");
                        if (!file.Exists)
                        {
                            picture = "";
                        }
                        else
                        {
                            picture = currentMembershipNo.Replace("/", "-") + ".gif";
                        }
                    }
                    else
                    {
                        picture = currentMembershipNo.Replace("/", "-") + ".jpg";
                    }
                }
            }
            else
            {
                picture = currentMembershipNo.Replace("/", "-") + ".gif"; 
            }
        }
        else
        {
            picture=currentMembershipNo.Replace("/","-")+".jpg";
        }

        return picture;
    }

    public static String DateReformation(string Date)
    {
      
        string datePaid = Date;
        if (Date.Contains("-"))
        {
            datePaid = Date.Split('-')[2] + "-" + Date.Split('-')[1] + "-" + Date.Split('-')[0];
        }
        else if (Date.Contains("/"))
        {
            datePaid = Date.Split('/')[2] + "-" + Date.Split('/')[1] + "-" + Date.Split('/')[0];
        }

        return datePaid;
    }

    public static string isInjection(string field)
    {
        if(
            field.Contains("=")
            || field.Contains("<")
            || field.Contains("--")
            || field.Contains(";")
            || field.Contains("''")
            || field.ToUpper().Contains("DROP ")
            || field.ToUpper().Contains("DELETE ")
            || field.ToUpper().Contains("UPDATE ")
            || field.ToUpper().Contains("CREATE ")
            || field.ToUpper().Contains("SELECT ")
            || field.ToUpper().Contains("INSERT ")
            //|| field.ToUpper().Contains(" AND ")
            || field.ToUpper().Contains(" OR ")
            || field.ToUpper().Contains("1=1")
            || field.ToUpper().Trim().Contains("1 = 1")
            || field.ToUpper().Trim().Contains("'1'='1'")
            )
        //if (!Regex.IsMatch(field, @"^(?=.*[a-z])(?=.*[A-Z]).{8,10}$"))
            throw new FormatException("SQL Injection");

        return field;
    }
    public static XmlDocument sendSMS(string _11DigitNo,string SMS)
    {
        MyWebRequest myRequest = new MyWebRequest("http://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + _11DigitNo.Substring(1, 10) + "&mask=IEB&sms=" + SMS);
        XmlDocument doc = new XmlDocument();

        string successMessage = "";
        doc.LoadXml(myRequest.GetResponse());
        XmlNodeList nodesUrl = doc.SelectNodes("response");
        return doc;
    }
    public static string StripHTML(string source)
    {
        try
        {
            string result;

            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            result = source.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating spaces because browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                  @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*head([^>])*>", "<head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*head( )*>)", "</head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<head>).*(</head>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*script([^>])*>", "<script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*script( )*>)", "</script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result,
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty,
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<script>).*(</script>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*style([^>])*>", "<style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*style( )*>)", "</style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<style>).*(</style>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*td([^>])*>", "\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*br( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*li( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*div([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*tr([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*p([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything that's enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<[^>]*>", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @" ", " ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"•", " * ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"‹", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"›", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"™", "(tm)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"⁄", "/",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @">", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"©", "(c)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"®", "(r)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see
            // http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&(.{2,6});", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // for testing
            //System.Text.RegularExpressions.Regex.Replace(result,
            //       this.txtRegex.Text,string.Empty,
            //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4.
            // Prepare first to remove any whitespaces in between
            // the escaped characters and remove redundant tabs in between line breaks
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\t)", "\t\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\r)", "\t\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\t)", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove multiple tabs following a line break with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Initial replacement target string for line breaks
            string breaks = "\r\r\r";
            // Initial replacement target string for tabs
            string tabs = "\t\t\t\t\t";
            for (int index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // That's it.
            return result;
        }
        catch
        {
            return source;
        }
    }

    public static void processSQLInjection()
    {
        processMembership();
        processEvent();
        processOffice();
    }

     public static void processEvent()
    {
        string sql = @"
SELECT Web_EventID,[SmallPictureURL]
      ,[DetailsPictureURL]
  FROM [Web_Event]
  where 
SmallPictureURL like '%<%' or
DetailsPictureURL like '%<%'
";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        sql = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            sql = @"
Update  [Web_Event] 
set SmallPictureURL='" + stringReplace(dr["SmallPictureURL"].ToString()).Split('<')[0].Trim() + @"'
, DetailsPictureURL='" + stringReplace(dr["DetailsPictureURL"].ToString()).Split('<')[0].Trim() + @"'

where Web_EventID=" + dr["Web_EventID"].ToString() + @";
                ";

            try
            {
                DatabaseManager.ExecSQL(sql);
            }
            catch (Exception ex)
            {

            }
        }
    }

     public static void processOffice()
    {
        string sql = @"
SELECT  [Comn_OfficeID]
      ,[Comn_OfficeName]
      ,[Website]
      ,[Phone]
      ,[Fax]
      ,[Details]
  FROM [Comn_Office]
  where Comn_OfficeName like '%<%'
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        sql = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            sql = @"Update  [Comn_Office] 
set Comn_OfficeName='" + stringReplace(dr["Comn_OfficeName"].ToString()).Split('<')[0] + @"'
, Website='" + stringReplace(dr["Website"].ToString()).Split('<')[0] + @"'
, Phone='" + stringReplace(dr["Phone"].ToString()).Split('<')[0] + @"'
, Fax='" + stringReplace(dr["Fax"].ToString()).Split('<')[0] + @"'
, Details='" + stringReplace(dr["Details"].ToString()).Split('<')[0] + @"'

where Comn_OfficeID=" + dr["Comn_OfficeID"].ToString() + @";
                ";

            try
            {
                DatabaseManager.ExecSQL(sql);
            }
            catch (Exception ex)
            {

            }
        }
    }

     public static void processMembership()
    {
        string sql = @"
SELECT Mem_MemberID,MemberShipNo----(10),>
           , Name----(256),>
           , PlaceOfBrith----(100),>
           , MailingAddress1----(256),>
           , MailingAddress2----(256),>
           , MailingAddress3----(256),>
           , MailingAddress----(256),>
           , PermanentAddress----(256),>
           , PermanentAddress1----(256),>
           , PermanentAddress2----(256),>
           , PermanentAddress3----(256),>
           , PhoneOffice----(256),>
           , PhoneResidence----(256),>
           , Mobile----(256),>
           , Email----(256),>
           , Fax----(256),>
           , OtherContactInfo----(256),>
           , PresentIEBMembershipNo----(50),>
           , CopiesOfCertificatesComment----(256),>
           , CopiesOfTranscriptsComment----(256),>
           , ProfessionalRecordEnclosedComment----(256),>
           , RecomenDationCommentOffice----(256),>
           , AgeMembershipSection----(256),>
           , Education----(256),>
           , Exprerience----(256),>
           , RecomenDationCommentMembershipSec----(256),>
           , PictureURL----(256),>
           , SignatureURL----(256),>
           , Comn_BloodGroup----(3),>
           , PassportNo----(20),>
           , NationalIDNo----(256),>
           , BirthRegistrationID----(256),>
           , ExtraField1----(256),>
           , ExtraField2----(256),>
           , ExtraField3----(256),>
           , ExtraField4----(256),>
           , ExtraField5----(256),>
           , ExtraField6----(256),>
           , ExtraField7----(256),>
           , ExtraField8----(256),>
           , ExtraField9----(256),>
           , ExtraField10----(256),>
           , ExtraField11----(256),>
           , ExtraField12----(256),>
           , ExtraField13----(256),>
           , ExtraField14----(256),>
           , ExtraField15----(256),>
           , ExtraField16----(256),>
           , ExtraField17----(256),>
           , ExtraField18----(256),>
           , ExtraField19----(256),>
           , ExtraField20----(256),>
  FROM [Mem_Member]
  where 
 MemberShipNo like '%<%'--(10),>
           or Name like '%<%'--(256),>
           or PlaceOfBrith like '%<%'--(100),>
           or MailingAddress1 like '%<%'--(256),>
           or MailingAddress2 like '%<%'--(256),>
           or MailingAddress3 like '%<%'--(256),>
           or MailingAddress like '%<%'--(256),>
           or PermanentAddress like '%<%'--(256),>
           or PermanentAddress1 like '%<%'--(256),>
           or PermanentAddress2 like '%<%'--(256),>
           or PermanentAddress3 like '%<%'--(256),>
           or PhoneOffice like '%<%'--(256),>
           or PhoneResidence like '%<%'--(256),>
           or Mobile like '%<%'--(256),>
           or Email like '%<%'--(256),>
           or Fax like '%<%'--(256),>
           or OtherContactInfo like '%<%'--(256),>
           or PresentIEBMembershipNo like '%<%'--(50),>
           or CopiesOfCertificatesComment like '%<%'--(256),>
           or CopiesOfTranscriptsComment like '%<%'--(256),>
           or ProfessionalRecordEnclosedComment like '%<%'--(256),>
           or RecomenDationCommentOffice like '%<%'--(256),>
           or AgeMembershipSection like '%<%'--(256),>
           or Education like '%<%'--(256),>
           or Exprerience like '%<%'--(256),>
           or RecomenDationCommentMembershipSec like '%<%'--(256),>
           or PictureURL like '%<%'--(256),>
           or SignatureURL like '%<%'--(256),>
           or Comn_BloodGroup like '%<%'--(3),>
           or PassportNo like '%<%'--(20),>
           or NationalIDNo like '%<%'--(256),>
           or BirthRegistrationID like '%<%'--(256),>
           or ExtraField1 like '%<%'--(256),>
           or ExtraField2 like '%<%'--(256),>
           or ExtraField3 like '%<%'--(256),>
           or ExtraField4 like '%<%'--(256),>
           or ExtraField5 like '%<%'--(256),>
           or ExtraField6 like '%<%'--(256),>
           or ExtraField7 like '%<%'--(256),>
           or ExtraField8 like '%<%'--(256),>
           or ExtraField9 like '%<%'--(256),>
           or ExtraField10 like '%<%'--(256),>
           or ExtraField11 like '%<%'--(256),>
           or ExtraField12 like '%<%'--(256),>
           or ExtraField13 like '%<%'--(256),>
           or ExtraField14 like '%<%'--(256),>
           or ExtraField15 like '%<%'--(256),>
           or ExtraField16 like '%<%'--(256),>
           or ExtraField17 like '%<%'--(256),>
           or ExtraField18 like '%<%'--(256),>
           or ExtraField19 like '%<%'--(256),>
           or ExtraField20 like '%<%'--(256),>
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        sql = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            sql = @"Update  [Mem_Member] 
set MemberShipNo='" + stringReplace(dr["MemberShipNo"].ToString()).Split('<')[0] + @"'
,Name='" + stringReplace(dr["Name"].ToString()).Split('<')[0] + @"'
,PlaceOfBrith='" + stringReplace(dr["PlaceOfBrith"].ToString()).Split('<')[0] + @"'
,MailingAddress1='" + stringReplace(dr["MailingAddress1"].ToString()).Split('<')[0] + @"'
,MailingAddress2='" + stringReplace(dr["MailingAddress2"].ToString()).Split('<')[0] + @"'
,MailingAddress3='" + stringReplace(dr["MailingAddress3"].ToString()).Split('<')[0] + @"'
,MailingAddress='" + stringReplace(dr["MailingAddress"].ToString()).Split('<')[0] + @"'
,PermanentAddress='" + stringReplace(dr["PermanentAddress"].ToString()).Split('<')[0] + @"'
,PermanentAddress1='" + stringReplace(dr["PermanentAddress1"].ToString()).Split('<')[0] + @"'
,PermanentAddress2='" + stringReplace(dr["PermanentAddress2"].ToString()).Split('<')[0] + @"'
,PermanentAddress3='" + stringReplace(dr["PermanentAddress3"].ToString()).Split('<')[0] + @"'
,PhoneOffice='" + stringReplace(dr["PhoneOffice"].ToString()).Split('<')[0] + @"'
,PhoneResidence='" + stringReplace(dr["PhoneResidence"].ToString()).Split('<')[0] + @"'
,Mobile='" + stringReplace(dr["Mobile"].ToString()).Split('<')[0] + @"'
,Email='" + stringReplace(dr["Email"].ToString()).Split('<')[0] + @"'
,Fax='" + stringReplace(dr["Fax"].ToString()).Split('<')[0] + @"'
,OtherContactInfo='" + stringReplace(dr["OtherContactInfo"].ToString()).Split('<')[0] + @"'
,PresentIEBMembershipNo='" + stringReplace(dr["PresentIEBMembershipNo"].ToString()).Split('<')[0] + @"'
,CopiesOfCertificatesComment='" + stringReplace(dr["CopiesOfCertificatesComment"].ToString()).Split('<')[0] + @"'
,CopiesOfTranscriptsComment='" + stringReplace(dr["CopiesOfTranscriptsComment"].ToString()).Split('<')[0] + @"'
,ProfessionalRecordEnclosedComment='" + stringReplace(dr["ProfessionalRecordEnclosedComment"].ToString()).Split('<')[0] + @"'
,RecomenDationCommentOffice='" + stringReplace(dr["RecomenDationCommentOffice"].ToString()).Split('<')[0] + @"'
,AgeMembershipSection='" + stringReplace(dr["AgeMembershipSection"].ToString()).Split('<')[0] + @"'
,Education='" + stringReplace(dr["Education"].ToString()).Split('<')[0] + @"'
,Exprerience='" + stringReplace(dr["Exprerience"].ToString()).Split('<')[0] + @"'
,RecomenDationCommentMembershipSec='" + stringReplace(dr["RecomenDationCommentMembershipSec"].ToString()).Split('<')[0] + @"'
,PictureURL='" + stringReplace(dr["PictureURL"].ToString()).Split('<')[0] + @"'
,SignatureURL='" + stringReplace(dr["SignatureURL"].ToString()).Split('<')[0] + @"'
,Comn_BloodGroup='" + stringReplace(dr["Comn_BloodGroup"].ToString()).Split('<')[0] + @"'
,PassportNo='" + stringReplace(dr["PassportNo"].ToString()).Split('<')[0] + @"'
,NationalIDNo='" + stringReplace(dr["NationalIDNo"].ToString()).Split('<')[0] + @"'
,BirthRegistrationID='" + stringReplace(dr["BirthRegistrationID"].ToString()).Split('<')[0] + @"'
,ExtraField1='" + stringReplace(dr["ExtraField1"].ToString()).Split('<')[0] + @"'
,ExtraField2='" + stringReplace(dr["ExtraField2"].ToString()).Split('<')[0] + @"'
,ExtraField3='" + stringReplace(dr["ExtraField3"].ToString()).Split('<')[0] + @"'
,ExtraField4='" + stringReplace(dr["ExtraField4"].ToString()).Split('<')[0] + @"'
,ExtraField5='" + stringReplace(dr["ExtraField5"].ToString()).Split('<')[0] + @"'
,ExtraField6='" + stringReplace(dr["ExtraField6"].ToString()).Split('<')[0] + @"'
,ExtraField7='" + stringReplace(dr["ExtraField7"].ToString()).Split('<')[0] + @"'
,ExtraField8='" + stringReplace(dr["ExtraField8"].ToString()).Split('<')[0] + @"'
,ExtraField9='" + stringReplace(dr["ExtraField9"].ToString()).Split('<')[0] + @"'
,ExtraField10='" + stringReplace(dr["ExtraField10"].ToString()).Split('<')[0] + @"'
,ExtraField11='" + stringReplace(dr["ExtraField11"].ToString()).Split('<')[0] + @"'
,ExtraField12='" + stringReplace(dr["ExtraField12"].ToString()).Split('<')[0] + @"'
,ExtraField13='" + stringReplace(dr["ExtraField13"].ToString()).Split('<')[0] + @"'
,ExtraField14='" + stringReplace(dr["ExtraField14"].ToString()).Split('<')[0] + @"'
,ExtraField15='" + stringReplace(dr["ExtraField15"].ToString()).Split('<')[0] + @"'
,ExtraField16='" + stringReplace(dr["ExtraField16"].ToString()).Split('<')[0] + @"'
,ExtraField17='" + stringReplace(dr["ExtraField17"].ToString()).Split('<')[0] + @"'
,ExtraField18='" + stringReplace(dr["ExtraField18"].ToString()).Split('<')[0] + @"'
,ExtraField19='" + stringReplace(dr["ExtraField19"].ToString()).Split('<')[0] + @"'
,ExtraField20='" + stringReplace(dr["ExtraField20"].ToString()).Split('<')[0] + @"'
where Mem_MemberID=" + dr["Mem_MemberID"].ToString() + @";
                ";

            try
            {
                DatabaseManager.ExecSQL(sql);
            }
            catch (Exception ex)
            {

            }
        }
    }

     public static string stringReplace(string p)
    {
        return p.Replace("'", "''");
    }  
}
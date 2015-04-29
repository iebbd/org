using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class Convention_MoneyReceiptProcessing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string sql = @"
SELECT    Mem_Member.Name,Mem_Member.Mobile,Mem_Member.Email,Conv_Registration.Conv_RegistrationID
FROM        Conv_Registration INNER JOIN
                     Mem_Member ON Conv_Registration.Mem_MemberID =Mem_Member.Mem_MemberID
                     where Conv_Registration.TrxID<>''
";

            DataSet ds = DatabaseManager.ExecSQL(sql);
            //bool isStart = false;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                


                //SMS
                /*
                if (dr["Mobile"].ToString().Trim() != "")
                {
                        try
                        {
                            string SMS = "Thanks for bKash payment to IEB. Your registration for Convention  55 is Confirmed.Please print your registration form (or money receipt) and bring it in Convention. www.iebbd.org/print.aspx?id=" + dr["Conv_RegistrationID"].ToString();
                            MyWebRequest myRequest = new MyWebRequest("https://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=" + dr["Mobile"].ToString().Trim().Substring(1, 10) + "&mask=IEB&sms=" + SMS);
                            //MyWebRequest myRequest = new MyWebRequest("https://cbsms.grameenphone.com/send_sms_api/send_sms_from_api.php?user_name=IEBadmin&password=IEBadmin123&subscriber_no=1818619647&mask=IEB&sms=" + SMS);
                            XmlDocument doc = new XmlDocument();

                            doc.LoadXml(myRequest.GetResponse());
                        }
                        catch (Exception ex)
                        { }

                    }
                */
                    //Mail
                    if (dr["Email"].ToString().Trim() != "")
                    {
                        try
                        {
                            //string mialMessage = "Dear " + dr["Name"].ToString() + ",<br/><br/>Thanks for bKash payment.Your registration for Convention  55 is Confirmed.<br/><a href='www.iebbd.org/print.aspx?id=" +dr["Conv_RegistrationID"].ToString() + "'>Click here to print your registration form(or money receipt) which you need to bring in Convention</a><hr/>This is system generated payment confirmation mail.<hr/>With regards<br/>IT Section, IEB<br/>01766674142";
                           Sendmail.sendEmail(dr["Email"].ToString().Trim(), "[Correction] IEB 55th Convention Registration form(i.e. Money receipt)", MoneyReceiptGeneration.ConventionConfirmation(int.Parse(dr["Conv_RegistrationID"].ToString())));

                        }
                        catch (Exception ex)
                        { }
                    }
            }

        }
    }
}
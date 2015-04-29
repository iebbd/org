using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;


/// <summary>
/// Summary description for Sendmail
/// </summary>
public class Sendmail
{
    public Sendmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void sendEmail(String toAddr,  String subject, String body)
    {
        try
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("it.iebbd@gmail.com", "itiebbdorg");
            MailAddress from = new MailAddress("it.iebbd@gmail.com", "IEB");
            MailAddress to = new MailAddress(toAddr);
            MailAddress bcc = new MailAddress("it.iebbd@gmail.com");
            MailMessage message = new MailMessage(from,to);
            message.Bcc.Add(bcc);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
            }
        }
        catch (Exception ex)
        {

            

        }

    }
}

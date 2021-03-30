using System;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

/// <summary>
/// Summary description for SendEmail1
/// </summary>
public class SendEmail1
{
	public SendEmail1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool SendEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {

            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "86.96.198.37";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\admissions", "Mark205");
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\hrd@skylineuniversity.ac.ae", "Hsky2090");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;

            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != "")
                mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);

            mail.Body = mailbody.ToString();
            SmtpServer.Send(mail);
            return true;


        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
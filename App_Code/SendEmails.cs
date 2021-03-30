using System;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

/// <summary>
/// Summary description for SendEmails
/// </summary>
public class SendEmails
{
    public SendEmails()
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
           // SmtpServer.Port =25;
           //SmtpServer.Host = "86.96.198.37";
           // //SmtpServer.Host = "smtp.office365.com";
           //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\hrd@skylineuniversity.ac.ae", "Hsky2090");

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\hrd@skylineuniversity.ac.ae", "Hsky2090");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;
     

            mail.From = new MailAddress(pGmailEmail);
            mail.To.Add(pTo);
            mail.Subject = pSubject;

            if (cc != "")
            {
                string[] CCId = cc.Split(',');
                foreach (string CCEmail in CCId)
                {
                    mail.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                }
            }

            //if (cc != "")
            //    mail.CC.Add(cc);
            mail.IsBodyHtml = true;

            mailbody.Append(pBody);
                     

            mail.Body = mailbody.ToString();
            SmtpServer.Send(mail);
            return true;


        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public static bool TestSendEmail(string pGmailEmail, string pTo, string pSubject, string pBody, string cc)
    {
        try
        {

            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            // SmtpServer.Port =25;
            //SmtpServer.Host = "86.96.198.37";
            // //SmtpServer.Host = "smtp.office365.com";
            //SmtpServer.Credentials = new NetworkCredential("86.96.198.37\\hrd@skylineuniversity.ac.ae", "Hsky2090");

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\software@skylineuniversity.ac.ae", "Ssky2007");
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;

            foreach (var address in pTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mail.To.Add(address);
            }

            mail.From = new MailAddress(pGmailEmail);
          //  mail.To.Add(pTo);
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
            throw;
        }
    }
   
}
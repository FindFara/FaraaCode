using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CodeTo.Core.Utilities.Senders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("codetofree@gmail.com");
                    message.To.Add(to);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;


                    //System.Net.Mail.Attachment attachment;
                    // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                    // mail.Attachments.Add(attachment);


                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("codetofree@gmail.com", "Nasern4567@@##$$");
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                }


            }
            catch (Exception er)
            {

                throw;
            }

        }
    }
}

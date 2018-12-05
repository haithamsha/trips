using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.Net;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void sendEmail()
        {
            

               // send mail
                //Thread mailThread = new Thread(delegate ()
                //{
                MailMessage ms = new MailMessage("Csharpproject2019@gmail.com", "haithamshaabann@gmail.com");
                ms.Subject = "test";
                ms.Body = "tet body";
                ms.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                NetworkCredential netWorkCard = new NetworkCredential("Csharpproject2019@gmail.com", "11223344mmc");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = netWorkCard;
                smtpClient.Port = 587;
                smtpClient.Send(ms);
               
            

        }

    }
}

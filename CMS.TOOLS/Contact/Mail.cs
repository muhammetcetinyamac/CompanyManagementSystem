using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CMS.TOOLS.Contact
{
    public class Mail
    {
      
        public void GorusmeSonucu(string email , string name, TransactionStatus confirmation)
        {
            switch ((int)confirmation)
            {
                case 7:
                    SendMail("CMS İnsan Kaynakları", email, "Sayın " + name + ";\n" + "Şirketimize bulunduğunuz iş başvuru onaylanmadı");
                    break;
                case 6:
                    SendMail("CMS İnsan Kaynakları", email, "Sayın " + name + ";\n" + "Şirketimize bulunduğunuz iş başvuru onaylandı. En yakın zamanda Firmamıza bekleriz");
                    break;
                case 1:
                    SendMail("CMS İnsan Kaynakları", email, "Sayın " + name + ";\n" + "İş Başvurunuz İnsan Kaynakları Tarafından İncelendikten Sonra Sizi Mail İle Bilgilendireceğiz. İyi Günler");
                    break;
            }
            
        }


        public void SendMail(string konu, string alici, string message)
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                sc.Credentials = new NetworkCredential("eposta@gmail.com", "gmail_sifre");

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(alici, "CMS");

                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = message;

                sc.Send(mail);
               // return true;

            }
            catch
            {
               // return false;
            }
            
        }
    }
}

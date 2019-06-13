using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows;

namespace WpfMailSender
{
    public class EmailSendServiceClass
    {
        public void MailSend(string strPassword)
        {
            foreach (string mail in SmtpServer.ListStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(SmtpServer.Sender, mail))
                {
                    // Формируем письмо
                    mm.Subject = SmtpServer.Subject; // Заголовок письма
                    mm.Body = SmtpServer.Body;       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                     // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient(SmtpServer.Host, SmtpServer.Port))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new System.Net.NetworkCredential(SmtpServer.Sender, strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                            SendErrorWindow srw = new SendErrorWindow("Невозможно отправить письмо: " + ex.ToString());
                            srw.ShowDialog();
                        }
                    }
                }
            }
            //MessageBox.Show("Работа завершена.");
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();


        }
    }
}

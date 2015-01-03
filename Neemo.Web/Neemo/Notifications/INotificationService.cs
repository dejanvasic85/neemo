using System.Net.Mail;
using System.Threading.Tasks;

namespace Neemo.Notifications
{
    public interface INotificationService
    {
        void Email(string subject, string body, string from, params string[] to);
    }

    public class NotificationService : INotificationService
    {
        public void Email(string subject, string body, string @from, params string[] to)
        {
            Task.Run(() =>
            {
                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    Body = body,
                    Subject = subject
                };
                mailMessage.To.Add(string.Join(",", to));
                mailMessage.From = new MailAddress(from);

                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);
            });
        }
    }
}
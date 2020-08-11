using Min_Helpers.AttributeHelper;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Min_Helpers.EmailHelper
{
    /// <summary>
    /// Email
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Config
        /// </summary>
        public IEmailConfig Config { get; private set; }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="config"></param>
        public void Initialization(IEmailConfig config)
        {
            try
            {
                Validate.TryValidateObject(config);
                
                if (string.IsNullOrEmpty(config.SenderName))
                {
                    config.SenderName = config.SenderEmail;
                }

                this.Config = config;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"email helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(IEmailMessage message)
        {
            try
            {
                Validate.TryValidateObject(message);

                using (SmtpClient client = new SmtpClient(this.Config.ServerHost, this.Config.ServerPort))
                {
                    client.Credentials = new NetworkCredential(this.Config.SenderEmail, this.Config.SenderPassword);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(this.Config.SenderEmail, this.Config.SenderName);
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.Normal;

                        mail.Subject = message.Title;

                        mail.Body = message.Content;

                        for (int i = 0; message.Tos != null && i < message.Tos.Count; i++)
                            mail.To.Add(message.Tos[i]);

                        for (int i = 0; message.Ccs != null && i < message.Ccs.Count; i++)
                            mail.CC.Add(message.Ccs[i]);

                        for (int i = 0; message.Ccs != null && i < message.Ccs.Count; i++)
                            mail.Bcc.Add(message.Bccs[i]);

                        for (int i = 0; message.Attachments != null && i < message.Attachments.Count; i++)
                            mail.Attachments.Add(message.Attachments[i]);

                        await client.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"email helper: {ex.Message}", ex);

                throw exception;
            }
        }
    }
}

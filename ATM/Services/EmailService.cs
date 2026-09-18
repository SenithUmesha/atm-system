using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace ATM
{
    internal static class EmailService
    {
        public static bool IsConfigured
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ZEMO_SMTP_HOST"))
                    && !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ZEMO_SMTP_USERNAME"))
                    && !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ZEMO_SMTP_PASSWORD"));
            }
        }

        public static bool TrySendTemplate(
            string recipient,
            string subject,
            string templateFileName,
            IDictionary<string, string> replacements,
            out string error)
        {
            error = null;

            if (!IsConfigured)
            {
                error = "SMTP is not configured.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(recipient))
            {
                error = "The account does not have an email address.";
                return false;
            }

            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templateFileName);
            if (!File.Exists(templatePath))
            {
                error = "The email template could not be found.";
                return false;
            }

            string body = File.ReadAllText(templatePath);
            if (replacements != null)
            {
                foreach (KeyValuePair<string, string> replacement in replacements)
                {
                    string safeValue = WebUtility.HtmlEncode(replacement.Value ?? string.Empty);
                    body = body.Replace("{{" + replacement.Key + "}}", safeValue);
                }
            }

            string host = Environment.GetEnvironmentVariable("ZEMO_SMTP_HOST");
            string username = Environment.GetEnvironmentVariable("ZEMO_SMTP_USERNAME");
            string password = Environment.GetEnvironmentVariable("ZEMO_SMTP_PASSWORD");
            string from = Environment.GetEnvironmentVariable("ZEMO_SMTP_FROM");
            if (string.IsNullOrWhiteSpace(from))
            {
                from = username;
            }

            int port = 587;
            string portValue = Environment.GetEnvironmentVariable("ZEMO_SMTP_PORT");
            if (!string.IsNullOrWhiteSpace(portValue) && int.TryParse(portValue, out int configuredPort))
            {
                port = configuredPort;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(host, port))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(username, password);

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(from, "ZEMO Bank");
                        mailMessage.To.Add(new MailAddress(recipient));
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Priority = MailPriority.High;
                        smtpClient.Send(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}

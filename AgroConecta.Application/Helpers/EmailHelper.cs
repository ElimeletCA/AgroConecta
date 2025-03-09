using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace AgroConecta.Application.Helpers;

public class EmailHelper
    {
        private readonly IConfiguration _config;
        public EmailHelper(IConfiguration config)
        {
            _config = config;
        }

        public bool EnviarCorreoCodigoDobleFactor(string userEmail, string code)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_config["Mail:Username"]);
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Código de verificación 2FA";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = code;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            client.Host = _config["Mail:Host"];
            client.Port = Convert.ToInt32(_config["Mail:Port"]);

            try
            {
                var mensaje = mailMessage;
                //client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
        public bool EnviarCorreo(string userEmail, string confirmationLink)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_config["Mail:Username"]);
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirmación de correo electrónico";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            client.Host = _config["Mail:Host"];
            client.Port = Convert.ToInt32(_config["Mail:Port"]);

            try
            {
                var mensaje = mailMessage;
                //client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
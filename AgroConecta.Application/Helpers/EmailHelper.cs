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
            mailMessage.From = new MailAddress("no-reply@agroconecta.com.do");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Código de verificación 2FA";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $@"
                 <html>
                 <body>
                     <p>Hola {userEmail},</p>
                     <p>Gracias por utilizar nuestros servicios. Para continuar con tu proceso de autenticación, por favor usa el siguiente código:</p>
                     <p><strong style='font-size: 24px;'>{code}</strong></p>
                     <p>Este código es válido por los próximos 3 minutos. Si no has solicitado este código, por favor ignora este correo.</p>
                     <p>Si tienes alguna pregunta o necesitas ayuda, no dudes en contactarnos.</p>
                 </body>
                 </html>";

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            client.Host = _config["Mail:Host"];
            client.Port = Convert.ToInt32(_config["Mail:Port"]);

            try
            {
                //TODO: Mejorar mensajes de confirmacion
                var mensaje = mailMessage;
                client.Send(mailMessage);
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
            mailMessage.Body = $@"
                <html>
                <body>
                    <p>Hola {userEmail},</p>
                    <p>Gracias por registrarte con nosotros. Para completar el proceso de registro, por favor haz clic en el siguiente enlace para confirmar tu correo electrónico:</p>
                    <p><a href='{confirmationLink}' style='font-size: 16px; font-weight: bold;'>Confirmar correo electrónico</a></p>
                    <p>Si no has solicitado esta confirmación, por favor ignora este correo.</p>
                    <p>Si tienes alguna pregunta o necesitas ayuda, no dudes en contactarnos.</p>
                    <p>¡Gracias y bienvenido(a)!</p>
                </body>
                </html>";

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            client.Host = _config["Mail:Host"];
            client.Port = Convert.ToInt32(_config["Mail:Port"]);

            try
            {
                //TODO: Mejorar mensajes de confirmacion
                var mensaje = mailMessage;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
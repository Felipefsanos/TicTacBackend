using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Services.Interfaces.Email;
using TicTacBackend.Infra.Helpers.Extension.Methods;

namespace TicTacBackend.Domain.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async void EnviarEmailNovoOrcamento(string email, string nomeCliente)
        {
            await Enviar(email, "Seu Orçamento com a TicTac", nomeCliente, DateTime.Now.AddDays(7));
        }

        private async Task Enviar(string email, string assunto, string nomeCliente, DateTime? dataValidade)
        {
            try
            {
                var corpoEmail = EmailsResource.EmailOrcamento;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(email, "TicTac Gourmet | Animáximo Eventos")
                };

                mail.To.Add(new MailAddress(email, nomeCliente));

                mail.Subject = assunto;
                corpoEmail = FormatarCorpoEmail(nomeCliente, dataValidade, corpoEmail);

                mail.Body = corpoEmail;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(configuration.GetSection("GmailConfig:UserNameEmail").Value, configuration.GetSection("GmailConfig:UserNamePassword").Value),
                    EnableSsl = true
                };
                await smtp.SendMailAsync(mail);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string FormatarCorpoEmail(string nomeCliente, DateTime? dataValidade, string corpoEmail)
        {
            corpoEmail = corpoEmail.Replace("{0}", nomeCliente.FirstName());
            corpoEmail = corpoEmail.Replace("{1}", DateTime.Now.ToString("dd/MM/yyyy"));
            if (dataValidade.HasValue)
                corpoEmail = corpoEmail.Replace("{2}", dataValidade.GetValueOrDefault().ToString("dd/MM/yyyy"));
            return corpoEmail;
        }
    }
}

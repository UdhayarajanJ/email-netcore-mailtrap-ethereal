using api.fakesmtp.provider.IRepository;
using api.fakesmtp.provider.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.Repository
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private EtherealMailConfiguration _etherealMailConfiguration;
        public EmailSenderRepository(EtherealMailConfiguration etherealMailConfiguration)
        {
            _etherealMailConfiguration = etherealMailConfiguration;
        }

        public async Task<bool> SendingAttachmentEmailOfEthereal(SendingAttachmentFileOfEtherealModel sendingAttachmentFileOfEtherealModel)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_etherealMailConfiguration.userName);
            email.To.Add(MailboxAddress.Parse(sendingAttachmentFileOfEtherealModel.toEmailAddress));
            email.Subject = sendingAttachmentFileOfEtherealModel.subject;

            BodyBuilder builder = new BodyBuilder();
            builder.TextBody = sendingAttachmentFileOfEtherealModel.message;
            

            //Email Attachment
            if (sendingAttachmentFileOfEtherealModel.emailAttachment != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await sendingAttachmentFileOfEtherealModel.emailAttachment.CopyToAsync(memoryStream);
                    builder.Attachments.Add(sendingAttachmentFileOfEtherealModel.emailAttachment.FileName, memoryStream.ToArray());
                }
            }
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_etherealMailConfiguration.host, _etherealMailConfiguration.port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_etherealMailConfiguration.userName, _etherealMailConfiguration.password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return true;

            throw new NotImplementedException();
        }

        public async Task<bool> SendingEmailOfEthereal(SendingEmailOfEtherealModel sendingEmailOfEtheralModel)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_etherealMailConfiguration.userName);
            email.To.Add(MailboxAddress.Parse(sendingEmailOfEtheralModel.toEmailAddress));
            email.Subject = sendingEmailOfEtheralModel.subject;

            BodyBuilder builder = new BodyBuilder();
            builder.TextBody = sendingEmailOfEtheralModel.message;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_etherealMailConfiguration.host, _etherealMailConfiguration.port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_etherealMailConfiguration.userName, _etherealMailConfiguration.password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return true;
            throw new NotImplementedException();
        }
    }
}

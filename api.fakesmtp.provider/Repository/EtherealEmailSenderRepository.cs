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
    public class EtherealEmailSenderRepository : IEtherealEmailSenderRepository
    {
        private EtherealMailConfiguration _etherealMailConfiguration;
        public EtherealEmailSenderRepository(EtherealMailConfiguration etherealMailConfiguration)
        {
            _etherealMailConfiguration = etherealMailConfiguration;
        }

        public async Task<bool> SendingAttachmentEmailOfEthereal(SendingAttachmentFileOfModel sendingAttachmentFileOfEtherealModel)
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

        public async Task<bool> SendingEmailOfEthereal(SendingEmailOfModel sendingEmailOfEtheralModel)
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

        public async Task<bool> SendingHtmlEmailOfEthereal(SendingEmailOfModel sendingEmailOfEtherealModel)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_etherealMailConfiguration.userName);
            email.To.Add(MailboxAddress.Parse(sendingEmailOfEtherealModel.toEmailAddress));
            email.Subject = sendingEmailOfEtherealModel.subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = @"<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Ethereal Email Template</title> <style type='text/css'> *{margin: 0; padding: 0; box-sizing: border-box;}body{padding: 0 4rem;}header{background-color: blueviolet; color: white; margin-top: 1rem;}h3{font-size: 2rem; font-weight: bold; text-align: center; padding: .8rem;}p{font-weight: bold; text-align: justify; text-indent: 5rem; padding: 1.8rem 0;}footer{text-align: center;}</style></head><body> <header> <h3>Ethereal Email Template</h3> </header> <main> <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quidem atque possimus voluptatem maxime illum dolorem laudantium recusandae! Odio explicabo incidunt vel. Magnam sapiente, dolores quas debitis tempora fugiat in corrupti. Atque similique saepe repudiandae, consequatur sint id mollitia cupiditate animi et eligendi dolores ipsam itaque odio architecto doloribus nisi voluptatum maiores rerum assumenda recusandae sit sunt veniam ratione adipisci. Corrupti. Quo repellendus error recusandae cum corrupti expedita consequuntur. Nam et obcaecati accusantium itaque labore perferendis ducimus aliquam tempora in. Id, ea tempore? Voluptas, blanditiis. Dignissimos delectus repudiandae beatae voluptas asperiores? Obcaecati pariatur optio reprehenderit in aliquid quasi error laudantium, quam voluptatum vero, aperiam hic iusto voluptates eaque! Illum natus, a esse itaque veniam cumque cupiditate autem ullam quo, voluptatibus dolores! Ab dignissimos dolorem veniam temporibus fuga eum obcaecati voluptate laudantium? Eius culpa consequatur nostrum accusantium dolorum numquam officia illo quis expedita quos minus ut minima, sed hic? Veniam, vero quae. Magni non consectetur odio blanditiis dignissimos, corporis porro laudantium magnam labore libero laborum, molestiae illo nemo impedit placeat deleniti reiciendis perspiciatis voluptas. Itaque ipsam nam nisi sequi accusamus odio saepe! Laudantium consequatur architecto cumque debitis totam, at facilis corrupti, consectetur nulla voluptatum quam minus culpa voluptatibus. Accusantium vel, dolorum hic placeat consequatur pariatur nam explicabo, mollitia aliquam consequuntur dolore ea. Laborum facilis ullam id minus quisquam placeat aliquid velit reprehenderit ipsa rerum aut, impedit earum mollitia dolorem labore error fugiat quibusdam maiores consequatur corporis eligendi, quidem magnam! Iusto, ipsam quam. Facere minima ipsum quae, temporibus veniam vero sequi maiores cum mollitia et quasi ullam soluta ut recusandae dolorem laboriosam voluptatum asperiores aliquam impedit repudiandae nobis possimus consequatur reiciendis eius? Quam! Tempore, rem quibusdam quam nostrum qui et necessitatibus beatae autem harum amet atque, exercitationem, eius aut molestias optio totam. Ducimus odit distinctio, necessitatibus aliquam doloribus natus dignissimos eos maiores nemo! </p></main> <footer> <h6>That Is Only For Learning Purpose @ 2022 .Net Core Mail Concepts</h6> </footer></body></html>";
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

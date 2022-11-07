using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.IRepository
{
    public interface IEmailSenderRepository
    {
        public Task<bool> SendingEmailOfEthereal(SendingEmailOfEtherealModel sendingEmailOfEtheralModel);
        public Task<bool> SendingAttachmentEmailOfEthereal(SendingAttachmentFileOfEtherealModel sendingAttachmentFileOfEtherealModel);
        public Task<bool> SendingHtmlEmailOfEthereal(SendingEmailOfEtherealModel sendingEmailOfEtherealModel);
    }
}

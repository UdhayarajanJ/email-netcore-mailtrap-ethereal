using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.IRepository
{
    public interface IEtherealEmailSenderRepository
    {
        public Task<bool> SendingEmailOfEthereal(SendingEmailOfModel sendingEmailOfEtheralModel);
        public Task<bool> SendingAttachmentEmailOfEthereal(SendingAttachmentFileOfModel sendingAttachmentFileOfEtherealModel);
        public Task<bool> SendingHtmlEmailOfEthereal(SendingEmailOfModel sendingEmailOfEtherealModel);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.IRepository
{
    public interface IMailTrapEmailSenderRepository
    {
        public Task<bool> SendingEmailOfMailTrap(SendingEmailOfModel sendingEmailOfMailTrapModel);
        public Task<bool> SendingAttachmentEmailOfMailTrap(SendingAttachmentFileOfModel sendingAttachmentFileOfMailTrapModel);
        public Task<bool> SendingHtmlEmailOfMailTrap(SendingEmailOfModel sendingEmailOfMailTrapModel);
    }
}

using api.fakesmtp.provider.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.email.testing.Mocks
{
    public class MockEtherealEmailController
    {
        public Task<SendingEmailOfModel> GetMockSendingEmailDataForEthereal()
        {
            return Task.FromResult(new SendingEmailOfModel()
            {
                message = "Test Mail Message",
                subject = "Test Ethereal Email",
                toEmailAddress = "test@ethereal.com"
            });
        }
        public Task<SendingAttachmentFileOfModel> GetMockSendingEmailDataWithAttachmentForEthereal()
        {
            return Task.FromResult(new SendingAttachmentFileOfModel()
            {
                message = "Test Mail Message",
                subject = "Test Ethereal Email",
                toEmailAddress = "test@ethereal.com",
                emailAttachment = new FormFile(null, 0, 124, "test", "test.*")
            }); ;
        }
    }
}

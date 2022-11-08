using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.IRepository
{
    public class SendingEmailOfModel
    {
        public string subject { get; set; }
        public string toEmailAddress { get; set; }
        public string message { get; set; }
    }

    public class SendingAttachmentFileOfModel : SendingEmailOfModel
    {
        public IFormFile emailAttachment { get; set; }
    }
}

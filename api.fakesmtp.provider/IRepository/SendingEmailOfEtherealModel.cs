using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.IRepository
{
    public class SendingEmailOfEtherealModel
    {
        public string subject { get; set; }
        public string toEmailAddress { get; set; }
        public string message { get; set; }
    }

    public class SendingAttachmentFileOfEtherealModel : SendingEmailOfEtherealModel
    {
        public IFormFile emailAttachment { get; set; }
    }
}

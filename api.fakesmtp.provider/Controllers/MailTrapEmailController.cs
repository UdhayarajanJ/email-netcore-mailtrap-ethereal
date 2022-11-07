using api.fakesmtp.provider.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.Controllers
{
    [Route("MailTrapEmail")]
    [ApiController]
    public class MailTrapEmailController : ControllerBase
    {
        private IMailTrapEmailSenderRepository _mailTrapEmailSenderRepository;
        public MailTrapEmailController(IMailTrapEmailSenderRepository mailTrapEmailSenderRepository)
        {
            _mailTrapEmailSenderRepository = mailTrapEmailSenderRepository;
        }


    }
}

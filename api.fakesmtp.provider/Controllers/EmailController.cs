using api.fakesmtp.provider.IRepository;
using api.fakesmtp.provider.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.Controllers
{
    [Route("EmailSender")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailSenderRepository _emailSenderRepository;
        public EmailController(IEmailSenderRepository emailSenderRepository)
        {
            _emailSenderRepository = emailSenderRepository;
        }

        [HttpPost("SendingEmailOfEthereal")]
        public async Task<IActionResult> SendingEmailOfEthereal([FromBody] SendingEmailOfEtherealModel sendingEmailOfEtheralModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result =await _emailSenderRepository.SendingEmailOfEthereal(sendingEmailOfEtheralModel);
                if (result)
                {
                    apiReponse.statusCode = (int)HttpStatusCode.OK;
                    apiReponse.statusMessage = "Email Sent Successfully...";
                    apiReponse.responseData = result; 
                }
                else
                {
                    apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                    apiReponse.statusMessage = "Email Not Sent...";
                }

            }
            catch (Exception ex)
            {
                apiReponse.statusCode = (int)HttpStatusCode.InternalServerError;
                apiReponse.statusMessage = ex.Message;
                apiReponse.responseData = ex;
            }
            return Ok(apiReponse);
        }
        [HttpPost("SendingAttachmentEmailOfEthereal")]
        public async Task<IActionResult> SendingAttachmentEmailOfEthereal([FromForm] SendingAttachmentFileOfEtherealModel sendingAttachmentFileOfEtherealModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result = await _emailSenderRepository.SendingAttachmentEmailOfEthereal(sendingAttachmentFileOfEtherealModel);
                if (result)
                {
                    apiReponse.statusCode = (int)HttpStatusCode.OK;
                    apiReponse.statusMessage = "Email Sent Successfully...";
                    apiReponse.responseData = result;
                }
                else
                {
                    apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                    apiReponse.statusMessage = "Email Not Sent...";
                }

            }
            catch (Exception ex)
            {
                apiReponse.statusCode = (int)HttpStatusCode.InternalServerError;
                apiReponse.statusMessage = ex.Message;
                apiReponse.responseData = ex;
            }
            return Ok(apiReponse);
        }
    }
}

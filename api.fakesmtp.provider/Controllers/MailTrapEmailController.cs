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
    [Route("MailTrapEmail")]
    [ApiController]
    public class MailTrapEmailController : ControllerBase
    {
        private IMailTrapEmailSenderRepository _mailTrapEmailSenderRepository;
        public MailTrapEmailController(IMailTrapEmailSenderRepository mailTrapEmailSenderRepository)
        {
            _mailTrapEmailSenderRepository = mailTrapEmailSenderRepository;
        }

        /// <summary>
        /// To Send Plain Message Email To Mail Trap SMTP Provider
        /// </summary>
        /// <param name="sendingEmailOfMailTrapModel"></param>
        /// <returns></returns>

        [HttpPost("SendingEmailOfMailTrap")]
        public async Task<IActionResult> SendingEmailOfMailTrap([FromBody] SendingEmailOfModel sendingEmailOfMailTrapModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result = await _mailTrapEmailSenderRepository.SendingEmailOfMailTrap(sendingEmailOfMailTrapModel);
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

        /// <summary>
        /// To Send Attachment With Message Email To Mail Trap SMTP Provider
        /// </summary>
        /// <param name="sendingAttachmentFileOfMailTrapModel"></param>
        /// <returns></returns>

        [HttpPost("SendingAttachmentEmailOfMailTrap")]
        public async Task<IActionResult> SendingAttachmentEmailOfMailTrap([FromForm] SendingAttachmentFileOfModel sendingAttachmentFileOfMailTrapModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result = await _mailTrapEmailSenderRepository.SendingAttachmentEmailOfMailTrap(sendingAttachmentFileOfMailTrapModel);
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

        /// <summary>
        /// To Send HTML Email To Mail Trap SMTP Provider
        /// </summary>
        /// <param name="sendingEmailOfMailTrapModel"></param>
        /// <returns></returns>

        [HttpPost("SendingHtmlEmailOfMailTrap")]
        public async Task<IActionResult> SendingHtmlEmailOfMailTrap([FromBody] SendingEmailOfModel sendingEmailOfMailTrapModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result = await _mailTrapEmailSenderRepository.SendingHtmlEmailOfMailTrap(sendingEmailOfMailTrapModel);
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

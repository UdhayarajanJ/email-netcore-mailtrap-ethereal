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
    [Route("EtherealEmail")]
    [ApiController]
    public class EtherealEmailController : ControllerBase
    {
        private IEtherealEmailSenderRepository _emailSenderRepository;
        public EtherealEmailController(IEtherealEmailSenderRepository emailSenderRepository)
        {
            _emailSenderRepository = emailSenderRepository;
        }
        
        /// <summary>
        /// To Send Plain Message Email To Ethereal SMTP Provider
        /// </summary>
        /// <param name="sendingEmailOfEtheralModel"></param>
        /// <returns></returns>

        [HttpPost("SendingEmailOfEthereal")]
        public async Task<IActionResult> SendingEmailOfEthereal([FromBody] SendingEmailOfModel sendingEmailOfEtheralModel)
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

        /// <summary>
        /// To Send Attachment With Message Email To Ethereal SMTP Provider
        /// </summary>
        /// <param name="sendingAttachmentFileOfEtherealModel"></param>
        /// <returns></returns>

        [HttpPost("SendingAttachmentEmailOfEthereal")]
        public async Task<IActionResult> SendingAttachmentEmailOfEthereal([FromForm] SendingAttachmentFileOfModel sendingAttachmentFileOfEtherealModel)
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

        /// <summary>
        /// To Send HTML Email To Ethereal SMTP Provider
        /// </summary>
        /// <param name="sendingEmailOfEtheralModel"></param>
        /// <returns></returns>

        [HttpPost("SendingHtmlEmailOfEthereal")]
        public async Task<IActionResult> SendingHtmlEmailOfEthereal([FromBody] SendingEmailOfModel sendingEmailOfEtheralModel)
        {
            ApiReponse apiReponse = new ApiReponse();
            try
            {
                bool result = await _emailSenderRepository.SendingHtmlEmailOfEthereal(sendingEmailOfEtheralModel);
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

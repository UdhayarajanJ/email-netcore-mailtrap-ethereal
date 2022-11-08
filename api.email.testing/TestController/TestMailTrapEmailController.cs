using api.email.testing.Mocks;
using api.fakesmtp.provider.Controllers;
using api.fakesmtp.provider.IRepository;
using api.fakesmtp.provider.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.email.testing.TestController
{
    public class TestMailTrapEmailController
    {
        private Mock<IMailTrapEmailSenderRepository> _mockMailTrapEmailSenderRepository;
        private MockMailTrapEmailController _mockMailTrapEmailController;
        public TestMailTrapEmailController()
        {
            _mockMailTrapEmailSenderRepository = new Mock<IMailTrapEmailSenderRepository>();
            _mockMailTrapEmailController = new MockMailTrapEmailController();

        }
        /// <summary>
        ///  Should_Not_Be_Send_MailTrap_Plain_Message_Email Test Cased Passed
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "Should_Be_Send_MailTrap_Plain_Message_Email")]
        private async Task Should_Be_Send_MailTrap_Plain_Message_Email()
        {
            //Arrange
            bool result = true;
            int expectedStatusCode = 200;
            SendingEmailOfModel sendingEmailOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingEmailOfMailTrap(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object);
            var callAPI = mailTrapEmailController.SendingEmailOfMailTrap(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Sent Successfully...");
            apiReponse.responseData.Should().Be(result);
        }

        /// <summary>
        /// Should_Not_Be_Send_MailTrap_Plain_Message_Email Test Cased Failed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Not_Be_Send_MailTrap_Plain_Message_Email")]
        private async Task Should_Not_Be_Send_MailTrap_Plain_Message_Email()
        {
            //Arrange
            bool result = false;
            int expectedStatusCode = 404;
            SendingEmailOfModel sendingEmailOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingEmailOfMailTrap(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object);
            var callAPI = mailTrapEmailController.SendingEmailOfMailTrap(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Not Sent...");
            apiReponse.responseData.Should().BeNull();
        }

        /// <summary>
        /// Should_Not_Be_Send_MailTrap_HTML_Message_Email Test Case Failed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Not_Be_Send_MailTrap_HTML_Message_Email")]
        private async Task Should_Not_Be_Send_Ethereal_HTML_Message_Email()
        {
            //Arrange
            bool result = false;
            int expectedStatusCode = 404;
            SendingEmailOfModel sendingEmailOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingHtmlEmailOfMailTrap(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object);
            var callAPI = mailTrapEmailController.SendingHtmlEmailOfMailTrap(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Not Sent...");
            apiReponse.responseData.Should().BeNull();
        }

        /// <summary>
        /// Should_Be_Send_MailTrap_HTML_Message_Email Test Case Passed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Be_Send_MailTrap_HTML_Message_Email")]
        private async Task Should_Be_Send_Ethereal_HTML_Message_Email()
        {
            //Arrange
            bool result = true;
            int expectedStatusCode = 200;
            SendingEmailOfModel sendingEmailOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingHtmlEmailOfMailTrap(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object);
            var callAPI = mailTrapEmailController.SendingHtmlEmailOfMailTrap(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Sent Successfully...");
            apiReponse.responseData.Should().Be(result);
        }

        /// <summary>
        /// Should_Be_Send_MailTrap_Attachment_With_Message_Email Test Case Passed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Be_Send_MailTrap_Attachment_With_Message_Email")]
        private async Task Should_Be_Send_Ethereal_Attachment_With_Message_Email()
        {
            //Arrange
            bool result = true;
            int expectedStatusCode = 200;
            SendingAttachmentFileOfModel sendingAttachmentFileOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataWithAttachmentForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingAttachmentEmailOfMailTrap(sendingAttachmentFileOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object); 
            var callAPI = mailTrapEmailController.SendingAttachmentEmailOfMailTrap(sendingAttachmentFileOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Sent Successfully...");
            apiReponse.responseData.Should().Be(result);
        }

        /// <summary>
        /// Should_Not_Be_Send_MailTrap_Attachment_With_Message_Email Test Case Failed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Not_Be_Send_MailTrap_Attachment_With_Message_Email")]
        private async Task Should_Not_Be_Send_Ethereal_Attachment_With_Message_Email()
        {
            //Arrange
            bool result = false;
            int expectedStatusCode = 404;
            SendingAttachmentFileOfModel sendingAttachmentFileOfModel = await _mockMailTrapEmailController.GetMockSendingEmailDataWithAttachmentForMailTrap();
            _mockMailTrapEmailSenderRepository.Setup(x => x.SendingAttachmentEmailOfMailTrap(sendingAttachmentFileOfModel)).Returns(Task.FromResult(result));

            //Act
            MailTrapEmailController mailTrapEmailController = new MailTrapEmailController(_mockMailTrapEmailSenderRepository.Object);
            var callAPI = mailTrapEmailController.SendingAttachmentEmailOfMailTrap(sendingAttachmentFileOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Not Sent...");
            apiReponse.responseData.Should().BeNull();
        }
    }
}

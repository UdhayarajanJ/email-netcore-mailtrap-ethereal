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
    public class TestEtherealEmailController
    {
        private Mock<IEtherealEmailSenderRepository> _mockEtherealEmailSenderRepository;
        private MockEtherealEmailController _mockEtherealEmailController;

        public TestEtherealEmailController()
        {
            _mockEtherealEmailSenderRepository = new Mock<IEtherealEmailSenderRepository>();
            _mockEtherealEmailController = new MockEtherealEmailController();
        }

        /// <summary>
        /// Should_Be_Send_Ethereal_Plain_Message_Email Test Cased Passed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Be_Send_Ethereal_Plain_Message_Email")]
        private async Task Should_Be_Send_Ethereal_Plain_Message_Email()
        {
            //Arrange
            bool result = true;
            int expectedStatusCode = 200;
            SendingEmailOfModel sendingEmailOfModel = await _mockEtherealEmailController.GetMockSendingEmailDataForEthereal();
            _mockEtherealEmailSenderRepository.Setup(x => x.SendingEmailOfEthereal(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            EtherealEmailController etherealEmailController = new EtherealEmailController(_mockEtherealEmailSenderRepository.Object);
            var callAPI = etherealEmailController.SendingEmailOfEthereal(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Sent Successfully...");
            apiReponse.responseData.Should().Be(result);
        }

        /// <summary>
        /// Should_Not_Be_Send_Ethereal_Plain_Message_Email Test Cased Failed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Not_Be_Send_Ethereal_Plain_Message_Email")]
        private async Task Should_Not_Be_Send_Ethereal_Plain_Message_Email()
        {
            //Arrange
            bool result = false;
            int expectedStatusCode = 404;
            SendingEmailOfModel sendingEmailOfModel = await _mockEtherealEmailController.GetMockSendingEmailDataForEthereal();
            _mockEtherealEmailSenderRepository.Setup(x => x.SendingEmailOfEthereal(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            EtherealEmailController etherealEmailController = new EtherealEmailController(_mockEtherealEmailSenderRepository.Object);
            var callAPI = etherealEmailController.SendingEmailOfEthereal(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Not Sent...");
            apiReponse.responseData.Should().BeNull();
        }

        /// <summary>
        /// Should_Not_Be_Send_Ethereal_HTML_Message_Email Test Case Failed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Not_Be_Send_Ethereal_HTML_Message_Email")]
        private async Task Should_Not_Be_Send_Ethereal_HTML_Message_Email()
        {
            //Arrange
            bool result = false;
            int expectedStatusCode = 404;
            SendingEmailOfModel sendingEmailOfModel = await _mockEtherealEmailController.GetMockSendingEmailDataForEthereal();
            _mockEtherealEmailSenderRepository.Setup(x => x.SendingHtmlEmailOfEthereal(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            EtherealEmailController etherealEmailController = new EtherealEmailController(_mockEtherealEmailSenderRepository.Object);
            var callAPI = etherealEmailController.SendingHtmlEmailOfEthereal(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Not Sent...");
            apiReponse.responseData.Should().BeNull();
        }

        /// <summary>
        /// Should_Be_Send_Ethereal_HTML_Message_Email Test Case Passed
        /// </summary>
        /// <returns></returns>

        [Fact(DisplayName = "Should_Be_Send_Ethereal_HTML_Message_Email")]
        private async Task Should_Be_Send_Ethereal_HTML_Message_Email()
        {
            //Arrange
            bool result = true;
            int expectedStatusCode = 200;
            SendingEmailOfModel sendingEmailOfModel = await _mockEtherealEmailController.GetMockSendingEmailDataForEthereal();
            _mockEtherealEmailSenderRepository.Setup(x => x.SendingHtmlEmailOfEthereal(sendingEmailOfModel)).Returns(Task.FromResult(result));

            //Act
            EtherealEmailController etherealEmailController = new EtherealEmailController(_mockEtherealEmailSenderRepository.Object);
            var callAPI = etherealEmailController.SendingHtmlEmailOfEthereal(sendingEmailOfModel);
            var actionResult = await callAPI as OkObjectResult;
            ApiReponse apiReponse = (ApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Email Sent Successfully...");
            apiReponse.responseData.Should().Be(result);
        }
    }
}

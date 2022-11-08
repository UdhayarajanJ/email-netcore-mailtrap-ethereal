﻿using api.fakesmtp.provider.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.email.testing.Mocks
{
   public class MockMailTrapEmailController
    {
        public Task<SendingEmailOfModel> GetMockSendingEmailDataForMailTrap()
        {
            return Task.FromResult(new SendingEmailOfModel()
            {
                message = "Test Mail Message",
                subject = "Test Ethereal Email",
                toEmailAddress = "test@mailtrap.com"
            });
        }
    }
}
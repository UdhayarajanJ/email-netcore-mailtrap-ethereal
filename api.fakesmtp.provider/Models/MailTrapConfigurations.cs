using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.Models
{
    public class MailTrapConfigurations
    {   
        public string userName { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public int port { get; set; }
    }
}

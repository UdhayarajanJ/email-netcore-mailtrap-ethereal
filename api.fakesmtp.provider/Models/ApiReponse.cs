using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.fakesmtp.provider.Models
{
    public class ApiReponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public object responseData { get; set; }
    }
}

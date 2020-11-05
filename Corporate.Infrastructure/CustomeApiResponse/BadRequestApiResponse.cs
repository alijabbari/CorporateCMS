using Corporate.Infrastructure.CustomeApiRespone;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Infrastructure.CustomeApiResponse
{
    public class BadRequestApiResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public BadRequestApiResponse():base(400)
        {

        }
    }
}

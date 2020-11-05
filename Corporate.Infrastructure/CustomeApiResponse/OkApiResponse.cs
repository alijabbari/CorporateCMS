using Corporate.Infrastructure.CustomeApiRespone;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Infrastructure.CustomeApiResponse
{
    public class OkApiResponse : ApiResponse
    {
        public object Result { get; set; }
        public OkApiResponse(object result):base(200)
        {
            Result = result;
        }
    }
}

using Corporate.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Infrastructure
{
    public static class CorporateHeaderExtention
    {
        public static void PagingHeader(this HttpResponse httpResponse,string headerName, string pageingDto)
        {
            httpResponse.Headers.Add(headerName,pageingDto);
        }
    }
}

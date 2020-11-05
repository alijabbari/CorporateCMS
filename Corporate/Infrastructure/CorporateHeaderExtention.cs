using Corporate.Model.Dtoes;
using Corporate.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Corporate.Infrastructure
{
    public static class CorporateHeaderExtention
    {
        public static void PagingHeader(this HttpResponse httpResponse,string headerName, PageingDto pageingDto)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var camecasePaging=JsonSerializer.Serialize(pageingDto, options);
            httpResponse.Headers.Add(headerName, camecasePaging);
            //httpResponse.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            httpResponse.Headers.Add("Access-Control-Expose-Headers","Pagination");
        }
    }
}

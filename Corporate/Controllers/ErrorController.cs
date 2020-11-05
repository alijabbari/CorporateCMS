using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate.Infrastructure.CustomeApiRespone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        public async Task<IActionResult> Error(int code)
        {
            return  new ObjectResult(new ApiResponse(code));
        }
    }
}

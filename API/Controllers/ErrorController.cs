using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class ErrorController : BaseApiController
    {
        [Route("error/{code}")]
        [ApiExplorerSettings(IgnoreApi = true)]
          public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
       
    }
}
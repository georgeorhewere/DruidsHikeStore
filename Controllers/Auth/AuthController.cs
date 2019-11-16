using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DruidsHikeStore.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {



        [HttpPost("register", Name ="Register")]
        public ActionResult<StoreDB.StoreUser> Register([FromBody] StoreDB.StoreUser value)
        {
            return value;
        }
    }
        
}
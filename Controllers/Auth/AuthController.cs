using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DruidsHikeStore.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<StoreDB.StoreUser> _userManager;
        public AuthController(UserManager<StoreDB.StoreUser> userManager)
        {
            this._userManager = userManager;


        }



        [HttpPost("register", Name ="Register")]
        public async Task<ActionResult<Boolean>> Register([FromBody] StoreDB.ViewModels.AddUserViewModel value)
        {
            if (ModelState.IsValid)
            {
                var storeUser = new StoreDB.StoreUser()
                {
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Email = value.Email,
                    UserName = value.Email,
                    Address = value.Address,
                    City = value.City,
                    Country = value.Country
                };
                try
                {
                    var result = await _userManager.CreateAsync(storeUser, value.Password);

                    return result.Succeeded;
                }
                catch (Exception ec) {
                    return false;
                }
            }
            return false;

        }
    }
        
}
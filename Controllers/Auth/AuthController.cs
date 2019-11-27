using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using StoreDB.ViewModels.ServiceResult;

namespace DruidsHikeStore.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<StoreDB.StoreUser> _userManager;
        private IEmailSender emailSender;
        public AuthController(UserManager<StoreDB.StoreUser> userManager, IEmailSender _emailSender)
        {
            this._userManager = userManager;
            emailSender = _emailSender;
        }



        [HttpPost("register", Name = "Register")]
        public async Task<ActionResult<StoreDB.ViewModels.ServiceResult.ServiceResultViewModel>> Register([FromBody] StoreDB.ViewModels.AddUserViewModel value)
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
                    //add current claim
                    if (result.Succeeded)
                    {
                        var claim = new Claim("role",value.Role.ToString());
                        await _userManager.AddClaimAsync(storeUser, claim);

                        //send email confirmation
                        //TODO Configure proper route as email is delivered
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(storeUser);
                        var callbackUrl = Url.Page("/Auth/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = storeUser.Id, code = code },
                    protocol: Request.Scheme);

                     await emailSender.SendEmailAsync(storeUser.Email, "Confirm your email", $"Please confirm your account by < a href = '{HtmlEncoder.Default.Encode(callbackUrl)}' > clicking here </ a >.");


                    }
                    return new ServiceResultViewModel(result.Succeeded, result);
                }
                catch (Exception ec)
                {
                    return new ServiceResultViewModel(false, ec);
                }
            }
            else
            {
                return new ServiceResultViewModel(false, new { Message = "Invalid Model" });
            }           

        }
    }

}
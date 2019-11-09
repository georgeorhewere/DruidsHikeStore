using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB;

namespace DruidsHikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {

        private StoreDB.Repository.IDataRepository<User> _userService;
        public UsersController(StoreDB.IStoreManager service)
        {
            _userService = service.UserManager;
        }
        // GET: api/Users
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public IEnumerable<StoreDB.User> Get()
        {
            try {
                return _userService.GetAll().Select(a => a).ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // GET: api/Users/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            return _userService.Get(id);
        }

        // POST: api/Users
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public IActionResult Post([FromBody] StoreDB.User value)
        {

            if(value == null)
            {
                return BadRequest("user is null");
            }
            
            try
            {
                _userService.Add(value);
                return CreatedAtRoute("Get",
                  new { Id = value.UserId },
                  value);
            }
            catch(Exception ex)
            {
                return BadRequest("user no saved => " + ex.Message);
            }            
        }

        [EnableCors("_myAllowSpecificOrigins")]
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreDB.User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            StoreDB.User userToUpdate = _userService.Get(id);

            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _userService.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("_myAllowSpecificOrigins")]        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StoreDB.User user = _userService.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _userService.Delete(user);
            return NoContent();
        }
    }
}

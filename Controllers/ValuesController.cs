using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreDB;

namespace DruidsHikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StoreDB.Repository.IDataRepository<User> _userService;
        public ValuesController(StoreDB.IStoreManager service)
        {

            _userService = service.UserManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {            
            //AddList            
            return _userService.GetAll().Select(a => a).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Base.Lgm.Core.Interfaces.Business;
using Base.Lgm.Core.Models.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base.Lgm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = userBusiness.GetAllUsers();
            if (result.Data == null) return NotFound();

            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = userBusiness.GetUser(id);
            if (result.Data == null) return NotFound();

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] UserRequest request)
        {
            var result = userBusiness.CreateUser(request);
            if(result.Data) return Ok();

            return BadRequest(result.Error);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

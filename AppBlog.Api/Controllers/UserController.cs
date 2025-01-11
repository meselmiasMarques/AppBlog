using AppBlog.Domain.Repositories;
using AppBlog.Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBlog.Api.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
            => _repository = repository;
        
        [HttpGet("v1/user")]
        public ActionResult Get()
        {
            var users = _repository.GetAll();
            return Ok(users);
        }

        [HttpGet("v1/user/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                NotFound();
            }
            return Ok(user);
        }

        [HttpPost("v1/user")]
        public async Task<ActionResult> Create(User model)
        {
            try
            {
                if (model != null)
                {
                    await _repository.Add(model);
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("v1/user/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] User model)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            user.Role = model.Role;

            await _repository.Update(user);

            return Ok(user);
        }


        [HttpDelete("v1/user/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null) return NotFound();

            await _repository.Delete(user);
            
            return Ok();



        }
    }
}



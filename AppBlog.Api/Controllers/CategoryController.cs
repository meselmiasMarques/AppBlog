using System.Diagnostics.CodeAnalysis;
using AppBlog.Domain.Repositories;
using AppBlog.Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBlog.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
            => _repository = repository;

        [HttpGet("v1/category/")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var category = await _repository.GetAll();
                return Ok(category);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("v1/category/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var category = await _repository.GetById(id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("v1/category")]
        public async Task<ActionResult> Create([FromBody] Category model)
        {
            try
            {
                await _repository.Add(model);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPut("v1/category/{id:int}")]
        public async Task<ActionResult> Update([FromBody] Category model, int id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;

            await _repository.Update(category);
            return Ok();
        }

        [HttpDelete("v1/category/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            await _repository.Delete(category);
            return Ok();
        }
    }
}
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await categoryService.GetCategoriesAsync();
                return StatusCode(200, categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await categoryService.AddAsync(categoryDTO);
                return StatusCode(200, "Funcionou");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HttpDelete(int id)
        {
            try
            {
                await categoryService.RemoveAsync(id);
                return StatusCode(200, "Funcionou");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

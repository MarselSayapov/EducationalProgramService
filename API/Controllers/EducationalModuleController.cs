using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UrfuTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public EducationalModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var modules = await _moduleService.GetAllModulesAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(Guid id)
        {
            try
            {
                var module = await _moduleService.GetModuleByIdAsync(id);
                return Ok(module);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddModule([FromBody] EducationalModule module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _moduleService.AddModuleAsync(module);
            return Ok("Module added successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(Guid id, [FromBody] EducationalModule updatedModule)
        {
            try
            {
                await _moduleService.UpdateModuleAsync(id, updatedModule);
                return Ok("Module updated successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            try
            {
                await _moduleService.DeleteModuleAsync(id);
                return Ok("Module deleted successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

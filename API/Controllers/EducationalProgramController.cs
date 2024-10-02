using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UrfuTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public EducationalProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programService.GetAllProgramsAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(Guid id)
        {
            try
            {
                var program = await _programService.GetProgramByIdAsync(id);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProgram([FromBody] EducationalProgram program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _programService.AddProgramAsync(program);
            return Ok("Program added successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] EducationalProgram updatedProgram)
        {
            try
            {
                await _programService.UpdateProgramAsync(id, updatedProgram);
                return Ok("Program updated successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            try
            {
                await _programService.DeleteProgramAsync(id);
                return Ok("Program deleted successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

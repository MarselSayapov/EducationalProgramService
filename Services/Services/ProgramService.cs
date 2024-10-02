using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IRepository<EducationalProgram> _programRepository;

        public ProgramService(IRepository<EducationalProgram> programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<EducationalProgram>> GetAllProgramsAsync()
        {
            return await _programRepository.GetAllAsync();
        }

        public async Task<EducationalProgram> GetProgramByIdAsync(Guid id)
        {
            var program = await _programRepository.GetAsync(id);
            if (program == null)
            {
                throw new Exception("Program not found");
            }
            return program;
        }

        public async Task AddProgramAsync(EducationalProgram program)
        {
            await _programRepository.CreateAsync(program);
        }

        public async Task UpdateProgramAsync(Guid id, EducationalProgram updatedProgram)
        {
            var program = await _programRepository.GetAsync(id);
            if (program == null)
            {
                throw new Exception("Program not found");
            }
            program.Title = updatedProgram.Title;
            program.Status = updatedProgram.Status;
            program.Cypher = updatedProgram.Cypher;
            program.Level = updatedProgram.Level;
            program.Standart = updatedProgram.Standart;
            program.Institute = updatedProgram.Institute;
            program.Head = updatedProgram.Head;
            program.AccreditationTime = updatedProgram.AccreditationTime;

            _programRepository.Update(program);
        }

        public async Task DeleteProgramAsync(Guid id)
        {
            var program = await _programRepository.GetAsync(id);
            if (program == null)
            {
                throw new Exception("Program not found");
            }
            await _programRepository.DeleteAsync(id);
        }
    }
}

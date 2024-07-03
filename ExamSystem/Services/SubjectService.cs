using ExamSystem.Data;
using ExamSystem.Dtos;
using ExamSystem.Entities;
using ExamSystem.Models;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<SubjectResponse>> AddSubject(SubjectRequest request)
        {
            var checkSubject = _context
                .Subjects
                .Where(c => c.Name == request.Name)
                .Any();

            if (checkSubject)
                return ApiResult<SubjectResponse>.Error($"{checkSubject}", "Exists");

            var subject = new Subject
            {
                Name = request.Name,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
            };

            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            var response = new SubjectResponse
            {
                Name = subject.Name
            };

            return ApiResult<SubjectResponse>.Ok(response);


        }

        public async Task<List<SubjectDto>> GetAllSubjects(PaginationModel model)
        {
            var subjects = await _context
                             .Subjects
                             .Select(c => new SubjectDto
                             {
                                 Name = c.Name

                             })
                             .Skip((model.PageNumber - 1) * model.PageSize)
                             .Take(model.PageSize)
                             .ToListAsync();

            return subjects;
        }
    }
}

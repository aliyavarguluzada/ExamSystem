using ExamSystem.Data;
using ExamSystem.Dtos;
using ExamSystem.Entities;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Services
{
    public class MarkService : IMarkService
    {
        private readonly ApplicationDbContext _context;

        public MarkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<MarkResponse>> Add(MarkRequest request)
        {
            var newMark = new Mark
            {
                Value = request.Mark,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                StudentId = request.StudentId,
                ExamId = request.ExamId
            };

            await _context.AddAsync(newMark);

            await _context.SaveChangesAsync();

            var response = new MarkResponse
            {
                Mark = request.Mark,
                Description = request.Description,
            };

            return ApiResult<MarkResponse>.Ok(response);

        }

        public async Task<List<MarkDto>> GetAllMarks()
        {
            var marks = await _context
                              .Marks
                              .Include(c => c.Student)
                              .Include(c => c.Exam)
                              .Select(c => new MarkDto
                              {
                                  Mark = c.Value,
                                  StudentEmail = c.Student.Email,
                                  StudentName = c.Student.Name,
                                  ExamName = c.Exam.Name
                              })
                              .ToListAsync();
            return marks;

        }


    }
}

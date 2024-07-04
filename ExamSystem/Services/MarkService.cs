using ExamSystem.Data;
using ExamSystem.Entities;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

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
                StudentId = request.StudentId
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

        
    }
}

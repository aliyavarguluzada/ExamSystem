using ExamSystem.Data;
using ExamSystem.Entities;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext _context;

        public ExamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<ExamResponse>> AddExam(ExamRequest request)
        {

            var newExam = new Exam
            {
                Name = request.Name,
                Date = DateTime.Now.AddDays(request.Day),
                Description = request.Description,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                SubjectId = request.SubjectId,
            };

            await _context.Exams.AddAsync(newExam);
            await _context.SaveChangesAsync();

            return ApiResult<ExamResponse>.Ok(new ExamResponse());
        }

    }
}

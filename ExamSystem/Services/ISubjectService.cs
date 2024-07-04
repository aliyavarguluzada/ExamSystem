using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public interface ISubjectService
    {
        public Task<ApiResult<SubjectResponse>> AddSubject(SubjectRequest request);
        public Task<List<SubjectDto>> GetAllSubjects(PaginationModel model);
        public Task<ApiResult<SubjectResponse>> Update(int id, SubjectRequest request);
        public Task<ApiResult<SubjectResponse>> Deactivate(int id);

    }
}

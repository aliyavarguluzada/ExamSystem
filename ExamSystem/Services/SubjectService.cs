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
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var checkSubject = _context
                    .Subjects
                    .Where(c => c.Name == request.Name)
                    .Any();

                if (String.IsNullOrEmpty(request.Name))
                    return ApiResult<SubjectResponse>.Error("", "Enter a name for Subject");

                if (checkSubject)
                    return ApiResult<SubjectResponse>.Error($"{checkSubject}", "Exists");

                var subject = new Subject
                {
                    Name = request.Name,
                    CreateDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    IsActive = true
                };

                await _context.Subjects.AddAsync(subject);
                await transaction.CommitAsync();
                await _context.SaveChangesAsync();

                var response = new SubjectResponse
                {
                    Name = subject.Name
                };

                return ApiResult<SubjectResponse>.Ok(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                return ApiResult<SubjectResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }


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
        public async Task<ApiResult<SubjectResponse>> Update(int id, SubjectRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var subject = await _context
                                    .Subjects
                                    .Where(c => c.Id == id)
                                    .FirstAsync();

                if (id == null || id == 0)
                    return ApiResult<SubjectResponse>.Error("", "Id is null or 0", StatusCodes.Status406NotAcceptable);


                subject.Name = request.Name;

                _context.Update(subject);
                await transaction.CommitAsync();
                await _context.SaveChangesAsync();

                var response = new SubjectResponse
                {
                    Name = request.Name,
                    Description = request.Description

                };

                return ApiResult<SubjectResponse>.Ok(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                return ApiResult<SubjectResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }
        }
        public async Task<ApiResult<SubjectResponse>> Deactivate(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var subject = await _context
                                    .Subjects
                                    .Where(c => c.Id == id)
                                    .FirstAsync();

                subject.IsActive = false;

                _context.Update(subject);
                await _context.SaveChangesAsync();

                var response = new SubjectResponse
                {
                    Name = subject.Name
                };

                return ApiResult<SubjectResponse>.Ok(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                return ApiResult<SubjectResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }
        }
    }
}


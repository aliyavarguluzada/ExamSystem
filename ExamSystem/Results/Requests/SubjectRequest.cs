namespace ExamSystem.Results.Requests
{
    public class SubjectRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; } 
        public bool? IsActive { get; set; }
    }
}

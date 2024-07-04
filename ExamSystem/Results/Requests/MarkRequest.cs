namespace ExamSystem.Results.Requests
{
    public class MarkRequest
    {
        public int Mark { get; set; }
        public string Description { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
    }
}

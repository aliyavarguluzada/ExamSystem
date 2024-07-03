namespace ExamSystem.Entities
{
    public class Mark : BaseEntity
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}

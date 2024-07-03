namespace ExamSystem.Entities
{
    public class Exam : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public List<Mark> Marks { get; set; }
        public List<Student> Students { get; set; }
    }
}

namespace ExamSystem.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }

    }
}

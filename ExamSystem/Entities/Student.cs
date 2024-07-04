namespace ExamSystem.Entities
{
    public class Student : BaseEntity
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public List<Mark> Marks { get; set; }
        public UserRole UserRole { get; set; }


    }
}

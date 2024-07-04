namespace ExamSystem.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Admin> Admins { get; set; }

    }
}

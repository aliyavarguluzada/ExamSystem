namespace ExamSystem.Entities
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}

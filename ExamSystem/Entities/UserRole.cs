namespace ExamSystem.Entities
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }


    }
}

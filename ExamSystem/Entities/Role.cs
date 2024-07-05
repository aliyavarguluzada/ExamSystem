namespace ExamSystem.Entities
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<UserRole> UserRoles { get; set; }

    }
}

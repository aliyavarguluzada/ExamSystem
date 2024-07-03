namespace ExamSystem.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public void CreatePassword(string password)
        {
            string pass = BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);
            Password = pass;
        }
        public bool VerifyPassword(string password)
        {
            var verifiedPass = BCrypt.Net.BCrypt.EnhancedVerify(password, Password);
            return verifiedPass;
        }
    }
}

namespace ExamSystem.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public string CreatePassword(string password)
        {
            string pass = BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);
            Password = pass;
            return Password;
        }
        public bool VerifyPassword(string password)
        {
            var verifiedPass = BCrypt.Net.BCrypt.EnhancedVerify(password, Password);
            return verifiedPass;
        }
    }
}

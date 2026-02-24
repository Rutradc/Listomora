namespace ListomoraFront.Models.Users
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }

        public UserProfile(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }

    public class UserNav
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRole? Role { get; set; }

        public UserNav(string firstName, string? lastName, UserRole? role = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }

    public enum UserRole
    {
        ADMIN,  // 0
        USER    // 1
    }
}

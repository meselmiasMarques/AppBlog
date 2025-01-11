namespace AppBlog.Entities.Domain
{
    public class User
    {
        public User(int id, string name, string email, string passwordHash, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // E.g., "Admin", "Author"
        public DateTime CreatedAt { get; set; }
    }
}

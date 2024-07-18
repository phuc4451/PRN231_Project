namespace Project_PRN231_API.ViewModel
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int? RoleId { get; set; }
    }

}

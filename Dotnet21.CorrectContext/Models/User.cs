namespace Dotnet21.CorrectContext.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        
        public Profile Profile { get; set; }
    }
}
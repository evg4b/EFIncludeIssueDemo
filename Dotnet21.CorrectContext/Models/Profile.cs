namespace Dotnet21.CorrectContext.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public User User { get; set; }
    }
}
namespace Dotnet5.IncorrectContext.Models
{
    public class User
    {
        public User()
        {
            Profile = new Profile();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        
        public Profile Profile { get; set; }
    }
}
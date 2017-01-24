namespace AuthorityGames.Domain.Models
{
	public class UserRegistration
    {
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}

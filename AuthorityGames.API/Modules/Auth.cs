using System.Configuration;
using AuthorityGame.Domain.Services;
using AuthorityGames.DAL;
using AuthorityGames.Domain.Models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace AuthorityGames.API.Modules
{
	public class Auth : NancyModule
    {
		#region Fields
		#endregion

		#region Constructors
		public Auth(IAuthService authService) : base("/auth/")
		{
			Post["/register"] = _ =>
			{
				var user = this.Bind<UserRegistration>();
				var result = authService.RegisterNewUser(user);

				return result.Succeded ?
					new Response { StatusCode = HttpStatusCode.Created } :
					new Response { StatusCode = HttpStatusCode.Conflict };
			};

			Post["/login"] = _ =>
			{
				var apiKey = authService.ValidateUser(
					(string)this.Request.Form.Username,
					(string)this.Request.Form.Password);

				return string.IsNullOrEmpty(apiKey)
					? new Response { StatusCode = HttpStatusCode.Unauthorized }
					: this.Response.AsJson(new { ApiKey = apiKey });
			};

			Post["/logout"] = _ =>
			{
				var apiKey = this.Request.Headers.Authorization;
				var result = authService.DisableApiKey(apiKey);

				return result.Succeded ? 
					new Response { StatusCode = HttpStatusCode.OK } : 
					new Response { StatusCode = HttpStatusCode.InternalServerError };
			};
		}
		#endregion

		#region Methods
		#endregion
	}
}

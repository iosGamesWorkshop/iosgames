using System;
using System.Collections.Generic;
using System.Text;
using AuthorityGame.Domain.Services;
using AuthorityGames.API.Auth;
using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Unity;

namespace AuthorityGames.API
{
	public class UnityBootstrapper : UnityNancyBootstrapper
	{
		#region Fields
		IUnityContainer _container;
		IAuthService _authService;
		#endregion

		#region Constructors
		public UnityBootstrapper(IUnityContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_container = container;
			_authService = _container.Resolve<IAuthService>();
		}
		#endregion

		#region Methods
		protected override IUnityContainer GetApplicationContainer()
		{
			return _container;
		}

		protected override void RequestStartup(IUnityContainer container, IPipelines pipelines, NancyContext context)
		{
			var configuration = new StatelessAuthenticationConfiguration(ctx =>
			{
				var apikey = ctx.Request.Headers.Authorization;
				if (apikey != null)
				{
					var claimPrincipal = _authService.GetUserFromApiKey(apikey);
					if (claimPrincipal != null)
					{
						return new UserIdentity()
						{
							Claims = new List<string>() { claimPrincipal.Identity.Name },
							UserName = claimPrincipal.Identity.Name
						};
					}
				}

				return null;
			});

			AllowAccessToConsumingSite(pipelines);
			StatelessAuthentication.Enable(pipelines, configuration);
		}
		#endregion

		#region Methods Private
		static void AllowAccessToConsumingSite(IPipelines pipelines)
		{
			pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
			{
				x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
				x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
			});
		}
		#endregion
	}
}

using System.Configuration;
using AuthorityGames.DAL;
using Nancy;
using Nancy.Security;

namespace AuthorityGames.API.Modules
{
	public class Root : NancyModule
    {
		#region Fields
		IUnitOfWork _db;
		private string _version = "0.0.0";
		#endregion

		#region Constructors
		public Root(IUnitOfWork db)
		{
			this.RequiresAuthentication();

			_db = db;
			_version = ConfigurationManager.AppSettings.Get("version");

			Get["/"] = _ => Response.AsJson<string>(string.Format("Authority Games API v. {0}", _version));
			Post["/"] = _ => Response.AsJson<string>(string.Format("Authority Games API v. {0}", _version));
		}
		#endregion

		#region Methods
		#endregion
	}
}

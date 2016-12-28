using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.API.Models;
using AuthorityGames.Domain.Abstraction.DAL;
using AuthorityGames.Domain.Models;
using Nancy;
using Nancy.ModelBinding;

namespace AuthorityGames.API.Modules
{
	public class Root : NancyModule
    {
		#region FIELDS
		IUnitOfWork _db;
		private string _version = "0.0.0";
		#endregion

		#region CONSTRUCTORS
		public Root(IUnitOfWork db)
		{
			_db = db;

			_version = ConfigurationManager.AppSettings.Get("version");

			Get["/version"] = _ => Response.AsJson<string>(string.Format("Authority Games API v. {0}", _version));
			Post["/user"] = _ => AddScore(this.Bind<ScoreViewModel>());
		}
		#endregion

		#region METHODS
		private dynamic AddScore(ScoreViewModel model)
		{
			var user = _db.UserRepository.Get(u => u.Name == model.UserName).FirstOrDefault();
			var score = new Score()
			{
				User = user,
				UserId = user.Id,
				Value = model.Value,
				ValueDate = model.ValueDate
			};

			_db.ScoreRepository.Insert(score);
			_db.Save();

			return new Response()
			{
				StatusCode = HttpStatusCode.Created,
				ReasonPhrase = "Score successfully added to score board."
			};
		}
		#endregion
	}
}

using System.Collections.Generic;
using System.Linq;

namespace AuthorityGames.Domain.Models
{
	public class ServiceResult
	{
		#region Fields
		bool _succeded;
		ICollection<string> _errors;
		#endregion

		#region Constructors
		public ServiceResult(params string[] errors)
		{
			_succeded = false;
			_errors = errors.ToList();
		}

		public ServiceResult(ICollection<string> errors)
		{
			_succeded = false;
			_errors = errors;
		}

		public ServiceResult(bool succeded)
		{
			_succeded = succeded;
			_errors = new List<string>();
		}
		#endregion

		#region Properties
		public bool Succeded { get { return _succeded; } }
		public ICollection<string> Errors { get { return _errors; } }
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.API.Models
{
    public class ScoreViewModel
    {
		public ScoreViewModel()
		{

		}

		#region PROPERTIES
		public string UserName { get; set; }
		public int Value { get; set; }
		public DateTime ValueDate { get; set; }
		#endregion
	}
}

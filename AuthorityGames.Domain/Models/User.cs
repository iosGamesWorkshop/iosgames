using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain.Models
{
    public class User
    {
		#region PROPERTIES
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Score> Scores { get; set; }
		#endregion
	}
}

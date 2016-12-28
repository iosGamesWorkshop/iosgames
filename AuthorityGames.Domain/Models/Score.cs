using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain.Models
{
    public class Score
    {
		#region PROPERTIES
		public int Id { get; set; }
		public int UserId { get; set; }
		public int Value { get; set; }
		public DateTime ValueDate { get; set; }

		public User User { get; set; }
		#endregion

	}
}

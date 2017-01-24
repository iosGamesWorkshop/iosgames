using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.DAL.Models
{
    public class GameBattleshipMatch
    {
		#region Properties
		[Key]
		public int Id { get; set; }

		public int FirstUserId { get; set; }

		public int SecondUserId { get; set; }

		public string FirstUserShipSetup { get; set; }

		public string SecondShipSetup { get; set; }

		public DateTime Created { get; set; }

		public DateTime Finished { get; set; }


		public ICollection<UserMatchHistory> UserMatchHistories { get; set; }
		#endregion
	}
}

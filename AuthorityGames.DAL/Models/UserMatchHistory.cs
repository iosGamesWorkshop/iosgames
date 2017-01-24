using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.DAL.Models
{
    public class UserMatchHistory
    {
		#region Properties
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }

		public int GameBattleshipMatchId { get; set; }

		public string Result { get; set; }

		public int Score { get; set; }


		public User User { get; set; }

		public GameBattleshipMatch GameBattleshipMatch { get; set; }
		#endregion
	}
}

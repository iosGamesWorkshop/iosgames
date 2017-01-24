using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain.Models
{
    public class UserSession
    {
		public string UserName { get; set; }
		public string ApiKey { get; set; }
		public DateTime ExpirationDateTime { get; set; }
		public bool IsActive { get; set; }
	}
}

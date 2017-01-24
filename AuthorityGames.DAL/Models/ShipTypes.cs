using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.DAL.Models
{
    public class ShipType
    {
		#region Properties
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(150)]
		[Index(IsUnique = true)]
		public string Name { get; set; }

		public string Width { get; set; }

		public string Height { get; set; }
		#endregion
	}
}

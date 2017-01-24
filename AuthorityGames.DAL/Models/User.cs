using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorityGames.DAL.Models
{
	public class User
    {
		#region Properties
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(150)]
		[Index(IsUnique = true)]
		public string UserName { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public bool IsActive { get; set; }

		public bool EmailConfirmed { get; set; }

		public DateTime RegistrationDate { get; set; }

		[DataType(DataType.Password)]
		public string PasswordHash { get; set; }

		[DataType(DataType.Password)]
		public string PasswordSalt { get; set; }


		public ICollection<UserMatchHistory> UserMatchHistories { get; set; }
		#endregion
	}
}

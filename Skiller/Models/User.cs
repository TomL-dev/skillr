using Skiller.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skiller.Models
{
	public class User
	{
		public int ID { get; set; }

		[Required]
		public EUserRole UserRole { get; set; }

		[Required]
		[DisplayName("First Name")]
		[StringLength(150, MinimumLength = 2)]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		[Required]
		[DisplayName("Last Name")]
		[StringLength(150, MinimumLength = 2)]
		public string LastName { get; set; }

		public EGender Gender { get; set; }

		public int Age { get; set; }

		public string FullName()
		{
			return FirstName + " " + MiddleName + " " + LastName;
		}
	}
}

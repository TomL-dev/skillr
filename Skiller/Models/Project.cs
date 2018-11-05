using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skiller.Models
{
	public class Project
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public Company Company { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task5_CRUD_EF.Models
{
	public class Actor
	{
		[Key]
		public int Actor_ID { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
	}
}

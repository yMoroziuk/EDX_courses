using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDbMigration
{
    public partial class Country
    {
		public Country()
		{
			City = new HashSet<City>();
		}
		[Key]
		public short CountryId { get; set; }
        public string Country1 { get; set; }
        public DateTime? LastUpdate { get; set; }

        public ICollection<City> City { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbMigration
{
    public partial class City
    {
		[Key]
        public int CityId { get; set; }
        public string City1 { get; set; }
        public short CountryId { get; set; }
        public DateTime LastUpdate { get; set; }
		[ForeignKey("CountryId")]
        public  Country Country { get; set; }
    }
}

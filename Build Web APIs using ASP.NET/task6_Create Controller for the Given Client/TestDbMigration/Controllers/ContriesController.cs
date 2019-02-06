using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestDbMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContriesController : ControllerBase
    {
		private SakilaContextFactory _context;

		public ContriesController()
		{
			_context = SakilaCreate.Create("Server=ZHENIA-LAPTOP;Database=Sakila;Trusted_Connection=True;");
		}

		[HttpGet]
		public ActionResult Get() //Get all countries
		{
			return Ok(_context.Country.ToArray());
		}
	}
}
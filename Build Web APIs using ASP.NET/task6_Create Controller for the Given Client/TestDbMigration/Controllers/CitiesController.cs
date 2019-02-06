using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestDbMigration.Controllers
{
	//Get all cities
	//Get specific city by city ID
	//Get cities by country code
	//Create a new city
	//Update an existing city
	//Delete an existing city

	[Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
		private SakilaContextFactory _context;

		public CitiesController()
		{
			_context = SakilaCreate.Create("Server=ZHENIA-LAPTOP;Database=Sakila;Trusted_Connection=True;");
		}

		[HttpGet]
		public ActionResult Get() //Get all cities
		{
			return Ok(_context.City.ToArray());
		}

		[HttpGet("city/{id}")]
		public ActionResult Get(int id) //Get specific city by city ID
		{
			var spcity = _context.City.SingleOrDefault(city => city.CityId == id);
			if (spcity != null)
				return Ok(spcity);
			else
				return NotFound();
		}
		
		[HttpGet("country/{contryId}")]
		public ActionResult Get(short contryId)//Get cities by country code
		{
			var spcity = _context.City.Where(city => city.CountryId == contryId).ToArray() ;
			if (spcity != null)
				return Ok(spcity);
			else
				return NotFound();
		}

		[HttpPost]
		public ActionResult Post(City city)//Create a new city
		{
			if (ModelState.IsValid)
			{
				_context.City.Add(city);
				_context.SaveChanges();
				return Created("api/[city]",city);
			}
			else
				return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult Put(City city, int id)//Update an existing city
		{
			var spcity = _context.City.SingleOrDefault(c => c.CityId == id);

			if (ModelState.IsValid && spcity != null)
			{
				_context.Entry(spcity).CurrentValues.SetValues(city);
				_context.SaveChanges();
				return Ok(city);
			}
			else
				return NotFound();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)//Delete an existing city
		{
			var spcity = _context.City.SingleOrDefault(c => c.CityId == id);

			if (ModelState.IsValid && spcity != null)
			{
				_context.City.Remove(spcity);
				_context.SaveChanges();
				return Ok();
			}
			else
				return NotFound();
		}
	}
}
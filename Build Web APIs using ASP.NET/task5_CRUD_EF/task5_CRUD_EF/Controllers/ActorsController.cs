using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task5_CRUD_EF.Models;

namespace task5_CRUD_EF.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActorsController : ControllerBase
	{
		private ActorDbContext _context;

		public ActorsController()
		{
			_context = ActorDbContextFactory.Create("Server=ZHENIA-LAPTOP;Database=Sakila;Trusted_Connection=True;");
		}

		[HttpGet]
		public ActionResult Get() => Ok(_context.Actor.ToArray());

		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			var actor = _context.Actor.SingleOrDefault(a => a.Actor_ID == id);
			if (actor != null)
				return Ok(actor);
			else
				return NotFound();
		}
		[HttpPost]
		public ActionResult Post([FromBody] Actor actor)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			else
			{
				_context.Actor.Add(actor);
				_context.SaveChanges();
				return Created("api/actors", actor);
			}
		}

		[HttpPut("{id}")]
		public ActionResult Put([FromBody] Actor actor, int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			else
			{
				var temp = _context.Actor.SingleOrDefault(a => a.Actor_ID == id);
				if (temp != null)
				{
					_context.Entry(temp).CurrentValues.SetValues(actor);
					_context.SaveChanges();
					return Ok(actor);
				}
				else return BadRequest();
			}
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var temp = _context.Actor.SingleOrDefault(a => a.Actor_ID == id);
			if (temp != null)
			{
				_context.Actor.Remove(temp);
				_context.SaveChanges();
				return Ok();
			}
			else
				return NotFound();
		}
	}
}
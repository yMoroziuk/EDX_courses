using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;

namespace WebServer.Controllers
{
	[Route("api/[controller]")]

	public class PersonController : ControllerBase
	{
		[HttpGet]
		public Person[] Get() => Repository.people.ToArray();

		[HttpGet("id")]
		public Person Get(int id) => Repository.GetPersonByID(id);

		[HttpPost]
		public void Post([FromBody] Person person) => Repository.AddPerson(person);

		[HttpPut]
		public void Put(int id, [FromBody] Person person) => Repository.ReplacePersonByID(id, person);

		[HttpDelete]
		public void Delete(int id) => Repository.RemovePersonByID(id);

		[HttpGet]
		public Person Action1([FromQuery]Person person) => person;  //query will be like: http://localhost:5000/?id=1&name=aba&price=100 

		[HttpGet("{id}/{name}/{price}")]
		public Person Action2([FromRoute] Person person) => person; //query will be like: http://localhost:5000/1/aba/100 

		[HttpGet("{id}/{name}")]
		public Person Action3([FromRoute] Person person) => person; //query will be like: http://localhost:5000/1/aba?price=100 

		[HttpPost]
		public Person Action4([FromForm] Person person) => person;   
		/* 
		<form action = "api/products" method="post">
			<input name = "id" value="101"/>
			<input name = "name" value="P101"/>
			<input name = "price" value="99.99"/>
			<input type = "submit" value="Submit"/>
		</form>
		*/
		[HttpPost]
		public Person Action5([FromBody] Person person) => person;
		/*
		{
			"id": 121,
			"name": "p001",
			"price": 99.88
		} 
		 */


	}

}
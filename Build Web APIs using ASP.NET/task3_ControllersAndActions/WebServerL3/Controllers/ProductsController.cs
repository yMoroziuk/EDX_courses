using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServerL3.Models;

namespace WebServerL3.Controllers
{
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		[HttpGet]
		public Product[] Get() => FakeData.Products.Values.ToArray();

		[HttpGet("{id}")]
		public Product Get(int id)
		{
			if (FakeData.Products.ContainsKey(id))
				return FakeData.Products[id];
			else
				return null;
		}

		[HttpPost]
		public Product Post([FromBody] Product product)
		{
			product.ID = FakeData.Products.Keys.Max() + 1;
			if (!FakeData.Products.ContainsKey(product.ID))
				FakeData.Products.Add(product.ID, product);
			return product;
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Product product)
		{
			if (FakeData.Products.ContainsKey(id))
			{
				FakeData.Products.Remove(id);
				FakeData.Products.Add(id, product);
			}
			else
			{
				FakeData.Products.Add(id, product);
			}
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			if (FakeData.Products.ContainsKey(id))
			{
				FakeData.Products.Remove(id);
			}
		}
	}
}
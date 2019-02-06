using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{

	[Route("api/[controller]")]
	public class ProductsController : Controller
	{
		//The frontend will send a GET request to api/products to get all products.
		[HttpGet]
		public ActionResult Get()
		{
			if (FakeData.Products != null)
				return Ok(Model.GetProduct());
			else
				return null;
		}

		//The frontend will send a GET request to api/products/101 to get the product whose ID is 101
		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			if (FakeData.Products.ContainsKey(id))
				return Ok(Model.GetProduct(id));
			else
				return null;
		}

		//The frontend will send a GET request to api/products/price/6/9 to get the products whose price is between 6 and 9.
		[HttpGet("price/{min}/{max}")]
		public ActionResult Get(double min, double max)
		{
			var products = FakeData.Products.Values;
			if (Model.GetProduct(min, max).Length > 0)
				return Ok(Model.GetProduct(min, max));
			else
				return null;
		}

		//The frontend will send a DELETE request to api/products/101 to delete the product whose ID is 101
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (FakeData.Products.ContainsKey(id))
			{
				var t = FakeData.Products[id];//to know which product was deleted
				Model.DeleteProduct(id);
				return Ok(t);
			}
			else
				return null;
		}

		//The frontend will send a POST request to api/products to create a new product
		[HttpPost]
		public ActionResult Post([FromBody] Product product)
		{
			return Created($"api/products/{product.ID}", product);
		}

		//The frontend will send a PUT request to api/products/101 to update the product whose ID is 101
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Product product)
		{
			if (FakeData.Products.ContainsKey(id))
				return Ok(Model.PutProduct(id, product));
			else
				return null;
		}

		//The frontend will send PUT request to api/products/raise/3 to raise the price of all products by 3
		[HttpPut("raise/{a}")]
		public ActionResult Put(int a)
		{
			if (FakeData.Products != null)
				return Ok(Model.PutProduct(a));
			else
				return null;
		}
	}
}




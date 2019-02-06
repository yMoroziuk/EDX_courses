using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebServer.Models
{

	public class Model
	{
		public static Product[] GetProduct() => FakeData.Products.Values.ToArray();

		public static Product GetProduct(int id) => FakeData.Products[id];

		public static Product[] GetProduct(double stPrice, double fiPrice) => FakeData.Products.Values.Where(p => p.Price >= stPrice && p.Price <= fiPrice).ToArray();

		public static void DeleteProduct(int id) => FakeData.Products.Remove(id);

		public static Product PostProduct(Product product)
		{
			int id = FakeData.Products.Keys.Max() + 1;
			FakeData.Products.Add(id, product);
			return product;
		}

		public static Product PutProduct(int id, Product product)
		{
			FakeData.Products[id] = new Product
			{
				ID = product.ID,
				Name = product.Name,
				Price = product.Price
			};
			return product;
		}

		public static Product[] PutProduct(int a)
		{
			for (int i = 0; i < FakeData.Products.Count; i++)
			{
				FakeData.Products[i] = new Product()
				{
					ID = FakeData.Products[i].ID,
					Name = FakeData.Products[i].Name,
					Price = FakeData.Products[i].Price + a
				};
			}
			return FakeData.Products.Values.ToArray();
		}

	}
}

using System;
using Newtonsoft.Json;

namespace SeDes
{
    class Program
    {
        static void Main(string[] args)
        {
			var products = new Product[]
			{
				new Product{ID = 101, Name = "Pelmeni", Price=100 },
				new Product{ID = 104, Name = "Vareniki", Price=72 },
				new Product{ID = 203, Name = "Kefir", Price=32 },
			};

			var jsonStr = SerealizeObject(products);

			Console.WriteLine(jsonStr);
			Console.WriteLine("===================================");

			var products2 = DeSerealizeJsonStr<Product>(jsonStr);

			foreach (var item in products2)
			{
				Console.WriteLine($"id: {item.ID}, name: {item.Name},  price: {item.Price} ");
			}

			Console.ReadKey();
        }

		public static string SerealizeObject<T>(T[] objects) => JsonConvert.SerializeObject(objects);

		public static T[] DeSerealizeJsonStr<T>(string json) => JsonConvert.DeserializeObject<T[]>(json);
	}
}

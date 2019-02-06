using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
	public class Repository
	{
		public static List<Person> people { get;} = new List<Person>();
		private static int _counter;

		public static Person GetPersonByID(int ID)
		{
			var target = people.SingleOrDefault(p => p.id == ID);
			return target;
		}

		public static void RemovePersonByID(int ID)
		{
			var target = people.SingleOrDefault(p => p.id == ID);
			if (target != null)
				people.Remove(target);
		}

		public static void ReplacePersonByID(int ID, Person person)
		{
			var target = people.SingleOrDefault(p => p.id == ID);
			if (target != null)
			{
				people.Remove(target);
				people.Add(person);
			}
		}

		public static void AddPerson(Person person)
		{
			person.id = _counter++;
			people.Add(person);
		}
	}
}

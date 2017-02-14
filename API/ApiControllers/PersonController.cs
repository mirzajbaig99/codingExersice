using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestApi1.ApiControllers
{
	[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
	public class PersonController : System.Web.Http.ApiController
	{
		public const int NumberOfItemsinData = 2;
		public const string FirstNamePrefix = "FirstName_";
		public const string LastNamePrefix = "LastName_";
		public const string JobTitlePrefix = "JobTitle_";

		public static Dictionary<int, Person> Data = null;
		public PersonController()
		{
			if (Data == null || Data.Count == 0)
			{
				Person.incrementalCount = 0;
				this.populateData();
			}
		}

		[HttpGet]
		public IEnumerable<Person> Get()
		{
			return Data.Select(x => x.Value);
		}

		[HttpGet]
		public Person GetById(int Id)
		{
			Person retval = null;
			if (PersonController.Data.ContainsKey(Id))
			{
				retval = Data[Id];
			}
			return retval;
		}

		[HttpPut]
		public bool Update(Person Person)
		{
			bool retval = false;
			if (Person.Id != null && PersonController.Data.ContainsKey(Person.Id.Value))
			{
				Data[Person.Id.Value] = Person;
				Console.WriteLine("Data Updated for Person Id (" + Person.Id.Value + ")");
				retval = true;
			}
			return retval;
		}

		private void populateData()
		{
			Data = new Dictionary<int, Person>();
			for (int i = 0; i < NumberOfItemsinData; i++)
			{
				Person p = new Person(true);
				p.FirstName = FirstNamePrefix + i;
				p.LastName = LastNamePrefix + i;
				p.JobTitle = JobTitlePrefix + i;
				Data.Add(p.Id.Value, p);
			}
		}
	}

	public class Person {
		public static int incrementalCount = 0;

		public int? Id { get; set; }
		public Person()
		{
		}

		public Person(bool assignId)
		{
			if (assignId)
			{
				Id = ++Person.incrementalCount;
			}
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string JobTitle { get; set; }

		public void Print()
		{
			Console.WriteLine("Person Infromation:(" + this.Id + ")");
			Console.WriteLine("=====================================");
			Console.WriteLine("FirstName : " + this.FirstName);
			Console.WriteLine("LastName : " + this.LastName);
			Console.WriteLine("JobTitle : " + this.JobTitle);
			Console.WriteLine("=====================================");
		}
	}
}
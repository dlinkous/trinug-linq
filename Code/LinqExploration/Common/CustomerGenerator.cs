using System;
using System.Collections.Generic;

namespace LinqExploration.Common
{
	internal class CustomerGenerator
	{
		internal IEnumerable<Customer> Generate(int quantity)
		{
			var customers = new List<Customer>();
			for (var i = 1; i <= quantity; i++)
			{
				customers.Add(new Customer()
				{
					Id = i,
					FirstName = $"First{i}",
					LastName = $"Last{i}",
					CreatedDate = DateTime.Parse("01/01/2001").AddDays(i),
					ModifiedDate = DateTime.Parse("01/01/2002").AddDays(i),
					LoginCount = 100 + i,
					IsActive = i == 3
				});
			}
			return customers;
		}
	}
}

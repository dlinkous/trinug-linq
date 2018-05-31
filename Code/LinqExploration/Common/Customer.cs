using System;

namespace LinqExploration.Common
{
	internal class Customer
	{
		internal int Id { get; set; }
		internal string FirstName { get; set; }
		internal string LastName { get; set; }
		internal DateTime CreatedDate { get; set; }
		internal DateTime ModifiedDate { get; set; }
		internal int LoginCount { get; set; }
		internal bool IsActive { get; set; }
	}
}

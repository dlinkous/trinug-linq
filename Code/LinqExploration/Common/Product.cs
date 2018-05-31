using System;
using System.Collections.Generic;

namespace LinqExploration.Common
{
	internal class Product : IEquatable<Product>
	{
		internal int Id { get; set; }
		internal string Name { get; set; }

		public override bool Equals(object obj)
		{
			return Equals(obj as Product);
		}

		public bool Equals(Product other)
		{
			return other != null &&
				   Id == other.Id &&
				   Name == other.Name;
		}

		public override int GetHashCode()
		{
			var hashCode = -1919740922;
			hashCode = hashCode * -1521134295 + Id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			return hashCode;
		}
	}
}

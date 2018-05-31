using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExploration.Examples
{
	internal class Pager<T>
	{
		private readonly IEnumerable<T> items;
		private readonly int pageSize;
		private int page = -1;

		internal Pager(IEnumerable<T> items, int pageSize)
		{
			this.items = items;
			this.pageSize = pageSize;
		}

		internal IEnumerable<T> Next()
		{
			page++;
			return items.Skip(page * pageSize).Take(pageSize);
		}
	}
}

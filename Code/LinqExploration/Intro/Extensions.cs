using System;
using System.Collections.Generic;

namespace LinqExploration.Intro
{
	public static class Extensions
	{
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			foreach (var item in items)
			{
				if (predicate(item)) yield return item;
			}
		}
	}
}

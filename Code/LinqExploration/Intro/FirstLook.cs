using System;
using System.Collections.Generic;

namespace LinqExploration.Intro
{
	public class FirstLook
	{
		public void Example1()
		{
			var numbers = new List<int>() { 1, 2, 3, 4, 5, 20, 21, 22 };
			var evens = new List<int>();
			foreach (var number in numbers)
			{
				if (number % 2 == 0) evens.Add(number);
			}
		}

		public void Example2()
		{
			var numbers = new List<int>() { 1, 2, 3, 4, 5, 20, 21, 22 };
			var evens = Example2Filter(numbers, number => number % 2 == 0);
		}

		private List<int> Example2Filter(List<int> numbers, Func<int, bool> predicate)
		{
			var matches = new List<int>();
			foreach (var number in numbers)
			{
				if (predicate(number)) matches.Add(number);
			}
			return matches;
		}

		public void Example3()
		{
			var numbers = new List<int>() { 1, 2, 3, 4, 5, 20, 21, 22 };
			var evens = Example3Filter(numbers, number => number % 2 == 0);
		}

		private List<T> Example3Filter<T>(List<T> items, Func<T, bool> predicate)
		{
			var matches = new List<T>();
			foreach (var item in items)
			{
				if (predicate(item)) matches.Add(item);
			}
			return matches;
		}

		public void Example4()
		{
			var numbers = new List<int>() { 1, 2, 3, 4, 5, 20, 21, 22 };
			var evens = Example4Filter(numbers, number => number % 2 == 0);
		}

		private IEnumerable<T> Example4Filter<T>(IEnumerable<T> items, Func<T, bool> predicate)
		{
			foreach (var item in items)
			{
				if (predicate(item)) yield return item;
			}
		}

		public void Example5()
		{
			var numbers = new List<int>() { 1, 2, 3, 4, 5, 20, 21, 22 };
			var evens = numbers.Filter(number => number % 2 == 0);
		}
	}
}

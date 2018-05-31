using System;
using LinqExploration.Examples;
using LinqExploration.Intro;

namespace LinqApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var firstLook = new FirstLook();
			firstLook.Example1();
			firstLook.Example2();
			firstLook.Example3();
			firstLook.Example4();
			firstLook.Example5();
			var examples = new Examples();
			examples.ExampleQuantity();
			examples.ExampleIndividual();
			examples.ExampleBoolean();
			examples.ExampleReduction();
			examples.ExampleOrdering();
			examples.ExampleAggregation();
			examples.ExampleModification();
			examples.ExampleConversionItems();
			examples.ExampleConversionSets();
			examples.ExampleCombining();
			examples.ExampleJoining();
		}
	}
}

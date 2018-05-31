using System;
using System.Linq;
using System.Text;
using LinqExploration.Common;

namespace LinqExploration.Examples
{
	public class Examples
	{
		public void ExampleQuantity()
		{
			var customers = new CustomerGenerator().Generate(5);
			var count = customers.Count();
			var longCount = customers.LongCount();
			var countOnes = customers.Count(c => c.Id == 1);
			var countForties = customers.Count(c => c.Id == 40);
		}

		public void ExampleIndividual()
		{
			var customers = new CustomerGenerator().Generate(5);
			var first = customers.First();
			var firstOrDefault = customers.FirstOrDefault();
			var single = customers.Single(c => c.Id == 3);
			var singleOrDefault = customers.SingleOrDefault(c => c.Id == 99);
			var last = customers.Last();
			var lastOrDefault = customers.LastOrDefault();
			var elementAt = customers.ElementAt(3);
			var elementAtOrDefault = customers.ElementAtOrDefault(99);
		}

		public void ExampleBoolean()
		{
			var customers = new CustomerGenerator().Generate(5);
			var anyCustomers = customers.Any();
			var anyCustomersWithOverOneHundredLogins = customers.Any(c => c.LoginCount > 100);
			var anyCustomersWithNoLogins = customers.Any(c => c.LoginCount == 0);
			var allCustomersHaveAtLeastOneLogin = customers.All(c => c.LoginCount > 0);
			var allCustomersHaveIdOfOne = customers.All(c => c.Id == 1);

			var numbers = new int[] { 1, 2, 3, 4, 5 };
			var containsThree = numbers.Contains(3);
			var containsSixty = numbers.Contains(60);
			var otherNumbers = new int[] { 1, 2, 3, 4, 5 };
			var identicalToOtherNumbers = numbers.SequenceEqual(otherNumbers);
			var outOfOrderNumbers = new int[] { 2, 4, 5, 3, 1 };
			var identicalToOutOfOrderNumbers = numbers.SequenceEqual(outOfOrderNumbers);

			var customer1 = new Customer() { Id = 1 };
			var customer2 = new Customer() { Id = 2 };
			var customersWithIds = new Customer[] { customer1, customer2 };
			var containsNewCustomer = customersWithIds.Contains(new Customer());
			var containsNewCustomer1 = customersWithIds.Contains(new Customer() { Id = 1 });
			var containsCustomer1 = customersWithIds.Contains(customer1);
			var containsCustomer2 = customersWithIds.Contains(customer2);

			var widgets = new Tuple<int, string>[]
			{
				new Tuple<int, string>(1, "One"),
				new Tuple<int, string>(2, "Two")
			};
			var containsWidget1 = widgets.Contains(new Tuple<int, string>(1, "One"));
			var containsWidget9 = widgets.Contains(new Tuple<int, string>(9, "Nine"));

			var products = new Product[]
			{
				new Product() { Id = 1, Name = "One" },
				new Product() { Id = 2, Name = "Two" }
			};
			var containsProduct1 = products.Contains(new Product() { Id = 1, Name = "One" });
			var containsProduct9 = products.Contains(new Product() { Id = 9, Name = "Nine" });
		}

		public void ExampleReduction()
		{
			var customers = new CustomerGenerator().Generate(5);
			var customersWithLotsOfLogins = customers.Where(c => c.LoginCount > 103);
			var customersWithOverOneMillionLogins = customers.Where(c => c.LoginCount > 1_000_000);
			var customer3ViaSingle = customers.Single(c => c.Id == 3);
			var customer3ViaWhereSingle = customers.Where(c => c.Id == 3).Single();
			var customersWithoutFirstCustomer = customers.Skip(1);
			var firstThreeCustomers = customers.Take(3);
			const int pageSize = 2;
			var customersPage1 = customers.Skip(0).Take(pageSize);
			var customersPage2 = customers.Skip(pageSize).Take(pageSize);

			var pager = new Pager<Customer>(customers, pageSize);
			var newPage1 = pager.Next();
			var newPage2 = pager.Next();
			var newPage3 = pager.Next();
			var newPage4 = pager.Next();

			var customersFromActiveOnward = customers.SkipWhile(c => !c.IsActive);
			var allExceptLastTwoCustomers = customers.SkipLast(2);
			var initialSetOfInactiveCustomers = customers.TakeWhile(c => !c.IsActive);
			var lastTwoCustomers = customers.TakeLast(2);
			var numbers = new int[] { 3, 1, 1, 2, 1, 3 };
			var distinct = numbers.Distinct();
		}

		public void ExampleOrdering()
		{
			var customers = new CustomerGenerator().Generate(5);
			var customersReversed = customers.Reverse();
			var customersOrdered = customers.OrderBy(c => c.IsActive);
			var customersOrderedDescending = customers.OrderByDescending(c => c.IsActive);
			var customersOrderedTwiceAscending = customers
				.OrderBy(c => c.IsActive)
				.ThenBy(c => c.CreatedDate);
			var customersOrderedTwiceDescending = customers
				.OrderBy(c => c.IsActive)
				.ThenByDescending(c => c.CreatedDate);
		}

		public void ExampleAggregation()
		{
			var customers = new CustomerGenerator().Generate(5);
			var totalLogins = customers.Sum(c => c.LoginCount);
			var averageLogins = customers.Average(c => c.LoginCount);
			var min = customers.Min(c => c.LoginCount);
			var max = customers.Max(c => c.LoginCount);
			var aggregate = customers.Aggregate((ac, c) => new Customer()
			{
				Id = Math.Max(ac.Id, c.Id),
				FirstName = ac.FirstName + " " + c.FirstName,
				LastName = ac.LastName + " " + c.LastName,
				CreatedDate = new DateTime(Math.Min(ac.CreatedDate.Ticks, c.CreatedDate.Ticks)),
				ModifiedDate = new DateTime(Math.Max(ac.ModifiedDate.Ticks, c.ModifiedDate.Ticks)),
				LoginCount = ac.LoginCount + c.LoginCount,
				IsActive = ac.IsActive || c.IsActive
			});
		}

		public void ExampleModification()
		{
			var customers = new CustomerGenerator().Generate(5);
			var customersWithOneExtraAtBeginning = customers.Prepend(new Customer() { Id = 0 });
			var customersWithOneExtraAtEnd = customers.Append(new Customer() { Id = 99 });
			var allFiveCustomers = customers.DefaultIfEmpty();
			var emptyCustomersArray = new Customer[0];
			var containsNullCustomer = emptyCustomersArray.DefaultIfEmpty();
			var containsOneDefaultCustomer = emptyCustomersArray.DefaultIfEmpty(new Customer());
		}

		public void ExampleConversionItems()
		{
			var numbersAsObjects = new object[] { 1, 2, 3, 4, 5 };
			var numbersAsInts = numbersAsObjects.Cast<int>();
			var customers = new CustomerGenerator().Generate(5);
			var users = customers.Select(c => new User()
			{
				Id = c.Id,
				Name = c.FirstName + " " + c.LastName,
				FavoriteNumbers = new int[0]
			});
			var inactivePeople = customers
				.Where(c => !c.IsActive)
				.Select(c => new { c.Id, Name = c.LastName + ", " + c.FirstName })
				.OrderBy(p => p.Name);

			var usersWithFavoriteNumbers = new User[]
			{
				new User() { Id = 1, Name = "User1", FavoriteNumbers = new int[] { 7 }},
				new User() { Id = 2, Name = "User2", FavoriteNumbers = new int[] { 1, 3, 7 }},
				new User() { Id = 3, Name = "User3", FavoriteNumbers = new int[] { 2, 3, 5, 7, 11 }},
				new User() { Id = 4, Name = "User4", FavoriteNumbers = new int[] { 1, 2 }}
			};
			var allFavoriteNumbers = usersWithFavoriteNumbers.SelectMany(u => u.FavoriteNumbers);
			var distinctOrderedFavoriteNumbers = usersWithFavoriteNumbers
				.SelectMany(u => u.FavoriteNumbers)
				.Distinct()
				.OrderBy(n => n);

			var infos = new PlayerInfo[]
			{
				new PlayerInfo() { PlayerId = 1, Name = "Name1", CreatedDate = DateTime.Parse("01/01/2001") },
				new PlayerInfo() { PlayerId = 2, Name = "Name2", CreatedDate = DateTime.Parse("02/02/2002") }
			};
			var metadatas = new PlayerMetadata[]
			{
				new PlayerMetadata() { PlayerId = 1, Tags = new string[] { "strong slow" } },
				new PlayerMetadata() { PlayerId = 2, Tags = new string[] { "weak fast" } }
			};
			var players = infos.Zip(metadatas, (i, m) => new Player()
			{
				Id = i.PlayerId == m.PlayerId ? i.PlayerId : Int32.MinValue,
				Name = i.Name,
				CreatedDate = i.CreatedDate,
				Tags = m.Tags
			});
		}

		public void ExampleConversionSets()
		{
			var products = new Product[]
			{
				new Product() { Id = 1, Name = "One" },
				new Product() { Id = 2, Name = "Two" }
			};
			var array = products.ToArray();
			var list = products.ToList();
			var dictionaryOfProducts = products.ToDictionary(p => p.Id);
			var lookupOfNames = products.ToLookup(p => p.Id, p => p.Name);
			var hashset = products.ToHashSet();
			var lookup = products.ToLookup(p => p.Id);
		}

		public void ExampleCombining()
		{
			var numbersAlpha = new int[] { 1, 2, 3 };
			var numbersBravo = new int[] { 2, 4 };
			var numbersConcat = numbersAlpha.Concat(numbersBravo);
			var numbersUnion = numbersAlpha.Union(numbersBravo);
		}

		public void ExampleJoining()
		{
			var numbersAlpha = new int[] { 1, 2, 3 };
			var numbersBravo = new int[] { 2, 4 };
			var numbersExcludingBravo = numbersAlpha.Except(numbersBravo);
			var products = new Product[]
			{
				new Product() { Id = 1, Name = "One" },
				new Product() { Id = 2, Name = "Two" }
			};
			var productsDiscontinued = new Product[]
			{
				new Product() { Id = 2, Name = "Two" }
			};
			var productsAvailable = products.Except(productsDiscontinued);
			var numbersInBothSets = numbersAlpha.Intersect(numbersBravo);

			var infos = new PlayerInfo[]
			{
				new PlayerInfo() { PlayerId = 1, Name = "Name1", CreatedDate = DateTime.Parse("01/01/2001") },
				new PlayerInfo() { PlayerId = 2, Name = "Name2", CreatedDate = DateTime.Parse("02/02/2002") },
				new PlayerInfo() { PlayerId = 7, Name = "Name7", CreatedDate = DateTime.Parse("07/07/2007") }
			};
			var metadatas = new PlayerMetadata[]
			{
				new PlayerMetadata() { PlayerId = 1, Tags = new string[] { "strong slow" } },
				new PlayerMetadata() { PlayerId = 2, Tags = new string[] { "weak fast" } },
				new PlayerMetadata() { PlayerId = 8, Tags = new string[] { "tall smart" } }
			};
			var joinedPlayers = infos.Join(metadatas, i => i.PlayerId, m => m.PlayerId, (i, m) => new Player()
			{
				Id = i.PlayerId,
				Name = i.Name,
				CreatedDate = i.CreatedDate,
				Tags = m.Tags
			});

			var parents = new ParentRow[]
			{
				new ParentRow() { ParentId = 1, ParentName = "Parent1" },
				new ParentRow() { ParentId = 2, ParentName = "Parent2" }
			};
			var children = new ChildRow[]
			{
				new ChildRow() { ChildId = 1, ParentId = 1, ChildName = "Child1" },
				new ChildRow() { ChildId = 2, ParentId = 1, ChildName = "Child2" },
				new ChildRow() { ChildId = 3, ParentId = 2, ChildName = "Child3" },
				new ChildRow() { ChildId = 4, ParentId = 2, ChildName = "Child4" }
			};

			var joinedFamily = parents.Join(children, p => p.ParentId, c => c.ParentId, (p, c) => new
			{
				Parent = p,
				Child = c
			});
			var joinedFamilyMessageBuilder = new StringBuilder();
			foreach (var relationship in joinedFamily)
			{
				var line = relationship.Parent.ParentName + ":" + relationship.Child.ChildName;
				joinedFamilyMessageBuilder.AppendLine(line);
			}
			var joinedFamilyMessage = joinedFamilyMessageBuilder.ToString();

			var groupJoinedFamily = parents.GroupJoin(children, p => p.ParentId, c => c.ParentId, (p, c) => new
			{
				Parent = p,
				Children = c
			});
			var groupJoinedFamilyMessageBuilder = new StringBuilder();
			foreach (var parent in groupJoinedFamily)
			{
				var childrensNames = String.Join(",", parent.Children.Select(c => c.ChildName));
				var line = parent.Parent.ParentName + ":" + childrensNames;
				groupJoinedFamilyMessageBuilder.AppendLine(line);
			}
			var groupJoinedFamilyMessage = groupJoinedFamilyMessageBuilder.ToString();

			var numbers = new int[] { 1, 2, 3, 4, 5 };
			var groups = numbers.GroupBy(n => n % 2 == 0);
			var groupMessageBuilder = new StringBuilder();
			foreach (var group in groups)
			{
				var line = (group.Key ? "Even" : "Odd") + ":" + String.Join(",", group);
				groupMessageBuilder.AppendLine(line);
			}
			var groupMessage = groupMessageBuilder.ToString();

			var animals = new Animal[]
			{
				new Animal() { Id = 1, Species = "Dog", Age = 7 },
				new Animal() { Id = 2, Species = "Cat", Age = 3 },
				new Animal() { Id = 3, Species = "Cat", Age = 6 },
				new Animal() { Id = 4, Species = "Cat", Age = 3 },
				new Animal() { Id = 5, Species = "Dog", Age = 6 }
			};
			var animalSummaryBuilder = new StringBuilder();
			var animalsByAge = animals.GroupBy(a => a.Age);
			foreach (var ageGroup in animalsByAge)
			{
				animalSummaryBuilder.AppendLine($"Animals Age {ageGroup.Key}");
				foreach (var animal in ageGroup)
				{
					var line = $"\tId:{animal.Id}:Species:{animal.Species}";
					animalSummaryBuilder.AppendLine(line);
				}
			}
			var animalsBySpecies = animals.GroupBy(a => a.Species);
			foreach (var speciesGroup in animalsBySpecies)
			{
				animalSummaryBuilder.AppendLine($"{speciesGroup.Key}s");
				foreach (var animal in speciesGroup)
				{
					var line = $"\tId:{animal.Id}:Age:{animal.Age}";
					animalSummaryBuilder.AppendLine(line);
				}
			}
			var animalSummary = animalSummaryBuilder.ToString();
		}
	}
}

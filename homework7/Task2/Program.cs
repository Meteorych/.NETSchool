using System.Globalization;


namespace Task2
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			var dataString = await File.ReadAllLinesAsync("data.txt");
			var listOfObjects = new List<(string, double, double)>();
			foreach (var objectParameters in dataString)
			{
				var parameters = objectParameters.Split(',');
				listOfObjects.Add((parameters[0], double.Parse(parameters[1].Trim(), CultureInfo.InvariantCulture), double.Parse(parameters[2].Trim(), 
					CultureInfo.InvariantCulture)));
			}
			await GetNamesOfObjects(listOfObjects, 3);
		}

		public static (string, double, double) KClosestAlgorithm(List<(string, double, double)> listOfObjects, (double, double) unknownObject, int k)
		{

			var elementName = listOfObjects
				.AsParallel()
				.OrderBy(knownObject =>
					Math.Sqrt(Math.Pow(knownObject.Item2 - unknownObject.Item1, 2) + Math.Pow(knownObject.Item3 - unknownObject.Item2, 2)))
				.Take(k)
				.GroupBy(knownObject => knownObject.Item1)
				.OrderByDescending(group => group.Count())
				.First()
				.Key;
			var result = (elementName, unknownObject.Item1, unknownObject.Item2);
			return result;
		}

		public static async Task GetNamesOfObjects(List<(string, double, double)> listOfObjects, int k)
		{
			await foreach (var unknownElement in GetUnknownObject())
			{
				Console.WriteLine(KClosestAlgorithm(listOfObjects, unknownElement, k));
			}
		}

		public static async IAsyncEnumerable<(double, double)> GetUnknownObject()
		{
			var rand = new Random();
			for (var i = 0; i < 10; i++)
			{
				await Task.Delay(1000);
				yield return ((rand.NextDouble() + rand.Next(0, 9)), (rand.NextDouble() + rand.Next(0, 9)));
			}
		}
	}
}

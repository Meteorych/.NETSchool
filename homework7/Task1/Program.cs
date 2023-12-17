using System.Globalization;
using System.Text.Json;
using System.Xml.Linq;

namespace Task1;

public class Program
{
	public static void Main(string[] args)
	{
		var vacations = new List<Vacation>();
		try
		{
			using (var dataStream = new StreamReader(Path.Combine(Environment.CurrentDirectory, "data.csv")))
			{
				string? line;
				var lineNumber = 0;
				while (!string.IsNullOrEmpty(line = dataStream.ReadLine()))
				{
					var vacation = new Vacation();
					var parts = line.Split(',');
					lineNumber++;
					if (parts.Length != 3)
					{
						Console.WriteLine($"Mistake in the string number {lineNumber}");
						continue;
					}

					vacation.EmployeeName = parts[0].Trim();
					if (!DateTime.TryParseExact(parts[1].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var beginDate))
					{
						Console.WriteLine($"Wrong beginDate format in the string number {lineNumber}");
						continue;
					}

					vacation.BeginDate = beginDate;
					if (!DateTime.TryParseExact(parts[2].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
					{
						Console.WriteLine($"Wrong endDate format in the string number {lineNumber}");
						continue;
					}

					vacation.EndDate = endDate;
					vacations.Add(vacation);
				}
			}
		}
		catch (IOException e)
		{
			Console.WriteLine($"{e}");
		}
		Console.WriteLine(AverageVacationSpan(vacations));
		VacationEmployee(vacations);
	}

	public static double AverageVacationSpan(List<Vacation> vacations)
	{
		var result = vacations
			.AsParallel()
			.Select(vacation => (vacation.EndDate - vacation.BeginDate).Days + 1)
			.Average();
		return result; 
	}

	public static void VacationEmployee(List<Vacation> vacations)
	{
		var result = vacations
			.AsParallel()
			.GroupBy(vacation => vacation.EmployeeName)
			.Select(employeeVacations => new
			{
				employeeName = employeeVacations.Key,
				TotalVacationDays = employeeVacations.Sum(g => (g.EndDate - g.BeginDate).Days + 1)
			})
			.OrderByDescending(employee => employee.TotalVacationDays)
			.ToList();
		ToJson(result);
		foreach (var element in result)
		{
			Console.WriteLine(element);
		}
	}

	public static void ToJson(object vacationDuration)
	{
		var json = JsonSerializer.Serialize(vacationDuration, new JsonSerializerOptions() { WriteIndented = true});
		File.WriteAllText("persons.json", json);
	}
}
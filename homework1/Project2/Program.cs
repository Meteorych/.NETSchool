namespace Project2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the first 9 symbols of ISBN: ");
            var isbn = Console.ReadLine();
            var controlNumber = 0;
            for (var i = 0; i < 9; i++ )
            {
                controlNumber += int.Parse(isbn[i].ToString()) * (10 - i);
            }
            var lastElement = 11 - (controlNumber % 11);
            isbn += lastElement switch
            {
                10 => "X",
                11 => 0,
                _ => lastElement.ToString()
            };

            Console.WriteLine($"\nFinal form of ISBN: {isbn}");
        }
    }
}
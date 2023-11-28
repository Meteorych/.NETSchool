using Task2;

internal class Program
{
    static void Main(string[] args)
    {
        const string testAuthor1 = "Herman Melvill";
        const string testAuthor2 = "Fyodor Dostoevsky";
        const string testAuthor3 = "Friedrich Nietzsche";
        Book testBook1 = new("Moby Dick", releaseDate: DateOnly.Parse("23.09.1851"), authors: new HashSet<string> { testAuthor1 });
        Book testBook2 = new("Brothers Karamazov", releaseDate: DateOnly.Parse("23.09.1881"), authors: new HashSet<string> { testAuthor2 });
        Book testBook3 = new("Thus Said Zarathustra", releaseDate: DateOnly.Parse("23.09.1885"), authors: new HashSet<string> { testAuthor3 });
        Book testBook4 = new("Crime and Punishment", releaseDate: DateOnly.Parse("23.09.1869"), authors: new HashSet<string> { testAuthor2 });
        Book testBook5 = new("Yan Zhyzhka");
        var testCatalog = new Catalog
        {
            ["1234433212343"] = testBook1,
            ["1237833215643"] = testBook2,
            ["123-4-56-789012-3"] = testBook3,
            ["1254438212373"] = testBook4,
            ["1124142153256"] = testBook5
        };
        Console.WriteLine(testCatalog["123-4-56-789012-3"].Title);
        Console.WriteLine(testCatalog["1234567890123"].Title);

        foreach (var book in testCatalog.SortedBooksByName("Fyodor Dostoevsky"))
        {
            Console.Write("\n");
            Console.WriteLine(book.Title);
        }
        foreach (var bookAuthor in testCatalog.AuthorBooks())
        {
            Console.Write("\n");
            Console.WriteLine(bookAuthor);
        }
        foreach (var title in testCatalog.SortedListOfTitles())
        {
            Console.Write("\n");
            Console.WriteLine(title);
        }
        ;
    }
}
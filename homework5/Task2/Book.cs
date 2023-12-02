namespace Task2;

public class Book
{
    private readonly HashSet<string>? _authors;
    public string Title { get; }
    public DateOnly? ReleaseDate { get; }
    public IEnumerable<string>? Authors => _authors;
    

    public Book(string title, DateOnly? releaseDate = null, HashSet<string>? authors = null)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException(nameof(title), "Title can't be null or empty.");
        }
        Title = title;
        ReleaseDate = releaseDate;
        _authors = authors ?? new HashSet<string>();
    }
}
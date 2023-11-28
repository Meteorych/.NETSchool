namespace Task2;

public class Book
{
    public string Title { get; }
    public DateOnly? ReleaseDate { get; }
    public HashSet<string>? Authors { get; }

    public Book(string title, DateOnly? releaseDate = null, HashSet<string>? authors = null)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException(nameof(title), "Title can't be null or empty.");
        }
        Title = title;
        ReleaseDate = releaseDate;
        Authors = authors ?? new HashSet<string>();
    }
}
using System.Text.RegularExpressions;

namespace Task2;

public class Catalog 
{
    private readonly Dictionary<string, Book> _books = new();

    public Book this[string isbn]
    {
        get
        {
            if (!IsbnCheck(isbn)) throw new ArgumentException("Wrong ISBN.");
            return _books[RemoveDashesFromIsbn(isbn)] ?? throw new KeyNotFoundException("Book with such ISBN isn't included in this catalog.");
        }
        set
        {
            if (!IsbnCheck(isbn)) throw new ArgumentException("Wrong ISBN.");
            _books[RemoveDashesFromIsbn(isbn)] = value;
        }
    }

    public IOrderedEnumerable<string> SortedListOfTitles()
    {
        return _books
            .Select(pair => pair.Value.Title)
            .OrderBy(title => title);
    }

    public IOrderedEnumerable<Book> SortedBooksByName(string name)
    {
        return _books
            .Select(pair => pair.Value)
            .Where(book => book.Authors != null && book.Authors.Any(author => author == name))
            .OrderBy(book => book.ReleaseDate);
    }

    public IEnumerable<(string, int)> AuthorBooks()
    {
        return _books.Values
            .Where(book => book.Authors != null)
            .SelectMany(book => book.Authors, (book, author) => new { Book = book, Author = author })
            .GroupBy(x => x.Author)
            .Select(group => (group.Key.ToString(), group.Count()));
    }

    private static bool IsbnCheck(string isbn)
    {
        var regexIsbn = new Regex(@"^\d{13}$|^\d{3}-\d-\d{2}-\d{6}-\d$");
        return regexIsbn.IsMatch(isbn);
    }

    private static string RemoveDashesFromIsbn(string isbn)
    {
        return isbn.Replace("-", string.Empty);
    }
}
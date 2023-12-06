namespace Task1;

public class CacheItem(object value)
{
    public object Value { get;} = value;
    public DateTime LastAccessed { get;} = DateTime.Now;
}
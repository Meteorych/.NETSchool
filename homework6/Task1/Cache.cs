namespace Task1;

public class Cache
{
    private readonly uint _capacity;
    private readonly Dictionary<string, CacheItem> _cache;
    private readonly object _lockObject = new();
        
    public Cache(uint capacity) 
    {
        _capacity = capacity;
        _cache = new Dictionary<string, CacheItem>();
        var cleanupThread = new Thread(CleanupCache)
        {
            IsBackground = true
        };
        cleanupThread.Start();
                
    }

    public void Set(string key, object obj)
    {
        KeyCheck(key);
        ArgumentNullException.ThrowIfNull(obj);
        lock (_lockObject)
        {
            if ((!_cache.ContainsKey(key)) && _cache.Count == _capacity)
            {
                RemoveLeastAccessedItems(true);
            }
            _cache[key] = new CacheItem(obj);
        }
    }

    public object? Get(string key)
    {
        KeyCheck(key);
        lock (_lockObject)
        {
            return !_cache.TryGetValue(key, out var value) ? null : value.Value;
        }
    }

    public bool Remove(string key)
    {
        lock (_lockObject)
        {
            KeyCheck(key);
            if (!_cache.ContainsKey(key)) return false;
            _cache.Remove(key);
            return true;

        }
    }

    private static void KeyCheck (string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }
    }


    private void RemoveLeastAccessedItems(bool compulsoryRemove = false)
    {
        var oldestTime = DateTime.Now;
        var lastAccessedElementKey = "";
        foreach (var pair in _cache)
        {
            if ((DateTime.Now - pair.Value.LastAccessed).Seconds > 10)
            {
                Remove(pair.Key);
            }

            if (!compulsoryRemove) return;
            if (pair.Value.LastAccessed < oldestTime)
            {
                lastAccessedElementKey = pair.Key;
            }
        }

        Remove(lastAccessedElementKey);
    }

    private void CleanupCache()
    {
        while (true)
        {
            Thread.Sleep(1000);
            if (_cache.Count == 0) continue;
            lock (_lockObject)
            {
                RemoveLeastAccessedItems();
            }
        }
    }
}
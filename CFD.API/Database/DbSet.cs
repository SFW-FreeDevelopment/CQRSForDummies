namespace CFD.API.Database;

public interface IDbSet<T> : IEnumerable<T> where T : BaseEntity
{
    T this[string key] { get; set; }
    T this[int index] { get; }
    T Find(string key);
    T Add(T item);
    void Remove(T item);
}

public class DbSet<T> : IDbSet<T> where T : BaseEntity
{
    private readonly IDictionary<string, T> _data = new Dictionary<string, T>();

    public DbSet() { }
    public DbSet(IEnumerable<T> data)
    {
        foreach (var item in data)
        {
            Add(item);
        }
    }
    
    public IEnumerator<T> GetEnumerator() => _data.Values.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public T this[string key]
    {
        get => _data.TryGetValue(key, out var value) ? value : default;
        set => Add(value);
    }
    public T this[int index] => _data.Values.OrderBy(x => x.CreatedAt).ToArray()[index];

    public T Find(string key) =>_data.TryGetValue(key, out var item) ? item : default;
    
    public T Add(T item)
    {
        if (_data.ContainsKey(item.Id))
        {
            _data[item.Id] = item;
        }
        else
        {
            _data.Add(item.Id, item);
        }
        return item;
    }
    
    public void Remove(T item)
    {
        if (_data.ContainsKey(item.Id))
            _data.Remove(item.Id);
    }
}
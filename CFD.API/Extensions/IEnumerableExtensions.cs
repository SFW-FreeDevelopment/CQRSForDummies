namespace CFD.API.Extensions;

public static class IEnumerableExtensions
{
    public static async Task<T[]> ToArrayAsync<T>(this IEnumerable<T> source) =>
        await Task.FromResult(source.ToArray());

    public static async Task<T> FirstOrDefaultAsync<T>(this IEnumerable<T> source) =>
        await Task.FromResult(source.FirstOrDefault());
}
using FlowaX.Core;

namespace FlowaX.Extensions
{
    public static class AsyncResultExtensions
    {
        // Asynchrones Map
        public static async Task<Result<TOut>> MapAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<TIn, Task<TOut>> func)
        {
            var result = await task;
            return result switch
            {
                Success<TIn> s => Result<TOut>.Success(await func(s.Value)),
                Failure<TIn> f => Result<TOut>.Failure(f.Error),
                _ => throw new InvalidOperationException("Ungültiger Zustand")
            };
        }

        // Asynchrones Binden
        public static async Task<Result<TOut>> BindAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<TIn, Task<Result<TOut>>> func)
        {
            var result = await task;
            return result switch
            {
                Success<TIn> s => await func(s.Value),
                Failure<TIn> f => Result<TOut>.Failure(f.Error),
                _ => throw new InvalidOperationException("Ungültiger Zustand")
            };
        }
    }
}

using FlowaX.Core;


namespace FlowaX.Extensions
{
    public static class ResultExtensions
    {
        // Map (Synchron)
        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
            => result switch
            {
                Success<TIn> s => Result<TOut>.Success(func(s.Value)),
                Failure<TIn> f => Result<TOut>.Failure(f.Error),
                _ => throw new InvalidOperationException("Ungültiger Zustand")
            };

        // Bind (Synchron)
        public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> func)
            => result switch
            {
                Success<TIn> s => func(s.Value),
                Failure<TIn> f => Result<TOut>.Failure(f.Error),
                _ => throw new InvalidOperationException("Ungültiger Zustand")
            };

        // Match für Fluent API
        public static void Match<T>(this Result<T> result, Action<T> onSuccess, Action<string> onFailure)
        {
            switch (result)
            {
                case Success<T> s:
                    onSuccess(s.Value);
                    break;
                case Failure<T> f:
                    onFailure(f.Error);
                    break;
            }
        }
        
    }
}

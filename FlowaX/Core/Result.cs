using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowaX.Core
{
    public abstract class Result<T>
    {
        public abstract bool IsSuccess { get; }
        public abstract T Value { get; }
        public abstract string Error { get; }
        public abstract Exception Exception { get; }

        // Factory-Methoden für Success und Failure
        public static Result<T> Success(T value) => new Success<T>(value);
        public static Result<T> Failure(string error) => new Failure<T>(error);
        public static Result<T> Failure(Exception ex) => new Failure<T>(ex.Message, ex);

        // Automatische Fehlerbehandlung (Synchron)
        public static Result<T> From(Func<T> func)
        {
            try
            {
                return Success(func());
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }

        // Automatische Fehlerbehandlung (Asynchron)
        public static async Task<Result<T>> FromAsync(Func<Task<T>> func)
        {
            try
            {
                T result = await func();
                return Success(result);
            }
            catch (Exception ex)
            {
                return Failure(ex);
            }
        }

    }

    public sealed class Success<T> : Result<T>
    {
        public override bool IsSuccess => true;
        public override T Value { get; }
        public override string Error { get; }
        public override Exception Exception => null;

        internal Success(T value) => Value = value;
    }

    public sealed class Failure<T>: Result<T>
    {
        public override bool IsSuccess => false;
        public override T Value => throw new InvalidOperationException("No Value");
        public override string Error { get; }
        public override Exception Exception { get; }

        internal Failure(string error, Exception ex = null)
        {
            Error = error;
            Exception = ex;
        }
    }
}

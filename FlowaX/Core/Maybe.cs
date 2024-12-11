using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowaX.Core;

public sealed class Maybe<T>
{
    public T Value { get; }
    public bool HasValue { get; }

    private Maybe(T value, bool hasValue)
    {
        Value = value;
        HasValue = hasValue;
    }

    public static Maybe<T> Some(T value) => new(value, true);
    public static Maybe<T> None() => new(default, false);
}

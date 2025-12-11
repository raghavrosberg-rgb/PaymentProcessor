using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.ExpressionTree
{
    public sealed class Result<TValue, TError>
    {
        private readonly TValue? _value;
        private readonly TError? _error;

        private Result(TError error)
        {
            _error = error;
        }

        private Result(TValue value)
        {
            _value = value;
        }

        public bool IsSuccess => _error == null;

        public TValue? Value => _value ?? throw new InvalidOperationException();

        public static Result<TValue, TError> Success(TValue value) => new(value);

        public static Result<TValue, TError> Error(TError error) => new(error);
    }

    //public static class ResultExtensions
    //{
    //    extension<TValue, TError>(Result<TValue, TError> result)
    //    {
    //        // Use as: result.IsError()
    //        public bool IsError => !result.IsSuccess;//<-- this is a property!

    //        // Use as: result.GetValueOrDefault()
    //        public TValue? GetValueOrDefault() => result.IsSuccess
    //            ? result.Value
    //            : default;
    //    }
    //}

    public sealed class NotFound;

    // extensions with static member
    public static class ResultExtensions
    {
        extension<TValue, TError>(Result<TValue, TError> _)
        {
            public static Result<TValue, NotFound> NotFound() =>
                Result<TValue, NotFound>.Error(new NotFound());
        }
    }
}

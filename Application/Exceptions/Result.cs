using Application.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public Error Error{ get; }


        public bool IsFailure => !IsSuccess;

        public Result(bool isSuccess, Error errortest)
        {
            IsSuccess = isSuccess;
            Error = errortest;
        }

        public static Result Success()
        {
            return new(true, null);
        }

        public static Result Failure(Error error)
        {
            return new(false, error);
        }

        public static Result<T> Failure<T>(Error error)
        {
            return new(default, false, error);
        }

    }

    public class Result<T> : Result
    {
        public T? Value { get; private set; }

        public Result(T? value, bool isSuccess, Error error): base(isSuccess, error)
        {
            Value = value;
        }


        public static Result<T> Success(T value) => new Result<T>(value, true, null);
        public static Result<T> Failure(Error error) => new Result<T>(default, false, error);

        public static Result<T> ValidationFailure(Error error)
        {
            return new(default, false, error);
        }

    }

}

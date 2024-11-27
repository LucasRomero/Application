using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Exceptions
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string? Error { get; private set; }


        public bool IsFailure => !IsSuccess;

        public Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new(true, null);
        }

        public static Result Failure(string error)
        {
            return new(false, error);
        }
    }

    public class Result<T> : Result
    {
        public T? Value { get; private set; }

        public Result(bool isSuccess, T? value, string? error): base(isSuccess, error)
        {
            Value = value;
        }


        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
    }

}

﻿using System.Diagnostics;

namespace ResultMonad.Extensions.ResultWithValue.Map
{
    public static class MapExtensions
    {
        [DebuggerStepThrough]
        public static Result ToResult<TValue>(this Result<TValue> result)
        {
            return result.IsSuccess
                ? Result.Ok()
                : Result.Fail();
        }
    }
}
﻿using ResultMonad.Extensions.ResultWithValueAndErrorMonad.OnError;
using Shouldly;
using Xunit;

namespace ResultMonad.Extensions.Tests.ResultWithValueAndErrorMonad.OnError
{
    [Trait("Extensions", "ResultWithValueError")]
    public class OnErrorToResultWithErrorTests1
    {
        [Fact]
        public void OnError_executes_function_if_result_is_fail()
        {
            var functionExecuted = false;
            var result = Result.Fail<int, string>("error")
                .OnErrorToResultWithError(i => OnErrorFunc(i));

            functionExecuted.ShouldBeTrue();

            int OnErrorFunc(string error)
            {
                functionExecuted = true;
                return 1;
            }
        }

        [Fact]
        public void OnError_does_not_execute_function_if_result_is_ok()
        {
            var functionExecuted = false;
            var result = Result.Ok<int, string>(1)
                .OnErrorToResultWithError(i => OnErrorFunc(i));

            functionExecuted.ShouldBeFalse();

            int OnErrorFunc(string error)
            {
                functionExecuted = true;
                return 1;
            }
        }


        [Fact]
        public void OnError_propagates_error_into_function_if_result_is_fail()
        {
            var propagatedValue = "";
            var error = "error";
            var result = Result.Fail<int, string>(error)
                .OnErrorToResultWithError(i => OnErrorFunc(i));

            propagatedValue.ShouldBe(error);

            int OnErrorFunc(string err)
            {
                propagatedValue = err;
                return 1;
            }
        }

        [Fact]
        public void OnError_new_result_contains_error_from_function_if_result_is_fail()
        {
            var newError = "abc";
            var result = Result.Fail<int, string>("error")
                .OnErrorToResultWithError(i => newError);

            result.Error.ShouldBe(newError);
        }
    }
}

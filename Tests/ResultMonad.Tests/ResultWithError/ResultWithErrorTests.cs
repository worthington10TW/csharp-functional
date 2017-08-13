﻿using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace ResultMonad.Tests.ResultWithError
{
    [Trait("Monad", "ResultSimple")]
    public class ResultWithErrorTests
    {
        [Fact]
        public void Ok_result_IsSuccess_is_true()
        {
            var result = ResultMonad.ResultWithError.Ok<string>();
            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public void Ok_result_IsFailure_is_false()
        {
            var result = ResultMonad.ResultWithError.Ok<string>();
            result.IsFailure.ShouldBeFalse();
        }

        [Fact]
        public void Fail_result_IsSuccess_is_false()
        {
            var result = ResultMonad.ResultWithError.Fail("abc");
            result.IsSuccess.ShouldBeFalse();
        }

        [Fact]
        public void Fail_result_IsFailure_equals_true()
        {
            var result = ResultMonad.ResultWithError.Fail("abc");
            result.IsFailure.ShouldBeTrue();
        }

        [Fact]
        public void Acessing_the_error_of_fail_result_returns_error()
        {
            var error = "abc";
            var result = ResultMonad.ResultWithError.Fail(error);
            var isEqual = result.Error.Equals(error);
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Acessing_the_error_of_ok_result_throws_exception()
        {
            var result = ResultMonad.ResultWithError.Ok<string>();
            var exception = Should.Throw<InvalidOperationException>(() =>
            {
                var value = result.Error;
            });
        }

        [Fact]
        public void From_if_predicate_is_true_returns_ok_result()
        {
            var error = "error";
            var result = ResultMonad.ResultWithError.From(() => true, error);
            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public void From_if_predicate_is_false_returns_fail_result_with_error()
        {
            var error = "error";
            var result = ResultMonad.ResultWithError.From(() => false, error);
            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe(error);
        }

        [Fact]
        public void Combine_if_all_results_are_ok_returns_ok_result()
        {
            var resultsLists = new List<ResultWithError<string>>
            {
                ResultMonad.ResultWithError.Ok<string>(),
                ResultMonad.ResultWithError.Ok<string>(),
                ResultMonad.ResultWithError.Ok<string>()
            };

            var combinedResult = Result.Combine(resultsLists.ToArray());
            combinedResult.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public void Combine_returns_first_fail_result_if_at_least_one_result_is_a_fail()
        {
            var firstFailure = ResultMonad.ResultWithError.Fail("error");
            var resultsLists = new List<ResultWithError<string>>
            {
                ResultMonad.ResultWithError.Ok<string>(),
                firstFailure,
                ResultMonad.ResultWithError.Ok<string>(),
                ResultMonad.ResultWithError.Fail("secod error")
            };

            var combinedResult = Result.Combine(resultsLists.ToArray());
            combinedResult.IsFailure.ShouldBeTrue();
            combinedResult.Error.ShouldBe(firstFailure.Error);
        }
    }
}

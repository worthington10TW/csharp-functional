﻿using Shouldly;
using Xunit;

namespace ResultMonad.Tests.ResultWithErrorMonad.Equality
{
    [Trait("Monad", "ResultWithError")]
    public class ResultWithErrorInequalityOperatorTests
    {
        [Fact]
        public void Inequality_operator_between_error_and_fail_ResultWithError_is_false_if_errors_are_equals()
        {
            var error = "abc";
            var result = ResultWithError.Fail(error);
            var isDifferent = result != error;
            isDifferent.ShouldBeFalse();
        }

        [Fact]
        public void Inequality_operator_between_error_and_ok_ResultWithError_is_true()
        {
            var error = "abc";
            var result = ResultWithError.Ok<string>();
            var isDifferent = result != error;
            isDifferent.ShouldBeTrue();
        }

        [Fact]
        public void Inequality_operator_between_two_fail_ResultWithErrors_is_false_if_errors_are_equal()
        {
            var error = "abc";
            var result1 = ResultWithError.Fail(error);
            var result2 = ResultWithError.Fail(error);
            var isDifferent = result1 != result2;
            isDifferent.ShouldBeFalse();
        }

        [Fact]
        public void Inequality_operator_between_two_fail_ResultWithErrors_is_true_if_errors_are_not_equal()
        {
            var result1 = ResultWithError.Fail("abc");
            var result2 = ResultWithError.Fail("zzz");
            var isDifferent = result1 != result2;
            isDifferent.ShouldBeTrue();
        }

        [Fact]
        public void Inequality_operator_between_two_ok_ResultWithErrors_is_false()
        {
            var result1 = ResultWithError.Ok<string>();
            var result2 = ResultWithError.Ok<string>();
            var isDifferent = result1 != result2;
            isDifferent.ShouldBeFalse();
        }

        [Fact]
        public void Inequality_operator_between_ok_ResultWithError_and_fail_ResultWithError_is_true()
        {
            var okResult = ResultWithError.Ok<string>();
            var errorResult = ResultWithError.Fail("abc");
            var isDifferent = okResult != errorResult;
            isDifferent.ShouldBeTrue();
        }
    }
}

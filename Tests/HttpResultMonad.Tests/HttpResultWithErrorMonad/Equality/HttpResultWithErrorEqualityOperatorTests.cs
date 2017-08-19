﻿using Shouldly;
using Tests.Shared;
using Xunit;

namespace HttpResultMonad.Tests.HttpResultWithErrorMonad.Equality
{
    [Trait("Monad", "HttpResultWithError")]
    public class HttpResultWithErrorEqualityOperatorTests
    {
        [Fact]
        public void Equality_operator_between_two_fail_HttpResultWithError_is_true_if_the_HttpState_and_the_error_are_equal()
        {
            var error = "abc";
            var result1 = HttpResultWithError.Fail(error);
            var result2 = HttpResultWithError.Fail(error);
            var result3 = HttpResultWithError.Fail(error, Test.CreateHttpStateA());
            var result4 = HttpResultWithError.Fail(error, Test.CreateHttpStateA());

            var isEqual1 = result1 == result2;
            var isEqual2 = result3 == result4;

            isEqual1.ShouldBeTrue();
            isEqual2.ShouldBeTrue();
        }
        
        [Fact]
        public void Equality_operator_between_two_fail_HttpResultWithError_with_different_error_is_false()
        {
            var result1 = HttpResultWithError.Fail("abc");
            var result2 = HttpResultWithError.Fail("zzz");
            var isEqual = result1 == result2;
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equality_operator_between_two_fail_HttpResultWithError_with_different_HttpState_is_false()
        {
            var result1 = HttpResultWithError.Fail("abc", Test.CreateHttpStateA());
            var result2 = HttpResultWithError.Fail("abc", Test.CreateHttpStateB());
            var isEqual = result1 == result2;
            isEqual.ShouldBeFalse();
        }
       
        [Fact]
        public void Equality_operator_between_two_ok_HttpResultWithError_is_true_if_HttpState_are_equal()
        {
            var result1 = HttpResultWithError.Ok<string>();
            var result2 = HttpResultWithError.Ok<string>();
            var result3 = HttpResultWithError.Ok<string>(Test.CreateHttpStateA());
            var result4 = HttpResultWithError.Ok<string>(Test.CreateHttpStateA());

            var isEqual1 = result1 == result2;
            var isEqual2 = result3 == result4;

            isEqual1.ShouldBeTrue();
            isEqual2.ShouldBeTrue();
        }
        
        [Fact]
        public void Equality_operator_between_two_ok_HttpResultWithError_is_false_if_HttpState_are_not_equal()
        {
            var result1 = HttpResultWithError.Ok<string>(Test.CreateHttpStateA());
            var result2 = HttpResultWithError.Ok<string>(Test.CreateHttpStateB());

            var isEqual1 = result1 == result2;
            isEqual1.ShouldBeFalse();
        }

        [Fact]
        public void Equality_operator_between_ok_HttpResultWithError_and_fail_HttpResultWithError_is_false()
        {
            var okResult = HttpResultWithError.Ok<string>();
            var errorResult = HttpResultWithError.Fail("abc");
            var isEqual = okResult == errorResult;
            isEqual.ShouldBeFalse();
        }
    }
}

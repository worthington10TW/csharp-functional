﻿using Shouldly;
using Tests.Shared;
using Xunit;

namespace HttpResultMonad.Tests.HttpResultWithErrorMonad.Equality
{
    [Trait("Monad", "HttpResultWithError")]
    public class HttpResultWithErrorGetHashCodeTests
    {
        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithError_of_same_type_is_true()
        {
            var result1 = HttpResultWithError.Ok<string>();
            var result2 = HttpResultWithError.Ok<string>();
            var result3 = HttpResultWithError.Ok<string>(Test.CreateHttpStateA());
            var result4 = HttpResultWithError.Ok<string>(Test.CreateHttpStateB());
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
            result3.GetHashCode().ShouldBe(result4.GetHashCode());
        }
        
        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithError_of_different_types_is_not_equal()
        {
            var result1 = HttpResultWithError.Ok<int>();
            var result2 = HttpResultWithError.Ok<string>();
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_HttpResultWithError_is_equal_if_error_are_equal()
        {
            var error = "abc";
            var result1 = HttpResultWithError.Fail(error);
            var result2 = HttpResultWithError.Fail(error);
            var result3 = HttpResultWithError.Fail(error, Test.CreateHttpStateA());
            var result4 = HttpResultWithError.Fail(error, Test.CreateHttpStateB());
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
            result3.GetHashCode().ShouldBe(result4.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_HttpResultWithError_is_not_equal_if_both_errors_are_not_equal()
        {
            var result1 = HttpResultWithError.Fail("abc");
            var result2 = HttpResultWithError.Fail("zzz");
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }
        
        [Fact]
        public void GetHasCode_between_ok_HttpResultWithError_and_fail_HttpResultWithError_is_not_equal()
        {
            var result1 = HttpResultWithError.Ok<string>();
            var result2 = HttpResultWithError.Fail("abc");
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }
    }
}

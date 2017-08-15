﻿using Shouldly;
using Xunit;

namespace HttpResultMonad.Tests.HttpResultWithValueAndErrorMonad.Equality
{
    public class HttpResultWithValueAndErrorGetHashCodeTests
    {
        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithValueAndError_is_equal_if_both_values_and_HttpState_are_equal()
        {
            var value = "abc";
            var httpState = Test.CreateHttpStateA();
            var result1 = HttpResult.Ok<string, string>(value);
            var result2 = HttpResult.Ok<string, string>(value);
            var result3 = HttpResult.Ok<string, string>(value, httpState);
            var result4 = HttpResult.Ok<string, string>(value, httpState);
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
            result3.GetHashCode().ShouldBe(result4.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithValueAndError_is_not_equal_if_values_are_not_equal()
        {
            var result1 = HttpResult.Ok<int, string>(1);
            var result2 = HttpResult.Ok<int, string>(2);
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }


        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithValueAndError_is_not_equal_if_HttpState_are_not_equal()
        {
            var value = 1;
            var result1 = HttpResult.Ok<int, string>(value, Test.CreateHttpStateA());
            var result2 = HttpResult.Ok<int, string>(value, Test.CreateHttpStateB());
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_ok_HttpResultWithValueAndError_is_not_equal_if_errors_are_not_of_the_same_type()
        {
            var value = 1;
            var result1 = HttpResult.Ok<int, bool>(value);
            var result2 = HttpResult.Ok<int, string>(value);
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_HttpResultWithValueAndError_is_equal_if_HttpState_and_error_are_equal()
        {
            var error = "abc";
            var httpState = Test.CreateHttpStateA();
            var result1 = HttpResult.Fail<string, string>(error);
            var result2 = HttpResult.Fail<string, string>(error);
            var result3 = HttpResult.Fail<string, string>(error, httpState);
            var result4 = HttpResult.Fail<string, string>(error, httpState);
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
            result3.GetHashCode().ShouldBe(result4.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_HttpResultWithValueAndError_is_not_equal_if_values_are_not_of_the_same_type()
        {
            var result1 = HttpResult.Fail<int, string>("error");
            var result2 = HttpResult.Fail<string, string>("error");
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_HttpResultWithValueAndError_is_not_equal_if_errors_are_not_of_the_same_type()
        {
            var result1 = HttpResult.Fail<string, int>(1);
            var result2 = HttpResult.Fail<string, string>("error");
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_ok_HttpResultWithValueAndError_and_fail_HttpResultWithValueAndError_is_not_equal()
        {
            var result1 = HttpResult.Ok<string, string>("value");
            var result2 = HttpResult.Fail<string, string>("error");
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }
    }
}

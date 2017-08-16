﻿using Shouldly;
using Xunit;

namespace HttpResultMonad.Tests.HttpResultSimpleMonad.Equality
{
    [Trait("Monad", "HttpResultWithSimple")]
    public class HttpResultSimpleEquasHttpResultSimpleTests
    {
        [Fact]
        public void Equals_between_two_ok_HttpResultSimple_is_true_if_HttpState_are_equal()
        {
            var httpState = Test.CreateHttpStateA();
            var result1 = HttpResult.Ok();
            var result2 = HttpResult.Ok();
            var result3 = HttpResult.Ok(httpState);
            var result4 = HttpResult.Ok(httpState);

            var isEqual1 = result1.Equals(result2);
            var isEqual2 = result3.Equals(result4);

            isEqual1.ShouldBeTrue();
            isEqual2.ShouldBeTrue();
        }
        
        [Fact]
        public void Equals_between_two_ok_HttpResultSimple_is_false_if_HttpState_are_not_equal()
        {
            var httpState1 = Test.CreateHttpStateA();
            var httpState2 = Test.CreateHttpStateB();
            var result1 = HttpResult.Ok(httpState1);
            var result2 = HttpResult.Ok(httpState2);

            var isEqual = result1.Equals(result2);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_two_fail_HttpResultSimple_is_true_if_HttpState_are_equal()
        {
            var httpState = Test.CreateHttpStateA();
            var result1 = HttpResult.Fail();
            var result2 = HttpResult.Fail();
            var result3 = HttpResult.Fail(httpState);
            var result4 = HttpResult.Fail(httpState);

            var isEqual1 = result1.Equals(result2);
            var isEqual2 = result3.Equals(result4);

            isEqual1.ShouldBeTrue();
            isEqual2.ShouldBeTrue();
        }

        [Fact]
        public void Equals_between_two_fail_HttpResultSimple_is_false_if_HttpState_are_not_equal()
        {
            var httpState1 = Test.CreateHttpStateA();
            var httpState2 = Test.CreateHttpStateB();
            var result1 = HttpResult.Fail(httpState1);
            var result2 = HttpResult.Fail(httpState2);

            var isEqual = result1.Equals(result2);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_ok_HttpResultSimple_and_fail_HttpResultSimple_is_false()
        {
            var result1 = HttpResult.Ok();
            var result2 = HttpResult.Fail();
            var isEqual1 = result1.Equals(result2);
            var isEqual2 = result2.Equals(result1);
            isEqual1.ShouldBeFalse();
            isEqual2.ShouldBeFalse();
        }
    }
}
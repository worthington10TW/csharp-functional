﻿using Shouldly;
using Xunit;

namespace ResultMonad.Tests.ResultSimple.Equality
{
    [Trait("Monad", "ResultSimple")]
    public class ResultSimpleGetHashCodeTests
    {
        [Fact]
        public void GetHasCode_between_two_ok_results_is_equal()
        {
            var result1 = Result.Ok();
            var result2 = Result.Ok();
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
        }

        [Fact]
        public void GetHasCode_between_two_fail_results_is_equal()
        {
            var result1 = Result.Fail();
            var result2 = Result.Fail();
            result1.GetHashCode().ShouldBe(result2.GetHashCode());
        }
        
        [Fact]
        public void GetHasCode_between_ok_result_and_fail_result_is_not_equal()
        {
            var result1 = Result.Ok();
            var result2 = Result.Fail();
            result1.GetHashCode().ShouldNotBe(result2.GetHashCode());
        }
    }
}

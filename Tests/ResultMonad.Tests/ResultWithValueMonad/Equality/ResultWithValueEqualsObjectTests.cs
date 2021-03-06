﻿using Shouldly;
using Xunit;

namespace ResultMonad.Tests.ResultWithValueMonad.Equality
{
    [Trait("Monad", "ResultWithValue")]
    public class ResultWithValueEqualsObjectTests
    {
        [Fact]
        public void Equals_betwwen_ResultWithValue_and_null_is_false()
        {
            var result = Result.Ok("value");
            var isEqual = result.Equals(null);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_ok_ResultWithValue_and_object_is_true_if_object_is_equal_to_the_value_in_ResultWithValue()
        {
            var value = "abc";
            var result = Result.Ok(value);
            object someObject = value;
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Equals_between_ok_ResultWithValue_and_object_is_false_if_object_is_not_equal_to_the_value_in_ResultWithValue()
        {
            var result = Result.Ok("abc");
            object someObject = "zzz";
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_ok_ResultWithValue_and_object_is_true_if_object_is_ok_ResultWithValue_and_both_values_are_equal()
        {
            var value = "abc";
            var result = Result.Ok(value);
            object someObject = Result.Ok(value);
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Equals_between_ok_ResultWithValue_and_object_is_false_if_object_is_ok_ResultWithValue_and_both_values_are_not_equal()
        {
            var result = Result.Ok("abc");
            object someObject = Result.Ok("zzz");
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_fail_ResultWithValue_and_object_is_true_if_object_is_fail_ResultWithValue_with_values_of_the_same_type()
        {
            var result = Result.Fail<string>();
            object someObject = Result.Fail<string>();
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Equals_between_fail_ResultWithValue_and_object_is_false_if_object_is_fail_ResultWithValue_with_values_of_different_type()
        {
            var result = Result.Fail<int>();
            object someObject = Result.Fail<string>();
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Equals_between_fail_ResultWithValue_and_object_is_false_if_object_is_not_fail_ResultWithValue()
        {
            var result = Result.Fail<string>();
            object someObject = "zzz";
            var isEqual = result.Equals(someObject);
            isEqual.ShouldBeFalse();
        }
    }
}

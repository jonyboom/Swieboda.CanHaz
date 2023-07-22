using Shouldly;

namespace Swieboda.CanHaz.Specs;

public class HazAddendsShould
{
    [Fact]
    public void Return_false_when_empty_set_input()
    {
        const int k = 17;
        var set = Array.Empty<int>();

        var hasValues = HazAddends.HasSumOfTwoValues(set, k);

        hasValues.ShouldBeFalse();
    }

    [Fact]
    public void Return_false_when_single_item_set_input()
    {
        const int k = 17;
        var set = new[] { 10 };

        var hasValues = HazAddends.HasSumOfTwoValues(set, k);

        hasValues.ShouldBeFalse();
    }

    [Fact]
    public void Return_false_when_set_does_not_contain_values()
    {
        const int k = 17;
        var set = new[] { 10, 11, 12 };

        var hasValues = HazAddends.HasSumOfTwoValues(set, k);

        hasValues.ShouldBeFalse();
    }

    [Fact]
    public void Return_true_when_set_contains_correct_values()
    {
        const int k = 17;
        var values = new[] { 10, 7 };

        var hasValues = HazAddends.HasSumOfTwoValues(values, k);

        hasValues.ShouldBeTrue();
    }

    [Fact]
    public void Return_true_when_set_contains_correct_values_with_additional()
    {
        const int k = 17;
        var values = new[] { 10, 15, 3, 7 };

        var hasValues = HazAddends.HasSumOfTwoValues(values, k);

        hasValues.ShouldBeTrue();
    }

    [Theory]
    [InlineData(new[] { 1, 2, 4, 8 }, 3)]
    [InlineData(new[] { 1, 2, 4, 8 }, 12)]
    public void Return_true_when_set_contains_correct_values_at_the_edge(int[] values, int k)
    {
        var hasValues = HazAddends.HasSumOfTwoValues(values, k);

        hasValues.ShouldBeTrue();
    }
}

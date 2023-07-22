namespace Swieboda.CanHaz;

public class HazAddends
{
    public static bool HasSumOfTwoValues(int[] values, int k)
    {
        var set = new HashSet<int>(values);

        foreach (var value in values)
        {
            var secondValue = k - value;

            if (set.Contains(secondValue))
                return true;
        }

        return false;
    }
}

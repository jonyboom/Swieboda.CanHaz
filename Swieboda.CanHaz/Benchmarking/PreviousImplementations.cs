namespace Swieboda.CanHaz.Benchmarking;

public class PreviousImplementations
{
    public static bool Impl1(int[] values, int k)
    {
        for (var i = 0; i < values.Length; i++)
        {
            for (var j = 0; j < values.Length; j++)
            {
                if (i == j) continue;
                if (values[i] + values[j] == k) return true;
            }
        }

        return false;
    }

    public static bool Impl2(int[] values, int k)
    {
        foreach (var value in values)
        {
            var secondValue = k - value;

            if (values.Contains(secondValue))
                return true;
        }

        return false;
    }

    public static bool Impl3(int[] values, int k)
    {
        var set = new HashSet<int>();

        foreach (var value in values)
        {
            var secondValue = k - value;

            if (set.Contains(secondValue))
                return true;

            set.Add(value);
        }

        return false;
    }
}
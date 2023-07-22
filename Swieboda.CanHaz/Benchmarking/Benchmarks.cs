using BenchmarkDotNet.Attributes;

namespace Swieboda.CanHaz.Benchmarking;

[MemoryDiagnoser]
public class Benchmarks
{
    private const int SetLength = 1_000_000;

    private int bestCaseScenarioK;
    private int worstCaseScenarioK;
    private int averageCaseScenarioK;
    
    private int[] values = Array.Empty<int>();

    [GlobalSetup]
    public void Setup()
    {
        const int centerIndex = SetLength / 2 - 1;

        values = Enumerable.Range(0, SetLength).Select(x => x switch
        {
            < 2 => x + SetLength * 2,
            centerIndex or centerIndex + 1 => x + SetLength * 2,
            > SetLength - 3 => x + SetLength * 2,
            _ => x
        }).ToArray();

        bestCaseScenarioK = values.Take(2).Sum(); 
        worstCaseScenarioK = values.Skip(SetLength - 2).Sum();
        averageCaseScenarioK = values.Skip(SetLength / 2 - 1).Take(2).Sum();
    }

    [Benchmark]
    public void Impl1_BestCaseScenario()
    {
        _ = PreviousImplementations.Impl1(values, bestCaseScenarioK);
    }
    
    [Benchmark]
    public void Impl1_WorstCaseScenario()
    {
        _ = PreviousImplementations.Impl1(values, worstCaseScenarioK);
    }
    
    [Benchmark]
    public void Impl1_AverageCaseScenario()
    {
        _ = PreviousImplementations.Impl1(values, averageCaseScenarioK);
    }
    
    [Benchmark]
    public void Impl2_BestCaseScenario()
    {
        _ = PreviousImplementations.Impl2(values, bestCaseScenarioK);
    }
    
    [Benchmark]
    public void Impl2_WorstCaseScenario()
    {
        _ = PreviousImplementations.Impl2(values, worstCaseScenarioK);
    }
    
    [Benchmark]
    public void Impl2_AverageCaseScenario()
    {
        _ = PreviousImplementations.Impl2(values, averageCaseScenarioK);
    }

    [Benchmark]
    public void Impl3_BestCaseScenario()
    {
        _ = PreviousImplementations.Impl3(values, bestCaseScenarioK);
    }

    [Benchmark]
    public void Impl3_WorstCaseScenario()
    {
        _ = PreviousImplementations.Impl3(values, worstCaseScenarioK);
    }

    [Benchmark]
    public void Impl3_AverageCaseScenario()
    {
        _ = PreviousImplementations.Impl3(values, averageCaseScenarioK);
    }

    [Benchmark]
    public void FinalImplementation_BestCaseScenario()
    {
        _ = HazAddends.HasSumOfTwoValues(values, bestCaseScenarioK);
    }

    [Benchmark]
    public void FinalImplementation_WorstCaseScenario()
    {
        _ = HazAddends.HasSumOfTwoValues(values, worstCaseScenarioK);
    }

    [Benchmark]
    public void FinalImplementation_AverageCaseScenario()
    {
        _ = HazAddends.HasSumOfTwoValues(values, averageCaseScenarioK);
    }
}

/*

// * Summary *

BenchmarkDotNet v0.13.6, macOS Ventura 13.4.1 (c) (22F770820d) [Darwin 22.5.0]
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2

10 items
|                                  Method |       Mean |     Error |     StdDev |     Median |   Gen0 | Allocated |
|---------------------------------------- |-----------:|----------:|-----------:|-----------:|-------:|----------:|
|                  Impl1_BestCaseScenario |   2.496 ns | 0.0330 ns |  0.0293 ns |   2.491 ns |      - |         - |
|                 Impl1_WorstCaseScenario |  65.336 ns | 1.5840 ns |  4.6704 ns |  64.879 ns |      - |         - |
|               Impl1_AverageCaseScenario |   7.739 ns | 0.1939 ns |  0.5717 ns |   7.642 ns |      - |         - |

|                  Impl2_BestCaseScenario |   8.395 ns | 0.2070 ns |  0.6104 ns |   8.625 ns |      - |         - |
|                 Impl2_WorstCaseScenario |  81.197 ns | 1.6081 ns |  2.0337 ns |  81.712 ns |      - |         - |
|               Impl2_AverageCaseScenario |  10.393 ns | 0.2301 ns |  0.3443 ns |  10.473 ns |      - |         - |

|                  Impl3_BestCaseScenario |  52.103 ns | 1.0778 ns |  3.1441 ns |  50.889 ns | 0.0200 |     168 B |
|                 Impl3_WorstCaseScenario | 254.987 ns | 4.8605 ns |  4.9913 ns | 253.937 ns | 0.0792 |     664 B |
|               Impl3_AverageCaseScenario | 131.467 ns | 3.0807 ns |  9.0835 ns | 129.797 ns | 0.0401 |     336 B |

|    FinalImplementation_BestCaseScenario | 182.072 ns | 3.7818 ns | 11.1507 ns | 183.674 ns | 0.0391 |     328 B |
|   FinalImplementation_WorstCaseScenario | 231.937 ns | 5.2244 ns | 15.4043 ns | 238.648 ns | 0.0391 |     328 B |
| FinalImplementation_AverageCaseScenario | 189.835 ns | 3.8296 ns | 10.1556 ns | 193.011 ns | 0.0391 |     328 B |


10,000 items
|                                  Method |              Mean |           Error |          StdDev |            Median |    Gen0 |    Gen1 |    Gen2 | Allocated |
|---------------------------------------- |------------------:|----------------:|----------------:|------------------:|--------:|--------:|--------:|----------:|
|                  Impl1_BestCaseScenario |          2.084 ns |       0.0661 ns |       0.0619 ns |          2.072 ns |       - |       - |       - |         - |
|                 Impl1_WorstCaseScenario | 51,220,007.806 ns | 834,068.6617 ns | 892,444.1234 ns | 51,152,244.250 ns |       - |       - |       - |     234 B |
|               Impl1_AverageCaseScenario |      5,163.343 ns |     102.8901 ns |     256.2321 ns |      5,128.368 ns |       - |       - |       - |         - |

|                  Impl2_BestCaseScenario |          8.062 ns |       0.1922 ns |       0.4220 ns |          8.109 ns |       - |       - |       - |         - |
|                 Impl2_WorstCaseScenario | 10,028,895.005 ns | 200,036.7369 ns | 557,622.4676 ns | 10,211,637.477 ns |       - |       - |       - |      15 B |
|               Impl2_AverageCaseScenario |      1,057.660 ns |      24.2108 ns |      71.3861 ns |      1,100.504 ns |       - |       - |       - |         - |

|                  Impl3_BestCaseScenario |         46.459 ns |       1.0134 ns |       2.9075 ns |         48.125 ns |  0.0200 |       - |       - |     168 B |
|                 Impl3_WorstCaseScenario |    250,598.518 ns |   5,955.9601 ns |  17,561.2827 ns |    257,638.974 ns | 95.2148 | 95.2148 | 95.2148 |  538688 B |
|               Impl3_AverageCaseScenario |    115,638.382 ns |   2,404.1391 ns |   7,088.6584 ns |    115,280.479 ns | 31.1279 | 31.1279 | 31.1279 |  258285 B |

|    FinalImplementation_BestCaseScenario |    161,827.270 ns |   3,690.3830 ns |  10,881.1776 ns |    166,055.560 ns | 38.3301 | 38.3301 | 38.3301 |  161826 B |
|   FinalImplementation_WorstCaseScenario |    233,226.641 ns |   6,341.9184 ns |  18,499.6738 ns |    233,453.737 ns | 38.3301 | 38.3301 | 38.3301 |  161826 B |
| FinalImplementation_AverageCaseScenario |    167,792.665 ns |   3,929.8451 ns |  11,587.2370 ns |    173,509.556 ns | 38.3301 | 38.3301 | 38.3301 |  161826 B |


100,000 items
|                                  Method |            Mean |         Error |         StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
|---------------------------------------- |----------------:|--------------:|---------------:|---------:|---------:|---------:|----------:|
|                  Impl3_BestCaseScenario |        42.85 ns |      0.817 ns |       0.941 ns |   0.0200 |        - |        - |     168 B |
|                 Impl3_WorstCaseScenario | 2,747,579.39 ns | 54,161.107 ns | 125,526.601 ns | 550.7813 | 523.4375 | 523.4375 | 4830691 B |
|               Impl3_AverageCaseScenario | 1,124,813.59 ns | 21,135.330 ns |  19,770.001 ns | 527.3438 | 505.8594 | 500.0000 | 2327637 B |

|    FinalImplementation_BestCaseScenario | 1,560,741.41 ns | 29,445.062 ns |  43,160.190 ns | 498.0469 | 498.0469 | 498.0469 | 1738585 B |
|   FinalImplementation_WorstCaseScenario | 2,092,830.45 ns | 40,153.404 ns |  47,799.771 ns | 496.0938 | 496.0938 | 496.0938 | 1738585 B |
| FinalImplementation_AverageCaseScenario | 1,634,639.06 ns | 31,651.339 ns |  43,324.711 ns | 498.0469 | 498.0469 | 498.0469 | 1738585 B |


1,000,000 items
|                                  Method |             Mean |          Error |           StdDev |     Gen0 |     Gen1 |     Gen2 |  Allocated |
|---------------------------------------- |-----------------:|---------------:|-----------------:|---------:|---------:|---------:|-----------:|
|                  Impl3_BestCaseScenario |         43.02 ns |       0.741 ns |         0.853 ns |   0.0200 |        - |        - |      168 B |
|                 Impl3_WorstCaseScenario | 27,811,202.71 ns | 552,505.199 ns | 1,302,319.757 ns | 906.2500 | 906.2500 | 906.2500 | 43111741 B |
|               Impl3_AverageCaseScenario | 10,661,872.93 ns | 210,684.295 ns |   363,420.057 ns | 625.0000 | 609.3750 | 609.3750 | 20787267 B |

|    FinalImplementation_BestCaseScenario | 11,950,929.22 ns | 226,431.864 ns |   269,551.026 ns | 515.6250 | 515.6250 | 515.6250 | 18605644 B |
|   FinalImplementation_WorstCaseScenario | 17,524,874.82 ns | 346,269.023 ns |   384,877.101 ns | 500.0000 | 500.0000 | 500.0000 | 18605522 B |
| FinalImplementation_AverageCaseScenario | 12,018,736.58 ns | 239,636.202 ns |   413,360.675 ns | 468.7500 | 468.7500 | 468.7500 | 18605233 B |

*/

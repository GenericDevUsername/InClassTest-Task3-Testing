namespace InClassTest_Task3_Tests.Problems;
using InClassTest_Task3.Problems;

public static class Problem1Tests
{
    [Test]
    public static void Test_That_SumNumbersOf_Returns_23_For_3_And_5_Below_10()
    {
        Assert.That(Problem1.SumNumbersOf([3, 5], 10), Is.EqualTo(23));
    }
    
    [Test]
    public static void Test_That_SumNumbersOf_Returns_233168_For_3_And_5_Below_1000()
    {
        Assert.That(Problem1.SumNumbersOf([3, 5]), Is.EqualTo(233168));
    }
    
    // random test
    [TestCaseSource(nameof(GetRandomNumbers))]
    [TestCaseSource(nameof(GetSmallNumbers))]
    public static void Test_That_SumNumbersOf_DoesNotThrowExceptionForRandomNumbers(int[] numbers, int to)
    {
        Assert.DoesNotThrow(() => Problem1.SumNumbersOf(numbers, to));
    }
    
    private static IEnumerable<TestCaseData> GetSmallNumbers()
    {
        int[] numbers = {3, 5};
        for (int i = 0; i < 10; i++)
        {
            yield return new TestCaseData(numbers, i).SetArgDisplayNames("Small Numbers", $"{i}");
        }
    }
    private static IEnumerable<TestCaseData> GetRandomNumbers()
    {
        for (int i = 0; i < 100; i++)
        {
            // random list length
            int length = new Random().Next(1, 10);
            // random list
            int[] numbers = Enumerable.Range(1, length).Select(_ => new Random().Next(1, 10)).ToArray();
            // random to
            int to = new Random().Next(1, 100000);
            yield return new TestCaseData(numbers, to).SetArgDisplayNames("Random Numbers", $"{i}");
        }
    }
}
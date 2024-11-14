using InClassTest_Task3.Problems;

namespace InClassTest_Task3_Tests.Problems;

public static class Problem2Tests
{
    [Test]
    public static void Test_That_FindSmallestDivisibleBy_Returns_2520_For_Numbers_From_1_To_10()
    {
        Assert.That(Problem2.FindSmallestDivisibleBy(Enumerable.Range(1, 10).ToArray()), Is.EqualTo(2520));
    }
    
    [Test]
    public static void Test_That_FindSmallestDivisibleBy_Returns_232792560_For_Numbers_From_1_To_20()
    {
        Assert.That(Problem2.FindSmallestDivisibleBy(Enumerable.Range(1, 20).ToArray()), Is.EqualTo(232792560));
    }
    
    // random test
    [TestCaseSource(nameof(GetRandomNumbers))]
    public static void Test_That_FindSmallestDivisibleBy_CanHandleOtherRangesOfNumbers(int[] numbers)
    {
        Assert.DoesNotThrow(() => Problem2.FindSmallestDivisibleBy(numbers));
    }
    
    private static IEnumerable<TestCaseData> GetRandomNumbers()
    {
        for (int i = 0; i < 100; i++)
        {
            // random list length
            int length = new Random().Next(1, 10);
            // random list
            int[] numbers = Enumerable.Range(1, length).Select(_ => new Random().Next(1, 10)).ToArray();
            yield return new TestCaseData(numbers).SetArgDisplayNames("Random Numbers", $"{i}");
        }
    }
    
    
}

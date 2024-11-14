using InClassTest_Task3.Problems;

namespace InClassTest_Task3_Tests.Problems;

public static class Problem3Tests
{
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_25164150_For_First_100_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(), Is.EqualTo(25164150));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_0_For_First_1_Natural_Number()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(1), Is.EqualTo(0));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_4_For_First_2_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(2), Is.EqualTo(4));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_22_For_First_3_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(3), Is.EqualTo(22));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_70_For_First_4_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(4), Is.EqualTo(70));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_170_For_First_5_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(5), Is.EqualTo(170));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_350_For_First_6_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(6), Is.EqualTo(350));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_644_For_First_7_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(7), Is.EqualTo(644));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_1092_For_First_8_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(8), Is.EqualTo(1092));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_1740_For_First_9_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(9), Is.EqualTo(1740));
    }
    
    [Test]
    public static void Test_That_FindDifferenceOfSumOfSquaresAndSquareOfSum_Returns_2640_For_First_10_Natural_Numbers()
    {
        Assert.That(Problem3.FindDifferenceOfSumOfSquaresAndSquareOfSum(10), Is.EqualTo(2640));
    }
}
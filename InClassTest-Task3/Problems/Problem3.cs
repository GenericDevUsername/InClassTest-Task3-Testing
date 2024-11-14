namespace InClassTest_Task3.Problems;

public static class Problem3
{
    public static void Run()
    {
        Console.WriteLine("Problem 3");
        
        Console.WriteLine("The difference between the sum of the squares of the first 100 natural numbers and the square of the sum is: "
                          + FindDifferenceOfSumOfSquaresAndSquareOfSum());
        
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine($"The difference between the sum of the squares of the first {i} natural numbers and the square of the sum is: "
                              + FindDifferenceOfSumOfSquaresAndSquareOfSum(i));
        }
    }
    
    /// <summary>
    ///   find the difference between the sum of the squares of the first x natural numbers and the square of the sum.
    /// </summary>
    /// <returns></returns>
    public static int FindDifferenceOfSumOfSquaresAndSquareOfSum(int first = 100)
    {
        int sumOfSquares = 0;
        int squareOfSum = 0;
        for (int i = 1; i <= first; i++)
        {
            sumOfSquares += i * i;
            squareOfSum += i;
        }
        squareOfSum *= squareOfSum;
        return squareOfSum - sumOfSquares;
    }
    
}
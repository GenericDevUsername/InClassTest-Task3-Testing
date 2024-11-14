namespace InClassTest_Task3.Problems;

public static class Problem1
{
    public static void Run()
    {
        Console.WriteLine("Problem 1");
        Console.WriteLine("The sum of all the natural numbers below 1000 that are multiples of 3 or 5 is: "
                          + SumNumbersOf([3, 5]));
    }
    
    /// <summary>
    ///  find the sum of all the natural numbers below 1000 that are multiples of numbers[].
    /// </summary>
    /// <param name="numbers"> an array of numbers to find the sum of their multiples </param>
    /// <param name="to"> the number to find the multiples of the numbers[] below it </param>
    /// <returns> the sum of all the natural numbers below to that are multiples of numbers[] </returns>
    public static int SumNumbersOf(int[] numbers, int to = 1000)
    {
        int sum = 0;
        for (int i = 0; i < to; i++)
        {
            if (numbers.Any(n => i % n == 0))
            {
                sum += i;
            }
        }
        return sum;
    }
    
}
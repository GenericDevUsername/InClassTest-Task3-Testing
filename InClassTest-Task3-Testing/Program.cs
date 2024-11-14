namespace InClassTest_Task3_Testing;
using Problems;
using UI;

internal static class Program
{
    private static void Main(string[] args)
    {
        (string, string)[] problems = new[]
        {
            ("Problem 1", "InClassTest_Task3_Testing.Problems.Problem1"),
            ("Problem 2", "InClassTest_Task3_Testing.Problems.Problem2"),
            ("Problem 3", "InClassTest_Task3_Testing.Problems.Problem3")
        };
        string projectToRun = Ui.SelectMenu("Select a problem to run\n===============", problems);
        switch (projectToRun)
        {
            case "InClassTest_Task3_Testing.Problems.Problem1":
                Problem1.Run();
                break;
            case "InClassTest_Task3_Testing.Problems.Problem2":
                Problem2.Run();
                break;
            case "InClassTest_Task3_Testing.Problems.Problem3":
                Problem3.Run();
                break;
        }
    }
}
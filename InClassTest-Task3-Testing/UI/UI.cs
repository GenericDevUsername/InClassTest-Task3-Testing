using System.Text;

namespace InClassTest_Task3_Testing.UI;

public static class Ui
{
    /// <summary>
    ///  Display a menu and get the user's selection
    /// </summary>
    /// <param name="prompt"> The prompt to display to the user </param>
    /// <param name="options"> The options to display to the user </param>
    /// <returns></returns>
    public static string SelectMenu(string prompt, string[] options)
    {
        // Display the prompt and options. select with arrow keys and enter
        Console.CursorVisible = false;
        int selected = 0;
        Console.Clear();
        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(i == selected ? "\x1b[107;30m" : "");
                Console.WriteLine(options[i]);
                Console.Write(i == selected ? "\x1b[0m" : "");
            }

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selected = Math.Max(0, selected - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selected = Math.Min(options.Length - 1, selected + 1);
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return options[selected];
            }
        }
    }
    /// <summary>
    ///  Display a menu and get the user's selection
    /// </summary>
    /// <param name="prompt"> The prompt to display to the user </param>
    /// <param name="options"> The options to display to the user </param>
    /// <returns></returns>
    public static string SelectMenu(string prompt, (string display, string value)[] options)
    {
        // Display the prompt and options. select with arrow keys and enter
        Console.CursorVisible = false;
        int selected = 0;
        Console.Clear();
        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(i == selected ? "\x1b[107;30m" : "");
                Console.WriteLine(options[i].display);
                Console.Write(i == selected ? "\x1b[0m" : "");
            }

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selected = Math.Max(0, selected - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selected = Math.Min(options.Length - 1, selected + 1);
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return options[selected].value;
            }
        }
    }

    /// <summary>
    ///  Get an integer input from the user
    /// </summary>
    /// <param name="prompt"> The prompt to display to the user </param>
    /// <param name="validators"> A list of validation functions to run on the input </param>
    /// <returns></returns>
    public static int GetInt(string prompt, (Func<string, bool> validator, string errorMessage)[]? validators)
    {
        // Display the prompt and get an integer input
        Console.Clear();
        Console.WriteLine(prompt);
        Console.Write("> ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (validators != null)
                {
                    bool valid = true;
                    foreach ((Func<string, bool> validator, string errorMessage) in validators)
                    {
                        if (validator(result.ToString())) continue;
                        Console.WriteLine(errorMessage);
                        valid = false;
                        break;
                    }

                    if (!valid) continue;
                    return result;
                }
            }
            Console.WriteLine("Please enter a valid number");
        }
    }
    
    /// <summary>
    ///  Get a string input from the user
    /// </summary>
    /// <param name="prompt"> The prompt to display to the user </param>
    /// <param name="validators"> A list of validation functions to run on the input </param>
    /// <returns></returns>
    public static string GetString(string prompt, (Func<string, bool> validator, string errorMessage)[]? validators)
    {
        // Display the prompt and get a string input
        Console.Clear();
        Console.WriteLine(prompt);
        Console.Write("> ");
        while (true)
        {
            // run each validator on the input
            string result = Console.ReadLine() ?? String.Empty;
            if (validators != null)
            {
                bool valid = true;
                foreach ((Func<string, bool> validator, string errorMessage) in validators)
                {
                    if (validator(result)) continue;
                    Console.WriteLine(errorMessage);
                    valid = false;
                    break;
                }

                if (!valid) continue;
                return result;
            }
            return result;
        }
    }

    /// <summary>
    ///  Get multiple inputs from the user as a form
    /// </summary>
    /// <param name="fields"></param>
    /// <returns></returns>
    public static object[] Form((Type type, string prompt, bool required, (Func<string, object[], bool> validator, string errorMessage)[]? validators)[] fields)
    {
        // Display the prompts and get input for each one
        Console.Clear();
        object[] answers = new object[fields.Length];
        for (int i = 0; i < fields.Length; i++)
        {
            // print progress bar
            Console.Clear();
            // --[X]--[ ]--[ ]--
            // [X] = current prompt
            // [ ] = remaining prompts
            // [#] = completed prompts
            StringBuilder progressBar = new();
            progressBar.Append("--");
            for (int j = 0; j < fields.Length; j++)
            {
                progressBar.Append(j == i ? "[X]" : j < i ? "[#]" : "[ ]");
                progressBar.Append("--");
            }

            Console.WriteLine(progressBar);
            Console.WriteLine(fields[i].prompt);
            bool accepted = false;
            while (!accepted)
            {
                // try to get input for the current field
                Console.Write("> ");
                string answer = Console.ReadLine() ?? String.Empty;
                
                // validate the input
                if (fields[i].required && string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("This field is required");
                }
                else if (fields[i].type == typeof(int) && !int.TryParse(answer, out _))
                {
                    Console.WriteLine("This field must be a number");
                }
                else if (fields[i].type == typeof(float) && !float.TryParse(answer, out _))
                {
                    Console.WriteLine("This field must be a number");
                }
                else if (fields[i].type == typeof(double) && !double.TryParse(answer, out _))
                {
                    Console.WriteLine("This field must be a number");
                }
                else if (fields[i].type == typeof(decimal) && !decimal.TryParse(answer, out _))
                {
                    Console.WriteLine("This field must be a number");
                }
                else if (fields[i].type == typeof(bool) && !bool.TryParse(answer, out _))
                {
                    Console.WriteLine("This field must be a boolean");
                }
                else
                {
                    (Func<string, object[], bool> validator, string errorMessage)[]? valueTuples = fields[i]
                        .validators;
                    if (fields[i].validators != null)
                    {
                        bool valid = true;
                        if (valueTuples != null)
                            foreach ((Func<string, object[], bool> validator, string errorMessage) in valueTuples)
                            {
                                Console.WriteLine("Validating");
                                if (validator(answer, answers)) continue;
                                Console.WriteLine(errorMessage);
                                valid = false;
                                break;
                            }

                        if (!valid) continue;
                        answers[i] = Convert.ChangeType(answer, fields[i].type);
                        accepted = true;
                    }
                    else
                    {
                        // record the answer and move to the next field
                        answers[i] = Convert.ChangeType(answer, fields[i].type);
                        accepted = true;
                    }
                }
            }
        }
        // return the answers
        return answers;
    }
}
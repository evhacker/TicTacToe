namespace TicTacToe;

public static class UIMethods
{
    /// <summary>
    /// Displays welcome message
    /// </summary>
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Hello, this is a little TicTacToe Game!");
    }

    /// <summary>
    /// Prints array to Console
    /// </summary>
    /// <param name="array">array to be printed</param>
    public static void PrintArray(string[,] array)
    {
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                Console.Write(array[row, col]);
                if (col < array.GetLength(1) - 1)
                {
                    Console.Write("|");
                }
            }

            Console.Write("\n");
            if (row < array.GetLength(0) - 1)
            {
                Console.Write(string.Concat(Enumerable.Repeat("- ", array.GetLength(0))));
            }

            Console.Write("\n");
        }
    }

    /// <summary>
    /// Displays question to user
    /// </summary>
    /// <param name="question">Question to display to user</param>
    public static void DisplayQuestion(string question)
    {
        Console.WriteLine(question);
    }

    /// <summary>
    /// Gets user input (user chooses row/col)
    /// </summary>
    /// <param name="question">Question to be printed to console</param>
    /// <returns>row/col chosen by the user</returns>
    public static int GetUserInput()
    {
        int inputUser = 0;
        while (true)
        {
            bool success = int.TryParse(Console.ReadLine(), out inputUser);
            if (success && inputUser < 4 && inputUser > 0)
            {
                return inputUser;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again!");
            }
        }
    }

    /// <summary>
    /// Display message when field is already taken
    /// </summary>
    public static void DisplayMessageTaken()
    {
        Console.WriteLine("This field is already taken, choose another one!");
    }

    /// <summary>
    /// Display message user wins
    /// </summary>
    public static void DisplayUserWin()
    {
        Console.WriteLine("You win!");
    }

    /// <summary>
    /// Display message Computer wins
    /// </summary>
    public static void DisplayAIWin()
    {
        Console.WriteLine("Computer wins!");
    }

    /// <summary>
    /// Display end of game if tie
    /// </summary>
    public static void DisplayTie()
    {
        Console.WriteLine("Tie! Game ends...");
    }
}
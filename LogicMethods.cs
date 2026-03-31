namespace TicTacToe;

public static class LogicMethods
{
    /// <summary>
    /// Checks if field chosen by the user is still available
    /// </summary>
    /// <param name="userRow">row chosen by user</param>
    /// <param name="userCol">column chosen by user</param>
    /// <param name="array">array to be checked</param>
    /// <returns>true or false</returns>
    public static bool CheckUserInput(int userRow, int userCol, string[,] array)
    {
        if (array[userRow - 1, userCol - 1] == " ")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// generates random AI input and checks if field still available
    /// </summary>
    /// <param name="array">array to fill and check</param>
    /// <param name="rng">random number</param>
    /// <param name="symbol">AI symbol to put</param>
    /// <returns>array filled with AI input</returns>
    public static string[,] GetAIInput(string[,] array, Random rng, string symbol)
    {
        while (true)
        {
            int AIRow = rng.Next(0, array.GetLength(0));
            int AICol = rng.Next(0, array.GetLength(1));

            if (array[AIRow, AICol] == " ")
            {
                array[AIRow, AICol] = symbol;
                break;
            }
        }

        return array;
    }

    /// <summary>
    /// Checks if symbol wins
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="symbol">symbol to check</param>
    /// <returns>true or false</returns>
    public static bool CheckIfWin(string[,] array, string symbol)
    {
        bool win = false;
        //check all horizontal lines
        for (int row = 0; row < array.GetLength(0); row++)
        {
            if (array[row, 0] == symbol && array[row, 1] == symbol && array[row, 2] == symbol)
            {
                win = true;
            }
        }

        //check all vertical lines
        for (int col = 0; col < array.GetLength(1); col++)
        {
            if (array[0, col] == symbol && array[1, col] == symbol && array[2, col] == symbol)
            {
                win = true;
            }
        }

        //check diagonal 1
        if (array[0, 0] == symbol && array[1, 1] == symbol && array[2, 2] == symbol)
        {
            win = true;
        }

        //check diagonal 2
        if (array[0, 2] == symbol && array[1, 1] == symbol && array[2, 0] == symbol)
        {
            win = true;
        }

        return win;
    }

    /// <summary>
    /// Checks if there is at least one empty field in array
    /// </summary>
    /// <param name="array">array to check</param>
    /// <returns>true or false</returns>
    public static bool CheckIfEmptyField(string[,] array)
    {
        bool empty = false;
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                if (array[row, col] == " ")
                {
                    empty = true;
                }
            }
        }
        return empty;
    }
}
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
        //check all horizontal lines
        bool winHorizontal = CheckAllHorizontalLines(array, symbol);
        
        //check all vertical lines
        bool winVertical = CheckAllVerticalLines(array, symbol);

        //check diagonals
        bool winDiagonal = CheckAllDiagonalLines(array, symbol);
        
        bool win = false;
        if (winHorizontal || winVertical || winDiagonal)
        {
            win = true;
        }

        return win;
    }

    /// <summary>
    /// Checks all horizontal Lines for wins
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="symbol">symbol to check</param>
    /// <returns></returns>
    public static bool CheckAllHorizontalLines(string[,] array, string symbol)
    {
        bool win = false;
        for (int row = 0; row < array.GetLength(0); row++)
        {
            bool boolWinRow = true;
            for (int col = 1; col < array.GetLength(1); col++)
            {
                if (array[row, col] != array[row, col - 1])
                {
                    boolWinRow = false;
                }

                if (array[row, col] != symbol)
                {
                    boolWinRow = false;
                }
            }

            if (boolWinRow)
            {
                win = true;
            }
        }

        return win;
    }

    /// <summary>
    /// Checks all vertical Lines for wins
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="symbol">symbol to check</param>
    /// <returns></returns>
    public static bool CheckAllVerticalLines(string[,] array, string symbol)
    {
        bool win = false;
        for (int col = 0; col < array.GetLength(1); col++)
        {
            bool boolWinCol = true;
            for (int row = 1; row < array.GetLength(0); row++)
            {
                if (array[row, col] != array[row - 1, col])
                {
                    boolWinCol = false;
                }

                if (array[row, col] != symbol)
                {
                    boolWinCol = false;
                }
            }

            if (boolWinCol)
            {
                win = true;
            }
        }

        return win;
    }


    /// <summary>
    /// Checks both diagonals of an array for wins
    /// </summary>
    /// <param name="array">array to check</param>
    /// <param name="symbol">symbol to check</param>
    /// <returns></returns>
    public static bool CheckAllDiagonalLines(string[,] array, string symbol)
    {
        bool win = false;
        //Diagonal 1
        bool boolWinDiag = true;
        int row = 1;
        for (int col = 1; col < array.GetLength(1); col++)
        {
            if (array[row, col] != array[row - 1, col - 1])
            {
                boolWinDiag = false;
            }

            if (array[row, col] != symbol)
            {
                boolWinDiag = false;
            }

            row++;
        }

        if (boolWinDiag)
        {
            win = true;
        }

        //Diagonal 2
        boolWinDiag = true;
        row = 1;
        for (int col = array.GetLength(1) - 2; col >= 0; col--)
        {
            if (array[row, col] != array[row - 1, col + 1])
            {
                boolWinDiag = false;
            }

            if (array[row, col] != symbol)
            {
                boolWinDiag = false;
            }

            row++;
        }

        if (boolWinDiag)
        {
            win = true;
        }

        return win;
    }


    /// <summary>
    /// Checks if there is at least one empty field in array
    /// /// </summary>
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
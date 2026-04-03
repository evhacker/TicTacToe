namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        //initialize array

        string[,] array = new string[Constants.DIM, Constants.DIM];
        //populate array
        for (int row = 0; row < Constants.DIM; row++)
        {
            for (int col = 0; col < Constants.DIM; col++)
            {
                array[row, col] = " ";
            }
        }

        UIMethods.DisplayWelcomeMessage();
        UIMethods.PrintArray(array);

        int rowUser = 0;
        int colUser = 0;

        bool winAI = false;
        bool winUser = false;

        bool emptyFields = true;

        while (winUser == false && winAI == false)
        {
            while (true) //input validation
            {
                UIMethods.DisplayQuestion("Please choose a row - 1,2 or 3 and press Enter");
                rowUser = UIMethods.GetUserInput();
                UIMethods.DisplayQuestion("Please choose a column - 1,2 or 3 and press Enter");
                colUser = UIMethods.GetUserInput();

                bool userInputSlotIsAvailable = LogicMethods.CheckIfSlotIsAvailable(rowUser, colUser, array);
                if (userInputSlotIsAvailable)
                {
                    break;
                }
                else
                {
                    UIMethods.DisplayMessageTaken();
                }
            }


            //Update Array User Input
            array[rowUser - 1, colUser - 1] = Constants.SYMBOL_USER;
            UIMethods.PrintArray(array);

            //Check if win
            winUser = LogicMethods.CheckIfWin(array, Constants.SYMBOL_USER);
            if (winUser)
            {
                UIMethods.DisplayUserWin();
                break;
            }

            //Check if still empty fields
            emptyFields = LogicMethods.CheckIfEmptyField(array);
            if (emptyFields == false)
            {
                break;
            }

            //Update Array AI Input
            array = LogicMethods.GetAIInput(array);
            UIMethods.PrintArray(array);

            winAI = LogicMethods.CheckIfWin(array, Constants.SYMBOL_AI);
            if (winAI)
            {
                UIMethods.DisplayAIWin();
            }
        }

        if (winUser == false && winAI == false)
        {
            UIMethods.DisplayTie();
        }
    }
}
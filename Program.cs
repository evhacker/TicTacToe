namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        const int DIM = 3;
        const string SYMBOL_USER = "X";
        const string SYMBOL_AI = "O";

        //initialize array

        string[,] array = new string[DIM, DIM];
        //populate array
        for (int row = 0; row < DIM; row++)
        {
            for (int col = 0; col < DIM; col++)
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

                bool userInputValid = LogicMethods.CheckIfSlotIsAvailable(rowUser, colUser, array);
                if (userInputValid)
                {
                    break;
                }
                else
                {
                    UIMethods.DisplayMessageTaken();
                }
            }


            //Update Array User Input
            array[rowUser - 1, colUser - 1] = SYMBOL_USER;
            UIMethods.PrintArray(array);

            //Check if win
            winUser = LogicMethods.CheckIfWin(array, SYMBOL_USER);
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
            array = LogicMethods.GetAIInput(array, SYMBOL_AI);
            UIMethods.PrintArray(array);

            winAI = LogicMethods.CheckIfWin(array, SYMBOL_AI);
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
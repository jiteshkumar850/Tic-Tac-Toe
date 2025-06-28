using System;

class TicTacToe
{
    static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int choice;
    static int flag = 0;

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("TIC TAC TOE GAME");
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine();

            Board();

            Console.Write("Player {0}, enter a number (1-9): ", player);
            bool validInput = int.TryParse(Console.ReadLine(), out choice);

            if (!validInput || choice < 1 || choice > 9)
            {
                Console.WriteLine("Invalid input! Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            if (board[choice] != 'X' && board[choice] != 'O')
            {
                board[choice] = (player % 2 == 1) ? 'X' : 'O';
                player++;
            }
            else
            {
                Console.WriteLine("Cell already taken! Press Enter to try again.");
                Console.ReadLine();
            }

            flag = CheckWin();
        } while (flag != 1 && flag != -1);

        Console.Clear();
        Board();

        if (flag == 1)
            Console.WriteLine("==> Player {0} wins!", (player % 2) + 1);
        else
            Console.WriteLine("==> Draw!");

        Console.ReadLine();
    }

    static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
        Console.WriteLine("     |     |      ");
    }

    static int CheckWin()
    {
        // Winning combinations
        int[,] winCombos = new int[,]
        {
            {1, 2, 3}, {4, 5, 6}, {7, 8, 9},
            {1, 4, 7}, {2, 5, 8}, {3, 6, 9},
            {1, 5, 9}, {3, 5, 7}
        };

        for (int i = 0; i < 8; i++)
        {
            int a = winCombos[i, 0];
            int b = winCombos[i, 1];
            int c = winCombos[i, 2];

            if (board[a] == board[b] && board[b] == board[c])
                return 1;
        }

        // Check for draw
        for (int i = 1; i <= 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
                return 0;
        }

        return -1;
    }
}

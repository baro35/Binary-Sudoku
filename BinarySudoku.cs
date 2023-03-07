using System;
using System.IO;

namespace Project_AB
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = File.Exists("HighScoreTable.txt");
            Console.Title = "Binary Sudoku";
            if (flag == false)
            {
                StreamWriter f = File.CreateText("HighScoreTable.txt");
                f.WriteLine("Gökay;19846");
                f.WriteLine("Yüksel;1653");
                f.WriteLine("Mehmet;856");
                f.WriteLine("Ahmet;653");
                f.WriteLine("Fuat;594");
                f.WriteLine("Merve;567");
                f.WriteLine("Nadirhan;435");
                f.WriteLine("Cemre;271");
                f.WriteLine("Baran;257");
                f.Write("Emir;135");
                f.Close();
            }
            do
            {
                Console.Clear();
                int cx = 4, cy = 5;
                ConsoleKeyInfo cki;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|------------------------|");
                Console.WriteLine("|                        |");
                Console.WriteLine("|      BINARY SUDOKU     |");
                Console.WriteLine("|        MAIN MENU       |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|        Play Game       |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|       Intructions      |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|     High Score Table   |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|           Exit         |");
                Console.WriteLine("|                        |");
                Console.WriteLine("|------------------------|");
                while (true)
                {
                    if (cy == 5)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(9, 5);
                    Console.WriteLine("Play Game      ");
                    if (cy == 7)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(8, 7);
                    Console.WriteLine("Intructions     ");
                    if (cy == 9)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(6, 9);
                    Console.WriteLine("High Score Table  ");
                    if (cy == 11)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(12, 11);
                    Console.WriteLine("Exit        ");
                    Console.SetCursorPosition(cx, cy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(">");
                    Console.SetCursorPosition(cx + 19, cy);
                    Console.Write("<");

                    Console.SetWindowSize(26, 14);
                    Console.SetCursorPosition(cx, cy);
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.UpArrow && cy > 5) cy -= 2;
                    if (cki.Key == ConsoleKey.DownArrow && cy < 11) cy += 2;
                    if (cki.Key == ConsoleKey.Enter) break;
                }
                if (cy == 5)
                {
                    Console.Clear();
                    Console.SetWindowSize(85, 23);
                    //STATIC SCREEN 
                    Console.WriteLine("  1 2 3 4 5 6 7 8 9      New Piece         Score : ");
                    Console.WriteLine(" +-----+-----+-----+");
                    Console.WriteLine("1|     |     |     |                    Piece No : ");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("2|     |     |     |");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("3|     |     |     |");
                    Console.WriteLine(" +-----+-----+-----+");
                    Console.WriteLine("4|     |     |     |");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("5|     |     |     |");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("6|     |     |     |");
                    Console.WriteLine(" +-----+-----+-----+");
                    Console.WriteLine("7|     |     |     |");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("8|     |     |     |");
                    Console.WriteLine(" |     |     |     |");
                    Console.WriteLine("9|     |     |     |");
                    Console.WriteLine(" +-----+-----+-----+");

                    //VARIABLES
                    int cursorx = 2, cursory = 2;
                    Console.SetCursorPosition(cursorx, cursory);
                    int[,] board = new int[9, 9];
                    int[,] newpiece = new int[3, 3];
                    Random rnd = new Random();
                    int newpiecerandom = rnd.Next(1, 11);
                    int piececontrol = 1;
                    int piecenumber = 0;
                    int[,] to_delete = new int[2, 9];
                    int score = 0;
                    int point = 0;
                    int a = 0;
                    int b = 0;
                    int completedNumber = 0;

                    //PRINT BOARD
                    for (int y = 0; y < 9; y++)
                    {
                        for (int x = 0; x < 9; x++)
                        {
                            board[y, x] = -1;
                        }
                    }

                    //GAME LOOP
                    Console.SetCursorPosition(cursorx, cursory);
                    while (true)
                    {
                        //PRINT BOARD
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int y = 0; y < 9; y++)
                        {
                            for (int x = 0; x < 9; x++)
                            {
                                Console.SetCursorPosition(2 * x + 2, 2 * y + 2);
                                if (board[y, x] == -1) Console.Write(".");
                                else Console.Write(board[y, x]);
                            }
                        }
                        //PIECE INIT
                        if (piececontrol == 1)
                        {
                            cursorx = 10;
                            cursory = 10;
                            for (int y = 0; y < 3; y++)
                                for (int x = 0; x < 3; x++)
                                    newpiece[y, x] = -1;
                            newpiecerandom = rnd.Next(1, 11);
                            switch (newpiecerandom)
                            {
                                case 1:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    break;
                                case 2:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    break;
                                case 3:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    break;
                                case 4:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    newpiece[0, 2] = rnd.Next(0, 2);
                                    break;
                                case 5:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    newpiece[2, 0] = rnd.Next(0, 2);
                                    break;
                                case 6:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    break;
                                case 7:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    newpiece[1, 1] = rnd.Next(0, 2);
                                    break;
                                case 8:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    newpiece[1, 1] = rnd.Next(0, 2);
                                    break;
                                case 9:
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    newpiece[1, 1] = rnd.Next(0, 2);
                                    break;
                                case 10:
                                    newpiece[0, 0] = rnd.Next(0, 2);
                                    newpiece[0, 1] = rnd.Next(0, 2);
                                    newpiece[1, 0] = rnd.Next(0, 2);
                                    newpiece[1, 1] = rnd.Next(0, 2);
                                    break;
                            }
                            piecenumber++;
                            piececontrol = 0;
                        }
                        Console.SetCursorPosition(51, 2);
                        Console.Write(piecenumber);
                        Console.SetCursorPosition(51, 0);
                        Console.Write(score);


                        //PRINT CURRENT PIECE ON SCREEN
                        for (int y = 0; y < 3; y++)
                        {
                            Console.SetCursorPosition(25, 2 + 2 * y);
                            for (int x = 0; x < 3; x++)
                            {
                                if (newpiece[y, x] != -1) Console.Write(newpiece[y, x] + " ");
                                else Console.Write("  ");
                            }
                        }

                        //END OF THE GAME
                        bool gameover = true;
                        for (int y = 0; y < 9; y++)
                        {
                            for (int x = 0; x < 9; x++)
                            {
                                int control2 = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        if (newpiece[i, j] != -1)
                                        {
                                            if (((y + i >= 9) || (x + j >= 9)) || (board[y + i, x + j] != -1)) control2++;
                                        }
                                    }
                                }
                                if (control2 == 0)
                                {
                                    gameover = false;
                                    break;
                                }
                                else if (control2 != 0)
                                {
                                    gameover = true;
                                }
                                if (gameover == false) break;
                            }
                            if (gameover == false) break;
                        }
                        if (gameover == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(35, 6);
                            Console.WriteLine("Game Over!!!");
                            break;
                        }

                        //DISPLAY PIECE ON THE BOARD
                        for (int y = 0; y < 3; y++)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                if (newpiece[y, x] != -1)
                                {
                                    Console.SetCursorPosition(cursorx + 2 * x, cursory + 2 * y);
                                    if (cursorx + 2 * x < 20 && cursory + 2 * y < 20)
                                    {
                                        if (board[(cursory - 2) / 2 + y, (cursorx - 2) / 2 + x] == -1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write(newpiece[y, x]);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                        }
                                    }
                                }
                            }
                        }

                        Console.SetCursorPosition(cursorx, cursory);
                        //SET CURSOR
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.RightArrow && (((newpiece[0, 1] == -1 && newpiece[1, 1] == -1) && cursorx < 17) || (newpiece[0, 2] == -1 && cursorx < 15) || (cursorx < 13))) cursorx += 2;
                        if (cki.Key == ConsoleKey.LeftArrow && cursorx > 2) cursorx -= 2;
                        if (cki.Key == ConsoleKey.UpArrow && cursory > 2) cursory -= 2;
                        if (cki.Key == ConsoleKey.DownArrow && (((newpiece[1, 0] == -1 && newpiece[1, 1] == -1) && cursory < 17) || (newpiece[2, 0] == -1 && cursory < 15) || (cursory < 13))) cursory += 2;
                        if (cki.Key == ConsoleKey.Escape) break;

                        //PRINT PIECE ON THE BOARD
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            int control = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (newpiece[i, j] != -1)
                                    {
                                        if (board[(cursory - 2) / 2 + i, (cursorx - 2) / 2 + j] != -1) control++;
                                    }
                                }
                            }
                            if (control == 0)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        if (newpiece[i, j] != -1)
                                        {
                                            board[(cursory - 2) / 2 + i, (cursorx - 2) / 2 + j] = newpiece[i, j];
                                        }
                                    }
                                }
                                piececontrol = 1;
                            }
                        }

                        //DISPLAY THE CALCULATIONS
                        if (completedNumber == 0)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                Console.SetCursorPosition(34, 7 + i);
                                Console.Write("                                             ");
                            }
                        }

                        //SCORE CALCULATION
                        int stepScore = 0;
                        completedNumber = 0;
                        int stepTotal = 0;
                        for (int y = 0; y < 2; y++)
                        {
                            for (int x = 0; x < 9; x++)
                            {
                                to_delete[y, x] = -1;
                            }
                        }
                        //HORIZONTAL CALCULATION
                        a = 0;
                        for (int y = 0; y < 9; y++)
                        {
                            point = 0;
                            for (int x = 0; x < 9; x++)
                            {
                                if (!(board[y, x] == -1))
                                {
                                    point++;
                                }
                            }
                            if (point == 9)
                            {
                                Console.SetCursorPosition(34, 8 + completedNumber);
                                completedNumber++;
                                b = 9;
                                Console.Write("(");
                                for (int x = 0; x < 9; x++)
                                {
                                    stepScore += board[y, x] * Convert.ToInt32(Math.Pow(2, --b));
                                    Console.Write(board[y, x]);
                                }
                                Console.Write(")2 = " + "(" + stepScore + ")10");
                                stepTotal += stepScore;
                                to_delete[0, a] = y;
                                a++;
                            }
                            stepScore = 0;
                        }
                        //VERTICAL CALCULATION
                        a = 0;
                        for (int x = 0; x < 9; x++)
                        {
                            point = 0;
                            for (int y = 0; y < 9; y++)
                            {
                                if (!(board[y, x] == -1))
                                {
                                    point++;
                                }
                            }
                            if (point == 9)
                            {
                                Console.SetCursorPosition(34, 8 + completedNumber);
                                completedNumber++;
                                b = 9;
                                Console.Write("(");
                                for (int y = 0; y < 9; y++)
                                {
                                    stepScore += board[y, x] * Convert.ToInt32(Math.Pow(2, --b));
                                    Console.Write(board[y, x]);
                                }
                                Console.Write(")2 = " + "(" + stepScore + ")10");
                                stepTotal += stepScore;
                                to_delete[1, a] = x;
                                a++;
                            }
                            stepScore = 0;
                        }
                        //BLOCK CALCULATION
                        for (int c = 0; c < 9; c += 3)
                        {
                            for (int r = 0; r < 9; r += 3)
                            {
                                point = 0;
                                for (int y = 0 + c; y < 3 + c; y++)
                                {
                                    for (int x = 0 + r; x < 3 + r; x++)
                                    {
                                        if (!(board[y, x] == -1))
                                        {
                                            point++;
                                        }
                                    }
                                }
                                if (point == 9)
                                {
                                    Console.SetCursorPosition(34, 8 + completedNumber);
                                    completedNumber++;
                                    b = 9;
                                    int z = 0;
                                    Console.Write("(");
                                    for (int y = 0 + c; y < 3 + c; y++)
                                    {
                                        for (int x = 0 + r; x < 3 + r; x++)
                                        {
                                            stepScore += board[y, x] * Convert.ToInt32(Math.Pow(2, --b));
                                            Console.Write(board[y, x]);
                                            board[y, x] = -1;
                                            z++;
                                        }
                                    }
                                    Console.Write(")2 = " + "(" + stepScore + ")10");
                                    stepTotal += stepScore;
                                }
                            }
                        }
                        score += stepTotal * completedNumber;

                        if (completedNumber > 0)
                        {
                            Console.SetCursorPosition(34, 7);
                            Console.Write("CALCULATIONS:");
                            if (completedNumber > 0)
                            {
                                Console.SetCursorPosition(34, 8 + completedNumber);
                                Console.Write($"Total: {stepTotal}");
                                Console.SetCursorPosition(34, 9 + completedNumber);
                                Console.Write($"{stepTotal} * {completedNumber} = {completedNumber * stepTotal} ");
                            }
                        }

                        //DELETING THE FILLED PARTS
                        for (a = 0; a < 9; a++)
                        {
                            if (!(to_delete[0, a] == -1))
                            {
                                for (int x = 0; x < 9; x++)
                                {
                                    board[to_delete[0, a], x] = -1;
                                }
                            }
                            if (!(to_delete[1, a] == -1))
                            {
                                for (int y = 0; y < 9; y++)
                                {
                                    board[y, to_delete[1, a]] = -1;
                                }
                            }
                        }
                    }

                    //FILE OPERATION
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(0, 21);
                    Console.Write("Please Enter Your Name: ");
                    string input = (Console.ReadLine() + ";" + score);
                    Console.SetCursorPosition(70, 5);
                    Console.WriteLine("TOP 10");
                    Console.SetCursorPosition(70, 6);
                    Console.WriteLine("---------------");

                    //READING TEXT FILE LINES AND SCORES
                    string[] high_score_table = new string[10];
                    int[] high_scores = new int[10];
                    char d = 'a';
                    int count = 0;

                    StreamWriter f0 = File.AppendText("HighScoreTable.txt");
                    f0.Close();

                    StreamReader f1 = File.OpenText("HighScoreTable.txt");
                    for (int i = 0; i < 10; i++)
                    {
                        high_score_table[i] = f1.ReadLine();
                    }
                    f1.Close();
                    for (int i = 0; i < 10; i++)
                    {
                        if (high_score_table[i] != null) count++;
                    }
                    StreamReader f2 = File.OpenText("HighScoreTable.txt");
                    for (int i = 0; i < count; i++)
                    {
                        if (i < 10)
                        {
                            while (d != ';')
                            {
                                d = Convert.ToChar(f2.Read());
                            }
                            high_scores[i] = int.Parse(f2.ReadLine());
                            d = 'a';
                        }
                    }
                    f2.Close();

                    //REPLACING THE NEW HIGH SCORE
                    int temp;
                    string temp2;
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            if (high_scores[i + 1] > high_scores[i])
                            {
                                temp2 = high_score_table[i];
                                high_score_table[i] = high_score_table[i + 1];
                                high_score_table[i + 1] = temp2;
                                temp = high_scores[i];
                                high_scores[i] = high_scores[i + 1];
                                high_scores[i + 1] = temp;
                            }
                        }
                    }
                    //SLIDE THE LINES AND DELETE THE LAST RECORD
                    for (int i = 0; i < 9; i++)
                    {
                        if (score >= high_scores[i])
                        {
                            for (int j = 0; j < 9 - i; j++)
                            {
                                high_score_table[9 - j] = high_score_table[8 - j];
                                high_scores[9 - j] = high_scores[8 - j];
                            }
                            high_score_table[i] = input;
                            high_scores[i] = score;
                            break;
                        }
                    }
                    //WRITING NEW HIGH SCORE TABLE TO SCREEN            
                    for (int i = 0; i < count + 1; i++)
                    {
                        if (i < 10)
                        {
                            Console.SetCursorPosition(70, 7 + i);
                            Console.WriteLine(high_score_table[i]);
                        }
                    }

                    //WRITING NEW HIGH SCORE TABLE TO SAME TEXT FILE
                    StreamWriter f3 = File.CreateText("HighScoreTable.txt");
                    for (int i = 0; i < count + 1; i++)
                    {
                        if (i < 10)
                            f3.WriteLine(high_score_table[i]);
                    }
                    f3.Close();
                    Console.SetCursorPosition(25, 10);
                    Console.WriteLine("Press any key to go to main menu.");
                    Console.SetCursorPosition(25, 12);
                    Console.WriteLine("If you don't want to go to main menu,");
                    Console.SetCursorPosition(25, 13);
                    Console.WriteLine("press the ESC key.");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape)
                        break;

                }
                else if (cy == 7)
                {
                    Console.Clear();
                    Console.SetWindowSize(108, 24);
                    Console.WriteLine("                                          GENERAL INFORMATION");
                    Console.WriteLine();
                    Console.WriteLine("The game is played on a 9 * 9 board.The board will be filled with 10 different game elements by the player.  ");
                    Console.WriteLine("The aim of the game is to fill a row, a column or a 3 * 3 block with the game elements and reaching the ");
                    Console.WriteLine("highest score.");
                    Console.WriteLine();
                    Console.WriteLine("                                            BOARD ELEMENTS");
                    Console.WriteLine();
                    Console.WriteLine("There are ten game elements.Each has a 1 / 10 probability of occurrence.The game elements are given below. ");
                    Console.WriteLine("(Each X represents 0 or 1, randomly generated)");
                    Console.WriteLine();
                    Console.WriteLine("Piece1 = X       Piece6 = XX");
                    Console.WriteLine("                          X");
                    Console.WriteLine();
                    Console.WriteLine("Piece2 = XX      Piece7 = XX");
                    Console.WriteLine("                           X");
                    Console.WriteLine();
                    Console.WriteLine("Piece3 = X       Piece8 = X");
                    Console.WriteLine("         X                XX");
                    Console.WriteLine();
                    Console.WriteLine("Piece4 = XXX     Piece9 =  X");
                    Console.WriteLine("                          XX");
                    Console.WriteLine();
                    Console.WriteLine("Piece5 = X       Piece10 =XX");
                    Console.WriteLine("         X                XX");
                    Console.WriteLine("         X");
                    Console.WriteLine();
                    Console.WriteLine("                                          GAME PLAYING RULES");
                    Console.WriteLine();
                    Console.WriteLine("The game starts with a 9 * 9 empty board.");
                    Console.WriteLine("A new piece is generated randomly and displayed on the right of the board.");
                    Console.WriteLine("The user can place the game element in an empty part of the board without overlaying. Game elements cannot");
                    Console.WriteLine("be rotated.Placement operation does not have a time limit.");
                    Console.WriteLine("If the located element: ");
                    Console.WriteLine("  - fills a full row(s)(and / or)");
                    Console.WriteLine("  - fills a column(s) completely(and / or)");
                    Console.WriteLine("  - fully fills a 3 * 3 block(s),");
                    Console.WriteLine("the fully filled row(s)/ column(s) / block(s) are treated as a binary number. The decimal equivalent of");
                    Console.WriteLine("binary numbers are calculated.");
                    Console.WriteLine("If the currently placed game element fills more than one row(s) / column(s) / block(s), the decimal ");
                    Console.WriteLine("of binary numbers are added and this sum is multiplied by the number completed parts(row(s)/column(s)");
                    Console.WriteLine("This result is added to the score.");
                    Console.WriteLine("/ block(s)). Completed parts are removed from the board");
                    Console.WriteLine();
                    Console.WriteLine("                                              GAMEPLAY");
                    Console.WriteLine();
                    Console.WriteLine("You can move the piece on the board with the arrow keys and press the Enter key to place it in appropriate ");
                    Console.WriteLine("places.When you press the Esc key, you can exit the game and save your score.");
                    Console.WriteLine();
                    Console.WriteLine("                                             GAME ENDING");
                    Console.WriteLine();
                    Console.WriteLine("If there is no suitable space left to place the new piece on the board, a notice appears saying Game Over");
                    Console.WriteLine("and you will save your score.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.WriteLine("Press ESC to exit.");
                    Console.SetCursorPosition(0, 0);
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape) break;
                }
                else if (cy == 9)
                {
                    string[] high_score_table = new string[10];
                    int[] high_scores = new int[10];
                    char d = 'a';
                    int count = 0;
                    Console.Clear();
                    Console.SetWindowSize(44, 15);
                    Console.WriteLine("High Score Table");
                    Console.WriteLine("----------------");
                    StreamReader f1 = File.OpenText("HighScoreTable.txt");
                    for (int i = 0; i < 10; i++)
                    {
                        high_score_table[i] = f1.ReadLine();
                    }
                    f1.Close();
                    for (int i = 0; i < 10; i++)
                    {
                        if (high_score_table[i] != null) count++;
                    }
                    StreamReader f2 = File.OpenText("HighScoreTable.txt");
                    for (int i = 0; i < count; i++)
                    {
                        if (i < 10)
                        {
                            while (d != ';')
                            {
                                d = Convert.ToChar(f2.Read());
                            }
                            high_scores[i] = int.Parse(f2.ReadLine());
                            d = 'a';
                        }
                    }
                    f2.Close();
                    //WRITING HIGH SCORE TABLE TO SCREEN            
                    for (int i = 0; i < count + 1; i++)
                    {
                        if (i < 10)
                        {
                            Console.SetCursorPosition(0, 2 + i);
                            Console.WriteLine(high_score_table[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the main menu.");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape) break;
                }
                else break;
            } while (true);

        }
    }
}

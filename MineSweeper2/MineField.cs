using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MineSweeper2
{
    public class MineField
    {
        FieldGenerator gen = new FieldGenerator();
        Visuals visual = new Visuals();
        private static int number = 0;
        private int rows;
        private int columns;
        private int mineChance;
        private int correctMineFlags = 0;
        private int wrongMineFlags = 0;
        private int totalMines = 0;
        private string gameStatus = "alive";
        public List<List<string>> mines = new List<List<string>>();
        public List<List<string>> minesWithAllNumbers = new List<List<string>>();
        public List<List<string>> playable = new List<List<string>>();


        // MineField constructor
        public MineField(int columnInput, int rowInput, int mineChanceInput)
        {
            number++;
            rows = rowInput;
            columns = columnInput;
            mineChance = mineChanceInput;
            Console.WriteLine("MineField " + number + " created");

            CreateANewField();
        }

        // Called in the constructor to create a new minefield
        public void CreateANewField()
        {
            gen.ClearMyLists();
            gen.GenerateNewFields(columns, rows, mineChance);
            mines = gen.GetMines();
            minesWithAllNumbers = gen.GetNumbers();
            playable = gen.GetPlayable();

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (mines[x][y] == "x")
                    {
                        totalMines++;
                    }
                }
            }
        }


        // takes in the inputs from the Main Program and decides what to do
        public string PlayInput(int yInput, int xInput, int isItAMineInput)
        {
            yInput--;
            xInput--;

            

            if(isItAMineInput == 1) // click, not a mine
            {

                if (minesWithAllNumbers[xInput][yInput] == "x") // steps on a mine              LOSES !!!!!!!!
                {
                    LostGame();
                    return gameStatus = "dead";
                }

                else if(playable[xInput][yInput] == "?")
                {
                    wrongMineFlags--;
                    playable[xInput][yInput] = minesWithAllNumbers[xInput][yInput];
                }

                else if (playable[xInput][yInput] == "-")
                {
                    playable[xInput][yInput] = minesWithAllNumbers[xInput][yInput];
                }

                else
                {
                    Console.WriteLine("mine input choice 1, else");
                }

                if (totalMines == correctMineFlags)
                {
                    return gameStatus = "won";
                }

                return gameStatus;
            }

            else if(isItAMineInput == 2) // put a flag
            {

                if(minesWithAllNumbers[xInput][yInput] == "x")
                {
                    playable[xInput][yInput] = "?";
                    correctMineFlags++;
                }

                else if(minesWithAllNumbers[xInput][yInput] != "x")
                {
                    playable[xInput][yInput] = "?";
                    wrongMineFlags++;
                }

                else
                {
                    Console.WriteLine("mine input choice 2, else");
                }

                if (totalMines == correctMineFlags)
                {
                    return gameStatus = "won";
                }

                return gameStatus;
            }

            else if (isItAMineInput == 3) // remove flag
            {

                if(minesWithAllNumbers[xInput][yInput] == "x" && playable[xInput][yInput] == "?")
                {
                    correctMineFlags--;
                    playable[xInput][yInput] = "-";
                }

                else if(minesWithAllNumbers[xInput][yInput] != "x" && playable[xInput][yInput] == "?")
                {
                    wrongMineFlags--;
                }

                else
                {
                    Console.WriteLine("there was no flag to remove");
                }

                return gameStatus;
            }

            if (totalMines == correctMineFlags)
            {
                return gameStatus = "won";
            }

            return gameStatus;
                
        }

        public string GameStatus()
        {
            return gameStatus;
        }


        // Method that activates when you step on a mine and lose
        public void LostGame()
        {
            playable = mines;
            playable[0][0] = "x";
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {


                    if (playable[x][y] == "x")
                    {
                        for (int a = x - 1; a < x + 1; a++)
                        {
                            for (int b = y - 1; b < y + 2; b++)
                            {

                                if ((a >= 0 && b >= 0) && (a < columns && b < rows))
                                {
                                    playable[a][b] = "x";

                                }

                            }
                        }

                    }

                    Console.Clear();
                    visual.PrintMinefield(playable);
                    Thread.Sleep(20);

                }
            }
            Console.WriteLine("YOU DIED");
        }
        
    }
}


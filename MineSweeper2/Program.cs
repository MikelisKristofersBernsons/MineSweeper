using System;
using System.Collections.Generic;
using System.Threading;

namespace MineSweeper2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Started------------\n" +
                              "---------Version 0.0.1---------\n" +
                              "--------Now with lists!--------\n\n\n");

            Visuals visual = new Visuals();
            List<MineField> mineFields = new List<MineField>();
            string begone = "1";
            int fieldIndex = 0;
            bool playing = false;


            //FieldGenerator gen = new FieldGenerator();
            //MineField mf1 = new MineField(Int32.Parse(rowInput), Int32.Parse(columnInput), Int32.Parse(chanceInput));



            while (begone == "1")
            {
                Console.Write("how many columns?:      ");
                string columnInput = Console.ReadLine();
                Console.Write("how many rows?:         ");
                string rowInput = Console.ReadLine();
                Console.Write("Chance of mines, 1 in : ");
                string chanceInput = Console.ReadLine();

                mineFields.Add(new MineField(Int32.Parse(columnInput),Int32.Parse(rowInput), Int32.Parse(chanceInput)));

                //visual.PrintMinefield(mineFields[fieldIndex].mines);
                //visual.PrintMinefield(mineFields[fieldIndex].minesWithAllNumbers);
                //visual.PrintMinefield(mineFields[fieldIndex].playable);
                visual.PrintMinefield(mineFields[fieldIndex].playable);

                Console.Clear();

                Console.WriteLine(    "------------------CONTROLS:-----------------\n" +
                                      "----input coordinates: 1st = X position-----\n" +
                                      "----input coordinates: 2nd = Y position-----\n" +
                                      "----a question mark is a flag for a mine: --\n" +
                                      "----after that input: ----------------------\n" +
                                      "----1 if its NOT a mine---------------------\n" +
                                      "----2 if you think that it is a mine--------\n" + 
                                      "----3 if you want to remove the flag--------\n");

                Console.Write("Press Enter to continue...\n");
                Console.ReadLine();
                Console.Clear();

                playing = true;

                while (playing)
                {
                    if (mineFields[fieldIndex].GameStatus() == "dead")
                    {
                        break;
                    }
                    else if(mineFields[fieldIndex].GameStatus() == "won")
                    {
                        visual.Victory();
                        break;
                    }

                    visual.PrintMinefield(mineFields[fieldIndex].playable);

                    Console.Write("Coordinate X:               ");
                    string xInput = Console.ReadLine();
                    Console.Write("Coordinate Y:               ");
                    string yInput = Console.ReadLine();
                    Console.Write("1 = not a mine, 2 = a mine: ");
                    string isAMine = Console.ReadLine();

                    mineFields[fieldIndex].PlayInput(Int32.Parse(xInput), Int32.Parse(yInput), Int32.Parse(isAMine));


                    // say something before clearing


                    //Console.Clear();
                }


                Console.Write("input 1 to play again: ");
                begone = Console.ReadLine();
                fieldIndex++;
            }

        }
        
    }
}

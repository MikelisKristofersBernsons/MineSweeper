using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper2
{
    class FieldGenerator
    {
        //for(int x = 0, x<rowInput; x++)
        //    {
        //        mineFieldList.Add(new List<string> { "a", "b" });
        //    }
        Random rand = new Random();
        private int fieldValue = 0;
        private int mineCounter = 0;

        List<List<string>> myList = new List<List<string>>();
        List<List<string>> myListNumbers = new List<List<string>>();
        List<List<string>> myListPlayable = new List<List<string>>();


        // generates 3 mine fields: 2 with "x" as a mine and "-" as a non mine, 1 field with only "-"
        public void  GenerateNewFields(int columnInput, int rowInput, int mineChanceInput)
        {

            for(int x = 0; x < columnInput; x++)
            {
                myList.Add(new List<string>());
                myListNumbers.Add(new List<string>());
                myListPlayable.Add(new List<string>());
                for (int y = 0; y < rowInput; y++)
                {
                    fieldValue = rand.Next(0, mineChanceInput);
                    if(fieldValue == 0)
                    {
                        myList[x].Add("x");
                        myListNumbers[x].Add("x");
                    }
                    else
                    {
                        myList[x].Add("-");
                        myListNumbers[x].Add("-");
                    }

                    myListPlayable[x].Add("-");
                }
            }
            GenerateNumberField(columnInput, rowInput);
            GeneratePlayableField(columnInput, rowInput);


        }

        // clears all lists like they are new, because they are...
        public void ClearMyLists()
        {
            myList = new List<List<string>>();
            myListNumbers = new List<List<string>>();
            myListPlayable = new List<List<string>>();
        }
        

        // generates a mine field with numbers
        public void GenerateNumberField(int columnInput, int rowInput)
        {

            for (int x = 0; x < columnInput; x++)
            {
                for (int y = 0; y < rowInput; y++)
                {

                    mineCounter = 0;

                    for (int a = x - 1; a < x + 2; a++)
                    {
                        for (int b = y - 1; b < y + 2; b++)
                        {


                            if ((a >= 0 && b >= 0) && (a < columnInput && b < rowInput))
                            {
                                if (myList[a][b] == "x")
                                {
                                    mineCounter = mineCounter + 1;
                                }
                            }


                        }
                    }

                    if(myList[x][y] != "x")
                    {
                        myListNumbers[x][y] = mineCounter.ToString();
                    }

                }
            }

        }

        // generates the playable field with zeroes and numbers around them
        public void GeneratePlayableField(int columnInput, int rowInput)
        {

            for (int x = 0; x < columnInput; x++)
            {
                for (int y = 0; y < rowInput; y++)
                {

                    if (myListNumbers[x][y] == "0")
                    {

                        for (int a = x - 1; a < x + 2; a++)
                        {
                            for (int b = y - 1; b < y + 2; b++)
                            {
                                if ((a >= 0 && a < columnInput) && (b >= 0 && b < rowInput))
                                {
                                    myListPlayable[a][b] = myListNumbers[a][b];
                                }
                            }
                        }
                    }

                }
            }
        }




        public List<List<string>> GetMines()
        {
            return myList;
        }
        public List<List<string>> GetNumbers()
        {
            return myListNumbers;
        }
        public List<List<string>> GetPlayable()
        {
            return myListPlayable;
        }

    }
}

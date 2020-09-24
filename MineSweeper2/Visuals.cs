using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper2
{
    class Visuals
    {

        private int y = 1;

        public void PrintMinefield(List<List<string>> inputList)
        {
            Console.Write("\n   X");
            for (int index = 1; index <= inputList[0].Count; index++)
            {
                Console.Write("   " + index);
            }
            Console.WriteLine("\n");
            foreach (List<string> subList in inputList)
            {
                Console.WriteLine("\n");
                Console.Write(y + "   ");
                foreach(string item in subList)
                {
                    Console.Write("   " + item);
                }
                y++;
            }
            Console.WriteLine("\n\n---");
            y = 1;
        }

        public void Victory()
        {
            Console.WriteLine("   -   -   -   -   -   -   -   -   -\n" +
                              "   -   -   -   -   T   -   -   -   -\n" +
                              "   -   -   -   C   T   O   -   -   -\n" +
                              "   -   -   I   C   T   O   R   -   -\n" +
                              "   -   V   I   C   T   O   R   Y   -\n" +
                              "   -   -   I   C   T   O   R   -   -\n" +
                              "   -   -   -   C   T   O   -   -   -\n" +
                              "   -   -   -   -   T   -   -   -   -\n" +
                              "   -   -   -   -   -   -   -   -   -\n");
        }



    }
}

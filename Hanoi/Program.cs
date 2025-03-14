using System;
using System.Collections.Generic;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || (args[0] != "-Recursive" && args[0] != "-Iterative"))
            {
                Console.WriteLine("Please write: 'dotnet run -Recursive <num>' or 'dotnet run -Iterative <num>'");
                return;
            }

            int numOfDisks;
            if (!int.TryParse(args[1], out numOfDisks) || numOfDisks < 1)
            {
                Console.WriteLine("Please write a valid number of disks.");
                return;
            }

            Stack<int> firstRod = new Stack<int>();
            Stack<int> secondRod = new Stack<int>();
            Stack<int> thirdRod = new Stack<int>();

            for (int i = numOfDisks; i > 0; i--)
            {
                firstRod.Push(i);
            }

            DrawHanoiTowers(numOfDisks, firstRod, secondRod, thirdRod);

            if (args[0] == "-Recursive")
            {
                SolveHanoiRecursive(numOfDisks, firstRod, thirdRod, secondRod, numOfDisks);
            }
            else
            {
                SolveHanoiIterative(numOfDisks, firstRod, secondRod, thirdRod);
            }
        }

        static void SolveHanoiRecursive(int n, Stack<int> firstRod, Stack<int> thirdRod, Stack<int> secondRod, int totalDisks)
        {
            if (n == 1)
            {
                thirdRod.Push(firstRod.Pop());
                DrawHanoiTowers(totalDisks, firstRod, secondRod, thirdRod);
                return;
            }

            SolveHanoiRecursive(n - 1, firstRod, secondRod, thirdRod, totalDisks);
            thirdRod.Push(firstRod.Pop());
            DrawHanoiTowers(totalDisks, firstRod, secondRod, thirdRod);
            SolveHanoiRecursive(n - 1, secondRod, thirdRod, firstRod, totalDisks);
        }

        static void SolveHanoiIterative(int numOfDisks, Stack<int> firstRod, Stack<int> secondRod, Stack<int> thirdRod)
        {
            Stack<int>[] towers = { firstRod, secondRod, thirdRod };

            int totalMoves = (int)Math.Pow(2, numOfDisks) - 1;
            if (numOfDisks % 2 == 0)
            {
                (towers[1], towers[2]) = (towers[2], towers[1]);
            }

            for (int i = 1; i <= totalMoves; i++)
            {
                int from = (i & i - 1) % 3;
                int to = ((i | i - 1) + 1) % 3;

                if (towers[to].Count == 0 || (towers[from].Count > 0 && towers[from].Peek() < towers[to].Peek()))
                {
                    towers[to].Push(towers[from].Pop());
                }
                else
                {
                    towers[from].Push(towers[to].Pop());
                }
                DrawHanoiTowers(numOfDisks, firstRod, secondRod, thirdRod);
            }
        }

        static void DrawHanoiTowers(int numOfDisks, Stack<int> left, Stack<int> middle, Stack<int> right)
        {
            Stack<int>[] towers = { left, middle, right };
            string[] fieldLabels = { "(L)", "(M)", "(R)" };
            int columnWidth = 2 * numOfDisks + 2;
            string divider = " | ";

            List<string>[] towerStrings = new List<string>[3];
            for (int i = 0; i < 3; i++)
            {
                towerStrings[i] = new List<string>();
                foreach (int disk in towers[i])
                {
                    int diskWidth = 2 * disk - 1;
                    string diskStr = new string('+', diskWidth).PadLeft(numOfDisks + disk).PadRight(columnWidth);
                    towerStrings[i].Add(diskStr);
                }
                while (towerStrings[i].Count < numOfDisks)
                {
                    towerStrings[i].Insert(0, new string(' ', columnWidth));
                }
            }

            for (int i = 0; i < numOfDisks; i++)
            {
                Console.WriteLine(string.Join(divider, towerStrings[0][i], towerStrings[1][i], towerStrings[2][i]));
            }

            Console.WriteLine(new string('-', columnWidth) + divider + new string('-', columnWidth) + divider + new string('-', columnWidth));
            Console.WriteLine(
                fieldLabels[0].PadLeft(columnWidth / 2 + fieldLabels[0].Length / 2).PadRight(columnWidth) +
                fieldLabels[1].PadLeft(columnWidth + fieldLabels[1].Length / 2).PadRight(columnWidth) +
                fieldLabels[2].PadLeft(columnWidth + fieldLabels[2].Length / 2).PadRight(columnWidth)
            );
            Console.WriteLine();
        }
    }
}
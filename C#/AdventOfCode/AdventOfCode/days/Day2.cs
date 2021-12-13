using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day2
    {
        public void Run()
        {
            Console.Write("Enter input location: ");
            var location = Console.ReadLine();

            // Read the input 
            var lines = System.IO.File.ReadAllLines(location);

            Task(lines);

            Console.ReadLine();
        }


        private void Task(string[] inputLines)
        {
            var task1Pos = new Dictionary<string, int>() { { "xPos", 0 }, { "yPos", 0 } };
            var task2Pos = new Dictionary<string, int>() { { "xPos", 0 }, { "yPos", 0 }, { "aim", 0 } };

            for (int x = 0; x < inputLines.Length; x++)
            {
                var splitted = inputLines[x].Split();
                var direction = splitted[0];
                var directionValue = int.Parse(splitted[1]);

                switch (direction)
                {
                    case "forward":
                        task1Pos["xPos"] += directionValue;
                        task2Pos["xPos"] += directionValue;
                        task2Pos["yPos"] += directionValue * task2Pos["aim"];
                        break;
                    case "up":
                        task1Pos["yPos"] -= directionValue;
                        task2Pos["aim"] -= directionValue;
                        break;
                    case "down":
                        task1Pos["yPos"] += directionValue;
                        task2Pos["aim"] += directionValue;
                        break;
                    default:
                        throw new Exception("Incorrect direction value.");
                }
            }

            Console.WriteLine("Task1: " + task1Pos["xPos"] * task1Pos["yPos"]);
            Console.WriteLine("Task2: " + task2Pos["xPos"] * task2Pos["yPos"]);
        }
    }
}

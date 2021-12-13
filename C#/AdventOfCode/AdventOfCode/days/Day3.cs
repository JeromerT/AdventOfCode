using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day3
    {
        public void Run()
        {
            Console.Write("Enter input location: ");
            var location = Console.ReadLine();

            // Read the input 
            var lines = System.IO.File.ReadAllLines(location);

            Task1(lines);
            Task2(lines);

            Console.ReadLine();
        }

        private void Task1(string[] inputLines)
        {
            var lineLength = inputLines[0].Length;
            var oneCountArray = new int[lineLength];

            for(var x = 0; x < inputLines.Length; x++)
            {
                var toCheck = inputLines[x];

                for(var y = 0; y < lineLength; y++)
                {
                    if(toCheck[y] == '1')
                    {
                        oneCountArray[y]++;
                    }
                }
            }

            var gammaString = "";
            var epsilonString = "";

            for (var y = 0; y < lineLength; y++)
            {
                if (oneCountArray[y] >= inputLines.Length / 2)
                {
                    gammaString += "1";
                    epsilonString += "0";
                }
                else
                {
                    gammaString += "0";
                    epsilonString += "1";
                }
            }

            var epsilon = Convert.ToInt32(epsilonString, 2);
            var gamma = Convert.ToInt32(gammaString, 2);

            Console.WriteLine(epsilon);
            Console.WriteLine(gamma);

            Console.WriteLine("Result1: " + epsilon * gamma);
        }

        private void Task2(string[] lines)
        {
            var oxygenGenerator= new List<string>(lines);
            var co2Scrubber = new List<string>(lines);

            var oxygenGeneratorPositionCount = 0;
            var co2ScrubberPositionCount = 0;

            while (oxygenGenerator.Count>1)
            {
                var targetBit = GetTargetBit(oxygenGenerator, oxygenGeneratorPositionCount, true);
                oxygenGenerator = RemoveWrongBit(oxygenGenerator, targetBit, oxygenGeneratorPositionCount);                
                oxygenGeneratorPositionCount++;
            }

            while (co2Scrubber.Count > 1)
            {
                var targetBit = GetTargetBit(co2Scrubber, co2ScrubberPositionCount, false);
                co2Scrubber = RemoveWrongBit(co2Scrubber, targetBit, co2ScrubberPositionCount);
                co2ScrubberPositionCount++;
            }

            var oxygenGeneratorValue = Convert.ToInt32(oxygenGenerator[0], 2);
            var co2ScrubberValue = Convert.ToInt32(co2Scrubber[0], 2);

            Console.WriteLine("Result2: " + oxygenGeneratorValue * co2ScrubberValue);
        }

        private List<string> RemoveWrongBit(List<string> inputList, char correctbit, int position)
        {
            for(int x = inputList.Count-1; x >=0; x--)
            {
                var toCheck = inputList[x];
                if (toCheck[position] != correctbit)
                    inputList.RemoveAt(x);
            }

            return inputList;
        }

        private char GetTargetBit(List<string> inputList, int position, bool mostCommon)
        {
            var oneCount = 0;

            for (var x = 0; x < inputList.Count; x++)
            {
                var toCheck = inputList[x];

                if (toCheck[position] == '1')
                    oneCount++;
            }

            if (oneCount >= inputList.Count -oneCount)
            {
                if (mostCommon)
                    return '1';
                else
                    return '0';
            }
            else 
            {
                if (mostCommon)
                    return '0';
                else
                    return '1';
            }
        }
    }
}

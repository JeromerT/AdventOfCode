using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day1
    {
        public  void Run()
        {
            Console.Write("Enter input location: ");
            var location = Console.ReadLine();

            // Read the input 
            var lines = System.IO.File.ReadAllLines(location);

            var measurements = ConvertToInt(lines);

            var result = Task1(measurements);

            Console.WriteLine(result);

            Console.ReadLine();

        }

        private int[] ConvertToInt(string[] lines)
        {
            var output = new int[lines.Length];

            for(var x = 0; x <lines.Length; x++)
            {
                output[x] = int.Parse(lines[x]);
            }

            return output;
        }

        private Tuple<int, int> Task1(int[] measurements)
        {
            var larger1 = 0;
            var larger2 = 0;

            var sumPrevious = measurements[0] + measurements[1] + measurements[2];

            for (var x = 1; x < measurements.Length; x++)
            {
                if (measurements[x] > measurements[x - 1]) larger1++;
                if(x+2 < measurements.Length)
                {
                    var currentSum = measurements[x] + measurements[x + 1] + measurements[x + 2];
                    if (currentSum > sumPrevious) larger2++;
                    sumPrevious = currentSum;
                }
                
            }

            return new Tuple<int, int>(larger1, larger2);
        }
    }
}

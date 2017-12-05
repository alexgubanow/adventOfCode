using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace day4p1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please give input file!");
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Please give input file!");
                return;
            }
            List<int> arr;
            using (var fileStream = File.OpenRead(args[0]))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                String line;
                arr = new List<int>();
                while ((line = streamReader.ReadLine()) != null)
                {
                    arr.Add(Convert.ToInt32(line));
                }
            }
            int numSteps = 0;
            int i = 0;
            while (i < arr.Count)
            {
                //for (int k = 0; k < arr.Count; k++)
                //{
                //    if (i == k)
                //    {
                //        Console.Write('(' + (arr[k]).ToString() + ')'+ ' ');
                //    }
                //    else
                //    {
                //        Console.Write((arr[k]).ToString() + ' ');
                //    }
                //}
                int nextStep = 0;
                if (arr[i] < 0)
                {
                    nextStep = i + arr[i];
                }
                else if (arr[i] == 0)
                {
                    nextStep = i;
                }
                else
                {
                    nextStep = i + arr[i];
                }
                //Console.WriteLine(nextStep.ToString());
                if (nextStep >= arr.Count || nextStep < 0)
                {
                    Console.WriteLine("Oops, overjump");
                    Console.WriteLine(numSteps + 1 + " steps we reach");
                    return;
                }
                arr[i]++;
                i = nextStep;
                numSteps++;
            }
            Console.WriteLine(numSteps + " steps you are need");
        }
    }
}

using System;
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
            using (var fileStream = File.OpenRead(args[0]))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                String line;
                int numTrue = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] arr = line.Split(' ');
                    bool n = false;
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        for (int k = i + 1; k < arr.Length; k++)
                        {
                            if (arr[i].Length == arr[k].Length)
                            {
                                if (arr[i] == arr[k] || getCharSum(arr[i]) == getCharSum(arr[k]))
                                {
                                    n = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!n)
                    {
                        numTrue++;
                    }
                }
                Console.WriteLine(numTrue + " passphrases are valid");
            }
        }

        static int getCharSum(string str1)
        {
            int sum = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                sum += (int)str1[i];
            }
            return sum;
        }
    }
}

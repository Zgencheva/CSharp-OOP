using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|").ToList();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Done")
                {
                    break;
                }

                string[] command = cmd.Split().ToArray();
                if (command[0] == "Add")
                {
                    int index = int.Parse(command[2]);
                    string item = command[1];
                    if (index >=0 && index < input.Count)
                    {
                        input.Insert(index, item);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < input.Count)
                    {
                        input.RemoveAt(index);
                    }
                   
                }
                else if (command[0] == "Check")
                {
                    List<string> currentList = new List<string>();
                    if (command[1] == "Even")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                currentList.Add(input[i]);
                            }
                        }
                        
                    }
                    else if (command[1] == "Odd")
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (i % 2 != 0)
                            {
                                currentList.Add(input[i]);
                            }
                        }
                       
                    }

                    Console.WriteLine(string.Join(" ", currentList)) ;
                }
            }
            Console.Write("You crafted ");
            foreach (var item in input)
            {
                
                Console.Write($"{item}");
            }
            Console.Write("!");
        }
    }
}

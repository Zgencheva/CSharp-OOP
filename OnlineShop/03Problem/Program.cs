using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end")
                {
                    break;
                }

                string[] command = cmd.Split().ToArray();

                if (command[0] == "Chat")
                {
                    chat.Add(command[1]);
                }
                else if (command[0] == "Delete")
                {
                    if (chat.Contains(command[1]))
                    {
                        chat.Remove(command[1]);
                    }
                }
                else if (command[0] == "Edit")
                {
                    string messageToEdit = command[1];
                    string messageToReplace = command[2];
                    if (chat.Contains(messageToEdit))
                    {
                        int index = chat.IndexOf(messageToEdit);
                        chat.Insert(index, messageToReplace);
                        chat.Remove(messageToEdit);
                    }
                }
                else if (command[0] == "Pin")
                {
                    string messageToPin = command[1];
                    if (chat.Contains(messageToPin))
                    {
                        chat.Remove(messageToPin);
                        chat.Add(messageToPin);
                    }
                }
                else if (command[0] == "Spam")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        chat.Add(command[i]);
                    }
                }
            }

            Console.WriteLine(string.Join("\n", chat));
        }
    }
}

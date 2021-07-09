using System;
using CommandPattern.Commands;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                int value = int.Parse(input[1]);

                ICommand command = null;
                switch (input[0])
                {
                    case "+":
                        command = new PlusCommand(value);
                        break;
                    case "-":
                        command = new MinusCommand(value);
                        break;
                    case "*":
                        command = new MultiplyCommand(value);
                        break;
                    case "undo": calc.Undo(value);
                        break;
                        case "redo": calc.Redo(value);
                        break;

                }
                if (command !=null)
                {
                    calc.AddCommand(command);
                }
                
            }
            

            
        }
    }
}

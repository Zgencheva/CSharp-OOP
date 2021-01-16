using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Sleep();
            Person child = new Child();
            child.Sleep();
            Person robot = new Robot();
            robot.Sleep();
        }
    }
}

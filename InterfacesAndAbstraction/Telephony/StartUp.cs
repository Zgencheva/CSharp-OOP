using System;

using Telephony.Exceptions;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            StationaryPhone stationPhone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();
            for (int i = 0; i < phones.Length; i++)
            {
                try
                {
                    if (phones[i].Length == 7)
                    {
                        Console.WriteLine(stationPhone.Call(phones[i]));
                    }
                    else if (phones[i].Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(phones[i]));
                    }
                    else
                    {
                        throw new InvalidPhoneNumException();
                    }
                }
                catch (InvalidPhoneNumException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(sites[i]));
                }
                catch (InvalidUrlException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}

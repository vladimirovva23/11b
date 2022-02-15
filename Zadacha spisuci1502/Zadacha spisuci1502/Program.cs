using System;
using System.Collections.Generic;
using System.Linq;

namespace ZadachaSpisuci1502
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            while (true)
            {
                string input = Console.ReadLine();

               


                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "add":
                        {
                            int index = int.Parse(commands[1]);
                            string element = (commands[2]);

                            if (!names.Contains(element))
                            {
                                names.Insert(index, element);
                                break;
                            }

                            break;
                        }

                    case "contains":
                        {
                            string nameToSearch =(commands[1]);
                            if (!names.Contains(nameToSearch))
                            {

                                Console.WriteLine(names.IndexOf(nameToSearch));
                            }

                            break;


                        }


                    case "print":
                
                        {
          
                            Console.WriteLine(String.Join("", names));

                        }

                        break;
                }


                



            }


        }
    }
}

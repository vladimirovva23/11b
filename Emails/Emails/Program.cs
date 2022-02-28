using System;
using System.Collections.Generic;

namespace Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionaryclass = new Dictionary<string, string>();

            while(true)
            {
                var input = Console.ReadLine().Split();
                
                if(input[0] == "Stop")
                {
                    break;
                }

                if(input[0] == "Add")
                {
                    string name = input[1];
                    string email = input[2];

                    if(!dictionaryclass.ContainsKey(name))
                    {
                        dictionaryclass.Add(name, email);
                    }

                    else 
                    {

                        dictionaryclass[name] = email;
                    }
                
                }
               
                if(input[0] == "Sent")
                {
                    string name = input[1];
                    
        
                    
                    if (dictionaryclass.ContainsKey(name))
                    {
                       
                        foreach (var currentName in dictionaryclass)
                        {
                            Console.WriteLine($"{currentName.Key} -> {currentName.Value}");
                        }
                    }
               
                    else 

                    {
                        Console.WriteLine($"Current {name} doesnt exist");
                    }

                    
                
                }
            

            }

            foreach (var currentName in dictionaryclass)
            {
                Console.WriteLine($"{currentName.Key} -> {currentName.Value}");
            }




            //dictionaryclass.Add("Ivan", "ivanivan@abv.bg");
            //dictionaryclass.Add("Petyr", "petyrtudjarov@abv.bg");

            //if (!dictionaryclass.ContainsKey("Ivan"))
            //{
            //    dictionaryclass.Add("Ivan", "ivanivan@abv.bg");
            //}

            //else
            //{
            //    dictionaryclass["Ivan"] = "ivanivan@abv.bg";

            //    foreach (var name in dictionaryclass)
            //    {
            //        Console.WriteLine($"{name.Key} -> {name.Value}");
            //    }
            //}
        }

    }
}

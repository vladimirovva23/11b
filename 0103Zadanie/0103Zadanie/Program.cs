using System;
using System.Collections.Generic;

namespace _0103Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary< string , int> emails = new Dictionary<string, int>();


            while (true)
            {
                var input = Console.ReadLine().Split();

               


                if (input[0] == "list")
                {
                    foreach (var currentEmail in emails)
                    {
                        Console.WriteLine($"{currentEmail.Key} -> {currentEmail.Value}");
                    }

                    break;
                }
                
                if (input[0] == "Add")
                {

                    string email = input[1];
                   
                    if (!emails.ContainsKey(email))
                    {
                        emails.Add(email,1);
                    }

                    else
                    {

                        if (emails.ContainsKey(email))
                        {
                            Console.WriteLine($"{email} already exist!");
                        }
                    }
               
                }

                if (input[0] == "Recieve")
                {
                    string email = input[1];
                    int letter = int.Parse(input[2]);

                    if (!emails.ContainsKey(email))
                    {
                        emails.Add(email,letter);
                    }

                    else
                    {
                        emails[email] += letter;
                            
                            
                    }        
                            
                            
                }            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                   
                







            }
        }
    }
}

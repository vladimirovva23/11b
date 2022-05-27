using System;

namespace XMLCommentsDemo
{
    /// <summary>
    /// Main class is sample illustrating how to use XML
    /// documentation in C#
    /// </summary>
    class MainClass
    {
        /// <summary>Calculates the square of a number</summary>
        /// <param name="num">The number of calculate</param>
        /// <returns>The clculated square</returns>
        /// <exception cref="OverflowException">Thrown when
        /// the result is too big to be stored in an int</exception>
        /// <seealso cref="System.Int32" />


        public static int Square(int num)
        {
            checked
            {
                return num * num;
            }
        }
   
        /// <summary>
        /// The main entry point for the applicatiom
        /// </summary>
        /// <param name="args">The command line argument</param>
    
        static void Main (string []args)
        {
            Console.WriteLine(" 3 * 3 = " + Square(3));
        }
    }

} 
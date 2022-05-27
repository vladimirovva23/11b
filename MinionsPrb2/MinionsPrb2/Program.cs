using System;
using System.Data.SqlClient;

namespace MinionsPrb2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SqlConnection("Server=DESKTOP-G29VUF0;DataBase=Minions;Integrated Security=true"))
            {
                conn.Open();
                SqlCommand comand1 = new SqlCommand
                    ();
            }
        }
    }
}


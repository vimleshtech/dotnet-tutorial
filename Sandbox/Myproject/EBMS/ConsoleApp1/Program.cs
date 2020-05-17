using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace ConsoleApp1
{
    class Program 
    {
        static void Main(string[] args)
        {

            string str =    ConfigurationSettings.AppSettings["con"].ToString();
            Phone1 obj = new Phone1();
            obj.call();
            Console.ReadLine();


        }
    }
}

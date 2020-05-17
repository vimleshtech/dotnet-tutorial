using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Phone
    {
        public void call()
        {
            Console.WriteLine("dsdshds");
        }
        
    }

    class Phone1 : Phone
    {
        public void call()
        {
            base.call();
        }
        
    }
}

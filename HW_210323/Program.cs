using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_210323
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wildebeest wildebeest = new Wildebeest();
            Console.WriteLine(wildebeest.Weight);

            Console.ReadKey();
        }
    }
}

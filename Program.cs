using System;

namespace Algorithms_lab_9
{
    class Program
    {
        static void Main(string[] args)
        {

            var dophantine = new CDiophantine(25);
            for(int i =0; i < 15; i++)
            {
                dophantine.Selection(0.6);
                foreach(var item in dophantine.population)
                {
                    if (item.Fitness() == 0)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }


            
        }
    }
}

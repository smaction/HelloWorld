using System;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            string scott = Console.ReadLine();
            int scott1 = Convert.ToInt32(scott);
            int sum = 0;
            for (int counter = scott1; counter < 21; counter++)
            {

                int remainder = counter % 3;
                if (remainder == 0)
                {
                    sum = sum + counter;
                }
            }
            Console.WriteLine($"Hello World! The sum is {sum}");

            var db = new Data();
            var horsesOut = db.GetHorses();
            foreach (var x in horsesOut) {
                Console.WriteLine($"name of horses {x.name }");
            }
           
            
        }
    }
}

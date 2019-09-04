using System;
using Coding.Collections.Generics;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>(new int[]{1,2,3,4,5});

            Display(list);
            
            list.MakeCircular(2);

            Display(list, 10);

            int startingPoint = list.FindStartingPointOfCircularList();

            Console.WriteLine(startingPoint);

        }

        static void Display(LinkedList<int> list, int len=-1)
        {
            int cnt = 0;
            foreach(var item in list)
            {
                cnt++;
                Console.Write($"{item}, ");

                if(cnt == len)
                    break;
            }

            Console.WriteLine();
        }
    }
}

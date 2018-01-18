using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptor
{
    class Program
    {
        static Random r = new Random();
        static Random r2 = new Random();

        static void Main(string[] args)
        {
            Item[] items = new Item[10000000];
            Item[] items2 = new Item[10000000];
            Item[] items3 = new Item[10000000];
            Item[] tester = new Item[10];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item(new float[] { r.Next(1, 11), r2.Next(1, 11) });
                items2[i] = new Item(new float[] { r2.Next(1, 11), r2.Next(1, 11) });
                items3[i] = new Item(new float[] { r.Next(1, 11), r.Next(1, 11) });
            }

            for (int i = 0; i < tester.Length; i++)
            {
                tester[i] = new Item(new float[] { r2.Next(1, 11), r2.Next(1, 11) });
            }

            Perceptor p = new Perceptor( (float) 0.1);

            Console.WriteLine("Wheights " + p.wheights[0] + " " + p.wheights[1]);

            p.train(items);
            p.train(items2);
            p.train(items3);

            Console.WriteLine("Wheights " + p.wheights[0] + " " + p.wheights[1]);

            foreach (Item item in tester)
            {
                int answer = p.Classify(item);
                Console.WriteLine("Correct: " + item.state + " || Answer: " + answer);
            }
        }
    }
}

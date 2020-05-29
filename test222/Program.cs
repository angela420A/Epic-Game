using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test222
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str;

            //while (true)
            //{
            //    str = Guid.NewGuid().ToString();
            //    Console.WriteLine(str);
            //    Console.ReadLine();
            //}

            string path = "../ProductText/Witcher3_text.txt";
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}

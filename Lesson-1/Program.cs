using System;
using System.Text;

namespace Lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Для вывода в консоли на кириллице
            Console.OutputEncoding = Encoding.UTF8;
            // Для ввода в консоли на кириллице
            Console.InputEncoding = Encoding.GetEncoding(1251);




        }
    }
}

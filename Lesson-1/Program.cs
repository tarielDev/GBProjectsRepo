﻿using System;
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



            // Запрашиваем имя, выводя на консоль
            Console.WriteLine("Введите ваше Имя");

            // Создаем строковую переменную и ожидаем ввода.
            // Присваиваем ей вводимое в консоли
            string name = Console.ReadLine();

        }
    }
}

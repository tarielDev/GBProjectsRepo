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



            // Запрашиваем имя, выводя на консоль
            Console.WriteLine("Введите ваше Имя");

            // Создаем строковую переменную и ожидаем ввода.
            // Присваиваем ей вводимое в консоли
            string name = Console.ReadLine();

            // Выводим в консоли введенное имя методом интерполяции,
            // а также дату и время в данный момент
            Console.WriteLine($"Здраствуйте! {name}! \n" +
                $"Сегодня: {DateTime.Now.ToShortDateString()} \n" +
                $"Время: {DateTime.Now.ToShortTimeString()}");

            // Для задержки дополнительно вставляю ожидание ввода с клавиатуры
            Console.ReadLine();

        }
    }
}

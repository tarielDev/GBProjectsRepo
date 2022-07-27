using System;
using System.Text;

namespace Lesson_2
{
    internal class Program
    {
        /// <summary>
        /// Статическая переменная помогает при выходе из главного меню
        /// пока мы находимся в заданиях она всегда false и только тогда
        /// когда мы выберем выход из программы становится true.
        /// </summary>
        public static bool vixod_iz_progi = false;

        /// <summary>
        /// Перечисление "График" это дни недели, которые каждая равна определенной битовой маске,
        /// она используется в задании, которая нужна для понимания и закрепления понятия битовых
        /// масок.
        /// </summary>
        
        [Flags]
        public enum График
        {
            Понедельник = 0b00000001,
            Вторник     = 0b00000010,
            Среда       = 0b00000100,
            Четверг     = 0b00001000,
            Пятница     = 0b00010000,
            Суббота     = 0b00100000,
            Воскресенье = 0b01000000
        }

        /// <summary>
        /// Перечисление "Зима" используется в задаче о средней температуре,
        /// при помощи нее сравнивается условие, когда температура >0 и месяц,
        /// который введен это зимний месяц и если это так, то выводим сообщение
        /// "Дождливая зима"
        /// </summary>
        public enum Зима
        {
            Январь = 1,
            Февраль = 2,
            Декабрь = 12
        }

        /// <summary>
        /// Перечисление OddEven используется при определении четности и нечетности числа,
        /// выводится в зависимости от условия значения из перечисления.
        /// </summary>
        public enum OddEven
        {
            Чётное = 0,
            Нечётное = 1
        }

        /// <summary>
        /// Перечисление zadanya используются при выборе перехода на номера заданий,
        /// в зависимости от выбора в шапке задания используется значение выбраного задания.
        /// </summary>
        public enum zadanya
        {
            zadanie1 = 1,
            zadanie2 = 2,
            zadanie3 = 3,
            zadanie4 = 4,
            zadanie5 = 5,
        }

        /// <summary>
        /// Перечисление "Месяцы" используется в задаче, где нужно в зависимости от того,
        /// какой номер был введен, выводится название того месяца.
        /// </summary>
        public enum Месяцы
        {
            Январь   = 1,
            Февраль  = 2,
            Март     = 3,
            Апрель   = 4,
            Май      = 5,
            Июнь     = 6,
            Июль     = 7,
            Август   = 8,
            Сентябрь = 9,
            Октябрь  = 10,
            Ноябрь   = 11,
            Декабрь  = 12
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConsoleCyrilicInputOutput();
            Start();
        }

        /// <summary>
        /// Выполнение 1-го задания
        /// </summary>
        /// <param name="zd"></param>
        /// Параметр zd имеет тип перечисления zadanya и передается в выводимую 
        /// шапку задания чтобы вывести номер задания.
        static void Задание1(zadanya zd)
        {
            string task1 = $"Запросить у пользователя минимальную и максимальную тем-  *\n" +
                           $"* пературу за сутки и вывести среднесуточную температуру.   *\n" +
                           $"* Если пользователь указал месяц из зимнего периода, а      *\n" +
                           $"* средняя температура > 0, вывести сообщение «Дождливая     *\n" +
                           $"* зима».                                                    *";

            Menu_TasksHead((int)zd, task1);
            month:
            Console.Write("Введите 0 для выхода или номер месяца: ");
            int month = int.Parse(Console.ReadLine());

            if (month >= 1 && month <= 12)
            {
                begin:
                Console.WriteLine();
                Console.Write("Введите минимальную температуру за сутки: ");
                double minTmp = double.Parse(Console.ReadLine());

                max_temp:
                Console.WriteLine();
                Console.Write("Введите максимальную температуру за сутки: ");
                double maxTmp = double.Parse(Console.ReadLine());

                if (minTmp > maxTmp)
                {
                    chs:
                    Console.WriteLine($"Вы ввели минимальную {minTmp} и максимальную {maxTmp}!");
                    Console.WriteLine("Минимальная температура не может быть больше максимальной !\nУ вас есть выбор:\n\n 0 -> ввод температур сначала\n 1 -> ввод снова только максимальную\n 2 -> выйти из задания");
                    Console.WriteLine();

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            goto begin;

                        case 1:
                            goto max_temp;

                        case 2:
                            return;

                        default:
                            goto chs;
                    }
                }
                else
                {
                    AverageTemp(month, minTmp, maxTmp);
                    cont:
                    Console.WriteLine();
                    Console.WriteLine("У вас есть выбор:\n0 -> Продолжить ввод температур сначала\n1 -> Выйти из задания");
                    Console.WriteLine();

                    int cont = int.Parse(Console.ReadLine());
                    switch (cont)
                    {
                        case 0:
                            goto month;

                        case 1:
                            return;

                        default:
                            goto cont;
                    }
                }

            }
            else if (month > 12)
            {
                Console.WriteLine();
                Console.WriteLine("Вы ввели неправильный номер месяца.\nВыберите число от 1 до 12 !\n");
                goto month;
            }

        }

        /// <summary>
        /// Выполнение 2-го задания
        /// </summary>
        /// <param name="zd"></param>
        /// Параметр zd имеет тип перечисления zadanya и передается в выводимую 
        /// шапку задания чтобы вывести номер задания.
        static void Задание2(zadanya zd)
        {
            string task2 = $"Запросить у пользователя порядковый номер текущего месяца *\n" +
                           $"* и вывести его название.                                   *";

            Menu_TasksHead((int)zd, task2);
            month:
            Console.Write("Введите 0 для выхода или номер месяца: ");
            int month = int.Parse(Console.ReadLine());

            if (month >= 1 && month <= 12)
            {
                Display_Month(month);
                goto month;
            }
            else if (month > 12)
            {
                Console.WriteLine();
                Console.WriteLine("Вы ввели неправильный номер месяца.\nВыберите 0 для выхода или число от 1 до 12!\n");
                goto month;
            }

        }

        /// <summary>
        /// Выполнение 3-го задания
        /// </summary>
        /// <param name="zd"></param>
        /// Параметр zd имеет тип перечисления zadanya и передается в выводимую 
        /// шапку задания чтобы вывести номер задания.
        static void Задание3(zadanya zd)
        {

            string task3 = $"Определить, является ли введённое пользователем число     *\n" +
                           $"* чётным.                                                   *";

            Menu_TasksHead((int)zd, task3);
            начало:
            Console.Write("Введите 0 для выхода или любое положительное целое число: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                ЧётноеНечётное(number);
                goto начало;
            }

        }

        /// <summary>
        /// Выполнение 4-го задания
        /// </summary>
        /// <param name="zd"></param>
        /// Параметр zd имеет тип перечисления zadanya и передается в выводимую 
        /// шапку задания чтобы вывести номер задания.
        static void Задание4(zadanya zd)
        {

            string task4 = $"Для полного закрепления понимания простых типов найдите   *\n" +
                           $"* любой чек, либо фотографию этого чека в интернете и схе-  *\n" +
                           $"* матично  нарисуйте его в консоли, только за место дина-   *\n" +
                           $"* мических, по вашему мнению, данных (это может быть дата,  *\n" +
                           $"* название магазина, сумма покупок) подставляйте переменные *\n" +
                           $"* которые были заранее заготовлены до вывода на консоль.    *";

            Menu_TasksHead((int)zd, task4);
            Console.Write("Для просмотра чека нажмите любую клавишу !!! ");
            Console.ReadLine();
            Console.WriteLine();
            Чек();
        }

        /// <summary>
        /// Выполнение 5-го задания
        /// </summary>
        /// <param name="zd"></param>
        /// Параметр zd имеет тип перечисления zadanya и передается в выводимую 
        /// шапку задания чтобы вывести номер задания.
        static void Задание5(zadanya zd)
        {

            string task5 = $"Для полного закрепления битовых масок, попытайтесь        *\n" +
                           $"* создать универсальную структуру расписания недели, к      *\n" +
                           $"* примеру, чтобы описать работу какого либо офиса. Явный    *\n" +
                           $"* пример - офис номер 1 работает со вторника до пятницы,    *\n" +
                           $"* офис номер 2 работает с понедельника до воскресенья и     *\n" +
                           $"* выведите его на экран консоли.                            *";

            Menu_TasksHead((int)zd, task5);
            Console.Write("Для продолжения нажмите любую клавишу !!! ");
            Console.ReadLine();
            Console.WriteLine();

            График Выходные_Ивана = График.Вторник | График.Среда | График.Пятница | График.Суббота | График.Понедельник;
            График Выходные_Петра = График.Среда | График.Четверг | График.Суббота | График.Воскресенье | График.Вторник;
            График Выходные_Васи = График.Четверг | График.Пятница | График.Воскресенье | График.Понедельник | График.Среда;

            График Рыбалка_вместе = Выходные_Ивана & Выходные_Петра & Выходные_Васи;

            Console.WriteLine("Когда смогут ребята сходить вместе на рыбалку при таком графике? ");
            Console.WriteLine();
            Console.WriteLine($"Выходные дни Ивана: {Выходные_Ивана}");
            Console.WriteLine($"Выходные дни Петра: {Выходные_Петра}");
            Console.WriteLine($"Выходные дни Васи:  {Выходные_Васи}");
            Console.WriteLine();
            Console.WriteLine($"Ребята смогут пойти вместе на рыбалку только в {Рыбалка_вместе} !!!");
            Console.WriteLine();

            Console.Write("Для выхода из задания нажмите любую клавишу !!! ");
            Console.ReadLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Шапка заданий, которая выводит номер задания и само задание.
        /// </summary>
        /// <param name="zd"></param>
        /// Номер задания
        /// 
        /// <param name="tsk"></param>
        /// Само задание
        static void Menu_TasksHead(int zd, string tsk)
        {
            Console.Clear();
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"*                  З А Д А Н И Е   N:{zd}                      *");
            Console.WriteLine("*                                                           *");
            Console.Write($"* {tsk}                                                          \n");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод номера месяца и его названия
        /// </summary>
        /// <param name="mnth"></param>
        static void Display_Month(int mnth)
        {
            Console.WriteLine($"Месяц {mnth} ==> это {(Месяцы)mnth}");
            Console.WriteLine();
        }

        /// <summary>
        /// Определение является ли чётным или нечетным и его вывод.
        /// </summary>
        /// <param name="num"></param>
        static void ЧётноеНечётное(int num)
        {
            int rez;
            if (num % 2 == 0)
            {
                rez = 0;
            }
            else
            {
                rez = 1;
            }
            Console.WriteLine($"Число {num} ==> это {(OddEven)rez}");
            Console.WriteLine();
        }

        /// <summary>
        /// Меню перехода на задания и выход.
        /// </summary>
        static void Menu_StartHead()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*               З А Д А Н И Я    У Р О К А  N:2             *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Задание N:1 => 1                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Задание N:2 => 2                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Задание N:3 => 3                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Задание N:4 => 4                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Задание N:5 => 5                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*     Выход       => 6                                      *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine();

        }

        /// <summary>
        /// Инициализация и сохранение в переменные данных чека и его вывод.
        /// </summary>
        static void Чек()
        {

            string store = "М А Г А З И Н   *О К Е А Н*";
            string sell_number = "128";
            string shift = "5";
            string product1_name = "Белуга х/к  вак. уп. кус";
            string product1_quantity = "1.853";
            string product1_price = "286.00";
            string product1_cost = Math.Round(double.Parse(product1_quantity) * double.Parse(product1_price), 2).ToString();
            string oper_num = "01";

            string product2_name = "Бонаква 0,5л";
            string product2_quantity = "2.000";
            string product2_price = "9.20";
            string product2_cost = Math.Round(double.Parse(product2_quantity) * double.Parse(product2_price), 2).ToString();
            string product2_discount = "1.84";
            string sum = Math.Round((double.Parse(product1_quantity) * double.Parse(product1_price)) + (double.Parse(product2_quantity) * double.Parse(product2_price) - double.Parse(product2_discount)), 2).ToString();

            string total_discount = "27.33";
            string total = Math.Round((double.Parse(product1_quantity) * double.Parse(product1_price)) + (double.Parse(product2_quantity) * double.Parse(product2_price) - double.Parse(product2_discount)) - double.Parse(total_discount), 2).ToString();
            string cash = "600.00";
            string cash_got = "600.00";
            string change = Math.Round(double.Parse(cash_got) - double.Parse(total), 2).ToString(); //80.81;
            string doc = "ДОК. 00000382";
            string cash_register = "#0189 К30";
            DateTime date = new DateTime(2022, 5, 17, 16, 56, 0);
            string sell_date = date.ToShortDateString();
            string sell_time = date.ToString("t");



            Console.WriteLine("*************************************************************");
            Console.WriteLine($"*               {store}                 *");
            Console.WriteLine("*                       *** ЧЕК ***                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine($"*              Продажа N:{sell_number}    Смена N:{shift}                   *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"*           {product1_name}                        *");
            Console.WriteLine($"*            {oper_num}       {product1_quantity} Х {product1_price} ={product1_cost}                *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"*           {product2_name}                                    *");
            Console.WriteLine($"*            {oper_num}       {product2_quantity} Х   {product2_price}  ={product2_cost}                 *");
            Console.WriteLine($"*           СКИДКА                    ={product2_discount}                 *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"*           ВСЕГО                    ={sum}                *");
            Console.WriteLine($"*           СКИДКА                    ={total_discount}                *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine($"*           ИТОГО                     ={total_discount}                *");
            Console.WriteLine($"*           НАЛИЧНЫМИ                ={cash}                *");
            Console.WriteLine($"*           ПОЛУЧЕНО                 ={cash_got}                *");
            Console.WriteLine($"*           СДАЧА                     ={change}                *");
            Console.WriteLine($"*           {doc}                                   *");
            Console.WriteLine($"*           {cash_register}    {sell_date}    {sell_time}                *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*               * СПАСИБО ЗА ПОКУПКУ *                      *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
            Console.Write("Для выхода из задания нажмите любую клавишу !!! ");
            Console.ReadLine();
            Console.WriteLine();

        }

        /// <summary>
        /// Вывод меню выбора заданий.
        /// </summary>
        static void Start()
        {

            begin_menu:
            Menu_StartHead();

            input:
            Console.Write("Введите 6 для выхода или номер задания: ");

            int tasks = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (tasks >= 1 && tasks <= 6)
            {
                switch (tasks)
                {
                    case 1:
                        Задание1(zadanya.zadanie1);
                        break;

                    case 2:
                        Задание2(zadanya.zadanie2);
                        break;

                    case 3:
                        Задание3(zadanya.zadanie3);
                        break;

                    case 4:
                        Задание4(zadanya.zadanie4);
                        break;

                    case 5:
                        Задание5(zadanya.zadanie5);
                        break;

                    case 6:
                        vixod_iz_progi = true;
                        break;

                    default:
                        goto begin_menu;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неправильный номер !\nВыберите число от 1 до 6\n");
                goto input;
            }

            if (vixod_iz_progi)
            {
                Menu_Exit();
            }
            else
            {
                goto begin_menu;
            }
        }

        /// <summary>
        /// Выход из программы.
        /// </summary>
        static void Menu_Exit()
        {
            Console.WriteLine("Спасибо что пользуетесь нашей программой !\nПодтвердите выход нажатием Enter !");
            Console.ReadLine();
        }

        /// <summary>
        /// Вычисление средней температуры и его вывод.
        /// </summary>
        /// <param name="mon"></param>
        /// номер месяца
        /// 
        /// <param name="min"></param>
        /// минимальная температура
        /// 
        /// <param name="max"></param>
        /// максимальная температура
        static void AverageTemp(int mon, double min, double max)
        {

            double avgTmp = (min + max) / 2;
            Console.WriteLine();
            Console.WriteLine($"Вы ввели минимальную {min} и максимальную {max}!");
            Console.WriteLine($"Средняя суточная температура в месяце ({(Месяцы)mon}) ==> {avgTmp} градуса !");
            if (avgTmp > 0 && ((int)Зима.Январь == mon || (int)Зима.Февраль == mon || (int)Зима.Декабрь == mon))
            {
                Console.WriteLine("Дождливая зима !!!");
            }
        }

        /// <summary>
        /// Ввод и вывод в консоли на кирилице.
        /// </summary>
        static void ConsoleCyrilicInputOutput()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
        }
    }
}

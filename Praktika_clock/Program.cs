using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praktika_clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol_draw = '█';                         //символ для заполнения(изменения) массива
            Console.CursorVisible = false;                  //скрываем курсор
            Console.ForegroundColor = ConsoleColor.Green;   //меняем цвет шрифта в консоли

            int position_x = 0;    //отступы цифр друг от друга по X

            bool clock_on = true;  //определение работы часов (для бесконечного цикла вывода времени)

            char[,] part_number = new char[11, 10];   //создание двумерного массива - основа для рисования цифры

            int first_number = 0,     //первая цифра (в часах, минутах, секундах)
                second_number = 0,    //вторая цифра
                hours = 0,            //кол-во часов
                minutes = 0,          //кол-во минут
                seconds = 0;          //кол-во секунд

            string time_now = " ";    //запись текущего времени

            /*------------------------------------------------------------------------------------------------------------*/

            //создание общих сегментов

            //верхний сегмент
            void up_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (i == 0 && j != 0 && j != 9) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //правый верхний сегмент
            void right_up_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (j == 9 && i != 0 && i != 5 && i <= 5) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //правый нижний сегмент
            void right_down_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (j == 9 && i != 0 && i != 5 && i >= 5 && i != 10) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //нижний сегмент
            void down_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (i == 10 && j != 0 && j != 9) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //левый нижний сегмент
            void left_down_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (j == 0 && i != 5 && i > 5 && i != 10) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //левый верхний сегмент
            void left_up_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (j == 0 && i != 0 && i != 5 && i <= 5) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //центральный сегмент
            void center_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (i == 5 && j != 0 && j != 9) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //двоеточие
            void colon_segment()
            {
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        if (i >= 2 && i <= 3 && j >= 5 && j <= 6) part_number[i, j] = symbol_draw;
                        if (i >= 7 && i <= 8 && j >= 5 && j <= 6) part_number[i, j] = symbol_draw;
                    }
                }
            }

            //рисование цифр в семи сегментном формате
            void draw_clock(int number)
            {
                if (position_x == 120) position_x = 0;  //возвращение в начало оси X

                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        part_number[i, j] = ' ';
                    }
                }

                switch (number)
                {
                    //0
                    case 0:
                        up_segment();
                        right_up_segment();
                        right_down_segment();
                        down_segment();
                        left_down_segment();
                        left_up_segment();
                        break;

                    //1
                    case 1:
                        right_up_segment();
                        right_down_segment();
                        break;

                    //2
                    case 2:
                        up_segment();
                        right_up_segment();
                        center_segment();
                        left_down_segment();
                        down_segment();
                        break;

                    //3
                    case 3:
                        up_segment();
                        right_up_segment();
                        center_segment();
                        right_down_segment();
                        down_segment();
                        break;

                    //4
                    case 4:
                        left_up_segment();
                        center_segment();
                        right_up_segment();
                        right_down_segment();
                        break;

                    //5
                    case 5:
                        up_segment();
                        left_up_segment();
                        center_segment();
                        right_down_segment();
                        down_segment();
                        break;

                    //6
                    case 6:
                        up_segment();
                        left_up_segment();
                        center_segment();
                        right_down_segment();
                        down_segment();
                        left_down_segment();
                        break;

                    //7
                    case 7:
                        up_segment();
                        right_up_segment();
                        right_down_segment();
                        break;

                    //8
                    case 8:
                        up_segment();
                        right_up_segment();
                        center_segment();
                        right_down_segment();
                        down_segment();
                        left_down_segment();
                        left_up_segment();
                        break;

                    //9
                    case 9:
                        up_segment();
                        right_up_segment();
                        center_segment();
                        right_down_segment();
                        down_segment();
                        left_up_segment();
                        break;

                    //:
                    case 10:
                        colon_segment();
                        break;
                }

                //вывод на консоль нового массива
                for (int i = 0; i < part_number.GetLength(0); i++)
                {
                    for (int j = 0; j < part_number.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(j + position_x, i + 2);
                        Console.Write(part_number[i, j]);
                    }

                    Console.WriteLine();
                }

                position_x += 15;

            }

            //получение текущего времени

            time_now = DateTime.Now.ToString("HH");   //получение часов в строчном формате
            hours = Convert.ToInt32(time_now);        //перевод в целый тип

            time_now = DateTime.Now.ToString("mm");   //получение минут в строчном формате   
            minutes = Convert.ToInt32(time_now);

            time_now = DateTime.Now.ToString("ss");   //получение секунд в строчном формате
            seconds = Convert.ToInt32(time_now);

            while (clock_on == true)
            {
                seconds++;

                //расчет времени (прототип обычных часов, 60 с = 1 мин, 60 мин = 1 ч, 24 ч = сутки)
                if (seconds == 60) 
                { 
                    seconds = 0; 
                    minutes++; 
                }

                if (minutes == 60) 
                { 
                    minutes = 0; 
                    hours++; 
                }

                if (hours == 24) hours = 0;

                //деление часов, минут, секунд на две отдельные цифры

                first_number = hours / 10;
                second_number = hours % 10;
                draw_clock(first_number);
                draw_clock(second_number);
                draw_clock(10);

                first_number = minutes / 10;
                second_number = minutes % 10;
                draw_clock(first_number);
                draw_clock(second_number);
                draw_clock(10);

                first_number = seconds / 10;
                second_number = seconds % 10;
                draw_clock(first_number);
                draw_clock(second_number);

                Thread.Sleep(1000);

            }
        }
    }
}
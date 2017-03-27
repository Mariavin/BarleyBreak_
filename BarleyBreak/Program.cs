using BarleyBreak.Data;
using BarleyBreak.Data.GameElement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Play1");
            string path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\BarleyBreak\Box.txt";
            try
            {
                string file = File.ReadAllText(path);
                Game newfield = new Game(ReadingFromFile.TextToBarleyBreak(file));
                Print.PrintGameArea(newfield.GameArea);
                Console.WriteLine("Введите любое значение,которое вы хотите передвинуть,для выхода нажмите 999");
                int value = Convert.ToInt32(Console.ReadLine());
                while (value != 999)
                {
                    newfield.Shift(value);
                    Print.PrintGameArea(newfield.GameArea);
                    value = int.Parse(Console.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error:File not found!");
            }

            Console.WriteLine("\nPlay2");
            Console.WriteLine("Введите любое значение костяшек на поле");
            var field1 = int.Parse(Console.ReadLine());
            Game2 k = new Game2(field1);
            //k.v();
            Print.PrintGameArea(k.GameArea);
            Console.WriteLine("Введите любое значение,которое вы хотите передвинуть,для выхода нажмите 999");
            var a = int.Parse(Console.ReadLine());
            while (a != 999)
            {
                k.Shift(a);
                if (k.IsSuccess())
                {
                    Console.WriteLine("ВЫ ВЫИГРАЛИ!Для выхода нажмите 999");
                }
                else
                {
                    Console.WriteLine("Попытайся еще раз");
                }
                Print.PrintGameArea(k.GameArea);
                a = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nPlay3");
            Game3 n = new Game3(16);            
            Print.PrintGameArea(n.GameArea);
            Console.WriteLine("Инструкция:Для выхода нажмите 999\nВвведите back для отката к предыдущему шагу\nДля продолжения нажмите play");
            Console.WriteLine("Введите любое значение,которое вы хотите передвинуть");
            var point = int.Parse(Console.ReadLine());
            var str = Convert.ToString(Console.ReadLine());
            while (point != 999)
            {               
                    if (str == "back")
                    {
                        n.Rollback();
                        Print.PrintGameArea(n.GameArea);
                        n.GetTagMemory();
                    }
                    if (str == "play")
                    { 
                        n.Shift(point);
                        Print.PrintGameArea(n.GameArea);
                        n.GetTagMemory();
                    }
                point = int.Parse(Console.ReadLine());
                str = Convert.ToString(Console.ReadLine());
                               
            }

            Console.ReadKey();
        }
    }
}







/*
//Console.WriteLine("Введите любое значение костяшек на поле, либо для выхода введите 999");
            //var a = int.Parse(Console.ReadLine());
            //while (a != 999)
            //{
            //    n.Shift(a);
            //    if (n.IsSuccess())
            //    {
            //        Console.WriteLine("все здорово");
            //    }
            //    else
            //    {
            //        Console.WriteLine("пытайся еще раз");
            //    }
            //    a = int.Parse(Console.ReadLine());
            //Game newfield = new Game(ReadingFromFile.TextToBarleyBreak(file));
            //Print.PrintGameArea(new Game(ReadingFromFile.TextToBarleyBreak(file)));

            //Game n2 = new Game(new int[] { 5, 2, 3, 4,
            //                                11, 1, 7, 8,
            //                                9, 6,10,0,
            //                                12,13,14,15 });

            //Console.WriteLine("Enter a variable");
            //int example = Convert.ToInt32(Console.ReadLine());
            //n2.Shift(example);
            //var coordinates = n2.GetLocation(example);
            //Console.WriteLine("New coordinates of the variable {0}({1},{2})", example, coordinates.X, coordinates.Y);

            ////======================================================           
            //string path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\BarleyBreak\Box.txt";
            //try
            //{
            //    string file = File.ReadAllText(path);
            //    Game newfield = new Game(ReadingFromFile.TextToBarleyBreak(file));
            //    Console.WriteLine("Enter a variable");
            //    int value = Convert.ToInt32(Console.ReadLine());
            //    newfield.Shift(value);
            //    var coordinatesone = newfield.GetLocation(value);
            //    Console.WriteLine("New coordinates of the variable {0}({1},{2})", value, coordinatesone.X, coordinatesone.Y);
            //}
            //catch(FileNotFoundException)
            //{
            //    Console.WriteLine("Error:File not found!");
            //}           
            //Console.ReadLine();       
*/
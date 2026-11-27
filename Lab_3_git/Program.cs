using System;
using System.Diagnostics;
namespace Lab_2
{
    class Program
    {
        static double IsUBool()
        {
            bool isBAccectable = false;
            double b = -1;
            while (!isBAccectable)
            {
                if (double.TryParse(Console.ReadLine(), out b))
                {
                    if (b < 0)
                        Console.WriteLine("Введите неотрицательное число: ");
                    else
                    {
                        isBAccectable = true;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число. Попробуйте снова\n");
                }
            }
            return b;
        }
        static int IsUInt()
        {
            bool isBAccectable = false;
            int b = -1;
            while (!isBAccectable)
            {
                if (int.TryParse(Console.ReadLine(), out b))
                {
                    if (b <= 0)
                        Console.WriteLine("Введите положительное число.");
                    else
                        isBAccectable = true;
                }

                else
                    Console.WriteLine("Вы ввели не число");
            }
            return b;

        }

        static int LenArray()
        {
            int n = IsUInt();
            return n;
        }
        static int[] RandomArray(int n)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(-10, 10);
            }
            return a;
        }
        static void OutputArray(int[] a)//ограничение по размеру массива
        {
            int n = a.Length;
            if (n > 10)
            {
                Console.WriteLine("Вы ввели слишком большую длину массива. Введите заново");
                //n = LenArray();
            }
            else
                Console.WriteLine(string.Join(" ", a));
        }
        static int[] CopyArray(int[] a)
        {
            int[] copy = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                copy[i] = a[i];
            //Console.WriteLine(string.Join(" ", copy));
            return copy;

        }
        static int[] GnomikSort(int[] a)
        {
            int i = 0;
            while (i < a.Length - 1)
            {
                //ограничение слева
                if (i >= 0)
                {

                    if ((a[i] <= a[i + 1]))
                    {
                        i++;
                    }
                    else
                    {
                        int ch = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = ch;
                        i--;
                    }

                }
                else
                {
                    i++;
                }
            }
            int[] gnom = a;
            return gnom;
        }
        static int[] SelectoinSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i; //минимум сейчас на i(?)
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[minIndex]) //настоящий минимум
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i) // Если мин не на своём месте поменяли местами
                {
                    int temp = a[i];
                    a[i] = a[minIndex];
                    a[minIndex] = temp;

                }
            }
            return a;
        }
        static double Formula()
        {
            Console.WriteLine("Введите 1 число");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Введите первое число: ");
            }

            Console.WriteLine("Введите 2 число, неотрицательное");
            double b = -1;
            IsUBool();
            double f = -4 * Math.Pow(Math.Sin(3 * a), 3) + (Math.Sqrt(b) / Math.Log(b + 2));
            return f;
        }
        static void GameOne()
        {
            double f = Formula();
            Console.WriteLine("Введите предполагаемый ответ:");
            double predpolozhenie;

            for (int i = 0; i < 3; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out predpolozhenie))
                {
                    Console.WriteLine("Введите предполагаемый ответ через запятую с 2 знаками после точки: ");

                }

                f = Math.Round(f, 2);
                if (Math.Abs(Math.Round(predpolozhenie, 2) - f) <= 0.01)
                {
                    Console.WriteLine("Вы угадали!:>\n");
                    i = 4;
                }

                else
                    Console.WriteLine("Вы не угадали:<\nПопробуйте снова: ");
            }
            Console.WriteLine($"Правильный ответ: {f}");

        }

        static void GameTwo()
        {

            Console.WriteLine("Марупова Вероника Владимировна 6104-090301D");

        }
        static void GameTree()
        {
            Console.Write("Введите длину массива: ");
            int n = LenArray();
            int[] resArray = RandomArray(n);


            Stopwatch sw1 = new Stopwatch();
            sw1.Start(); //отсчёт времени
                            //OutputArray(GnomikSort(resArray));
            Console.WriteLine("Сортировка гномиком:");
            OutputArray(GnomikSort(resArray));
            Console.WriteLine($"Время: {sw1.Elapsed.TotalMilliseconds} мс");
            sw1.Stop();

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            int[] copiedArray1 = CopyArray(resArray);
            Console.WriteLine("Сортировка выбором: ");
            OutputArray(SelectoinSort(copiedArray1));
            Console.WriteLine($"Время: {sw2.Elapsed.TotalMilliseconds} мс");
            sw2.Stop();


            if (sw1.ElapsedMilliseconds < sw2.ElapsedMilliseconds)
            {
                Console.WriteLine("Сортировка Гномиком оказалась быстрее");
            }
            else if (sw2.ElapsedMilliseconds < sw1.ElapsedMilliseconds)
            {
                Console.WriteLine("Сортировка Выбором оказалась быстрее");
            }
            else
                Console.WriteLine("Время одинаково");
        }
    

        static bool Exit()
        {
            bool TRUE = true;
            Console.WriteLine("Вы уверены, что хотите выйти?");
            string res = Console.ReadLine().ToLower();

            while ((res != "да") && (res != "нет"))
            {
                Console.WriteLine("Ответьте Да или Нет.");
                res = Console.ReadLine().ToLower();

            }

            switch (res)
            {
                case "да":
                    TRUE = false;
                    break;
                case "нет":
                    break;

            }

            return TRUE;
        }
        static void Main()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выбери 1 из 4 пунктов: \n1.Отгадай ответ \n2.Об авторе \n3.Сортировка массива \n4.Выход");
                int otvet;
                while (!int.TryParse(Console.ReadLine(), out otvet))
                {
                    Console.WriteLine("Введите число для пункта: ");

                }

                switch (otvet)
                {
                    case 1:

                        GameOne();
                        break;

                    case 2:

                        GameTwo();
                        break;

                    case 3:
                        GameTree();
                        break;

                    case 4:
                        if (Exit() == false)
                        {
                            flag = false;
                        }
                        break;
                }
            }

        }
    }
}
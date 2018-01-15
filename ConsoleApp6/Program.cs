using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); //читаю набор цифр
            string[] a = s.Split(' '); // создаю массив типа string, элементы которого мы берем со строки s, что разделены проблелом
          
                  
            for (int i = 0; i < a.Length; i++) //пробегаемся по массиву
            {
                int test = int.Parse(a[i]); // каждый элемент преобразовываю в тип int
                bool k = true; 
                if (test == 1) // 1 не простое число
                {
                    continue;
                }
                else
                {
                    for (int j = 2; j <= Math.Sqrt(test); j++)// достаточно проверить до корня числа
                    {
                        if (test % j == 0)
                        {
                            k = false; // если делится без остатка, значит число не простое, следовательно bool k = false
                        }
                    }
                    if (k == true)
                    {
                        Console.Write(a[i] + ' '); //в другом случае выводим это число
                    }
                }
            }

            Console.ReadKey();
        }
    }
}

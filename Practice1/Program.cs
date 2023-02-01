using System;
using System.Diagnostics.Tracing;
using System.Text;
namespace Practice1
{
    class Program
    {
        static string ChangedStr(string str)
        {
            string newStr;
            char[] mass = str.ToCharArray();
            int startPos = 0;
            
            if (str.Length == 0)
            {
                return "Неверный ввод";
            }
            else
            {
                if (str.Length % 2 == 0)
                {
                    Array.Reverse(mass);
                }
            }
            return new string(mass);

        }
        static void Main(string[] args)
        {
            string strInput;
            Console.WriteLine("Введите строку");
            strInput = Console.ReadLine();
            Console.WriteLine();
            strInput = ChangedStr(strInput);
            Console.WriteLine(strInput);
        }
    }
}
﻿using System.Text.RegularExpressions;

namespace Practice1
{
    class Program
    {
        static string ChangedStr(string str)
        {
            char[] mass = str.ToCharArray();
            for (int i = 0; i < mass.Length; i++)
            {
                if (char.IsUpper(mass[i]) == true)
                {
                    Console.WriteLine(mass[i]);
                }
                continue;
                
            }
            if (str.Length == 0)
            {
                return "Неверный ввод";
            }
            else
            {
                if (str.Length % 2 == 0)
                {
                    int mid = (mass.Length + 1) / 2;
                    char[] firstHalf = mass.Take(mid).ToArray();
                    char[] secondHalf = mass.Skip(mid).ToArray();
                    Array.Reverse(firstHalf);
                    Array.Reverse(secondHalf);
                    var final = firstHalf.Concat(secondHalf).ToArray();
                    return new string (final);
                }
                else
                {
                    char[] revMass = new char[mass.Length];
                    Array.Copy(mass, revMass, revMass.Length);
                    Array.Reverse(revMass);
                    var final = revMass.Concat(mass).ToArray();
                    return new string(final);
                }
            }
        }
        static void Main()
        {
            string strInput;
            Console.WriteLine("Введите строку");
            strInput = Console.ReadLine();
            if (Regex.IsMatch(strInput, "^[a-zA-Z0-9]*$"))
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                goto Reguest;
            }
            strInput = ChangedStr(strInput);
            Console.WriteLine(strInput);
            Reguest:
            Console.WriteLine("Ввести новую строку? 1 - Да, 2 - нет");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1) Main();
            else return;
        }
    }
}
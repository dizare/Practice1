﻿namespace Practice1
{
    class Program
    {
        static string ChangedStr(string str)
        {
            string newStr;
            char[] mass = str.ToCharArray();

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
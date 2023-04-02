using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            String inputString = Console.ReadLine();

            if (!CheckInputString(inputString)) return;

            int halfLengthLine = inputString.Length / 2;
            String result = inputString.Length % 2 == 0 ?
                ReverseLine(inputString.Substring(0, halfLengthLine)) + ReverseLine(inputString.Substring(halfLengthLine))
                : ReverseLine(inputString) + inputString;


            Console.WriteLine("Результат: {0}", result);
            CountingRepeatedCharacters(result, inputString);
            Console.WriteLine("Длинная подстрока с началом и концом из символов <aeiouy>: {0}", SubstringWithVowels(result));
            Console.WriteLine("Выберите метод сортировки Q/T (QuickSort / TreeSort):");
            SortingSelection(Console.ReadLine().ToString().ToUpper(), result);
            var indexDelet = IndexDeleted(result);
            Console.WriteLine("Урезанная строка: {1}, удалён символ - {0} с индекса {2}", 
                result[indexDelet],
                result.Remove(indexDelet, 1),
                indexDelet);
        }

        //Реверс строки inputString
        static String ReverseLine(String inputString)
        {
            var arrayLine = inputString.ToArray();
            Array.Reverse(arrayLine);
            return new String(arrayLine);
        }

        //Задание 2
        static bool CheckInputString(String inputString)
        {
            String result = "";
            if (!Regex.IsMatch(inputString, @"^[a-z]*$"))
            {
                Console.WriteLine("Были введены не подходящие символы. Не подходящих символы: ");
                foreach (var symbol in inputString)
                {
                    if (!Regex.IsMatch(symbol.ToString(), @"^[a-z]*$"))
                        result += symbol;
                }

                Console.WriteLine(result.Distinct().ToArray());
                return false;
            }
            return true;
        }

        //Задание 3
        static void CountingRepeatedCharacters(String resualt, String inputString)
        {
            HashSet<char> outLine = new HashSet<char>(inputString.ToCharArray());

            Console.WriteLine("\nСимвол (кол-во)");
            foreach (char symbolOutLine in outLine)
            {
                int countSymbol = 0;
                foreach (char symbolResualt in resualt) if (symbolResualt == symbolOutLine) countSymbol++;

                Console.WriteLine("{0} ({1})", symbolOutLine, countSymbol);
            }
        }

        //Задание 4
        static String SubstringWithVowels(String inputString)
        {
            char[] arrayString = inputString.ToCharArray();
            String vowels = "aeiouy";
            Predicate<char> predicate = e => vowels.Contains(e);
            int beginning = Array.FindIndex(arrayString, predicate),
                last = Array.FindLastIndex(arrayString, predicate);

            String resualt = "";

            if (beginning != -1) for (int i = beginning; i <= last; resualt += inputString[i], i++) ;
            else resualt = "Такой нету";

            return resualt;
        }

        //Задание 5
        static void SortingSelection(string choice, string result)
        {
            switch (choice)
            {
                case "Q":
                    Console.WriteLine("Реузльтат QuickSort: {0}", FastSort.QuickSort(result.ToCharArray()));
                    break;
                case "T":
                    Console.WriteLine("Реузльтат TreeSort: {0}", TreeNode.TreeSort(result.ToCharArray()));
                    break;
                default:
                    Console.WriteLine("Вы не выбрали сортировку");
                    break;
            }
        }
        //Задание 6
        static int IndexDeleted(string str_res)
        {
            int idnexDel;
            string str = "http://www.randomnumberapi.com/api/v1.0/random?max=" + (str_res.Length - 1) + "&count=1";
            try
            {
                var result = new HttpClient().GetAsync(new Uri(str)).Result.Content.ReadAsStringAsync().Result;
                idnexDel = Convert.ToInt32(result[1].ToString());
            }
            catch (Exception ex)
            {
                idnexDel = new Random().Next(str_res.Length);
            }
            return idnexDel;
        }
    }
}

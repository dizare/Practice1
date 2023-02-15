using System.Text.RegularExpressions;
namespace Practice1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите строку");
            string strInput = Console.ReadLine();

            if (!CheckString(strInput)) return;

            string strResult = ChangedStr(strInput);
            Console.WriteLine(strResult);
            NumOfReplays(strResult);
        }
        static string ChangedStr(string str)
        {
            char[] mass = str.ToCharArray();
            if (str.Length % 2 == 0)
            {
                int mid = (mass.Length + 1) / 2;
                char[] firstHalf = mass.Take(mid).ToArray();
                char[] secondHalf = mass.Skip(mid).ToArray();
                Array.Reverse(firstHalf);
                Array.Reverse(secondHalf);
                return new string(firstHalf) + new string(secondHalf);
            }
            else
            {
                Array.Reverse(mass);
                return new string(mass) + str;
            }
        }
        static bool CheckString(string str)
        {
            if (str.Length == 0)
            {
                Console.WriteLine("Не введены символы");
                return false;
            }
            if (!Regex.IsMatch(str, "^[a-z]*$"))
            {
                Console.WriteLine("Ошибка ввода\nНеверные символы:");
                Regex r = new Regex("[a-z]");
                for (int i = 0; i < str.Length; i++)
                {
                    if (!r.IsMatch(str[i].ToString()) || char.IsUpper(str[i]) || char.IsDigit(str[i]))
                    {
                        Console.Write(str[i]);
                    }
                }
                return false;
            }
            return true;
        }
        static void NumOfReplays(string str)
        {
            Console.WriteLine("Каждый символ входил в строку: ");
            List<char> tmp = new List<char>(str);
            foreach (var symbol in str.ToCharArray())
            {
                Predicate<char> removableSymbol = enumSymbols => enumSymbols == symbol;
                int numDelSymbols = tmp.RemoveAll(removableSymbol);
                if (numDelSymbols != 0) Console.WriteLine(symbol + " = " + numDelSymbols);
            }
        }
    }
}
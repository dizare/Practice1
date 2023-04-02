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
            SubString(strResult);
            Console.WriteLine("\nВыберите метод сортировки обработанной строки: \nQ - Быстрая сортировка, T - Сортировка деревом");
            Console.WriteLine("Выберите метод сортировки обработанной строки: \nQ - Быстрая сортировка, T - Сортировка деревом");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Q")
            {
                Console.WriteLine("\nРезультат сортировки QuickSort: ");
                Console.WriteLine(Sort.QuickSort(strResult));
            }
            else
            {
                Console.WriteLine("\nРезультат сортировки TreeSort: ");
                Console.WriteLine(Sort.TreeSort(strResult));
            }

            var deleteSymbol = WebRandom(strResult);
            Console.WriteLine("Урезанная обработанная строка: {0}, случайное число - {1}, удалён символ - {2}", strResult.Remove(deleteSymbol, 1), deleteSymbol + 1, strResult[deleteSymbol]);

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
                    char[] mass = str.ToCharArray();
                    char[] result = mass.Distinct().ToArray(); //удаление дубликатов неверных символов
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (!r.IsMatch(result[i].ToString()) || char.IsUpper(result[i]) || char.IsDigit(result[i]))
                        {
                            Console.Write(result[i]);
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
            static void SubString(string str)
            {
                Regex r = new Regex("^[aeiou]*$");
                char[] tmp = str.ToCharArray();
                Predicate<char> indexSymbol = e => r.IsMatch(e.ToString());
                if (Array.Exists(tmp, indexSymbol))
                {
                    int start = Array.FindIndex(tmp, indexSymbol);
                    int end = Array.FindLastIndex(tmp, indexSymbol);
                    Console.WriteLine("Самая длинная подстрока начинающаяся и заканчивающаяся на гласную:");
                    for (int i = start; i <= end; i++)
                    {
                        Console.Write(tmp[i].ToString());
                    }
                }
                else Console.WriteLine("Подстроки начинающаяся и заканчивающаяся на гласную не существует");
            }
            static int WebRandom(string str)
            {
                int ranNum;
                var client = new HttpClient();
                string strUrl = "http://www.randomnumberapi.com/api/v1.0/random?max=" + (str.Length - 1) + "&count=1";
                try
                {
                    var res = client.GetAsync(new Uri(strUrl)).Result.Content.ReadAsStringAsync().Result;
                    ranNum = Convert.ToInt32(res[1].ToString());
                }
                catch (Exception ex)
                {
                    ranNum = new Random().Next(str.Length);
                }
                return ranNum;
            }
        }
    }
}
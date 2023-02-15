using System.Text.RegularExpressions;
namespace Practice1
{
    class Program
    {
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
                var final = firstHalf.Concat(secondHalf).ToArray();
                return new string(final);
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
        static void Main()
        {
            string strInput;
            Console.WriteLine("Введите строку");
            strInput = Console.ReadLine();
            if (strInput.Length == 0)
            {
                Console.WriteLine("Ошибка ввода");
                goto Reguest;
            }
            if (Regex.IsMatch(strInput, "^[a-z]*$"))
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ошибка ввода\nНеверные символы:");
                for (int i = 0; i < strInput.Length; i++)
                {
                    Regex r = new Regex("[a-z]");
                    if (r.IsMatch(strInput, i) == false || char.IsUpper(strInput[i]) == true || char.IsDigit(strInput[i]) == true)
                    {
                        Console.WriteLine(strInput[i]);
                        continue;
                    }

                }
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
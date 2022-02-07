using System;

namespace KMP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte text:");
            string text = Console.ReadLine();

            Console.WriteLine("Zadejte vzor:");
            string vzor = Console.ReadLine();

            int vysledek = KMP(vzor, text);

            if (vysledek == -1)
                Console.WriteLine("Vzor nebyl nalezen.");
            else
                Console.WriteLine("Vzor byl nalezen a začíná na indexu {0}.", vysledek);

            Console.ReadKey();
        }
        static int KMP(string vzor, string text)
        {
            int[] shift = new int[vzor.Length]; //lps tabulka 

            int i, j;
            shift[0] = -1;
            for (i = 0, j = -1; i < vzor.Length - 1; i++, j++, shift[i] = j) 
                while (j >= 0 && vzor[i] != vzor[j])
                    j = shift[j];

            for (i = 0, j = 0; i < text.Length && j < vzor.Length; i++, j++)//procházení textu
                while (j >= 0 && text[i] != vzor[j])
                    j = shift[j];

            if (j == vzor.Length) //nalezení vzoru
                return i - vzor.Length;
            else
                return -1; //vzor není v hledaném textu
        }
    }
}




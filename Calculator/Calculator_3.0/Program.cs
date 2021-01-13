using System;

namespace Calculator_3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lommeregner. Indtast din ligning for at se resultatet.");
            Console.WriteLine("Eksempel: (2 + 5 * 9)");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');

        }

        //Denne methode kigger efter om input er nummer eller ej.
        public static bool CheckingNumber(string answer)
        {
            decimal value = 0;
            bool bChecking = decimal.TryParse(answer, out value);
            return bChecking;
        }

        //Denne methode kigger i gennem arrayet for at matche en med inputtet.
        public static bool CheckingOperand(string answer)
        {
            string[] operands = { "*", "/", "+", "-" };
            for (int i = 0; i < operands.Length; i++)
                if (operands[i] == answer)
                    return true;
            return false;
        }

        public static decimal GetTotal(decimal number, decimal total, string operand)
        {
            if (operand != null)
            {
                if (total != 0)
                {
                    switch (operand)
                    {
                        case ("*"):
                            {
                                total = total * number;
                                break;
                            }
                        case ("/"):
                            {
                                total = total / number;
                                break;
                            }
                        case ("+"):
                            {
                                total = total + number;
                                break;
                            }
                        case ("-"):
                            {
                                total = total - number;
                                break;
                            }
                    }
                }
                else
                    total = number;
            }
            else
                total = number;
            return total;
        }
    }
}
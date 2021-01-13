using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            bool bEnd = false;
            decimal total = 0;
            decimal number = 0;
            string strOperand = null;
            string strFormula = null;
            int counter = 1;

            Console.WriteLine("lommeregner. Skriv dit nummer en efter en.");
            Console.WriteLine("For at få resultatet skal du skrive = lige efter tallet.");


            do
            {
                string word = GetCounter(counter);

                Console.WriteLine("Indtast dit " + word + " nummer:");
                string strNumber = Console.ReadLine();

                //Denne her if sætning kigger efter = efter input tal.
                if (strNumber.Contains("="))
                {
                    strNumber = strNumber.Remove(strNumber.Length - 1, 1);
                    bEnd = true;
                }
                bool bChecking = CheckingNumber(strNumber);
                if (bChecking)
                {
                    strFormula += strNumber;
                    counter++;
                    number = Convert.ToDecimal(strNumber);
                    total = GetTotal(number, total, strOperand);

                    //Så længe vores bChecking eller bEnd er false kører denne loop.
                    bChecking = false;
                    while (!bChecking && !bEnd)
                    {
                        Console.WriteLine("Indtast din (+, -, /, *):");
                        strOperand = Console.ReadLine();
                        bChecking = CheckingOperand(strOperand);
                        if (bChecking)
                            strFormula += strOperand;
                        else
                            Console.WriteLine("Forkert operand!");
                    }
                }
                else
                    Console.WriteLine("Dette er ikke et tal.");
            }
            while (!bEnd);

            strFormula = strFormula + "=";
            Console.WriteLine("{0}{1}", strFormula, total.ToString());
            Console.ReadLine();
        }

        //Denne metode tæller, hvor mange tal der er indtastet og plusser med en hver gang.    
        public static string GetCounter(int counter)
        {
            string word = null;
            string[] words = { "1st", "2nd", "3rd" };
            if (counter < 3)
                word = words[counter - 1];
            else
                word = counter + "th";
            return word;
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
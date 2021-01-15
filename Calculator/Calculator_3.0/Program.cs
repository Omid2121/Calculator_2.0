using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Scanner
    {
        class Program
        {
            static void Main(string[] args)
            {
                Parser Parse = new Parser();
                while (true)    
                {
                    Console.Write("Skriv din ligning: ");
                    Parse.InitScan();
                    Parse.InputLine = Console.ReadLine();
                    Parse.curr_tok = Parse.get_token();
                    Console.WriteLine(Parse.expr());
                }
            }
        }

        public enum token_value
        {
            NAME, NUMBER,
            PLUS = '+', MINUS = '-',
            MUL = '*', DIV = '/',
            ASSIGN = '=',
        };

        public token_value curr_tok; 
        public double number_value; 
        public string name_string;     

        private char[] StringToParse;
        private int charpos = 0;
        private StringBuilder numberSB = new StringBuilder();

        public Dictionary<string, double> SymbolTable = new Dictionary<string, double>();

        public string InputLine
        {
            set
            {
                string line = value + "\n";
                StringToParse = line.ToCharArray();
            }
        }

        private char GetChar()
        {
            char ch = StringToParse[charpos];
            charpos++;
            return ch;
        }

        public void PutBackChar()
        {
            charpos--;
        }

        public void InitScan()
        {
            charpos = 0;
            number_value = 0.0;
            name_string = "";
        }

        public token_value get_token()
        {
            char ch;

            do 
            {
                ch = GetChar();
            }
            while (ch != '\n' && char.IsWhiteSpace(ch));
            switch (ch)
            {
                case '\n':
                    return curr_tok;
                case '*':
                case '/':
                case '+':
                case '-':
                case '=':
                    curr_tok = (token_value)(ch);
                    return curr_tok;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                case ',':
                    if (ch == '.') ch = ',';
                    numberSB.Append(ch);
                    ch = GetChar();
                    if (ch == '.') ch = ',';
                    while (char.IsDigit(ch) || ch == ',')
                    {
                        numberSB.Append(ch);
                        ch = GetChar();
                    }
                    PutBackChar();
                    try
                    {
                        number_value = Convert.ToDouble(numberSB.ToString());
                        numberSB.Remove(0, numberSB.Length);
                    }
                    catch
                    {
                        Console.WriteLine("Fout in formaat van getal.");
                    }
                    return token_value.NUMBER;
                default:

                    Console.WriteLine("Bad token.");
                   return token_value.NUMBER;
            }
        }     

    }

    class Parser : Scanner
    {
        public Parser()
        {
            SymbolTable.Add("pi", Math.PI);
            SymbolTable.Add("e", Math.E);
        }


        public double prim()
        {

        }

        public double term()
        {
          
        }

        public double expr()
        {
            
        }
    }
}

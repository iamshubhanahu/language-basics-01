using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string Variable_A = equation.Split('*')[0];
            string Variable_B = equation.Split('*')[1].Split('=')[0];
            string Variable_C = equation.Split('=')[1];

            
            bool Flag_A = Int32.TryParse(Variable_A, out int First);
            bool Flag_B = Int32.TryParse(Variable_B, out int Second);
            bool Flag_C = Int32.TryParse(Variable_C, out int Result);


            string Fullequation = "";

            if (Flag_A == false)
            {
                if (Result % Second == 0)
                {                              
                    string temp = (Result / Second) + "";
                    Fullequation += temp + "*" + Variable_B + "=" + Variable_C;
                }
                else
                    return -1;
            }

            if (Flag_B == false)
            {
                if (Result % First == 0)
                {
                    string temp = (Result / First) + "";
                    Fullequation += Variable_A + "*" + temp + "=" + Variable_C;
                }
                else
                    return -1;
            }

            if (Flag_C == false)
            {
                string temp = (First * Second) + "";
                Fullequation += Variable_A + "*" + Variable_B + "=" + temp;
            }


           
            if (equation.Length != Fullequation.Length)
            {
                return -1;
            }
            else
            {
                int var = equation.IndexOf('?');
                return (int)(Fullequation[var] -'0');
                    
                
            }
           
        }
    }
}

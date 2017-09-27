using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EquationSolder
{

    public static class EquationSolder
    {
        public static int[] ParseString(String line) {
            Regex rightSymbols = new Regex(@"[\-]{0,1}[0-9]{1,}[x]{1}[\^]{1}[2]{1}[\+]{1}[\-]{0,1}[0-9]{1,}[x]{1}[\+]{1}[\-]{0,1}[0-9]{1,}[\=]{1}[0]{1}");
            if (rightSymbols.IsMatch(line)) {
                int[] coefs = new int[3];
                int counterForCoefs = 0;
                string patternForParsingCoefs = @"(?:x\^2+)|(?:x+)|(?:\=0)|[+]";
                string[] lineInArray = Regex.Split(line, patternForParsingCoefs);
                String currentCoef = "";
                for (int i = 0; i < lineInArray.Length; i++)
                {
                    if (lineInArray[i].Equals(""))
                    {
                        coefs[counterForCoefs] = Int32.Parse(currentCoef);
                        currentCoef = "";
                        counterForCoefs++;
                        continue;
                    }
                    currentCoef = currentCoef + lineInArray[i];
                }
                return coefs;
            }else{
                Console.WriteLine("Неправильный формат введенной строки!");
                return null;
            }
        }

        public static int CalcDiscriminant(int[] coef) {
            int a = coef[0];
            int b = coef[1];
            int c = coef[2];
            int discriminant = (b * b) - (4 * a * c);
            return discriminant;
        }
        public static bool ValidateDiscriminant(int discriminant) {
            if (discriminant >= 0)
                return true;
            Console.WriteLine("У вашего квадратного уравнения нет действительных корней!");
            return false;
        }

        public static double CalcRoots(int discriminant, int[] coefs, bool first){
            int a = coefs[0];
            int b = coefs[1];
            int sign = 1;
            if (!first)
                sign *= -1;
            if (a == 0)
            {
                Console.WriteLine("Ваше уравнение не является квадратным!");
                return -1;
            }
            double root = ( (-1 * b) + (sign * Math.Sqrt(discriminant)) ) / (2*a);
            return root;
        } 

        public static String getResults(double root1, double root2)
        {
            return "Первый корень = " + root1 + "\nВторой корень = " + root2;
        }
    }
}

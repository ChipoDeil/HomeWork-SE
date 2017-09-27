using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolderConsole
{
    class EquationSolderConsole
    {
        static void Main(string[] args)
        {
            String equation = Console.ReadLine();
            int[] coefs = EquationSolder.EquationSolder.ParseString(equation);
            if (coefs == null) {
                return;
            }
            int discriminant = EquationSolder.EquationSolder.CalcDiscriminant(coefs);
            Console.WriteLine(discriminant);
            if (!EquationSolder.EquationSolder.ValidateDiscriminant(discriminant)) {
                return;
            }
            double root1 = EquationSolder.EquationSolder.CalcRoots(discriminant, coefs, true);
            double root2 = EquationSolder.EquationSolder.CalcRoots(discriminant, coefs, false);
            Console.WriteLine(EquationSolder.EquationSolder.getResults(root1, root2));
        }
    }
}

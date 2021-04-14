using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            GaussMethod Solution = new GaussMethod(3, 3);
            MinMax minmax = new MinMax(3,3);

            Solution.RightPart[0] = 7;
            Solution.RightPart[1] = 4;
            Solution.RightPart[2] = 9;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) {
                    Solution.Matrix[i][j] = rnd.Next(1,100);
                    minmax.Matrix[i][j] = Solution.Matrix[i][j];
                }

            minmax.count_minmax();

            minmax.show();
            Console.WriteLine("\n**********\n");

            Solution.showMatrix_Right_part();

            Solution.SolveMatrix();
            Console.WriteLine("\n**********\n");

            Solution.showMatrix_Right_part();
            Console.WriteLine("\n**********\n");

            Console.WriteLine($"x1:{Solution.Answer[0]}, x2:{Solution.Answer[1]}, x3:{Solution.Answer[2]}");
            Console.ReadLine();
        }
    }
}

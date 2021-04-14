using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheory
{
    public class MinMax
    {
        public uint RowCount;
        public uint ColumCount;
        public double[][] Matrix { get; set; }
        public double[] Min { get; set; }
        public double[] Max { get; set; }
        public double A_MaxMin { get; set; }
        public double B_MinMax { get; set; }
        public MinMax(uint Row, uint Colum)
        {
            Matrix = new double[Row][];
            for (int i = 0; i < Row; i++)
                Matrix[i] = new double[Colum];
            RowCount = Row;
            ColumCount = Colum;
            Min = new double[Row];
            Max = new double[Colum];

            //обнулим массив
            for (int i = 0; i < Row; i++)
            {
                Min[i] = 0;
                for (int j = 0; j < Colum; j++)
                {
                    Matrix[i][j] = 0;
                    Max[j] = 0;
                }
            }
        }

        public void count_minmax()
        {
            for (int i = 0; i < RowCount; i++)
            {
                Min[i] = Matrix[i][0];
                for (int j = 0; j < ColumCount; j++)
                {
                    Max[j] = Matrix[0][j];                    
                }
            }

            for (int i=0;i<RowCount;i++)
            {
                for(int j = 0; j < ColumCount; j++)
                {
                    if (Matrix[i][j] < Min[i])
                        Min[i] = Matrix[i][j];
                    if (Matrix[i][j] > Max[j])
                        Max[j] = Matrix[i][j];
                }
            }


            A_MaxMin = Min[0];
            B_MinMax = Max[0];
            for (int i = 0; i < RowCount; i++)
            {
                if (Min[i] > A_MaxMin)
                    A_MaxMin = Min[i];
                for (int j = 0; j < ColumCount; j++)
                {
                    if (Max[j] < B_MinMax)
                        B_MinMax = Max[j];
                }
            }
        }

        public void show()
        {
            for (int i = 0, r=0; i < RowCount+1; i++)
            {
                for (int j = 0, c=0; j < ColumCount+1; j++)
                {
                    if (j == ColumCount && r < 3)
                    {
                        Console.Write($" | {Min[r]}\n");
                        r++;
                    }
                    else if (i < RowCount)
                        Console.Write($" {Matrix[i][j]},");
                    else if (i == RowCount && c < 3)
                    {
                        Console.Write($" {Max[c]},");
                        c++;
                    }
                }
            }

            Console.WriteLine("\n**********\n");

            Console.WriteLine($"A_MaxMin:{A_MaxMin}, B_MinMax:{B_MinMax}");
        }
    }

}

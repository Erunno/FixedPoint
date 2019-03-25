using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.GaussianElimination
{
    /**/
    class MatrixDouble
    {
        private double[,] matrix;
        private double delta;
        int rows, columns;

        public MatrixDouble(double[,] matrix)
        {
            this.matrix = matrix;
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);
            delta = (double)1 / 100;
        }

        public void GaussElim()
        {
            int currentCol = 0;
            for (int rowPiv = 0; rowPiv < rows; rowPiv++)
            {
                while (currentCol < columns && !TrySetPivot(rowPiv, currentCol))
                    currentCol++;

                if (currentCol == columns) return; //there is just zero rows

                for (int rowBelowPivot = rowPiv + 1; rowBelowPivot < rows; rowBelowPivot++) //making zeros below pivot
                    EliminateNumBelowPivot(rowPiv ,rowBelowPivot, currentCol);
            }
        }

        private bool TrySetPivot(int row, int col) 
        {
            for (int i = row; i < rows; i++)
                if(!IsDeltaZero(matrix[i,col]))
                {
                    SwapRows(row, i);
                    return true;
                }

            return false;
        }

        private void EliminateNumBelowPivot(int rowPiv, int rowElim, int pivotCol)
        {
            if (IsDeltaZero(matrix[rowElim, pivotCol])) //if there is already zero there is no work...
                return;

            double coef = matrix[rowPiv, pivotCol] / matrix[rowElim, pivotCol];

            for (int col = pivotCol; col < columns; col++)
                matrix[rowElim, col] = matrix[rowElim, col] * coef - matrix[rowPiv, col];
        }

        private void SwapRows(int row1, int row2)
        {
            for (int i = 0; i < columns; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        private bool IsDeltaZero(double d) => d > -delta && d < delta; 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    sb.Append(matrix[i, j] + "\t");
                sb.Append('\n');
            }

            return sb.ToString();
        }
        
    }//*/
}

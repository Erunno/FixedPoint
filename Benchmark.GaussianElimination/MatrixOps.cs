using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuni.Arithmetics.FixedPoint;

namespace Benchmark.GaussianElimination
{
    class MatrixOps<Q> where Q : QFormat<Q>
    {
        private Fixed<Q>[,] matrix;
        private Fixed<Q> delta;
        int rows, columns;

        public MatrixOps(Fixed<Q>[,] matrix)
        {
            this.matrix = matrix;
            rows = matrix.GetLength(0);
            columns = matrix.GetLength(1);
            delta = (Fixed<Q>)1 / 100;
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
                if(!matrix[i,col].IsZero(delta))
                {
                    SwapRows(row, i);
                    return true;
                }

            return false;
        }

        private void EliminateNumBelowPivot(int rowPiv, int rowElim, int pivotCol)
        {
            if (matrix[rowElim, pivotCol].IsZero(delta)) //if there is already zero there is no work...
                return;

            Fixed<Q> coef = matrix[rowPiv, pivotCol] / matrix[rowElim, pivotCol];

            for (int col = pivotCol; col < columns; col++)
                matrix[rowElim, col] = matrix[rowElim, col] * coef - matrix[rowPiv, col];
        }

        private void SwapRows(int row1, int row2)
        {
            for (int i = 0; i < columns; i++)
            {
                Fixed<Q> temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

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

    }
}

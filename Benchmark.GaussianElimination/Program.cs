﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Cuni.Arithmetics.FixedPoint;

namespace Benchmark.GaussianElimination
{

    public class Program
    {
        [Benchmark]
        public void DoubleMatrix()
        {
            double[,] _m = new double[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixDouble dM = new MatrixDouble(_m);
            dM.GaussElim();
        }

        [Benchmark]
        public void IntegerMatrix()
        {
            int[,] _m = new int[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixInt iM = new MatrixInt(_m);
            iM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Ops_Q24_8()
        {
            Fixed<Q24_8>[,] _m = new Fixed<Q24_8>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixOps<Q24_8> fM = new MatrixOps<Q24_8>(_m);
            fM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Ops_Q16_16()
        {
            Fixed<Q16_16>[,] _m = new Fixed<Q16_16>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixOps<Q16_16> fM = new MatrixOps<Q16_16>(_m);
            fM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Ops_Q8_24()
        {
            Fixed<Q8_24>[,] _m = new Fixed<Q8_24>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixOps<Q8_24> fM = new MatrixOps<Q8_24>(_m);
            fM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Methods_Q24_8()
        {
            Fixed<Q24_8>[,] _m = new Fixed<Q24_8>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixMethods<Q24_8> fM = new MatrixMethods<Q24_8>(_m);
            fM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Methods_Q16_16()
        {
            Fixed<Q16_16>[,] _m = new Fixed<Q16_16>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixMethods<Q16_16> fM = new MatrixMethods<Q16_16>(_m);
            fM.GaussElim();
        }

        [Benchmark]
        public void FixedMatrix_Methods_Q8_24()
        {
            Fixed<Q8_24>[,] _m = new Fixed<Q8_24>[,] {
                {17, 21, 5, 8, 18, 5, 20, 19, 11, 7, 31, 7, 36, 15, 15, 27, 31, 3, 15, 2, 11, 30, 7, 34, 42},
                {36, 28, 0, 12, 31, 12, 29, 13, 31, 26, 27, 38, 7, 19, 0, 38, 15, 15, 16, 28, 37, 6, 34, 25, 42},
                {33, 22, 4, 10, 39, 31, 29, 27, 13, 11, 12, 30, 4, 8, 27, 39, 18, 18, 16, 10, 28, 16, 19, 11, 42},
                {3, 17, 27, 35, 14, 19, 36, 29, 33, 14, 18, 9, 7, 18, 13, 39, 36, 0, 24, 36, 7, 9, 33, 6, 42},
                {28, 16, 10, 19, 30, 24, 37, 16, 2, 32, 7, 22, 4, 34, 12, 34, 15, 22, 37, 29, 30, 18, 32, 39, 42},
                {4, 17, 13, 27, 32, 23, 4, 33, 23, 20, 7, 37, 9, 16, 39, 8, 17, 1, 6, 14, 11, 30, 35, 2, 42},
                {27, 30, 20, 24, 12, 3, 16, 9, 24, 10, 15, 12, 11, 9, 24, 19, 28, 14, 39, 24, 27, 15, 24, 38, 42},
                {23, 29, 12, 28, 12, 17, 28, 13, 21, 11, 0, 1, 2, 20, 20, 19, 3, 37, 12, 39, 1, 26, 36, 7, 42},
                {16, 27, 25, 36, 31, 11, 14, 12, 5, 22, 1, 23, 31, 28, 36, 6, 22, 1, 31, 39, 9, 22, 16, 8, 42},
                {33, 19, 20, 29, 2, 25, 37, 36, 32, 4, 11, 25, 32, 31, 21, 10, 36, 27, 36, 20, 19, 37, 28, 15, 42},
                {0, 5, 17, 39, 35, 37, 38, 34, 10, 17, 3, 12, 30, 25, 9, 20, 24, 4, 31, 26, 16, 11, 14, 30, 42},
                {19, 20, 2, 21, 26, 36, 29, 35, 30, 5, 28, 36, 8, 38, 1, 34, 6, 17, 14, 14, 27, 9, 20, 11, 42},
                {17, 15, 36, 14, 6, 2, 39, 29, 31, 26, 19, 15, 34, 17, 7, 14, 28, 8, 21, 25, 36, 13, 11, 25, 42},
                {2, 36, 19, 38, 37, 39, 2, 10, 39, 31, 3, 10, 39, 14, 28, 28, 5, 39, 5, 21, 18, 26, 0, 29, 42},
                {9, 0, 26, 19, 28, 35, 15, 4, 3, 10, 11, 10, 22, 0, 31, 31, 24, 9, 15, 3, 13, 37, 14, 13, 42},
                {19, 32, 19, 36, 8, 30, 7, 16, 36, 29, 28, 36, 13, 22, 21, 4, 16, 38, 6, 29, 2, 18, 5, 5, 42},
                {7, 13, 37, 9, 10, 36, 15, 12, 25, 12, 0, 36, 16, 18, 36, 13, 3, 35, 14, 32, 12, 35, 18, 1, 42},
                {27, 10, 27, 15, 30, 24, 11, 0, 26, 13, 29, 34, 32, 37, 5, 39, 14, 15, 10, 0, 21, 25, 28, 37, 42},
                {2, 33, 26, 7, 4, 12, 33, 12, 35, 36, 21, 0, 9, 0, 22, 1, 1, 0, 9, 2, 28, 2, 21, 5, 42},
                {29, 14, 18, 36, 24, 17, 19, 2, 21, 29, 13, 37, 38, 3, 35, 13, 20, 16, 38, 36, 15, 5, 30, 13, 42},
                {33, 9, 38, 21, 15, 26, 9, 39, 11, 20, 18, 30, 34, 36, 28, 17, 16, 18, 18, 19, 27, 25, 2, 38, 42} };

            MatrixMethods<Q8_24> fM = new MatrixMethods<Q8_24>(_m);
            fM.GaussElim();
        }

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
        }
    }
}

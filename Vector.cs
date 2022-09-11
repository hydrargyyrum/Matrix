using System;
namespace VectorsAndMatrix
{
    class Vector
    {
        private readonly double[] m;
        public readonly int n;

        public Vector(int n)
        {
            this.n = n;
            m = new double[n];
        }
        public Vector(Vector v)
        {
            this.n = v.n;
            m = new double[n];
            for (int i = 0; i < n; i++)
            {
                this.set(i, v.get(i));
            }
        }

        public void set(int i, double value) { m[i] = value; }
        public double get(int i) { return m[i]; }
        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{get(i)} ");

            }
            Console.WriteLine();
        }

        /*Vector multiplication by number*/
        public Vector MultiNumber(int a)
        {
            Vector v1 = new Vector(this);
            for (int i = 0; i < v1.n; i++) { v1.m[i] = v1.m[i] * a; }
            return v1;
        }

        /*Vector length*/
        public double Length()
        {
            double norma = 0;
            for (int i = 0; i < n; i++) { norma += m[i] * m[i]; }
            return Math.Sqrt(norma);
        }

        /*Vector addition*/
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            for (int i = 0; i < v1.n; i++)
            {
                v3.set(i, v1.get(i) + v2.get(i));
            }
            return v3;
        }

        /*Subtraction vectors*/
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            for (int i = 0; i < v1.n; i++)
            {
                v3.set(i, v1.get(i) - v2.get(i));
            }
            return v3;
        }

        /*Scalar product of vectors*/
        public static double operator *(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            double sum = 0;
            for (int i = 0; i < v1.n; i++)
            {
                sum += v1.get(i) * v2.get(i);
            }
            return sum;
        }
        public static Vector create(int[] values, int n)
        {
            Vector v = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                v.set(i, values[i]);
            }
            return v;
        }

        /*Vector product of vectors*/
        public static Vector operator %(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            v3.set(0, v1.get(2) * v2.get(0) - v1.get(0) * v2.get(2));
            v3.set(1, v1.get(1) * v2.get(2) - v1.get(2) * v2.get(1));
            v3.set(2, v1.get(0) * v2.get(1) - v1.get(1) * v2.get(0));
            return v3;
        }

        /*Mixed product of vectors*/
        static double combined(Vector v1, Vector v2, Vector v3)
        {
            return (v1 % v2) * v3;
        }
        public Matrix tensor(Vector v1, Vector v2)
        {
            int rows = v1.n;
            int columns = v2.n;
            Matrix m = new Matrix(rows, columns);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    m.set(row, column, v1.get(row) * v2.get(column));
                }
            }
            return m;
        }
    };
}

using System;

namespace AlgoLib
{
    public class Fibonacci
    {
        public static int Fr(int n)
        {
            int c = 0;
            return Fr(n, ref c);
        }

        public static int Fr(int n, ref int c)
        {
            var m = new int[n + 1];
            return Fr(n, m, ref c);
        }

        private static int Fr(int n, int[] m, ref int c)
        {
            if (m[n] > 0)
            {
                // lookup previous F(n)
                return m[n];
            }
            else if (n == 0 || n == 1)
            {
                // base cases
                c = c + 1;
                m[n] = n;
                return n;
            }
            else
            {
                // recursive case
                if (m[n - 2] == 0)
                {
                    c = c + 1;
                    m[n - 2] = Fr(n - 2, m, ref c);
                }
                if (m[n - 1] == 0)
                {
                    c = c + 1;
                    m[n - 1] = Fr(n - 1, m, ref c);
                }
                return m[n - 2] + m[n - 1];
            }
        }

        public static int Fl(int n)
        {
            var m = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                if (i == 0 || i == 1)
                    m[i] = i;
                else m[i] = m[i - 2] + m[i - 1];
            }
            return m[n];
        }
        
        public static int Fl2(int n)
        {
            var m = new int[2];
            for (int i = 0; i <= n; i++)
            {
                if (i == 0 || i == 1)
                    m[i] = i;
                else
                {
                    var c = m[0] + m[1];
                    m[0] = m[1];
                    m[1] = c;
                }
            }
            return m[1];
        }
    }
}

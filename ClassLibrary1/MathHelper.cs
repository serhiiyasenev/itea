using System;

namespace MathLibrary
{
    public class MathHelper
    {
        public static int GetMax(int a, int b, int c)
        {
            return a > b ? (a > c ? a : c) : (b > c ? b : c);
        }

        public static int GetMaxFromArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentException("array should not be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("array should not be empty");
            }

            var value = 0;

            foreach (var x in array)
            {
                if (x > value)
                {
                    value = x;
                }
            }

            return value;
        }
    }
}

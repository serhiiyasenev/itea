using System;

namespace MathLibrary
{
    public class MathHelper
    {
        public static int GetMax(int a, int b, int c)
        {
            return a > b ? (a > c ? a : c) : (b > c ? b : c);
        }

        public static int GetMaxFromArray(int[] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentException("array should not be null");
            }

            if (sourceArray.Length == 0)
            {
                throw new ArgumentException("array should not be emp");
            }

            var value = 0;

            foreach (var x in sourceArray)
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

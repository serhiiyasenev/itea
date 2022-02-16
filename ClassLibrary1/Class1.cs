namespace ClassLibrary1
{
    public class MathHelper
    {
        public static int GetMax(int a, int b, int c)
        {
            return a > b ? (a > c ? a : c) : (b > c ? b : c);
        }
    }
}

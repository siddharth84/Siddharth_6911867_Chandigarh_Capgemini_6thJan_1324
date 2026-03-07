namespace HalfAscendingHalfDescending
{
    internal class Program
    {
        static int[] SortHalf(int[] array, int size)
        {
            if (size < 0) return new int[] {-1};

            array.Sort();
            int mid = size / 2;

            int[] result = new int[size];
            for (int i = 0; i < mid; i++)
            {
                result[i] = array[i];
            }

            int index = mid;
            for (int i = size - 1; i >= mid; i--)
                result[index++] = array[i];

            return result;

        }
        static void Main(string[] args)
        {
            int[] array = { 1, 4, 2, 3, 5, 6 };
            int size = array.Length;

            int[] result = SortHalf(array, size);
            for( int i = 0; i < size; i++ )
            {
                Console.Write( result[i] + " ");
            }
        }
    }
}

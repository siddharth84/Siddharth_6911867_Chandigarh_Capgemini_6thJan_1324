namespace RemoveNegativeAndSort
{
    internal class Program
    {
        static int[] ArrayOps(int[] array,int size)
        {
            if (size<0) return new int[] { -1 };

            List<int> list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                if (array[i] >= 0)
                    list.Add(array[i]);
            }

            list.Sort();
            return list.ToArray();
        }
        static void Main(string[] args)
        {
            int[] array = { 5, 2, -3, 4, -6, 1 };
            int size = array.Length;

            int[] result = ArrayOps(array, size);
            for(int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]+" ");
            }
        }
    }
}

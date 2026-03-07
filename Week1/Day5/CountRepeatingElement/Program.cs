using System.Drawing;

namespace CountRepeatingElement
{
    internal class Program
    {
        static int CountOccurrences(int[] Input1,int Input2,int Input3)
        {
            if (Input2 < 0)
            {
                return -2;
            }
            else if (Input3 < 0)
            {
                return -3;
            }

            int cnt = 0;
            for(int i=0;i<Input1.Length;i++)
            {
                if (Input1[i] < 0) return -1;

                if(Input1[i] == Input3) cnt++;
            }
            return cnt;
        }
        static void Main(string[] args)
        {
            int[] Input1 =  { 1, 2, 2, 3, 3 };
            int Input2 = 5;
            int Input3 = 2;

            Console.WriteLine(CountOccurrences(Input1, Input2, Input3));
        }
    }
}

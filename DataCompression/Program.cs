namespace DataCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputData();
        }

        private static void InputData()
        {
            int countOfTests = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < countOfTests; i++)
            {
                int massSize = Int32.Parse(Console.ReadLine());
                string str = Console.ReadLine();
                int[] mass = str.Split(' ').
                    //Where(x => !String.IsNullOrEmpty(x)).
                    Select(x => int.Parse(x)).ToArray();
                OutputData(mass);
                Console.WriteLine("\n********************\n");
            }
        }

        private static void OutputData(int[] mass)
        {
            int count = 0;
            bool plus = false;
            bool minus = false;
            string result;
            string seq = "";
            int[] check = new int[mass.Length];
            for (int i = 1; i < mass.Length; i++)
            {

                if ((mass[count] == mass[i] + 1) && !plus)
                {
                    minus = true;
                    check[count] = -1;
                    check[i] = -1;
                    Console.WriteLine($"element: {count} {mass[count]} = {mass[i]} minus = {minus}");
                    count++;
                }
                else
                {
                    minus = false;
                    //count++;
                    //check[count + 1] = -1;
                    //continue;
                }
                //Console.WriteLine($"{mass[i - 1]} = {mass[i]}");
                if ((mass[count] == mass[i] - 1) && !minus)
                {
                    plus = true;
                    check[i - 1] = 1;
                    check[i] = -1;
                    Console.WriteLine($"element: {count} {mass[count]} = {mass[i]} plus = {plus}");
                    count++;
                }
                else
                {
                    plus = false;
                    //count++;
                    //check[count + 1] = 1;
                    //continue;
                }
                if (!plus && !minus)
                {
                    check[count] = 0;
                    Console.WriteLine($"element: {count} {mass[count]} = {mass[i] + 1} plus = {plus}");
                    count++;
                }
                if (i + 1 == mass.Length)
                {

                }
            }
            foreach (int e in check)
            {
                Console.Write($"{e} ");
            }
        }

    }
}
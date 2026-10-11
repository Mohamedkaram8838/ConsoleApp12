namespace Task_delegate
{
    public class Item
    {
       
        public void Check(int[] arr, Predicate<int> d)
        {
            foreach (var item in arr)
            {
                if (d(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        
        public void SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }

    
    public delegate int Calc(int num1, int num2);

    internal class Program
    {
        public static int Add(int num1, int num2) => num1 + num2;

        public static int PerformCalc(int num1, int num2, Calc c)
        {
            return c(num1, num2);
        }

        static void Main(string[] args)
        {
            Item item = new Item();

            
            int[] numbers = { 55, 565, -545, 654, -4461, -61888 };
            item.SortArray(numbers);

            Console.WriteLine("Sorted Array:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n-----------------------");

            
            Console.WriteLine("Negative Numbers:");
            item.Check(numbers, num => num < 0);
            Console.WriteLine("-----------------------");

           
            Calc addDelegate = new Calc(Add);
            Calc subDelegate = (n1, n2) => n1 - n2;

            int result1 = PerformCalc(10, 5, subDelegate);
            int result2 = PerformCalc(5, 6, addDelegate);

            Console.WriteLine($"Subtraction Result: {result1}");
            Console.WriteLine($"Addition Result: {result2}");
        }
    }
}
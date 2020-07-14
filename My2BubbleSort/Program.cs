using System;

namespace My2BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter counter: ");
            var counter = EnterCounter();

            int[] myArray = new int[counter];

            int[] myBubble1 = new int[counter];
            int[] myBubble2 = new int[counter];

            string str;
 
            while (true)
            {
                StartMessage();
                str = Console.ReadLine();

                switch (str)
                {
                    case "0":
                        break;
                    case "1":
                        myArray = WorstArray(counter);
                        break;
                    case "2":
                        myArray = BestArray(counter);
                        break;
                    case "3":
                        myArray = NinesArray(counter);
                        break;
                    case "4":
                        Console.WriteLine("Please enter your array step-by-step");
                        myArray = EnterIntArray(counter);
                        break;
                    default:
                        continue;
                } // -- end of switch
                break;
            } // -- end of while loop

            Console.Write("Your array is................: ");
            PrintArrayOneLine(myArray);
            
            Console.WriteLine(" ");
            myBubble1 = BubbleSort1(myArray);

            Console.Write("First bubble sort result is..: ");
            PrintArrayOneLine(myBubble1);

            Console.WriteLine(" ");
            myBubble2 = BubbleSort2(myArray);

            Console.Write("Second bubble sort result is.: ");
            PrintArrayOneLine(myBubble2);

        }
        //

        public static int[] BubbleSort2(int[] numbers)
        {
            // bubble sort with (while) loop
            int n = 0;
            int[] arr = CopyArray(numbers);
            var flag = true;
            while (true)
            {
                flag = true;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > arr[i - 1])
                    {
                        Swap(arr, i, i - 1);
                        flag = false;
                        n++;
                    }
                }
                if (flag == true)
                    break; // break when there is no swap has done
            }
            Console.WriteLine($"Second Bubble O({arr.Length}) = {n}");
            return arr;
        }
        private static int[] BubbleSort1(int[] array)
        {
            int[] arr = CopyArray(array);
            int n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = 1; k < arr.Length; k++)
                {
                    if (arr[k] > arr[k - 1])
                    {
                        Swap(arr, k, k - 1);
                        n++;
                    }
                }
            }
            Console.WriteLine($"First Bubble O({arr.Length}) = {n}");
            return arr;
        }
        private static void Swap(int[] numbers, int indx1, int indx2)
        {
            int temp = numbers[indx1];
            numbers[indx1] = numbers[indx2];
            numbers[indx2] = temp;
        }
        // =========================================================================================
        private static int[] EnterIntArray(int leng)
        {
            int[] res = new int[leng];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = EnterCounter();
            }
            return res;
        }
        private static int EnterCounter()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 20)
                    throw new ArgumentException();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a number 1 -> 20");
                return EnterCounter();
            }
            return a;
        }
        private static void PrintArrayOneLine(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine(" ");
        }
        private static int[] CopyArray(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static int[] WorstArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i + 1;
            }
            return a;
        }
        private static int[] BestArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = n - i;
            }
            return a;
        }
        private static int[] NinesArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 9;
            }
            return a;
        }
        private static void StartMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("(0).....................Exit");
            Console.WriteLine("(1).....................Wrost array (unordered array) is entered");
            Console.WriteLine("(2).....................Best array (ordered array) is entered");
            Console.WriteLine("(3).....................All items are equal 9 in the array!");
            Console.WriteLine("(4).....................Enter your own array");
            Console.WriteLine("any other key...........Stay here!");
            Console.WriteLine(" ");
        }
    }
}

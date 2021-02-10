using System;

namespace CodeTest
{
    class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] temp = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < (nums.Length - 1); j++)
                {
                    var sum = nums[i] + nums[j];
                    if (sum == target)
                    {
                        temp[i] = i;
                        temp[j] = j;
                        return temp;
                    }

                }

            }
            return temp;
        }


        static void Main(string[] args)
        {

            var a = TwoSum(new[] { 3, 2, 4 }, 6);
            for (int i = 0; i <= a?.Length; i++)
            {
                Console.WriteLine($"{a[i].ToString()}");
            }

        }
    }
}

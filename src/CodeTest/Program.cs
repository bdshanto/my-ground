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
                for (int j = nums.Length - 1; j > 0; j--)
                {
                    var sum = nums[i] + nums[j];
                    
                    if (sum == target && i!=j)
                    {
                        return new[] { i, j };
                    }

                }

            }
            return null;
        }


        static void Main(string[] args)
        {

            var a = TwoSum(new[] {3,3 }, 6);
            for (int i = 0; i < a?.Length; i++)
            {
                Console.WriteLine($"{a[i].ToString()}");
            }

        }
    }
}

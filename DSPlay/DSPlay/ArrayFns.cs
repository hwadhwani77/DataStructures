using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class ArrayBase
    {
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] ReverseArray(int[] array, int start, int end)
        {
            if (start >= end)
                return array;
            else
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                ReverseArray(array, start + 1, end - 1);
                return array;
            }
        }

        public static void Leaders(int[] array)
        {
            int max = array[array.Length - 1];
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (max < array[i])
                {
                    max = array[i];
                    Console.Write(max + " ");
                }
            }

            Console.WriteLine();
        }

        public static void ArrayHasTwoCandidates(int[] array, int size, int sum)
        {
            int l, r;
            l = 0; r = size - 1;
            bool flag = false;
            Sort.QuickSort(array, 0, size - 1);

            while (l < r)
            {
                if (array[l] + array[r] == sum)
                { Console.WriteLine("Two Candidates found: " + array[l] + ", " + array[r]); flag = true; break; }
                else if (array[l] + array[r] < sum)
                    l++;
                else
                    r--;
            }

            if (!flag)
                Console.WriteLine("No candidates found");

        }

        public static void MajorityElement(int[] array)
        {
            //Moore Voting Algorithm
            int candidate = findCandidate(array);
            bool foundMajorityElement = isMajorityElement(array, candidate);
            if (foundMajorityElement)
                Console.WriteLine("Found Majority Element: " + candidate);
            else
                Console.WriteLine("No Majority Element found");
        }

        public static int OddOccurrence(int[] array)
        {
            int res = 0;

            for (int i = 0; i < array.Length; i++)
            {
                res = res ^ array[i];
            }
            return res;
        }

        public static int[] ReverseArray(int[] array, int index)
        {
            int length = array.Length;
            rotateArray(array, 0, index - 1);
            rotateArray(array, index, length - 1);
            rotateArray(array, 0, length - 1);
            return array;
        }

        /// <summary>
        /// Twoes the sum. O(n2) implementation
        /// </summary>
        /// <param name="nums">The nums.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    { 
                        return new int[] {nums[i], nums[j]};
                    }
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// Twoes the sum hash. O(n) implementation
        /// </summary>
        /// <param name="nums">The nums.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static int[] TwoSumHash(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();            
            for (int i = 0; i < nums.Length; i++)
            {
                int result = target - nums[i];
                if (dict.ContainsKey(result))
                    return new int[] { dict[result], i };

                if(!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            throw new Exception("Not Found");   
        }


        private static int findCandidate(int[] array)
        {
            int max = 0, count = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[max] == array[i])
                    count++;
                else
                    count--;
                if (count == 0)
                { max = i; count = 1; }
            }
            return array[max];
        }

        private static bool isMajorityElement(int[] array, int candidate)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == candidate)
                    count++;
            }

            if (count > array.Length / 2)
                return true;

            return false;
        }

        private static void rotateArray(int[] array, int start, int end)
        {
            int temp;
            while (start < end)
            {
                temp = array[start];
                array[start] = array[end];
                array[end] = temp;

                start++;
                end--;
            }
        }
    }
    public class UnsortedArrayFns : ArrayBase
    {
        public static int Search(int[] array, int key)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == key)
                    return i;
            }

            return -1;
        }

        public static int Insert(int[] array, int key, int index)
        {

            if (array.Length < index)
                return -1;
            else
            {
                array[index] = key;
                return (index + 1);
            }
        }

        public static void Delete(int[] array, int key)
        {
            int index = Search(array, key);

            if (index != -1)
            {
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }
        }

    }

    public static class SortedArrayFns
    {

        public static int Search(int[] array, int key, int low, int high)
        {
            if (high < low)
                return -1;
            else
            {
                int mid = (low + high) / 2;

                if (key == array[mid])
                    return mid;
                else if (key > array[mid])
                    return Search(array, key, mid + 1, high);
                else
                    return Search(array, key, low, mid - 1);

            }
        }

        public static void Insert(int[] array, int key)
        {

            int i;
            for (i = array.Length - 2; (array[i] > key && i >= 0 && array[i] != 0); i--)
            {
                array[i + 1] = array[i];
            }

            array[i + 1] = key;
        }

        public static void Delete(int[] array, int key)
        {
            int index = Search(array, key, 0, array.Length - 1);

            if (index != -1)
            {
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }
        }
    }
}

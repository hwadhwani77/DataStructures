using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class Sort
    {
        public static void MergeSort(int[] inputArray, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSort(inputArray, l, m);
                MergeSort(inputArray, m + 1, r);
                merge(inputArray, l, m, r);
            }
        }

        private static void merge(int[] inputArray, int l, int m, int r)
        {
            int i = 0, j = 0;
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; ++i)
                L[i] = inputArray[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = inputArray[m + 1 + j];

            i = 0; j = 0;
            int k = l;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                { inputArray[k] = L[i]; i++; }
                else
                { inputArray[k] = R[j]; j++; }
                k++;
            }

            while (i < n1)
            {
                inputArray[k] = L[i];
                i++; k++;
            }

            while (j < n2)
            {
                inputArray[k] = R[j];
                j++; k++;
            }
        }

        public static void QuickSort(int[] inputArray, int low, int high)
        {
            if (low < high)
            {
                int pi = quickSortParitition(inputArray, low, high);

                QuickSort(inputArray, low, pi - 1);
                QuickSort(inputArray, pi + 1, high);
            }
        }

        private static int quickSortParitition(int[] inputArray, int low, int high)
        {
            int pivot = inputArray[high], temp = 0;
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (inputArray[j] <= pivot)
                {
                    i++;
                    temp = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = temp;
                }
            }

            temp = inputArray[i + 1];
            inputArray[i + 1] = inputArray[high];
            inputArray[high] = temp;

            return i + 1;

        }
    }
}

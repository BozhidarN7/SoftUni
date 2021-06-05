using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionCount
{
    class InversionCount
    {
        static void Main(string[] args)
        {
            int[] arrray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            /*int count = 0;

            for (int i = 0; i < arrray.Length - 1; i++)
            {
                for (int j = i + 1; j < arrray.Length; j++)
                {
                    if (arrray[i] > arrray[j])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);*/

            Console.WriteLine(MergeSort(arrray));
        }

        private static int MergeSort(int[] arrray)
        {
            int[] temp = new int[arrray.Length];
            return MergeSort(arrray, temp, 0, arrray.Length - 1);
        }

        private static int MergeSort(int[] array, int[] temp, int left, int right)
        {
            int mid = 0;
            int inversionCount = 0;

            if (right > left)
            {
                mid = (right + left) / 2;
                inversionCount = MergeSort(array, temp, left, mid);
                inversionCount += MergeSort(array, temp, mid + 1, right);
                inversionCount += Merge(array, temp, left, mid + 1, right);
            }
                return inversionCount;
        }

        private static int Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid;
            int k = left;

            int inversionCount = 0;

            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    inversionCount = inversionCount + (mid - i);
                }
            }

            while (i <= mid - 1)
                temp[k++] = arr[i++];


            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }

            return inversionCount;
        }
    }
}


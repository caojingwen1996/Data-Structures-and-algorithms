using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsearch
{
    public class Program
    {
        /*
         * 数组、有序、不重复
         */
        public static void Main(string[] args)
        {
            var value = int.Parse(Console.ReadLine());
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
           var a= bsearch(array, value);
            var b = bsearchWithDigui(array, 0, array.Length - 1, value);
            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.ReadLine();
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <returns></returns>
        public static int bsearch(int[] array,int value)
        {
            var n = array.Length;
            var low = 0;
            var high = n - 1;
            //条件中有=是为了判断a[low]=a[high]的值是否为要找的值
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if(array[mid]==value)
                {
                    return mid;
                }
                else if(array[mid]<value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 递归实现二分法
        /// 寻找value的下标
        /// </summary>
        /// <returns></returns>
        public static int bsearchWithDigui(int[] array,int low,int high,int value)
        {
            if (low > high) return -1;
            int mid = (low + high) / 2;
            if (array[mid] > value)
            {
                return bsearchWithDigui(array, low, mid, value);
            }else if (array[mid] < value)
            {
                return bsearchWithDigui(array, mid, high, value);
            }
            else
            {
                return mid;
            }
        }

        /// <summary>
        /// 寻找第一个等于给定值的下标
        /// </summary>
        /// <returns></returns>
        public static int bsearchForFirst(int[] array,int value)
        {
            var low = 0;
            var high = array.Length-1;
            if (high < low)
            {
                return -1;
            }
            while (high >= low)
            {
                int mid = (high + low) / 2;
                if (array[mid] > value)
                {
                    high = mid - 1;
                }
                else if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    if (mid == 0 || array[mid - 1] != value)
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid-1;
                    }
                }
            }
            return -1;
        }
    }
}

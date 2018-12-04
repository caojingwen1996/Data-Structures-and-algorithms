using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        public static void Main(string[] args)
        {
            //
            Array arr = new Array(5);

            arr.Insert(0, 3);
            arr.Insert(1, 4);
            arr.Insert(2, 5);
            arr.Insert(6, 6);
            arr.Insert(3, 7);
            arr.Delete(0);

            arr.printAll();
            Console.ReadLine();
        }
        /*数组的插入、删除*/
        public class Array
        {
            public int[] data;
            public int n;//数组长度
            public int count;//实际长度
            public Array(int capacity)
            {
                this.data = new int[capacity];
                this.n = capacity;
                this.count = 0;
            }

            public int find(int index)
            {
                if (index < 0 || index >= count) return -1;
                return data[index];
            }

            public Boolean Insert(int index,int value)
            {
                if (index < 0 || index > count)
                {
                    Console.WriteLine("位置不合法");
                    return false;                  
                }
                if (count == n)
                {
                    Console.WriteLine("没有可插入的位置");
                    return false;
                }
                for(int i = count; i > index; i--)
                {
                    data[i] = data[i - 1];
                }
                data[index] = value;
                ++count;//count+=1
                return true;
            }

            public Boolean Delete(int index)
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("位置不合法");
                    return false;
                }
                for(int i = index ; i < count; i++)
                {
                    data[i] = data[i + 1];
                }
                --count;
                return true;
            }

            public void printAll()
            {
                for(int i = 0; i < count; i++)
                {
                    Console.WriteLine(data[i].ToString());
                }
            }

        }
    }
}
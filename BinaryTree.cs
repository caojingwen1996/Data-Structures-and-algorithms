using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erchashu
{

    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            var tree = new BinaryTree<char>(data.Length+1);
            tree.Add('0');
            for(var i=0;i< data.Length; i++)
            {
                tree.Add(data[i]);
            }
            Console.WriteLine("先序遍历:");
            tree.PreOrder();
            Console.ReadLine();
        }
    }

    class BinaryTree<T>
    {
        /// <summary>
        /// 二叉树容器
        /// </summary>
        private T[] data;

        
        /// <summary>
        /// 当前二叉树的数量
        /// </summary>
        private int count = 0;

        public BinaryTree(int capacity)
        {
            data = new T[capacity];
        }

        public bool Add(T item)
        {
            if (count >= data.Length)
            {
                return false;
            }
            data[count] = item;
            count++;
            return true;
        }
        /// <summary>
        /// 前序遍历 为了方便计算，根节点会存储在下标为1的位置
        /// </summary>
        /// <param name="index">下标需从1开始</param>
        private void PreOrder(int index)
        {
            //终止条件:到达数组尾部，存储结点为null（-1表示）
            if (index >= count || data[index].Equals(-1))
                return;

            //为了方便计算，根节点会存储在下标为1的位置
            var num = index;
            Console.Write(data[index] + " ");
            
            int leftNum = num * 2;
            int rightNum = num * 2 + 1;
            
            PreOrder(leftNum);
            PreOrder(rightNum);
            
        }
        public void PreOrder()
        {
            PreOrder(1);
        }
    }
}

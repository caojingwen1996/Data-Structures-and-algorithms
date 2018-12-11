using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linked
{
    public class Program
    {
        /*5个常见的链表操作：
         * 单链表反转
         * 链表中环的检测
         * 两个有序的链表合并
         * 删除链表倒数第n个结点
         * 求链表的中间结点
         */

         public static void Main(string[] args)
        {
            Console.WriteLine("请输入数字");
            var link = new SinglyLinkedList();
            var array = new int[]{ 1, 2, 3, 4, 5 };
            foreach( var data in array)
            {
                link.insertTail(data);
            }
            Console.WriteLine("原始：");
            link.printAll();
            Console.WriteLine("删除5：");
            link.deleteByValue(5);
            link.printAll();
            Console.WriteLine("在头部插入5");
            link.insertToHead(5);
            link.printAll();
            Console.ReadLine();
        }
        public class Node
        {
            public int data;
            public Node next;

            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
            public int getData()
            {
                return data;
            }

        }

        public class SinglyLinkedList
        {

            private Node head = null;

            public Node findByValue(int value)
            {
                Node p = head;
                while (p != null && p.data != value)
                {
                    p = p.next;
                }
                return p;
            }

            public Node findByIndex(int index)
            {
                Node p = head;
                int pos = 0;//从0开始遍历
                while (p != null && pos != index)
                {
                    p = p.next;
                    ++pos;//p+=1
                }
                return p;
            }

            /// <summary>
            /// 无头结点插入（后插入的靠前）
            /// </summary>
            /// <param name="newNode"></param>
            public void insertToHead(Node newNode)
            {
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.next = head;//newnode.next存储旧的head的地址
                    head = newNode;//head的data指向最新的data
                }
            }
            public void insertToHead(int value)
            {
                Node newNode = new Node(value, null);
                insertToHead(newNode); 
            }

            /// <summary>
            /// 链表尾部插入
            /// </summary>
            /// <param name="value"></param>
            public void insertTail(int value)
            {
                var newNode = new Node(value, null);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    var q = head;
                    //指针移动到链表尾部
                    while (q.next != null)
                    {
                        q = q.next;
                    }
                    //把代表尾部的后继指针赋给newNode，你就是最后一个啦
                    newNode.next =q.next ;
                    q.next = newNode;
                }
            }

            /// <summary>
            /// 指定位置之后插入
            /// </summary>
            /// <param name="p"></param>
            /// <param name="value"></param>
            public void insertAfter(Node p,int value)
            {
                var newNode = new Node(value, null);
                insertAfter(p, newNode);
            }
            public void insertAfter(Node p,Node newNode)
            {
                if (p == null) return;
                newNode.next = p.next;
                p.next = newNode;
            }

            public void insertBefore(Node p,int value)
            {
                var newNode = new Node(value, null);
                insertBefore(p, newNode);

            }
            public void insertBefore(Node p,Node newNode)
            {
                if (p == null) return;
                if (p == head)
                {
                    insertToHead(newNode);
                    return;
                }
                var q = head;
                //找到p的前一个
                while (q != null && q.next != p)
                {
                    q = q.next;
                }
                if (q == null) return;

                newNode = p;
                q.next = newNode;
            }

            public void deleteByNode(Node p)
            {
                if (p == null || head == null) return;
                if (p == head)
                {
                    head = head.next;
                    return;
                }

                var q = head;
                while (q != null || q.next != p)
                {
                    q = q.next;
                }
                if (q == null)//没找到p
                {
                    return;
                }
                q.next = p.next;//q.next=q.next.next;
                
            }

            public  void deleteByValue(int Value)
            {
                if (head == null) return;
                var p = head;
                Node q = null;

                while (p != null && p.data != Value)
                {
                    q = p;
                    p = p.next;
                }
                if (p == null) return;
                if (q == null)//value 为head
                {
                    head = head.next;
                }
                else
                {
                    q.next = p.next;//p=q.next
                }
                

               
            }

            public void printAll()
            {
                Node p = head;
                while (p != null)
                {
                    Console.WriteLine(p.data);
                    p = p.next;
                }
                Console.ReadLine();
            }
        }
        /// <summary>
        /// 未完待续
        /// </summary>
        /// <param name="link"></param>
        /// <param name="newVisitData"></param>
        public static void LRU(SinglyLinkedList link,int newVisitData)
        {

            /*判断新访问数据是否被缓存在链表中
             *  1存在，从原位置删除，然后插入链表的头部
             *  2不存在，判断链表缓存是否已满
             *      1，满，删除链表尾结点，新数据插入头部
             *      2，不满，插入链表的头部
             */
            var newNode=link.findByValue(newVisitData);
            if (newNode == null)
            {

            }
            else
            {

            }
            Console.WriteLine("当前链表数据为：");
        }
    }
}

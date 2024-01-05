using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNode
{
    
  public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        // 在第 index 个节点之前插入一个新节点，例如index为0，那么新插入的节点为链表的新头节点。
        // 如果 index 等于链表的长度，则说明是新插入的节点为链表的尾结点
        // 如果 index 大于链表的长度，则返回空
        
   }
    public class MyLinkedList
    {
        //size存储链表元素的个数
        int size;
        //虚拟头结点
        ListNode head;
        public ListNode Head { get { return head; } }

        //初始化链表
        public MyLinkedList()
        {
            size = 0;
            head = new ListNode(0);
        }

        public void Print(ListNode headNode)
        {
            var cur = headNode;
            while(cur != null)
            {
                Console.Write($"{cur.val} ");
                cur = cur.next;
            }
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //find n
            //[s______________n_____e]
            //从左到右，n的位置是未知的； e的位置是已知的，所以线性思维无法确定终止条件
            //能否把移动到位置n 转换为 移动到位置e.当s移动到n时，s1移动到e.
            //即 [s,n+1]=[s1,e] 所以s1=s+n+1; 
            //在链表世界中，链表的移动比较笨拙，没有+=，只有++

            var dummyHead = new ListNode(0);
            dummyHead.next = head;

            if (head == null) return null;
            if (head.next == null && n == 1) return null;
            var s1 = head;
            var s = head;

            int d = n;
            for (int i = 0; i < d; i++)
            {
                s1 = s1.next;
            }
            if (s1 == null)
            {//说明移除正数第一个节点
                dummyHead.next = head.next;
            }
            else
            {
                //同时移动(当从dummyHead开始，终止条件就得是s1==null)
                while (s1.next != null)
                {
                    s1 = s1.next;
                    s = s.next;
                }
                s.next = s.next?.next??null;//to do 
            }



            return dummyHead.next;


        }
        public ListNode SwapPairs(ListNode head)
        {

            //1.终止条件
            if (head == null || head.next == null)
            {
                return head;

            }
            //2.函数执行
            var ret = SwapPairs(head.next.next);
            /*
                prev->1->2->?
                prev->1<->2
                prev->2->1->ret
            */
            var next=head.next;//(prev->1->)2
            next.next = head;//2->1->ret
            head.next = ret;//(prev->)1->ret
           


            //3.返回值
            return next;//2->1->ret


        }


        public ListNode ReverseList2(ListNode head)
        {

            if (head == null || head.next == null)
            {
                return head;
            }



            var new_head = ReverseList2(head.next); 

            //翻转
            //head.next 等于 new_head
            head.next.next = head; //5<->4
            Console.WriteLine($"before val:{head.val} next:{head.next.val}");
            //此时head是反转后的链表
            head.next = null; //4->null
            Console.WriteLine($"new_head:");//5->4->null
            return new_head;
        }


        //获取第index个节点的数值，注意index是从0开始的，第0个节点就是头结点
        public int get(int index)
        {
            //如果index非法，返回-1
            if (index < 0 || index >= size)
            {
                return -1;
            }
            ListNode currentNode = head;
            //包含一个虚拟头节点，所以查找第 index+1 个节点
            for (int i = 0; i <= index; i++)
            {
                currentNode = currentNode.next;
            }
            return currentNode.val;
        }

        //在链表最前面插入一个节点，等价于在第0个元素前添加
        public void addAtHead(int val)
        {
            addAtIndex(0, val);
        }

        //在链表的最后插入一个节点，等价于在(末尾+1)个元素前添加
        public void addAtTail(int val)
        {
            addAtIndex(size, val);
        }

        // 在第 index 个节点之前插入一个新节点，例如index为0，那么新插入的节点为链表的新头节点。
        // 如果 index 等于链表的长度，则说明是新插入的节点为链表的尾结点
        // 如果 index 大于链表的长度，则返回空
        public void addAtIndex(int index, int val)
        {
            if (index > size)
            {
                return;
            }
            if (index < 0)
            {
                index = 0;
            }
            size++;
            //找到要插入节点的前驱
            ListNode pred = head;
            for (int i = 0; i < index; i++)
            {
                pred = pred.next;
            }
            ListNode toAdd = new ListNode(val);
            toAdd.next = pred.next;
            pred.next = toAdd;
        }

        //删除第index个节点
        public void deleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                return;
            }
            size--;
            if (index == 0)
            {
                head = head.next;
                return;
            }
            ListNode pred = head;
            for (int i = 0; i < index; i++)
            {
                pred = pred.next;
            }
            pred.next = pred.next.next;
        }


    }
    }

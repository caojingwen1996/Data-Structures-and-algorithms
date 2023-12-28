/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    // public ListNode ReverseList(ListNode head) {
    //     //1.普通链表；
    //     if(head==null) return null;
    //     ListNode prev=null;
    //     var cur=head.next;
    //     while(cur!=null){
    //         var storeNext=cur.next;
    //         cur.next=prev;
    //         prev=cur;
    //         cur=storeNext;

    //     }
    //     return prev;

        



    // }

    //[1,2,3,4,5]
    public ListNode ReverseList2(ListNode head){
        /*利用递归，从后往前翻转
        函数递归情况
        * 
        step8   R(2) new_head=5->4->3->null;    head= 2->3->null;  2<->3; 2->null;
        step8   R(3) new_head=5->4->null;       head= 3->4->null;  3<->4; 3->null;(for next) 4->3->null;
        step7   R(4) new_head=5->null;          head= 4->5->null;  4<->5; 4->null;(for next) 5->4->null;
        new_head=lastNode;
        step6   R(5) return lastNode:(4->)5->null;
        step5   R(4) head:4->5
        step4   R(3) head:3->4
        step3   R(2) head:2->3
        step2   R(1) head:1->2
        step1   R(0) head:0->1
             
        */

        /*从前向后翻转，需要记录oldnext
        从后向前翻转，需要记录newnext。递归的方式可以利用head.next记录newlist 利用递归函数的参数记录prev
        Q:为什么head.next可以记录newlist? 
        head.next.next=head 通过next节点的指向反转到前一节点，反转后 两个节点相互指向
        递归的部分：next节点指向自己
        Q:为什么当前节点的next指向null， 当前节点的prev不会丢失？
        递归函数的参数已经记录



        */



        if(head==null||head.next==null){
            var newhead=head;
            return newhead;
        }
        
        //函数执行前，head.next表示oldlist的节点 
        var new_head=ReverseList2(head.next); //(4->)5->null 函数执行完，head.next已经指向newlist
        
        //翻转 赋值的动作 表示 新链表指向旧链表
        //key: head.next节点 同时被两个链表的next指向。(通过递归存储newlist)
        head.next.next=head; //newhead.next=old_curnode 影响新链表 newlist：5->null 变为 5->4
       
        head.next=null;//old_curnode 4->5 同时影响新旧链表； newList：5<->4 变为 5->4->null oldHead （3->)4->5 变为 (3->)4->null
        return new_head;
    }

    
在递归翻转链表的过程中，递归函数会在堆栈上创建一系列帧，每个帧对应一个函数调用。让我们逐步追踪递归函数在堆栈上的情况：

假设有一个链表 [1, 2, 3, 4]，并调用 reverse_list(head)，其中 head 是链表的头节点。

初始调用：

堆栈帧1：reverse_list(head=1 -> 2 -> 3 -> 4 -> None)
第一次递归调用：

堆栈帧2：reverse_list(head=2 -> 3 -> 4 -> None)
堆栈帧1（等待第一次递归返回）
第二次递归调用：

堆栈帧3：reverse_list(head=3 -> 4 -> None)
堆栈帧2（等待第二次递归返回）
堆栈帧1（等待第一次递归返回）
第三次递归调用：

堆栈帧4：reverse_list(head=4 -> None)
堆栈帧3（等待第三次递归返回）
堆栈帧2（等待第二次递归返回）
堆栈帧1（等待第一次递归返回）
基本情况 - 第四次递归返回：

堆栈帧3：返回 4 -> None
堆栈帧2（等待第二次递归返回）
堆栈帧1（等待第一次递归返回）
调整指针 - 第三次递归返回：

堆栈帧2：调整指针，返回 4 -> 3 -> None
堆栈帧1（等待第一次递归返回）
调整指针 - 第二次递归返回：

堆栈帧1：调整指针，返回 4 -> 3 -> 2 -> None
调整指针 - 第一次递归返回：

最终结果：4 -> 3 -> 2 -> 1 -> None
在这个过程中，堆栈的深度达到了链表的长度。每次递归调用都在堆栈上创建一个新的帧，直到达到链表的末尾，然后逐个返回，释放堆栈上的帧。这里的堆栈深度是链表长度的线性函数。在实际应用中，如果链表很长，可能需要考虑优化，比如使用迭代方式或尾递归优化。
}
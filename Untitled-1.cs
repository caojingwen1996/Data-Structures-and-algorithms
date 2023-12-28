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
        从后向前翻转，需要记录newnext。递归的方式可以利用head.next记录newlist

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
}
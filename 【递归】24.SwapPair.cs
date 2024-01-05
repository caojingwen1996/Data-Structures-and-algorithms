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
    public ListNode SwapPairs(ListNode head) {

        //1.终止条件
        if(head==null||head.next==null){
            return head;

        }
        //2.函数执行
        var ret=SwapPairs(head.next.next);//3
        //head=1
        //head->next

        /*
            prev->1->2->3
            prev->1<->2
            prev->2->1->ret
        */
var next=head.next;//(prev->1->)2
next.next = head;//2->1->ret
head.next = ret;//(prev->)1->ret

        //3.返回值
        return head.next;//2->1->ret
        

    }


    //非递归 
    public ListNode SwapPairs(ListNode head) {


        var dummyHead=new ListNode(0);
        dummyHead.next=head;

        var temp=dummyHead;

        //1.终止条件
        //1,2
        //3,4
        while(temp.next!=null&&temp.next.next!=null){
           /*ret->head->next
           ret->head<->next
           ret->next->head*/

           var cur=temp.next;//(null->)1->2->3->4
           var next=temp.next.next;//(1->)2->3

           cur.next=next.next;// 1->3
           temp.next=next;//prev->2 


           next.next=cur;//(prev->)2->1
           temp=cur;//(prev->2->)1->3
          

        }

        //3.返回值
        return  dummyHead.next;

    }
}
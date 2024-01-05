public ListNode RemoveNthFromEnd(ListNode head, int n) {
    //find n
    //[s______________n_____e]
    //从左到右，n的位置是未知的； e的位置是已知的，所以线性思维无法确定终止条件
    //能否把移动到位置n 转换为 移动到位置e.当s移动到n时，s1移动到e.
    //即 [s,n+1]=[s1,e] 所以s1=s+n+1; 
    //在链表世界中，链表的移动比较笨拙，没有+=，只有++
    
    var dummyHead=new ListNode(0);
    dummyHead.next=head;

    if(head==null)return null;
    if(head.next==null&&n==1) return null;
    var s1=head;
    var s=head;

    int d=n;
    for(int i=0;i<d;i++){
        s1=s1.next;
    }
    if(s1==null){//说明移除正数第一个节点
        dummyHead.next=head.next;
    }else{
        //同时移动(当从dummyHead开始，终止条件就得是s1==null)
        while(s1.next!=null){
            s1=s1.next;
            s=s.next;
        }
        s.next=s.next.next;
    }
    


    return  dummyHead.next;


}
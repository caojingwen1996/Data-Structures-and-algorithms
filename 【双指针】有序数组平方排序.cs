public int[] SortedSquares(int[] nums) {
    //key1:时间复杂度o(n),空间换时间
    //key2:有序递增数组,要利用原本的排序
    var res=new int[nums.Length];
    int i=0;
    int j=nums.Length-1;
    int m=nums.Length-1;

    while(i<=j){
        var left=nums[i]*nums[i];
        var right=nums[j]*nums[j];
        if(i==j){
             res[m]=left;
             break;
        }
         if(left<=right){
            res[m]=right;
            j--;
        }else{
            res[m]=left;
            i++;
        }
        m--;
    }
    return res;
}


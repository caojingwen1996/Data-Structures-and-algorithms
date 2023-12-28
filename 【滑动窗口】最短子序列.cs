 public int MinSubArrayLen(int target, int[] nums) {
    //滑块窗口
    //1.窗口结束移动：i,j=0,j++；if(sum>=target) break;
    //2.窗口起始移动：i++; if(sum<target) break; //找到>target的最小值
    //
    //2.终止条件：j=length-1,当i=?时，sum<target
    //...
    //3.

    int min=0;
    int sum;
    int i=0;
    for(int j=0;j<nums.Length;j++){
        sum+=nums[j];//移动窗口右边
        while(sum>=target){
            min=Math.min(min,j-i+1);
            sum-=nums[i++];//移动窗口左边
        }
    }

    return min;

}
  public int RemoveElement(int[] nums, int val) {
    
        int l=nums.Length;
        int i=l-1;//当前值
        int r=i;//右侧下标
       

        while(i>=0){
            if(nums[i]==val){
                //移动区间[i+1,r]
                if(i<r){
                    for(int j=i;j<r;j++){
                        nums[j]=nums[j+1];
                    }
                }
                
                 r--;//右侧下表边界
               

            }
            i--;
            
        }

        return r+1;

    }
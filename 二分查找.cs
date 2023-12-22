  public int Search(int[] nums, int target) {

        
        int length=nums.Length;
        int e=length-1;
        int s=0;

        //1.边界判断
        if(target<nums[0]||target>nums[length-1]){
            return -1;
        }

       

        //2.循环体
        /*
        * 确定区间：
        [s,e] [0,length-1]
        终止条件：s<=e
        移动区间：
            [s,mid] e=mid-1 (nums[mid]!=target已经判断)
            [mid,e] s=mid+1




        [s,e) [0,length)
        终止条件：s<e
        移动区间：
        [s,mid) e=mid 
        [mid,e) s=mid+1
        
        */
        while(s<e){
            var mid=(e-s)/2+s;//还有一种写法是(e+s)/2 当e s =？时，会出现溢出。
            if(target==nums[mid]){
                return mid;

            }else if(target>nums[mid]){
                s=mid+1;

            }else {
                e=mid;
            }
        }
        return -1;
        


    }
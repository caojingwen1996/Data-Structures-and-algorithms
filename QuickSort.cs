public void Start(int[] nums){
    QuickSort(nums,0,nums.Length-1);
}


public void  QuickSort(int[] arr,int low,int hight){
    if(low<high){
         int pivot_index=Partition(nums,low,high);//1.数组划分两堆，小于pivot的放左边，大于pivot的放右边
         QuickSort(arr,low,pivot_index-1);//2.按照同样的方式处理左侧数组，直到low==high 
         QuickSort(arr,pivot_index+1,high);
    }
  

}

private static int Partition(int arr,int low,int high){
    //1.find pivot
    //2.find < pivot  的元素 left_arr
    //3.find > pivot  的元素 right_arr
    int pivot_index=low;
    int pivot=arr[low];
    int store_index=low+1;//标记 数组中 left_arr的末尾位置，通过比较并交换 移动存储索引

    for(int i=store_index;i<=high;i++){
        var val=nums[i];
        if(val<pivot){          
            Swap(nums,i,store_index);
            store_index++; //保证store_index位于left_arr的末尾位置
        }
    }


    Swap(pivot, store_index-1); //pivot应该在left_arr的末尾
    return store_index-1;
} 

private static void Swap(int[] arr,int i,int j){
    int temp=arr[i];
    arr[i]=arr[j];
    arr[j]=temp;
}
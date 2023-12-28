public int[][] GenerateMatrix(int n) {

    //1.确定边长=n 左侧边界l 右侧边界r [l,r] 顶部边界top 底部边界bottom
    //2.一个loop:i正循环，j正循环；i逆循环 j逆循环
    //2.l=0; r=n-1;
    //3.loop停止：l>r top>bottom;


    int left=0;
    int right=n-1;
    int top=0;
    int bottom=n-1;
    int i,j;
    int num=1;
    int[][] arr=new int[n][];
    for(int m=0;m<n;m++){
        arr[m] = new int[n];
    }
 

   

    while(left<=right&&top<=bottom){
       
       for(int j=left;j<=right;j++){
            arr[top][j]=num++;
       }
       top++;
       for(int i=top;i<=bottom;i++ ){
            arr[i][right]=num++;
       }
       right--;
       for(int j=right;j>=left;j--){
          arr[bottom][j]=num++;
       }
       bottom--;

       for(int i=bottom;i>=top;i--){
         arr[i][left]=num++;
       }
       left++;
    }

}
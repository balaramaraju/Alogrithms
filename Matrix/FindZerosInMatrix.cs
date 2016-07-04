class FindZerosInMatrixTest{
      //Consider an n×n array A containing integer elements (positive, negative, and zero). 
      //Assume that the elements in each row of A are in strictly increasing order, and the elements of each column of A are in strictly decreasing order. 
      //(Hence there cannot be two zeroes in the same row or the same column.) Describe an efficient algorithm that counts the number of occurrences of the element 0 in A. 
      //Analyze its running time.
      public static void FindZerosInMatrix(int[,] matrix, int rowendIndex, int colendIndex) {

          while (rowendIndex >= 0 && colendIndex >= 0) {
              if (matrix[rowendIndex, colendIndex] == 0) {
                  Console.WriteLine(rowendIndex + ", " + colendIndex);
                  rowendIndex--;
                  colendIndex--;
              }else if (matrix[rowendIndex, colendIndex] > 0)
              {
                  colendIndex--;
              }else {
                  rowendIndex--;
              }
          }
          
      }
      
      //Test 
      static void Main(string[] args)
        {
            int[,] matrix = { 
                            {50,51,52,53,54},
                            {40,41,42,43,44},
                            {0,31,32,33,34},
                            {-1,0,22,23,24},
                            {-2, -1, 10, 11, 12},
                            {-3, -2, -1 , 0, 1}
                            };
            FindZerosInMatrix(matrix, 5, 4);
        }
}
        //Expected Output
        //5,3
        //3,1
        //2,0

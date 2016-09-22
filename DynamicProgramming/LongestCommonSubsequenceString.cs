using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class LongestCommonSubsequenceString {

        public static string Find(string firstString, string secondString) {
            int rowLength = firstString.Length+1;
            int colLength = secondString.Length+1;
            int[,] cache = new int[rowLength,colLength];
            int maxValue = -1;
            int resrIndex = -1;
            int rescIndex = -1;
            for (int rindex = 1; rindex < rowLength; rindex++) {
                for (int cindex = 1; cindex < colLength; cindex++) {
                    if (firstString[rindex-1] == secondString[cindex-1]){
                        cache[rindex, cindex] = cache[rindex - 1, cindex - 1] + 1;
                    } else {
                        cache[rindex, cindex] = 
                            cache[rindex - 1, cindex] > cache[rindex, cindex - 1] ? 
                            cache[rindex - 1, cindex] : 
                            cache[rindex, cindex - 1];
                    }
                    if (maxValue < cache[rindex, cindex]) {
                        maxValue = cache[rindex, cindex];
                        resrIndex = rindex;
                        rescIndex = cindex;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            while (cache[resrIndex, rescIndex] != 0) {
                if (cache[resrIndex, rescIndex] == cache[resrIndex, rescIndex - 1]){
                    rescIndex--;
                }else if (cache[resrIndex, rescIndex] == cache[resrIndex-1, rescIndex ]) {
                    resrIndex--;
                }else if (cache[resrIndex, rescIndex] > cache[resrIndex - 1, rescIndex - 1]) {
                    sb.Insert(0, firstString[resrIndex-1]);
                    rescIndex--;
                    resrIndex--;
                }else{
                    
                }
            }
            return sb.ToString();
        }
        public static void Solve() {
            //case sensitve comparison
            string str = Find("manhattan", "duchmanhadhat");
           Console.WriteLine(str);
        }
    }
}

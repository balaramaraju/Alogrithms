using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class LongestCommonSubstring{
        public static string Find(string firstString, string secondString) {
            int rowCount = firstString.Length+1;
            int colCount = secondString.Length+1;
            int[,] cache = new int[rowCount,colCount];
            rowInit(cache);
            colInit(cache);

            //cache the Highest value index
            int maxValue = -1;
            int resultRowindex = 0;
            int resultColindex = 0;

            //Building the cache results
            for (int rindex = 1; rindex < rowCount; rindex++)   {
            for (int cindex = 1; cindex < colCount; cindex++) {               
                    int value = 0;
                    if (secondString[cindex - 1] == firstString[rindex - 1]){
                        value = 1;
                    }
                    cache[rindex,cindex] = cache[ rindex - 1,cindex - 1] + value;
                    if (cache[rindex, cindex] > maxValue) {
                        maxValue = cache[rindex, cindex];
                        resultColindex = cindex;
                        resultRowindex = rindex;
                    }
                }            
            }
            
            //Build Substring by travers back.
            StringBuilder sb = new StringBuilder();
            while (cache[resultRowindex, resultColindex] != 0) {
                sb.Insert(0,firstString[resultRowindex - 1]);
                resultRowindex--;
                resultColindex--;
            }

            return sb.ToString();
        }
        private static void colInit(int[,] cache) {
            for (int i = 0; i < cache.GetLength(1); i++)
                cache[0, i] = 0;
        }
        private static void rowInit(int[,] cache)   {
            for (int i = 0; i < cache.GetLength(0); i++)
                cache[i,0] = 0;
        }
        public static void Solve() {
            string str = Find("common", "monitor");
            Console.WriteLine(str);
            str = Find("tutorialhorizon", "dynamictutorialProgramming");
            Console.WriteLine(str);
        }
    }
}

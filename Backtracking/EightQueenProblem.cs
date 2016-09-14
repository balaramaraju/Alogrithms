using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Backtracking{
    class EightQueen {
        class Point {
            internal int row;
            internal int col;
            public Point(int r, int c) {
                row = r;
                col = c;
            }
        }
        static bool isFinished = false;
        private static void BackTrackAlgo(bool[,] board, int index, bool[,] track) {
            if (IsSolved(board, index)) { 
                ProcessSolution(board);
                //One Solution is enoughf.. :)
                isFinished = true;
            } else {
                Point[] possibleCandidates = null;
                ConsturctCandidates(board, index, track,out possibleCandidates);
                index++;
                foreach (Point pt in possibleCandidates) {
                    MakeSelection(board, pt , track);
                    BackTrackAlgo(board, index, track);
                    //Multiple solutions are possible .. 
                    //Exit after Find one solution
                    if(isFinished) return;
                    RevertSelection(board, pt, track);
                }
            }
        }
        private static bool IsSolved(bool[,] board, int index){
            if (index == board.GetLength(0)) {
                return true;
            }
            return false;
        }
        private static void ProcessSolution(bool[,] board){
            for (int rowindex = 0; rowindex < board.GetLength(0); rowindex++) {
                for (int colindex = 0; colindex < board.GetLength(0); colindex++) {
                    if (board[rowindex, colindex]){
                        Console.Write("{"+rowindex+","+colindex+"}");
                    }
                }
            }
        }
        private static void UpdateTrackRecord(bool[,] board, Point pt, bool[,] track, bool value) {
            board[pt.row, pt.col] = value;
            for (int index = 0; index < board.GetLength(0); index++) {
                track[index, pt.col] = track[pt.row, index] = value;
                int tempColDown = pt.col + index;
                int tempColUp = pt.col - index;
                int tempRowDown = pt.row + index;
                int tempRowUp = pt.row - index;
                if (tempColUp >= 0 && tempRowUp >= 0) {
                    track[tempRowUp, tempColUp] = value;
                }
                if (tempRowDown < board.GetLength(0) && tempColDown < board.GetLength(0)){
                    track[tempRowDown, tempColDown] = value;
                }
                if(tempColDown < board.GetLength(0) && tempRowUp >= 0){
                    track[tempRowUp, tempColDown] = value;
                }
                if (tempRowDown < board.GetLength(0) && tempColUp >= 0) {
                    track[tempRowDown, tempColUp] = value;
                }
            }
        }
        private static void MakeSelection(bool[,] board, Point pt, bool[,] track){
            UpdateTrackRecord(board, pt, track, true);
        }
        private static void RevertSelection(bool[,] board, Point pt, bool[,] track){ 
            //UnMove.. this might override other Queens scope area..
            //So need to reset.
            UpdateTrackRecord(board, pt, track, false);

            //Reset the tracker with board values
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(0); j++) {
                    if (board[i, j]) {
                        MakeSelection(board, new Point(i, j), track);
                    }
                }
            }

        }
        private static void ConsturctCandidates(
            bool[,] board, 
            int index, 
            bool[,] track,
            out Point[] possibleCandidates){
            List<Point> points = new List<Point>();
           
            for (int i = 0; i < board.GetLength(0); i++) {
                if (!track[index, i]) {
                    points.Add( new Point(index, i));
                }
            }
            possibleCandidates = points.ToArray();
        }
        public static void Solve(){
            BackTrackAlgo(new bool[8, 8], 0, new bool[8, 8]);
        }
    }
}

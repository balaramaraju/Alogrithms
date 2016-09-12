namespace Algorithms.Backtracking
{
    class PrintAllSubSets {

        static bool IsSolution(int[] data, int currentindex) {
            if (currentindex == data.Length){
                return true;
            }
            return false;
        }

        static void ProcessSolution(int[] data, int k, bool[] track){
            Console.Write("{");
            for (int i = 0; i < k; i++){
                if (track[i] == true){
                    Console.Write(data[i]);
                }
            }
            Console.Write("} ");
        }

        static void ConstructCandidates(out bool[] possibleCandidate, ref int possibleCandidateCount){
            possibleCandidate = new bool[2];
            possibleCandidateCount = 2;
            possibleCandidate[0] = true;
            possibleCandidate[1] = false;
        }

        static void BackTrackingAlgo(int[] data, int k, bool[] track) {
            if (IsSolution(data, k)){
                ProcessSolution(data, k, track);
            }else {
                k++;
                bool[] possibleCandidates = null;
                int possibleCandidatesCount = 0;
                ConstructCandidates(out possibleCandidates,ref possibleCandidatesCount);
                for (int index = 0; index < possibleCandidatesCount; index++) {
                    track[k-1] = possibleCandidates[index];
                    BackTrackingAlgo(data, k, track);
                }
            }
        }

        public static void Solve(int[] data){ 
            int index = 0;
            BackTrackingAlgo(data, 0, new bool[data.Length]);
        }
        
        public static void Test() {
            int[] set = { 1, 2, 3 ,4 };
            Solve(set);
        }
    }
}

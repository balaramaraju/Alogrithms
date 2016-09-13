namespace Algorithms.Backtracking
{
    class PrintAllPermunations {
        private static void BacktrackingAlgo(int[] set, int index, int[] solutionSet,bool[] track){
            if (IsSolution(set, index)) {
                ProcessSolution( index, solutionSet);
            } else {
                
                int[] possibleCandidates = new int[set.Length-index];
                index++;
                int possibleCandidatesCount= possibleCandidates.Length;
                ConstructCandidates(set,  track, ref possibleCandidates);
                for (int i = 0; i < possibleCandidatesCount; i++) {
                    solutionSet[index - 1] = set[possibleCandidates[i]];
                    track[possibleCandidates[i]] = true;
                    BacktrackingAlgo(set, index, solutionSet, track);
                    track[possibleCandidates[i]] = false;
                }
            }
        }

        private static bool IsSolution(int[] set, int index) {
            if (index == set.Length) {
                return true;
            }
            return false;
        }
        private static void ProcessSolution(int index,int[] track) {
            Console.Write("{");
            for (int i = 0; i < index; i++) {
                Console.Write(track[i]);
            }
            Console.Write("}");

        }
        //Set the possible cadidates indexes
        private static void ConstructCandidates(int[] set,  bool[] track, ref int[] possibleCandidates) {
            int canditateIndex = 0;
            for (int index = 0; index < set.Length; index++) {
                if (!track[index]){
                    possibleCandidates[canditateIndex] = index;
                    canditateIndex++;
                }
            }
        }
        public static void Solve() {
            int[] set = { 1, 2, 3 };
            BacktrackingAlgo(set, 0, new int[set.Length], new bool[set.Length]);
        }

    }
}

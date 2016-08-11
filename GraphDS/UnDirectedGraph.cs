using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Algorithms.Graphs {
    class UnDirectedGraph : Graph  {
        
        public override void Add(int sourceEdge, int targetEdge) {
            List<int> edgeNodes;
            if (graphStructure.TryGetValue(sourceEdge, out edgeNodes)) {
                edgeNodes.Add(targetEdge);
                //Not handling the duplicate Nodes...
            } else {
                edgeNodes = new List<int>();
                edgeNodes.Add(targetEdge);
                graphStructure.Add(sourceEdge, edgeNodes);
            }

            List<int> edgeNodes2;
            if (graphStructure.TryGetValue(targetEdge, out edgeNodes2)){
                edgeNodes2.Add(sourceEdge);
                //Not handling the duplicate Nodes...
            } else {
                edgeNodes2 = new List<int>();
                edgeNodes2.Add(sourceEdge);
                graphStructure.Add(targetEdge, edgeNodes2);
            }
        }

        public override void Remove(int sourceEdge, int targetEdge) {
            List<int> edgeNodes;
            if (graphStructure.TryGetValue(sourceEdge, out edgeNodes)) {
                edgeNodes.Remove(targetEdge);
                //Not handling the duplicate Nodes...
            } 

            List<int> edgeNodes2;
            if (graphStructure.TryGetValue(targetEdge, out edgeNodes2)){
                edgeNodes2.Remove(sourceEdge);
                //Not handling the duplicate Nodes...
            } 
        }

         public override List<int> FindArticulationPoints(){
            List<int> aPoints = new List<int>();
            int[] vertexMaxPathWt = new int[graphStructure.Keys.Count+1];
            int[] vertexMinPathWt = new int[graphStructure.Keys.Count+1];
            int[] parent = new int[graphStructure.Keys.Count+1];
            bool[] isVisited = new bool[graphStructure.Keys.Count+1];
            bool[] isProcessed = new bool[graphStructure.Keys.Count+1];
            int rootKey = 1;
            int pathCount = 1;
            int rootChild = 0;
            Stack<int> tracker = new Stack<int>();
            tracker.Push(rootKey);
            vertexMaxPathWt[rootKey] = pathCount;
            vertexMinPathWt[rootKey] = pathCount;
            isVisited[rootKey] = true;
            //StillRoot need to be address
            while (tracker.Count > 0){
                int key = tracker.Peek();
                bool isCompleted = true;
                foreach (int edge in graphStructure[key]) {
                    
                    if (isProcessed[edge]) continue;
                    if (edge == parent[key]) continue;
                    if (isVisited[edge] == false ) {
                        if (key == rootKey) rootChild++;
                        parent[edge] = key;
                        isVisited[edge] = true;
                        pathCount++;
                        isCompleted = false;
                        vertexMaxPathWt[edge] = vertexMinPathWt[edge] = pathCount;
                        tracker.Push(edge);
                        break;
                    } else {
                        vertexMinPathWt[key] = vertexMinPathWt[key] < vertexMinPathWt[edge] ? vertexMinPathWt[key] : vertexMinPathWt[edge];
                    }
                }
                if (isCompleted){
                    isProcessed[key] = true;
                    int nEdeg = tracker.Pop();
                    int pKey = parent[key];
                    vertexMinPathWt[pKey] = vertexMinPathWt[key] < vertexMinPathWt[pKey] ? vertexMinPathWt[key] : vertexMinPathWt[pKey];
                    //Check for Non root element which don't have back edge
                    if (vertexMaxPathWt[pKey] <= vertexMinPathWt[key] && pKey != rootKey && parent[key] != 0){
                        aPoints.Add(pKey);
                        Console.WriteLine("Find Articulation point " + pKey);
                    }
                    pathCount--;
                }
            }
            //Root having two children -- tree kind of structure
            if (rootChild > 1) {
                aPoints.Add(rootChild);
                Console.WriteLine("Root is Articulation point " + rootKey);
            }
            return aPoints;
        }
    }
}

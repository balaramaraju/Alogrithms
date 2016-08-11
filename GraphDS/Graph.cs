using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public abstract class Graph {
        protected Dictionary<int, List<int>> graphStructure = new Dictionary<int, List<int>>();
        public abstract void Add(int sourceEdge, int targetEdge);
        public abstract void Remove(int sourceEdge, int targetEdge);
        public virtual List<int> BFSTraversal() {
            List<int> orederedList = new List<int>();
            Queue<int> tracker = new Queue<int>();
            tracker.Enqueue(1);
            orederedList.Add(1);
            bool[] IsTracked = new bool[graphStructure.Keys.Count+1];
            while (tracker.Count > 0){
                int startNode = tracker.Dequeue();
                foreach (int edge in graphStructure[startNode]){
                    if (IsTracked[edge] == false) {
                        tracker.Enqueue(edge);
                        orederedList.Add(edge);
                    }
                    IsTracked[edge] = true;
                }
                IsTracked[startNode] = true;
            }
            return orederedList;
        }

        public virtual List<int> DFSTraversal() {
            List<int> orderedList = new List<int>();
            bool[] IsVisited = new bool[graphStructure.Keys.Count+1];
            Stack<int> tracker = new Stack<int>();
            tracker.Push(1);
            IsVisited[1] = true;
            orderedList.Add(tracker.Peek());
            //Console.Write(tracker.Peek());
            while (tracker.Count > 0) {
                bool isCompleted = true;
                foreach (int edge in graphStructure[tracker.Peek()]){
                    if (IsVisited[edge] == false) {
                        orderedList.Add(edge);
                        //Console.Write(edge);
                        tracker.Push(edge);
                        isCompleted = false;
                        IsVisited[edge] = true;
                        break;
                    }
                }
                if (isCompleted){
                    tracker.Pop();
                }
            }
            return orderedList;
        }
        public virtual List<int> FindArticulationPoints() { throw new NotImplementedException();}
        //Strongly Connected
        //
        public virtual List<int> TopologicalSortOrder() {
            throw new Exception("Graph should be DAG");
        }
        public virtual List<int> ShortedPath(int sourceEdge, int endEdge) { throw new NotImplementedException(); }
        protected bool IsCyclic() { return false; }
    }
} 

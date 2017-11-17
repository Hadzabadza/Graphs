using System;
using System.Collections.Generic;

//class Node{}

class RedGraph : Graph {
   
   /*
   Adjacency lists represented using nested dictionaries 
   
   Outer dictionary records edges for each node
      adjLists[a] = edges from node b

   Inner dictionary records costs for each edge
      adjLists[a][b] = cost of edge from a->b
   */
   	private Dictionary<Node, Dictionary<Node, int>> adjLists;
   
   	public RedGraph() {
    	adjLists = new Dictionary<Node, Dictionary<Node, int>> ();
   	}

	public void AddNode(Node n){
        adjLists.Add(n,new Dictionary<Node, int>());
    }

	public void AddEdge (Node start, Node end, int length){
        adjLists[start].Add(end,length);
    }

	public List<Node> Nodes(){
		List<Node> temp = new List<Node>();
		foreach (Node nood in adjLists.Keys) {
			temp.Add (nood);
		}
        return temp;
    }

	public List<Node> Neighbours(Node n){
		List<Node> temp = new List<Node>();
		foreach (Node nood in adjLists[n].Keys) { temp.Add (nood); }
		return temp;
	}

	public int Cost(Node start, Node end){
		if (adjLists [start] [end] != null) { return adjLists [start] [end]; }
		else { return 0 };
	}


   // ADD MISSING METHODS HERE



   public void Write() {
      Console.WriteLine("RedGraph");

      foreach (Node node in adjLists.Keys) {
         Console.Write(node + ": ");
         bool first = true;
         foreach (Node neighbour in adjLists[node].Keys) {
            if (!first) Console.Write(", ");
            Console.Write(neighbour + "(" + Cost(node,neighbour) + ")");
            first = false;
         }
         
         Console.Write("\n");
      }
   }
}
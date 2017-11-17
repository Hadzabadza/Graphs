using System;
using System.Collections.Generic;

class BrokenGraph : Graph {

	public List<Node> nodes;
	public int[][] edges;
	
	public BrokenGraph() {
		nodes = new List<Node> ();
		edges=new int[nodes.Count*2][nodes.Count*2](0);
	}

	public void AddNode(Node a) {
		nodes.Add (a);
		if (edges.GetLength (0) <= nodes.Count) {
			int[][] tempEdges=new int[nodes.Count*2][nodes.Count*2](0);
			for (int i = 0; i < edges.GetLength (0); i++) {
				for (int j = 0; j < edges.GetLength (1); j++) {
					tempEdges [i] [j] = edges [i] [j];
				}
			}
			edges = tempEdges;
		}
	}

	public void AddEdge(Node a, Node b, int c) {
		edges [a.GetHashCode()] [b.GetHashCode()] = c;
	}

	public List<Node> Nodes() {
		return nodes;
	}

	public List<Node> Neighbours(Node a) {
		List<Node> poot = new List<Node> ();
		for (int i = 0; i < nodes.Count; i++) {
			if (edges [a.GetHashCode] [i] > 0)
				poot.Add (nodes [i]);
		}
		return poot;
	}     

	public int Cost(Node a, Node b) {
		return edges[a.GetHashCode()][b.GetHashCode()];
	}

	public void Write() {
		Console.WriteLine("You need to write a graph data structure.");
	}


}
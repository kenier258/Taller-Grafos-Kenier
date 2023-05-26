using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Grafos_Kenier
{
    class Graph
    {
    private int[,] adjacencyMatrix;
    private int numVertices;

    public void CreateGraph(int numVertices, int[,] edges)
    {
        this.numVertices = numVertices;
        adjacencyMatrix = new int[numVertices, numVertices];

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int source = edges[i, 0];
            int destination = edges[i, 1];
            AddEdge(source, destination);
        }
    }

    public void AddEdge(int source, int destination)
    {
        adjacencyMatrix[source, destination] = 1;
        adjacencyMatrix[destination, source] = 1;
    }

    public void PrintGraph()
    {
        Console.WriteLine("Adjacency Matrix:");
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public List<int> FindPath(int start, int end)
    {
        Dictionary<int, int> visited = new Dictionary<int, int>();
        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> parent = new Dictionary<int, int>();
        List<int> path = new List<int>();

        visited[start] = 1;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == end)
            {
                int node = end;
                while (node != start)
                {
                    path.Insert(0, node);
                    node = parent[node];
                }
                path.Insert(0, start);
                break;
            }

            for (int i = 0; i < numVertices; i++)
            {
                if (adjacencyMatrix[current, i] == 1 && !visited.ContainsKey(i))
                {
                    visited[i] = 1;
                    queue.Enqueue(i);
                    parent[i] = current;
                }
            }
        }

        return path;
    }
  }

}


    

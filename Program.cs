using Taller_Grafos_Kenier;

class Program
{
    
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        Console.Write("Ingrese el número de vértices: ");
        int numVertices = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el número de aristas: ");
        int numEdges = Convert.ToInt32(Console.ReadLine());

        int[,] edges = new int[numEdges, 2];

        for (int i = 0; i < numEdges; i++)
        {
            Console.WriteLine("Ingrese la arista " + (i + 1) + ":");
            Console.Write("Vértice fuente: ");
            int source = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vértice destino: ");
            int destination = Convert.ToInt32(Console.ReadLine());

            edges[i, 0] = source;
            edges[i, 1] = destination;
        }

        graph.CreateGraph(numVertices, edges);

        Menu(graph);
    }

    static void Menu(Graph graph)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("----- Menú -----");
            Console.WriteLine("1. Visualizar Grafo");
            Console.WriteLine("2. Agregar Nodo al Grafo");
            Console.WriteLine("3. Buscar Camino entre Nodos");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Se muestra el grafo :) ");
                    graph.PrintGraph();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Agregar un nodo al grafo:");
                    Console.Write("Vértice fuente: ");
                    int newNodeSource = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Vértice destino: ");
                    int newNodeDestination = Convert.ToInt32(Console.ReadLine());

                    graph.AddEdge(newNodeSource, newNodeDestination);

                    Console.WriteLine("Nuevo Grafo:");
                    graph.PrintGraph();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Buscar camino entre nodos:");
                    Console.Write("Vértice inicio: ");
                    int startNode = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Vértice fin: ");
                    int endNode = Convert.ToInt32(Console.ReadLine());

                    List<int> path = graph.FindPath(startNode, endNode);

                    Console.WriteLine("Camino desde el nodo " + startNode + " al nodo " + endNode + ":");
                    if (path.Count == 0)
                    {
                        Console.WriteLine("No se encontró un camino.");
                    }
                    else
                    {
                        foreach (int node in path)
                        {
                            Console.Write(node + " ");
                        }
                    }

                    Console.WriteLine();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Deja la bobada que esa no es una opcion del menú. Gracias :)");
                    break;
            }
        }
    }
}



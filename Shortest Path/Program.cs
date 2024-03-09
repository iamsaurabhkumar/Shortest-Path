using System;
using System.Collections.Generic;
using System.Linq;

namespace Shortest_Path
{
    public class Program
    {

        public static ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
        {
            var fromNode = graphNodes.FirstOrDefault(n => string.Equals(n.Name, fromNodeName, StringComparison.OrdinalIgnoreCase));
            var toNode = graphNodes.FirstOrDefault(n => string.Equals(n.Name, toNodeName, StringComparison.OrdinalIgnoreCase));

            // Check for null nodes and handle the case where nodes are not found
            if (fromNode == null || toNode == null)
            {
                return new ShortestPathData { NodeNames = new List<string>(), Distance = int.MaxValue };
            }

            var distances = new Dictionary<Node, int>();
            var previous = new Dictionary<Node, Node>();
            var nodes = new List<Node>(graphNodes);

            foreach (var node in nodes)
            {
                distances[node] = int.MaxValue;
                previous[node] = null;
            }

            distances[fromNode] = 0;

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == toNode)
                {
                    var path = new List<string>();
                    var current = toNode;

                    while (current != null)
                    {
                        path.Insert(0, current.Name);
                        current = previous[current];
                    }

                    return new ShortestPathData { NodeNames = path, Distance = distances[toNode] };
                }

                foreach (var neighbor in smallest.Edges.Keys)
                {
                    var alt = distances[smallest] + smallest.Edges[neighbor];
                    if (alt < distances[neighbor])
                    {
                        distances[neighbor] = alt;
                        previous[neighbor] = smallest;
                    }
                }
            }

            // If the loop completes without finding a path, return an indication of no path found
            return new ShortestPathData { NodeNames = new List<string>(), Distance = int.MaxValue };
        }



        static void Main(string[] args)
        {
            
            // Initialize nodes
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            var nodeF = new Node { Name = "F" };
            var nodeD = new Node { Name = "D" };
            var nodeE = new Node { Name = "E" };
            var nodeG = new Node { Name = "G" };
            var nodeH = new Node { Name = "H" };
            var nodeI = new Node { Name = "I" };

            // Initialize edges
            nodeA.Edges[nodeB] = 4;
            nodeA.Edges[nodeC] = 6;
            nodeB.Edges[nodeA] = 4;
            nodeB.Edges[nodeF] = 2;
            nodeF.Edges[nodeB] = 2;
            nodeF.Edges[nodeE] = 3;
            nodeF.Edges[nodeG] = 4;
            nodeF.Edges[nodeH] = 6;
            nodeC.Edges[nodeA] = 6;
            nodeC.Edges[nodeD] = 8;
            nodeE.Edges[nodeB] = 2;
            nodeE.Edges[nodeF] = 3;
            nodeE.Edges[nodeI] = 8;
            nodeE.Edges[nodeD] = 4;
            nodeH.Edges[nodeG] = 5;
            nodeH.Edges[nodeF] = 6;
            nodeD.Edges[nodeE] = 4;
            nodeD.Edges[nodeC] = 8;
            nodeD.Edges[nodeG] = 1;
            nodeG.Edges[nodeD] = 1;
            nodeG.Edges[nodeF] = 4;
            nodeG.Edges[nodeH] = 5;
            nodeG.Edges[nodeI] = 5;
            nodeI.Edges[nodeG] = 5;
            nodeI.Edges[nodeE] = 8;

            // Add other edges as needed

            var graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeF, nodeD, nodeE, nodeG, nodeH, nodeI }; 

            
            // Prompt user for start and end nodes
            Console.WriteLine("Enter start node:");
            string startNode = Console.ReadLine();
            Console.WriteLine("Enter end node:");
            string endNode = Console.ReadLine();

            // Check if the input nodes exist in the graph
            if (graphNodes.Any(n => string.Equals(n.Name, startNode, StringComparison.OrdinalIgnoreCase)) && graphNodes.Any(n => string.Equals(n.Name, endNode, StringComparison.OrdinalIgnoreCase)))
            {
                var result = ShortestPath(startNode, endNode, graphNodes);

                Console.WriteLine($"Shortest path: {string.Join(", ", result.NodeNames)}");
                Console.WriteLine($"Total distance: {result.Distance}");
            }
            else
            {
                Console.WriteLine("One or both of the specified nodes do not exist in the graph.");
            }
        }
    }
}

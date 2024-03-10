using NUnit.Framework;
using Shortest_Path; // This is correct based on your namespace
using System.Collections.Generic;
using System.Diagnostics;

namespace Shortest_Path.Tests
{
    [TestFixture]
    public class ShortestPathTests
    {
        [Test]
        public void ShortestPath_FromAToI_ReturnsCorrectPathAndDistance()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            Node nodeD = new Node { Name = "D", Edges = new Dictionary<Node, int>() };
            Node nodeE = new Node { Name = "E", Edges = new Dictionary<Node, int>() };
            Node nodeF = new Node { Name = "F", Edges = new Dictionary<Node, int>() };
            Node nodeG = new Node { Name = "G", Edges = new Dictionary<Node, int>() };
            Node nodeH = new Node { Name = "H", Edges = new Dictionary<Node, int>() };
            Node nodeI = new Node { Name = "I", Edges = new Dictionary<Node, int>() };

            // Initialize edges as in your Main method...
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


            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };

            // Expected Outcome
            var expectedPath = new List<string> { "A", "B", "F", "G", "I" };
            var expectedDistance = 15;

            // Act
            var result = Program.ShortestPath("A", "I", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(expectedPath, result.NodeNames, "The calculated path does not match the expected path.");
        }

        [Test]
        public void ShortestPath_FromIToA_ReturnsCorrectPathAndDistance()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            Node nodeD = new Node { Name = "D", Edges = new Dictionary<Node, int>() };
            Node nodeE = new Node { Name = "E", Edges = new Dictionary<Node, int>() };
            Node nodeF = new Node { Name = "F", Edges = new Dictionary<Node, int>() };
            Node nodeG = new Node { Name = "G", Edges = new Dictionary<Node, int>() };
            Node nodeH = new Node { Name = "H", Edges = new Dictionary<Node, int>() };
            Node nodeI = new Node { Name = "I", Edges = new Dictionary<Node, int>() };

            // Initialize edges as in your Main method...
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


            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };

            // Expected Outcome
            var expectedPath = new List<string> { "I", "E", "B", "A" };
            var expectedDistance = 14;

            // Act
            var result = Program.ShortestPath("I", "A", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(expectedPath, result.NodeNames, "The calculated path does not match the expected path.");
        }

        [Test]
        public void ShortestPath_DirectPath_ReturnsCorrectDistance()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            Node nodeD = new Node { Name = "D", Edges = new Dictionary<Node, int>() };
            Node nodeE = new Node { Name = "E", Edges = new Dictionary<Node, int>() };
            Node nodeF = new Node { Name = "F", Edges = new Dictionary<Node, int>() };
            Node nodeG = new Node { Name = "G", Edges = new Dictionary<Node, int>() };
            Node nodeH = new Node { Name = "H", Edges = new Dictionary<Node, int>() };
            Node nodeI = new Node { Name = "I", Edges = new Dictionary<Node, int>() };

            // Initialize edges as in your Main method...
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


            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };

            // Expected Outcome
            var expectedPath = new List<string> { "A", "B" };
            var expectedDistance = 4;

            // Act
            var result = Program.ShortestPath("A", "B", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(expectedPath, result.NodeNames, "The calculated path does not match the expected path.");
        }

        [Test]
        public void ShortestPath_NoPathExists_ReturnsEmptyPathAndZeroDistance()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            // Nodes D and I are isolated
            Node nodeD = new Node { Name = "D", Edges = new Dictionary<Node, int>() };
            Node nodeI = new Node { Name = "I", Edges = new Dictionary<Node, int>() };

            // Edges that don't connect A to I directly or indirectly
            nodeA.Edges[nodeB] = 4;
            nodeB.Edges[nodeC] = 6;
            nodeC.Edges[nodeA] = 5;

            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeI };

            // Expected Outcome
            var expectedPath = new List<string>(); // Empty path
            var expectedDistance = int.MaxValue; // Assuming no path exists, distance could be 0 or another indicator like -1 based on your design

            // Act
            var result = Program.ShortestPath("B", "I", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(expectedPath.Count, result.NodeNames.Count, "The calculated path does not match the expected path.");
            Assert.IsTrue(result.NodeNames.Count == 0, "Expected no path but found one.");
        }

        [Test]
        public void ShortestPath_HighCostEdges_ReturnsShortestPath()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            Node nodeD = new Node { Name = "D", Edges = new Dictionary<Node, int>() };

            // Adding high-cost edges
            nodeA.Edges[nodeB] = 100; // High cost
            nodeB.Edges[nodeC] = 100; // High cost
            nodeC.Edges[nodeD] = 100; // High cost

            // Adding a lower-cost path
            nodeA.Edges[nodeD] = 250; // Lower cost than A->B->C->D but still high

            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC, nodeD };

            // Expected outcome: the direct path A->D is chosen over the more expensive path through B and C
            var expectedPath = new List<string> { "A", "D" };
            var expectedDistance = 250; // The cost of the direct path A->D

            // Act
            var result = Program.ShortestPath("A", "D", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            CollectionAssert.AreEqual(expectedPath, result.NodeNames, "The calculated path does not match the expected path.");
        }

        [Test]
        public void ShortestPath_StartEqualsEnd_ReturnsSingleNodeAndZeroDistance()
        {
            // Arrange
            var nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            var graphNodes = new List<Node> { nodeA };

            // Expected Outcome
            var expectedPath = new List<string> { "A" };
            var expectedDistance = 0;

            // Act
            var result = Program.ShortestPath("A", "A", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(expectedPath.Count, result.NodeNames.Count, "The calculated path length does not match the expected path length.");
            Assert.AreEqual(expectedPath[0], result.NodeNames[0], "The calculated path does not match the expected path.");
        }

        [Test]
        public void ShortestPath_GraphWithCycles_ReturnsCorrectPath()
        {
            // Arrange
            Node nodeA = new Node { Name = "A", Edges = new Dictionary<Node, int>() };
            Node nodeB = new Node { Name = "B", Edges = new Dictionary<Node, int>() };
            Node nodeC = new Node { Name = "C", Edges = new Dictionary<Node, int>() };
            // Creating a cycle A -> B -> C -> A
            nodeA.Edges[nodeB] = 1;
            nodeB.Edges[nodeC] = 1;
            nodeC.Edges[nodeA] = 1; // This completes the cycle

            List<Node> graphNodes = new List<Node> { nodeA, nodeB, nodeC };
            var expectedPath = new List<string> { "A", "B", "C" };
            var expectedDistance = 2; // A -> B -> C

            // Act
            var result = Program.ShortestPath("A", "C", graphNodes);

            // Assert
            Assert.AreEqual(expectedDistance, result.Distance);
            Assert.AreEqual(expectedPath, result.NodeNames);
        }

        [Test]
        public void ShortestPath_LargeGraph_CompletesInReasonableTime()
        {
            // Arrange: Setup a large graph
            var graphNodes = new List<Node>();
            var edges = new Dictionary<Node, int>();
            int nodeCount = 1000; // Example large graph size
            for (int i = 0; i < nodeCount; i++)
            {
                var node = new Node { Name = $"Node{i}", Edges = new Dictionary<Node, int>() };
                graphNodes.Add(node);
                if (i > 0)
                {
                    // Creating a linear path for simplicity; 
                    graphNodes[i - 1].Edges[node] = 1; // Assigning a cost of 1 for each edge
                }
            }

            // Act: Measure time to find a path
            var stopwatch = Stopwatch.StartNew();
            var result = Program.ShortestPath("Node0", $"Node{nodeCount - 1}", graphNodes);
            stopwatch.Stop();

            // Assert: Verify the path is correct and the operation completes within a reasonable time frame
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000, "Algorithm took too long to complete."); // Example threshold of 1000 milliseconds
            Assert.AreEqual(nodeCount - 1, result.Distance, "The calculated distance does not match the expected distance.");
            Assert.AreEqual(nodeCount, result.NodeNames.Count, "The calculated path does not include the correct number of nodes.");
        }
    }
}

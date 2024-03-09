using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shortest_Path.Program;

namespace Shortest_Path
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Edges { get; set; } = new Dictionary<Node, int>();
    }

    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; } = new List<string>();
        public int Distance { get; set; }
    }
}

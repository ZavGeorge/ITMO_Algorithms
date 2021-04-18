using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_5
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public bool Oriented { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To}; {Weight})";
        }

    }
}

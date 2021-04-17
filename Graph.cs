using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_5
{
    class Graph
    {

        List<Vertex> V = new List<Vertex>();
        List<Edge> E = new List<Edge>();

        public int VertexCount => V.Count;
        public int EdgeCount => E.Count;

        public void AddVertex(Vertex vertex) 
        {
            V.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            E.Add(edge);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[V.Count, V.Count];

            foreach(var edge in E)
            {
                var row = edge.From.Number -1 ;
                var column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }


    }
}

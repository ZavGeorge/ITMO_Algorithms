using System;

namespace Algorithms_lab_5
{
    class Program
    {
        static void Main(string[] args)
        {

            var graph = new Graph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);

            var matrix = graph.GetMatrix();

            for (int i=0; i<graph.VertexCount; i++)
            {
                for (int j=0; j < graph.VertexCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(graph.BFS(v2, v4));
            Console.WriteLine(graph.BFS(v1, v5));
            Console.WriteLine(graph.BFS(v3, v6));
            Console.WriteLine(graph.BFS(v7, v1));
            Console.WriteLine(graph.BFS(v2, v7));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(graph.DFS(v2, v4));
            Console.WriteLine(graph.DFS(v1, v5));
            Console.WriteLine(graph.DFS(v3, v6));
            Console.WriteLine(graph.DFS(v7, v1));
            Console.WriteLine(graph.DFS(v2, v7));
            Console.WriteLine();
            Console.WriteLine();

            var graph2 = new Graph();

            graph2.AddVertex(v1);
            graph2.AddVertex(v2);
            graph2.AddVertex(v3);
            graph2.AddVertex(v4);
            graph2.AddVertex(v5);
            graph2.AddVertex(v6);

            graph2.AddEdge(v1, v2, 2);
            graph2.AddEdge(v1, v3, 3);
            graph2.AddEdge(v3, v4, 12);
            graph2.AddEdge(v2, v5, 6);
            graph2.AddEdge(v2, v6, 4);
            graph2.AddEdge(v6, v5, 7);

            var matrix2 = graph2.GetMatrix();

            for (int i = 0; i < graph2.VertexCount; i++)
            {
                for (int j = 0; j < graph2.VertexCount; j++)
                {
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            graph2.Dijkstra(v1);

            Console.WriteLine();
            Console.WriteLine();

            var graph3 = new Graph();

            graph3.AddVertex(v1);
            graph3.AddVertex(v2);
            graph3.AddVertex(v3);
            graph3.AddVertex(v4);
            graph3.AddVertex(v5);

            graph3.AddEdge(v1, v5, 10);
            graph3.AddEdge(v1, v4, 4);
            graph3.AddEdge(v4, v5, 2);
            graph3.AddEdge(v4, v3, 8);
            graph3.AddEdge(v5, v3, 6);
            graph3.AddEdge(v2, v3, 8);
            graph3.AddEdge(v2, v5, 10);
            graph3.AddEdge(v2, v1, 3);

            var matrix3 = graph3.GetMatrix();

            Console.WriteLine("Матрица до алгоритма Крускала");

            for (int i = 0; i < graph3.VertexCount; i++)
            {
                for (int j = 0; j < graph3.VertexCount; j++)
                {
                    Console.Write(matrix3[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            graph3.Kruskala();


            Console.WriteLine("Матрица после алгоритма Крускала");

            var matrix4 = graph3.GetMatrix();

            for (int i = 0; i < graph3.VertexCount; i++)
            {
                for (int j = 0; j < graph3.VertexCount; j++)
                {
                    Console.Write(matrix4[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}

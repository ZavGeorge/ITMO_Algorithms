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

        public void AddEdge(Vertex from, Vertex to, int weight=1)
        {
            var edge = new Edge(from, to, weight);
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
                row = edge.To.Number - 1;
                column = edge.From.Number - 1;
                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }

        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach( var edge in E)
            { 
                if(edge.From == vertex)
                {
                    result.Add(edge.To);
                }
                else if(edge.To == vertex)
                {
                    result.Add(edge.From);
                }
            }
            return result;
        }

        public bool BFS(Vertex start, Vertex finish)
        {
            var result = new List<Vertex>();
            var list = new List<Vertex>();

            list.Add(start);

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexLists(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }
            return list.Contains(finish);
        }

        public bool DFS(Vertex start, Vertex finish)
        {
            
            var list = new List<Vertex>();
            list.Add(start);

            void getNextVertexList(Vertex vertex)
            {
                foreach (var v in GetVertexLists(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                        getNextVertexList(v);
                    }
                 
                }
            }

            getNextVertexList(start);
            return list.Contains(finish);
        }

        public void Dijkstra(Vertex start)
        {
            int MimDistance(int[] distance, bool[] shortestPathTreeSet)
            {
                int min = int.MaxValue;
                int minIndex = 0;

                for (int v = 0; v < V.Count; ++v)
                {
                    if (shortestPathTreeSet[v] == false && distance[v] <= min)
                    {
                        min = distance[v];
                        minIndex = v;
                    }
                }
                return minIndex;
            }
            var graph = GetMatrix();
            int[] distance = new int[V.Count];
            bool[] shortestPathTreeSet = new bool[V.Count];

            for (int i = 0; i < V.Count; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            distance[start.Number -1 ] = 0;
           for (int count = 0; count < V.Count - 1; ++count)
           {
                int u = MimDistance(distance, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < V.Count; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    } 
                }        
           }
            Console.WriteLine("Кратчайшие пути из вершины: {0}", start.Number);
           for(int i = 0; i < V.Count; ++i)
           {
                Console.WriteLine("В вершину: {0}\tдлина пути: {1}", i + 1, distance[i]);
           }
        }

        public List<Edge> SortE()
        {
            var listWeight = new List<int>();
            List<Edge> sortedE = new List<Edge>();

            foreach(var edge in E)
            {
                listWeight.Add(edge.Weight);
            }
            int len = E.Count;
            for(int i = 0; i < len; i++)
            {
                Edge minvalue = E[0];
                int minindex=0;
                for (int j=0; j <E.Count; j++)
                {
                    if(listWeight[j] < minvalue.Weight)
                    {
                        minvalue = E[j];
                        minindex = j;
                    }
                }
                E.RemoveAt(minindex);
                listWeight.RemoveAt(minindex);
                sortedE.Add(minvalue); 
            }
            return sortedE;
        }
        
        public void Kruskala()
        {
            var list = new List<Edge>();
            var result = new List<Edge>();
            var connectedVertex = new List<Vertex>();
            bool brk=false;
            list = SortE();

            for (int i=0; i < list.Count; i++)
            {
                result.Add(list[i]);
                if (!connectedVertex.Contains(list[i].From))
                    connectedVertex.Add(list[i].From);
                if (!connectedVertex.Contains(list[i].To))
                    connectedVertex.Add(list[i].To);
                foreach(var vertex in V)
                {
                    if (connectedVertex.Contains(vertex))
                    {
                        brk = true;
                    }
                    else
                    {
                        brk = false;
                        break;
                    }
                }
                if (brk == true)
                {
                    E = result;
                    break;
                }
            }
        }

    }
}

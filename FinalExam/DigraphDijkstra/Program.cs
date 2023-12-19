using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigraphDijkstra
{
    /* Enum: EVertices
     * Author: Katie Bogart
     * Purpose: hold the values of the vertices
     * Restrictions: None
     */
    enum EVertices
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet,
        grey
    }

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: initialize digraphs and DFS
     * Restrictions: None
     */
    internal class Program
    {
        // adjacency matrix for digraph
        static int[,] digraphWeightsMatrix = new int[,]
        {        /*  red  orange  yellow   green   blue   indigo  violet  grey */
            /*red*/{ -1,    -1,     -1,     -1,     -1,      1,     -1,      5 },
         /*orange*/{ -1,    -1,     -1,     -1,     -1,     -1,      1,     -1 },
         /*yellow*/{ -1,    -1,     -1,      6,     -1,     -1,     -1,     -1 },
          /*green*/{ -1,    -1,     -1,     -1,     -1,     -1,     -1,     -1 },
           /*blue*/{ -1,    -1,     -1,     -1,     -1,      1,     -1,      0 },
         /*indigo*/{ -1,    -1,      8,     -1,      1,     -1,     -1,     -1 },
         /*violet*/{ -1,    -1,      1,     -1,     -1,     -1,     -1,     -1 },
           /*grey*/{ -1,     1,     -1,     -1,      0,     -1,     -1,     -1 },
        };

        // adjacency list for digraph
        static List<List<int>> digraphWeightsList = new List<List<int>>
        {        /*  red  orange  yellow   green   blue   indigo  violet  grey */
            /*red*/ new List<int>{ -1,    -1,     -1,     -1,     -1,      1,     -1,      5 },
         /*orange*/ new List<int>{ -1,    -1,     -1,     -1,     -1,     -1,      1,     -1 },
         /*yellow*/ new List<int>{ -1,    -1,     -1,      6,     -1,     -1,     -1,     -1 },
          /*green*/ new List<int>{ -1,    -1,     -1,     -1,     -1,     -1,     -1,     -1 },
           /*blue*/ new List<int>{ -1,    -1,     -1,     -1,     -1,      1,     -1,      0 },
         /*indigo*/ new List<int>{ -1,    -1,      8,     -1,      1,     -1,     -1,     -1 },
         /*violet*/ new List<int>{ -1,    -1,      1,     -1,     -1,     -1,     -1,     -1 },
           /*grey*/ new List<int>{ -1,     1,     -1,     -1,      0,     -1,     -1,     -1 },
        };

        static bool[] visited = new bool[digraphWeightsMatrix.GetLength(0)];
        static List<EVertices> shortestPath = new List<EVertices>();

        /* Method: Dijkstra
         * Purpose: check if we're at the end
         *          if not, add this to visited
         *          add all adjacent to queue
         *          see which has shortest path
         *          add that to path and continue recursively
         * Restrictions: None
         */
        static void Dijkstra(int startVertex, int endVertex)
        {
            if (startVertex == endVertex)
            {
                shortestPath.Add((EVertices)startVertex);
                return;
            }

            visited[startVertex] = true;
            List<int> queue = new List<int>();

            for (int i = 0; i < digraphWeightsMatrix.GetLength(0); i++)
            {
                if (digraphWeightsMatrix[startVertex, i] > 0 && !visited[i])
                {
                    queue.Add(i);
                }
            }

            if (queue.Count > 0)
            {
                int min = queue[0];
                int minVal = digraphWeightsMatrix[startVertex, queue[0]];

                for (int i = 1; i < queue.Count; i++)
                {
                    if (digraphWeightsMatrix[startVertex, queue[i]] < digraphWeightsMatrix[startVertex, min])
                    {
                        min = queue[i];
                    }
                }
                shortestPath.Add((EVertices)startVertex);
                Dijkstra(min, endVertex);
            }
            else
            {
                shortestPath.Add((EVertices) startVertex);
            }

        }


        /* Method: Main
         * Purpose: Perform Dijkstra
         *          Print vertices in visited order
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            Dijkstra((int)EVertices.red, (int)EVertices.green);
            foreach (EVertices vertex in shortestPath)
            {
                Console.WriteLine(vertex.ToString());
            }
        }
    }
}

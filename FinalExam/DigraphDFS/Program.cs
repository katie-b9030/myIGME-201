using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigraphDFS
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
        static List<EVertices> verticesVisited = new List<EVertices>();

        /* Method: DFS
         * Purpose: set vertex visited to true
         *          add vertex to order visited
         *          look for another vertex that isn't visited
         *          perform DFS from that vertex
         * Restrictions: None
         */
        static void DFS(int vertex)
        {
            visited[vertex] = true;
            verticesVisited.Add((EVertices)vertex);
            for (int i = 0; i < digraphWeightsMatrix.GetLength(0); i++)
            {
                if (digraphWeightsMatrix[vertex, i] > 0 && !visited[i])
                {
                    DFS(i);
                }
            }
        }


        /* Method: Main
         * Purpose: Perform DFS
         *          Print vertices in visited order
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            DFS((int)EVertices.red);
            foreach (EVertices vertex in verticesVisited)
            {
                Console.WriteLine(vertex.ToString());
            }
        }
    }
}

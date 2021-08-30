using System;
using System.Collections.Generic;
using System.Text;

namespace Path
{
    class Node
    {
        public bool isExplored = false;
        public Node isExploredFrom;
        public int X { set; get; }
        public int Y { set; get; }
        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    struct Vector
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class SearchPath
    {
        //private Node[] nodes = new Node[25];
        //private Vector[] positions = new Vector[25];

        private Node startingPoint;
        private Node endingPoint;
        private Dictionary<Vector, Node> _block = new Dictionary<Vector, Node>();

        private Node searchingPoint;
        private bool isExploring = true;
        private Vector[] directions = { new Vector(0, 1), new Vector(1, 0), new Vector(0, -1), new Vector(-1, 0) };
        private Queue<Node> queue = new Queue<Node>();
        private List<Node> _path = new List<Node>();

        public void CreateNodes()
        {
            Node[] nodes =
            {
                new Node(0, 0),
                new Node(0, 1),
                new Node(0, 2),
                new Node(0, 3),
                new Node(0, 4),
                new Node(1, 0),
                new Node(1, 1),
                new Node(1, 2),
                new Node(1, 3),
                new Node(1, 4),
                new Node(2, 0),
                new Node(2, 1),
                new Node(2, 2),
                new Node(2, 3),
                new Node(2, 4),
                new Node(3, 0),
                new Node(3, 1),
                new Node(3, 2),
                new Node(3, 3),
                new Node(3, 4),
                new Node(4, 0),
                new Node(4, 1),
                new Node(4, 2),
                new Node(4, 3),
                new Node(4, 4),
            };

            Vector[] positions =
            {
                new Vector(0, 0),
                new Vector(0, 1),
                new Vector(0, 2),
                new Vector(0, 3),
                new Vector(0, 4),
                new Vector(1, 0),
                new Vector(1, 1),
                new Vector(1, 2),
                new Vector(1, 3),
                new Vector(1, 4),
                new Vector(2, 0),
                new Vector(2, 1),
                new Vector(2, 2),
                new Vector(2, 3),
                new Vector(2, 4),
                new Vector(3, 0),
                new Vector(3, 1),
                new Vector(3, 2),
                new Vector(3, 3),
                new Vector(3, 4),
                new Vector(4, 0),
                new Vector(4, 1),
                new Vector(4, 2),
                new Vector(4, 3),
                new Vector(4, 4),
            };

            for (int i = 0; i < nodes.Length; i++)
            {
                if (positions[i].X == 0 && positions[i].Y == 2)
                {
                    startingPoint = nodes[i];
                    _block.Add(positions[i], startingPoint);
                }
                else if (positions[i].X == 4 && positions[i].Y == 2)
                {
                    endingPoint = nodes[i];
                    _block.Add(positions[i], endingPoint);
                }
                else
                {
                    _block.Add(positions[i], nodes[i]);
                }

            }

            Console.WriteLine("The starting point is: " + startingPoint.X + ", " + startingPoint.Y);
            Console.WriteLine("The final point is: " + endingPoint.X + ", " + endingPoint.Y);
            //Por alguna razon esto no quizo funcionar
            /*for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 5; j++)
                {
                    positions[i] = new Vector(i, j);
                }
            } //cree las posiciones

            for (int i = 0; i < 5; i++) //Cree los nodos
            {
                for (int j = 0; j < 5; j++)
                {
                    nodes[i] = new Node(i, j);
                }               
            }*/

        }

        public void BFS()
        {
            queue.Enqueue(startingPoint);
            while (queue.Count > 0 && isExploring)
            {
                searchingPoint = queue.Dequeue();
                OnReachingEnd();
                ExploreNeighbourNodes();
            }
        }

        private void ExploreNeighbourNodes()
        {
            if (!isExploring) { return; }

            foreach (Vector direction in directions)
            {
                Vector neighbourPos = (new Vector(direction.X + searchingPoint.X, direction.Y + searchingPoint.Y));

                if (_block.ContainsKey(neighbourPos))
                {
                    Node node = _block[neighbourPos];

                    if (!node.isExplored)
                    {
                        queue.Enqueue(node);
                        node.isExplored = true;

                        node.isExploredFrom = searchingPoint;
                    }
                }
            }
        }

        private void OnReachingEnd()
        {
            if (searchingPoint == endingPoint)
            {
                isExploring = false;
            }
            else
            {
                isExploring = true;
            }
        }

        public void CreatePath()
        {
            SetPath(endingPoint);
            Node previousNode = endingPoint.isExploredFrom;

            while (previousNode != startingPoint)
            {
                SetPath(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            SetPath(startingPoint);
            _path.Reverse();


        }
        private void SetPath(Node node)
        {
            _path.Add(node);
        }
        public void PrintPath()
        {
            Console.WriteLine("The designed path is: ");
            foreach(Node node in _path)
            {
                Console.WriteLine(node.X + "," + node.Y);
            }
        }
    }


}

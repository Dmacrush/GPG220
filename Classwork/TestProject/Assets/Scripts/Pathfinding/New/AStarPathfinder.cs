using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.New
{
    public class AStarPathfinder : MonoBehaviour
    {

        public Transform seeker, target;
        private Grid grid;

        private void Awake()
        {
            grid = GetComponent<Grid>();
        }

        private void Update()
        {
            FindPath(seeker.position,target.position);
        }

        void FindPath(Vector3 startPos, Vector3 endPos)
        {
            Node startNode = grid.NodeFromWorldPoint(startPos);
            Node targetNode = grid.NodeFromWorldPoint(endPos);

            List<Node> openSet = new List<Node>();
            HashSet<Node> closeSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost < currentNode.fCost ||
                        openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closeSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    RetracePath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.isWalkable || closeSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementConstToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementConstToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementConstToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                             openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
        
        void RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();

            grid.path = path;
        }
        
        int GetDistance(Node nodeA, Node nodeB)
        {
            int disX = Math.Abs(nodeA.gridX - nodeB.gridX);
            int disY = Math.Abs(nodeA.gridY - nodeB.gridY);

            if (disX > disY)
            {
                return 14 * disY + 10 * (disX - disY);
            }

            return 14 * disX + 10 * (disY - disX);
        }
    }
}
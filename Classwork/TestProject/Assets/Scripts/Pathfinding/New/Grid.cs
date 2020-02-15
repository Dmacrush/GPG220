﻿using UnityEngine;

namespace Pathfinding.New
{
    public class Grid : MonoBehaviour
    {
        public LayerMask unWalkableMask;
        public Vector2 gridWorldSize;
        public float nodeRadius;
        private Node[,] grid;

        private float nodeDiameter;
        private int gridSizeX, gridSizeY;
    
        private void Start()
        {
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
            CreateGrid();


        }

        private void CreateGrid()
        {
            grid = new Node[gridSizeX,gridSizeY];
            Vector3 worldBottemLeft =
                transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
            
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint = worldBottemLeft + Vector3.right * (x * nodeDiameter + nodeRadius) +
                                         Vector3.forward * (y * nodeDiameter + nodeRadius);
                    bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius,unWalkableMask));
                    grid[x,y] = new Node(walkable, worldPoint);
                
                }
            }
        }

        public Node NodeFromWorldPoint(Vector3 worldPosition)
        {
            float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
            return grid[x, y];
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x,1,gridWorldSize.y));
        
            if(grid != null)
            {
                foreach (Node node in grid)
                {
                    Gizmos.color = (node.isWalkable) ? Color.white : Color.red;
                    
                    Gizmos.DrawCube(node.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }
        }
    }
}
using UnityEngine;

namespace Pathfinding.New
{
    public class Node
    {
        public bool isWalkable;
        public Vector3 worldPosition;
        public int gridX;
        public int gridY;

        public int gCost;
        public int hCost;
        public Node parent;
        
        public Node(bool walkable, Vector3 worldPos, int gridXPos, int gridYPos)
        {
            isWalkable = walkable;
            worldPosition = worldPos;
            gridX = gridXPos;
            gridY = gridYPos;
        }

        public int fCost
        {
            get { return gCost + hCost; }
            
        }
        

    }
}

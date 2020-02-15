using UnityEngine;

namespace Pathfinding.New
{
    public class Node
    {
        public bool isWalkable;
        public Vector3 worldPosition;

        public Node(bool walkable, Vector3 worldPos)
        {
            isWalkable = walkable;
            worldPosition = worldPos;
        }

    }
}

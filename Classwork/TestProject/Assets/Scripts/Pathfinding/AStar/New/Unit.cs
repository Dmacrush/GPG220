using System.Collections;
using Pathfinding.New;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Pathfinding.AStar.New
{
    public class Unit : MonoBehaviour
    {
        public Transform target;
        float speed = 20;
        public float turnDst = 5f;

        private Path path;
        void Start()
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }

        public void OnPathFound(Vector3[] wayPoints, bool pathSuccessful)
        {
            if (pathSuccessful)
            {
                path = new Path(wayPoints,transform.position,turnDst);
               
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }

        IEnumerator FollowPath()
        {
            
            while (true)
            {
                yield return null;
            }
        }

        public void OnDrawGizmos()
        {
            if (path != null)
            {
                path.DrawWithGizmos();
            }
        }
    }
}
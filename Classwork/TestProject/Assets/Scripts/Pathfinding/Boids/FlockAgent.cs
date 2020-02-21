using System;
using UnityEngine;

namespace Pathfinding.Boids
{
    [RequireComponent(typeof(Collider))]
    public class FlockAgent : MonoBehaviour
    {
        private Collider agentCollider;

        public Collider AgentCollider
        {
            get
            {
                return agentCollider;
            }
        }

        private void Start()
        {
            agentCollider = GetComponent<Collider>();
        }

        public void Move(Vector3 velocity)
        {
            transform.forward = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
    }
}

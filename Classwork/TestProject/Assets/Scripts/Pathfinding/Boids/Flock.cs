using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pathfinding.Boids
{
    public class Flock : MonoBehaviour
    {
        [Header("Flock Setup")]
        public FlockAgent agentPrefab;
        List<FlockAgent> agents = new List<FlockAgent>();
        public FlockBehaviour behaviour;

        [Range(10, 500)] public int startingCount = 100;
        private const float AgentDensity = 0.8f;

        [Header("Agent Stats")] 
        [Range(1f, 100f)] 
        public float driveFactor = 10f;
        [Range(1f, 100f)] 
        public float maxSpeed = 5f;
        [Range(1f, 10f)] 
        public float neightbourRadius;
        [Range(0f, 1f)] 
        public float avoidanceRadiusMultiplier = 0.5f;

        private float squareMaxSpeed;
        private float squareNeighbourRadius;
        private float squareAvoidanceRadius;

        public float SquareAvoidanceRadius
        {
            get { return squareAvoidanceRadius; }
        }

        private void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighbourRadius = neightbourRadius * neightbourRadius;
            squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                Vector3 newPos = Random.insideUnitSphere * startingCount * AgentDensity;
                FlockAgent newAgent = Instantiate(agentPrefab, new Vector3(newPos.x,transform.position.y + 1,newPos.z),
                    Quaternion.Euler(Vector3.up * Random.Range(0f, 360)), transform);
                newAgent.name = "Agent " + i;
                agents.Add(newAgent);
            }
        }
    }
}

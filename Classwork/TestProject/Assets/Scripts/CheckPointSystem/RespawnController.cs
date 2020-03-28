using UnityEngine;
using System.Collections;

namespace CheckPointSystem
{
    public class RespawnController : MonoBehaviour
    {
        public RespawnController respawningCheckPoint = null;

        public delegate void MyDelegate();

        public event MyDelegate onRespawn;

        Vector3 initialPosition;

        void Awake()
        {
            if (respawningCheckPoint == null)
            {
                Debug.LogWarning("You forgot to assign a checkpoint to enemy " + gameObject.ToString());
            }

            respawningCheckPoint = GetComponent<RespawnController>();
            
            initialPosition = transform.position;
            respawningCheckPoint.onRespawn += TimeToRespawn;

        }

        public void TimeToRespawn()
        {
            transform.position = initialPosition;
            onRespawn();
        }
    }
}

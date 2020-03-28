using System;
using UnityEngine;

namespace CheckPointSystem
{
    public class Enemy : MonoBehaviour
    {
        public int health = 10;

        
        private void Awake()
        {
            
        }

        void ResetStuff()
        {
            health = 10;
            Debug.Log(health);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                health -= 1;
                Debug.Log(health);
            }
        }
    }
}

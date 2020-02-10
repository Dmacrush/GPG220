using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystemTest
{
    public class PlaceableBuilding : MonoBehaviour
    {
        [HideInInspector]
        public List<Collider> colliders = new List<Collider>();

        private bool isSelected;

        private void OnGUI()
        {
            if (isSelected)
            {
                GUI.Button(new Rect(100, 200, 100, 30), name);
                
                if (GUI.Button(new Rect(100, 250, 100, 30), "Do Thing"))
                {
                    TestFunction();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Building"))
            {
                colliders.Add(other);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Building"))
            {
                colliders.Remove(other);
            }
        }

        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }

        private void TestFunction()
        {
            Debug.Log("Huh");
        }
    }
}

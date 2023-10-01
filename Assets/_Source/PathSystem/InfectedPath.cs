using System;
using ItemsSystem;
using UnityEngine;

namespace PathSystem
{
    public class InfectedPath : MonoBehaviour
    {
        [SerializeField] private PathNode[] infectedNode;
        [SerializeField] private Key key;

        private void Start()
        {
            foreach (PathNode node in infectedNode)
            {
                node.IsInfected = true;
            }
            //key.OnPickUp += OpenPath
        }

        private void OpenPath()
        {
            foreach (PathNode node in infectedNode)
            {
                node.IsInfected = false;
            }
        }
    }
}

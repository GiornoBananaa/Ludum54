using System;
using InputSystem;
using UnityEngine;

namespace PathSystem
{
    public class PathNode : MonoBehaviour
    {
        [field: SerializeField] public PathNode[] NearNodes { get; private set; }
        public bool IsInfected { get; private set; }
        public Vector3 Point => transform.position;
        
        
        private void Awake()
        {
            IsInfected = false;
        }
        
        private void GetInfection()
        {
            IsInfected = true;
            //TODO: path red coloring after infection
        }

        private void OnMouseDown()
        {
            InputListener.Instance.MoveToNode(this);
        }
    }
}

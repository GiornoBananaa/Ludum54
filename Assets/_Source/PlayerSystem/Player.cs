using System;
using PathSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        public int blockedSteps;
        public PathNode spawnNode;
        
        private PlayerInvoker _playerInvoker;
        
        private void Awake()
        {
            transform.position = spawnNode.transform.position;
        }
    
        public void Construct(PlayerInvoker playerInvoker)
        {
            _playerInvoker = playerInvoker;
        }

        private void Update()
        {
            _playerInvoker.MoveToNode();
        }
    }
}

using PathSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker
    {
        private PlayerMovement _playerMovement;

        public PlayerInvoker(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public void SetNewPosition(PathNode node)
        {
            _playerMovement.SetNewPosition(node);
        }
        public void MoveToNode()
        {
            _playerMovement.Move();
        }
    }
}

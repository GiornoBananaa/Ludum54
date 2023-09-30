using PathSystem;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerInvoker _playerInvoker;
        public static InputListener Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public void Construct(PlayerInvoker playerInvoker)
        {
            _playerInvoker = playerInvoker;
        }
        
        public void MoveToNode(PathNode node)
        {
            _playerInvoker.SetNewPosition(node);
        }
    }
}

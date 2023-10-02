using PathSystem;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private AudioSource _clickNode;
        [SerializeField] private AudioSource _clickObstacle;
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

        public void ObstacleClick()
        {
            if(_clickObstacle != null)_clickObstacle.Play();
        }
        
        public void MoveToNode(PathNode node)
        {
            if(_clickNode != null)_clickNode.Play();
            _playerInvoker.SetNewPosition(node);
        }
    }
}

using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Player player;
        
        private PlayerInvoker _playerInvoker;
        private PlayerMovement _playerMovement;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _playerMovement = new PlayerMovement(player.transform, player.MoveSpeed ,player.spawnNode);
            _playerInvoker = new PlayerInvoker(_playerMovement);
            player.Construct(_playerInvoker);
            inputListener.Construct(_playerInvoker);
        }
    }
}

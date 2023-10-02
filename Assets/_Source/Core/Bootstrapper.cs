using InputSystem;
using PathSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private float lineWidth;
        [SerializeField] private int lineLayerOrder;
        [SerializeField] private Material lineMaterial;
        [SerializeField] private Material blockedPath;
        [SerializeField] private Material deafultPath;
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
            PathNode.Links = new PathLinkDictionary(lineWidth,lineLayerOrder,lineMaterial);
            _playerMovement = new PlayerMovement(player.transform, player.MoveSpeed,
                player.spawnNode,player.blockedSteps, blockedPath, deafultPath);
            _playerInvoker = new PlayerInvoker(_playerMovement);
            player.Construct(_playerInvoker);
            inputListener.Construct(_playerInvoker);
        }
    }
}

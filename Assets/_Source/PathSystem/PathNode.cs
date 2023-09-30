using System;
using InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace PathSystem
{
    public class PathNode : MonoBehaviour
    {
        [field: SerializeField] public PathNode[] NearNodes { get; private set; }
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite activatedSprite;
        [SerializeField] private Sprite blockedSprite;
        [SerializeField] private Sprite infectedSprite;
        [SerializeField] private Sprite deafultSprite;
        
        public Vector3 Point => transform.position;
        
        public bool IsActivated
        {
            get => _isActivated;
            set
            {
                if(_isBlocked || _isInfected) return;
                spriteRenderer.sprite = value ? activatedSprite : deafultSprite;
                _isActivated = value;
            }
        }
        
        public bool IsBlocked
        {
            get => _isBlocked;
            set
            {
                spriteRenderer.sprite = value ? blockedSprite : deafultSprite;
                _isBlocked = value;
            }
        }

        public bool IsInfected
        {
            get => _isInfected;
            set
            {
                spriteRenderer.sprite = value ? infectedSprite : deafultSprite;
                _isBlocked = value;
            }
        }
        private bool _isActivated;
        private bool _isBlocked;
        private bool _isInfected;
        
        private void Awake()
        {
            IsInfected = false;
            _isBlocked = false;
        }

        private void OnMouseEnter()
        {
            if(IsActivated)
                spriteRenderer.sprite = deafultSprite;
        }

        private void OnMouseDown()
        {
            if (IsActivated)
            {
                InputListener.Instance.MoveToNode(this);
            }
        }
        
        private void OnMouseExit()
        {
            if(IsActivated)
                spriteRenderer.sprite = activatedSprite;
        }
    }
}

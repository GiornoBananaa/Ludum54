using System;
using InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace PathSystem
{
    public class PathNode : MonoBehaviour
    {
        public static PathLinkDictionary Links;
        
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
                if (_isActivated) _isActivated = true;
            }
        }

        public bool IsInfected
        {
            get => _isInfected;
            set
            {
                spriteRenderer.sprite = value ? infectedSprite : deafultSprite;
                _isInfected = value;
                if (_isActivated) _isActivated = true;
            }
        }
        private bool _isActivated;
        private bool _isBlocked;
        private bool _isInfected;
        
        private void Start()
        {
            IsInfected = false;
            _isBlocked = false;
            for (int i = 0; i < NearNodes.Length; i++)
            {
                Links.Add(this,NearNodes[i]);
            }
            
            spriteRenderer.sprite = IsActivated ? activatedSprite : deafultSprite;
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

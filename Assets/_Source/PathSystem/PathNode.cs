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
        [SerializeField] private Sprite highlightedSprite;
        [SerializeField] private Sprite deafultSprite;
        [SerializeField] private bool isUnchangeable;
        
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
                if(isUnchangeable) return;
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
                if(isUnchangeable) return;
                spriteRenderer.sprite = value ? infectedSprite : deafultSprite;
                _isInfected = value;
                if (_isActivated) _isActivated = true;
            }
        }
        private bool _isActivated = false;
        private bool _isBlocked = false;
        private bool _isInfected = false;

        private void Start()
        {
            for (int i = 0; i < NearNodes.Length; i++)
            {
                Links.Add(this,NearNodes[i]);
            }
            if(IsActivated)
                spriteRenderer.sprite =  activatedSprite;
        }

        private void OnMouseEnter()
        {
            if(IsActivated)
                spriteRenderer.sprite = highlightedSprite;
        }

        private void OnMouseDown()
        {
            if (IsActivated)
            {
                InputListener.Instance.MoveToNode(this);
            }
            else if(IsInfected)
            {
                InputListener.Instance.VirusClick();
            }
        }
        
        private void OnMouseExit()
        {
            if(IsActivated)
                spriteRenderer.sprite = activatedSprite;
        }

        [ExecuteInEditMode]

        private void OnDrawGizmos()
        {
            for (int i = 0; i < NearNodes.Length; i++)
            {
                Gizmos.DrawLine(transform.position, NearNodes[i].gameObject.transform.position);
            }
        }
    }
}

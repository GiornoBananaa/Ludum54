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
        [SerializeField] private Sprite deafultSprite;
        
        public bool IsInfected { get; private set; }
        public Vector3 Point => transform.position;
        
        public bool IsActivated
        {
            get => _isActivated;
            set
            {
                if(value)
                    spriteRenderer.sprite = activatedSprite;
                else
                    spriteRenderer.sprite = deafultSprite;
                _isActivated = value;
            }
        }

        private bool _isActivated;
        
        private void Awake()
        {
            IsInfected = false;
        }
        
        private void GetInfection()
        {
            IsInfected = true;
            //TODO: path red coloring after infection
        }

        private void OnMouseEnter()
        {
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

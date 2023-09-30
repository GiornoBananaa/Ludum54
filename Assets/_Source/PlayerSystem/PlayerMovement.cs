using System.Linq;
using PathSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private readonly float _moveSpeed;
        private readonly Transform _transform;
        private float _timeElapsed;
        private bool _isMoving;
        private PathNode _destination;
        private PathNode _currentNode;
        
        public PlayerMovement(Transform transform,float moveSpeed, PathNode currentNode)
        {
            _transform = transform;
            _moveSpeed = moveSpeed;
            _currentNode = currentNode;
            _destination = currentNode;
            _isMoving = false;
            ActivateNodes(true);
        }
        
        public void Move()
        {
            if(!_isMoving) return;
            if (Vector3.Distance(_transform.position,_destination.Point) != 0)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, _destination.Point, Time.deltaTime * _moveSpeed);
            }
            else
            {
                _isMoving = false;
            }
        }
        
        public void SetNewPosition(PathNode node)
        {
            if (_isMoving || node.IsInfected) return;
            ActivateNodes(false);
            _currentNode = _destination;
            _isMoving = true;
            _timeElapsed = 0;
            _destination = node;
            ActivateNodes(true);

        }

        private void ActivateNodes(bool active)
        {
            foreach (var node in _destination.NearNodes)
            {
                node.IsActivated = active;
            }
        }
    }
}

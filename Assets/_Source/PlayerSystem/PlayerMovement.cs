using System.Collections.Generic;
using PathSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private readonly float _moveSpeed;
        private readonly Transform _transform;
        private float _timeElapsed;
        private int _blockedSteps;
        private bool _isMoving;
        private Material _blockedPath;
        private Material _deafultPath;
        private PathNode _destination;
        private PathNode _currentNode;
        private Queue<PathNode> _lastNodes;
        
        public PlayerMovement(Transform transform,float moveSpeed, PathNode currentNode, int blockedSteps, Material blockedPath,Material deafultPath)
        {
            _transform = transform;
            _moveSpeed = moveSpeed;
            _currentNode = currentNode;
            _destination = currentNode;
            _blockedSteps = blockedSteps;
            _blockedPath = blockedPath;
            _deafultPath = deafultPath;
            _isMoving = false;
            _lastNodes = new Queue<PathNode>();
            _lastNodes.Enqueue(_currentNode);
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
            _destination.IsBlocked = true;
            _currentNode = _destination;
            _isMoving = true;
            _timeElapsed = 0;
            _destination = node;
            LineBlockPath(_destination);
            _lastNodes.Enqueue(_destination);
            if (_lastNodes.Count > _blockedSteps)
            {
                PathNode delnode = _lastNodes.Dequeue();
                delnode.IsBlocked = false;
                LineUnBlockPath(delnode);
            }
            ActivateNodes(true);
        }
        
        private void LineBlockPath(PathNode node)
        {
            foreach (PathNode node2 in _lastNodes)
            {
                if (PathNode.Links.Contains(node2, node))
                {
                    LineRenderer line = PathNode.Links.GetLineRender(node, node2);
                    line.material = _blockedPath;
                }
            }
        }
        
        private void LineUnBlockPath(PathNode node)
        {
            foreach (PathNode node2 in _lastNodes)
            {
                if (PathNode.Links.Contains(node2, node))
                {
                    LineRenderer line = PathNode.Links.GetLineRender(node, node2);
                    line.material = _deafultPath;
                }
            }
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

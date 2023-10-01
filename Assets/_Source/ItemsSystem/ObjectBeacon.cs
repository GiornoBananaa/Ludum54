using UnityEngine;

namespace ItemsSystem
{
    public class ObjectBeacon : MonoBehaviour
    {
        [SerializeField] protected float minRenderDistance;
        [SerializeField] protected GameObject sprite;
        [SerializeField] private Transform target;

        protected bool _isHidden = false;

        private void Update()
        {
            LookAtItem(target);
            CheckDistance(target);
        }
        
        protected void LookAtItem(Transform targetTransform)
        {
            transform.right = targetTransform.position - transform.position;
        }
        
        protected void CheckDistance(Transform targetTransform)
        {
            if (Vector3.Distance(targetTransform.position,transform.position) < minRenderDistance)
            {
                _isHidden = true;
                sprite.SetActive(false);
            }
            else if(_isHidden)
            {
                _isHidden = false;
                sprite.SetActive(true);
            }
        }
    }
}

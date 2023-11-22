using UnityEngine;
using Utils;

namespace ObstacleSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CollapsiblePart : MonoBehaviour
    {
        private LayerMask _playerLayerMask;
        private CollapsibleObstacle _collapsibleObstacle;
        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;

        private void Awake()
        {
            _defaultPosition = transform.localPosition;
            _defaultRotation = transform.localRotation;
        }

        public void Construct(CollapsibleObstacle collapsibleObstacle,LayerMask playerLayerMask)
        {
            _collapsibleObstacle = collapsibleObstacle;
            _playerLayerMask = playerLayerMask;
        }

        public void Reset()
        {
            transform.localPosition = _defaultPosition;
            transform.localRotation = _defaultRotation;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(1);
            if (LayersUtility.Contains(_playerLayerMask,other))
            {
                Debug.Log(2);
                _collapsibleObstacle.ActivateObstacle();
            }
        }
    }
}

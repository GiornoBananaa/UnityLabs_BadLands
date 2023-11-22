using UnityEngine;

namespace ObstacleSystem
{
    public class CollapsibleObstacle : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private CollapsiblePart[] _collapsibleParts;
        [SerializeField] private Rigidbody2D[] _rigidbodies;

        private bool _isStatic;

        private void Awake()
        {
            _isStatic = true;
            foreach (var collapsiblePart in _collapsibleParts)
            {
                collapsiblePart.Construct(this, _playerLayerMask);
            }
        }

        private void OnDisable()
        {
            Reset();
        }

        private void Reset()
        {
            for (int i = 0; i < _collapsibleParts.Length; i++)
            {
                _rigidbodies[i].bodyType = RigidbodyType2D.Kinematic;
                _collapsibleParts[i].Reset();
            }
            _isStatic = true;
        }

        public void ActivateObstacle()
        {
            if (!_isStatic) return;
            _isStatic = false;
            for (int i = 0; i < _collapsibleParts.Length; i++)
            {
                _rigidbodies[i].bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

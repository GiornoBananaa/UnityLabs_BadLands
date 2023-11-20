using UnityEngine;
using UnityEngine.Serialization;

namespace ObstacleSystem
{
    public class СollapsibleObstacle : MonoBehaviour
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
        
        public void ActivateObstacle()
        {
            Debug.Log(_isStatic);
            if (!_isStatic) return;
            _isStatic = false;
            Debug.Log(2);
            for (int i = 0; i < _collapsibleParts.Length; i++)
            {
                _rigidbodies[i].bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

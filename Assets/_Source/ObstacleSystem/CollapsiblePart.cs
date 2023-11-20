using System;
using UnityEngine;

namespace ObstacleSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CollapsiblePart : MonoBehaviour
    {
        private LayerMask _playerLayerMask;

        private СollapsibleObstacle _сollapsibleObstacle;
        
        public void Construct(СollapsibleObstacle collapsibleObstacle,LayerMask playerLayerMask)
        {
            _сollapsibleObstacle = collapsibleObstacle;
            _playerLayerMask = playerLayerMask;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_playerLayerMask == (_playerLayerMask | (1 << other.gameObject.layer)))
            {
                _сollapsibleObstacle.ActivateObstacle();
            }
        }
    }
}

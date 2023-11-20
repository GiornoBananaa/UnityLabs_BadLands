using System;
using UnityEngine;

namespace ObstacleSystem
{
    public class DeadlyTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerMask;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_playerMask == (_playerMask  | (1<<collision.gameObject.layer)))
               gameObject.SetActive(false);
        }
    }
}

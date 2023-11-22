using UnityEngine;
using Utils;

namespace ObstacleSystem
{
    public class DeadlyTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayerMask;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayersUtility.Contains(_playerLayerMask,collision.gameObject.layer))
               gameObject.SetActive(false);
        }
    }
}

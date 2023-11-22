using System;
using Core;
using UnityEngine;
using Utils;

namespace LevelGenerationSystem
{
    public class LevelEndTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayerMask;

        public Action OnPlayerReachEnd;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayersUtility.Contains(_playerLayerMask,other))
            {
                OnPlayerReachEnd?.Invoke();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector: MonoBehaviour
    {
        [SerializeField] private LayerMask _deadlySurfaceMask;
        [SerializeField] private LayerMask _upScalerMask;
        [SerializeField] private LayerMask _downScalerMask;
        private Player _player;
        private bool _isDead;
        private List<Vector2> _collisionsVelocity;
        
        public void Construct(Player player)
        {
            _collisionsVelocity = new List<Vector2>();
            _isDead = false;
            _player = player;
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            foreach (var velocity in _collisionsVelocity)
            {
                float angle = Vector2.Angle(velocity, other.relativeVelocity);
                if (angle > 90f &&
                    angle < 270f)
                    Console.WriteLine("dead");
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _collisionsVelocity.Add(other.relativeVelocity);
            if(_deadlySurfaceMask == (_deadlySurfaceMask  | (1<<other.gameObject.layer)) && !_isDead)
            {
                _player.PlayDeath();
                _isDead = true;
            }
            else if(_upScalerMask == (_upScalerMask  | (1<<other.gameObject.layer)))
            {
                _player.UpSclale();
                other.gameObject.SetActive(false);
            }
            else if(_downScalerMask == (_downScalerMask  | (1<<other.gameObject.layer)))
            {
                _player.DownSclale();
                other.gameObject.SetActive(false);
            }
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            _collisionsVelocity.Remove(other.relativeVelocity);
        }
    }
}

using UnityEngine;

namespace CameraSystem
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _xBoundsForSpeed;
        
        private bool _playerIsAfk;

        private void Update()
        {
            if(!_playerIsAfk)
                MoveForward();
        }

        public void StartMove()
        {
            _playerIsAfk = false;
        }
        
        private void MoveForward()
        {
            float xOffset = transform.position.x - _player.position.x;
            float percent = (_xBoundsForSpeed + xOffset)/(_xBoundsForSpeed*2);
            percent = percent > 1 ? 1 : percent;
            percent = percent < 1 ? 0 : percent;
            float speed = _maxSpeed-(_maxSpeed-_minSpeed)*percent;
            transform.position += Vector3.right * (speed*Time.deltaTime);
        }
    }
}

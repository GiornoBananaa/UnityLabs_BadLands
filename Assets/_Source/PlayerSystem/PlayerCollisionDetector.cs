using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector: MonoBehaviour
    {
        [SerializeField] private LayerMask _deadlySurfaceMask;
        [SerializeField] private LayerMask _upScalerMask;
        [SerializeField] private LayerMask _downScalerMask;
        private Player _player;
        
        public void Construct(Player player)
        {
            _player = player;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_deadlySurfaceMask == (_deadlySurfaceMask  | (1<<other.gameObject.layer)))
            {
                _player.PlayDeath();
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
    }
}

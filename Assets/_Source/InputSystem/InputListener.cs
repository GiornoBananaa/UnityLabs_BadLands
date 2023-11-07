using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode _jumpKey;
        private Player _player;
        
        public void Constructor(Player player)
        {
            _player = player;
        }

        private void Update()
        {
            ReadPlayerMoveHorizontal();
            ReadJump();
        }
        
        private void ReadJump()
        {
            if(Input.GetKeyDown(_jumpKey))
                _player.Jump();
        }
        
        private void ReadPlayerMoveHorizontal()
        {
            float x = Input.GetAxis("Horizontal");
            if(x!=0)
                _player.MovePlayer(x);
        }
    }
}

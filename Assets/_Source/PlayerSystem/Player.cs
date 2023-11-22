using System;
using CameraSystem;
using Core;

namespace PlayerSystem
{
    public class Player
    {
        private readonly PlayerModel _model;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerScaling _playerScaling;
        private bool _isDead = false;
        private bool _isFirstMove = true;

        public Action OnStartMoving;
        public Action OnDeath;
        
        public Player(PlayerModel model, PlayerMovement playerMovement,
            PlayerScaling playerScaling)
        {
            _model = model;
            _playerMovement = playerMovement;
            _playerScaling = playerScaling;
        }
        
        public void StopRotation() => _playerMovement.StopRotationStabilizing();
        
        public void UpSclale() => _playerScaling.ChangeScale(true);
        public void DownSclale() => _playerScaling.ChangeScale(false);
        
        public void PlayDeath( )
        {
            _isDead = true;
            OnDeath?.Invoke();
        }
        
        public void MoveHorizontal(float x)
        {
            if(!_isDead)
                _playerMovement.HorizontalMove(x,_model.Speed);
        }
        
        public void Jump()
        {
            if(_isFirstMove)
            {
                OnStartMoving?.Invoke();
                _isFirstMove = false;
            }
            
            if(!_isDead)
                _playerMovement.Jump(_model.JumpForce);
        }
    }
}

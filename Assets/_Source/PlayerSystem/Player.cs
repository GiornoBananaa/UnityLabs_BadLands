using CameraSystem;
using Core;
using TMPro.EditorUtilities;
using UnityEngine;

namespace PlayerSystem
{
    public class Player
    {
        private readonly PlayerModel _model;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerScaling _playerScaling;
        private readonly CameraTarget _cameraTarget;
        private readonly Game _game;
        
        private bool _isDead = false;
        
        public Player(PlayerModel model, PlayerMovement playerMovement,
            PlayerScaling playerScaling,CameraTarget cameraTarget,Game game)
        {
            _model = model;
            _playerMovement = playerMovement;
            _playerScaling = playerScaling;
            _cameraTarget = cameraTarget;
            _game = game;
        }
            
        public void PlayDeath( )
        {
            _isDead = true;
            _game.LoseLevel();
        }
        
        public void UpSclale( )
        {
            _playerScaling.ChangeScale(true);
        }
        public void DownSclale( )
        {
            _playerScaling.ChangeScale(false);
        }
        public void MovePlayer(float x)
        {
            if(!_isDead)
                _playerMovement.HorizontalMove(x);
        }
        public void Jump()
        {
            _cameraTarget.StartMove();
            if(!_isDead)
                _playerMovement.Jump();
        }
    }
}

using System;
using CameraSystem;
using InputSystem;
using LevelGenerationSystem;
using PlayerSystem;
using UISystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private SceneTransitionView _sceneTransitionView;
        [SerializeField] private CameraTarget _cameraTarget;
        [SerializeField] private LevelEndTrigger _levelEndTrigger;
        
        private Game _game;
        private Player _player;
        private PlayerModel _playerModel;
        private PlayerMovement _playerMovement;
        private PlayerScaling _playerScaling;
            
        private void Awake()
        {
            //Core
            _game = new Game(_sceneTransitionView);
            //PlayerSystem
            _playerModel = new PlayerModel(5,5);
            _playerMovement = new PlayerMovement(_playerRigidbody);
            _playerScaling = new PlayerScaling(_playerRigidbody.transform,0.2f);
            _player = new Player(_playerModel,_playerMovement,_playerScaling);
            _playerCollisionDetector.Construct(_player);
            _player.OnDeath += _game.LoseLevel;
            _player.OnStartMoving += _cameraTarget.StartMove;
            //InputSystem
            _inputListener.Construct(_player);
            //Level
            _levelEndTrigger.OnPlayerReachEnd += _game.FinishLevel;
        }

        private void OnDestroy()
        {
            _player.OnDeath -= _game.LoseLevel;
            _player.OnStartMoving -= _cameraTarget.StartMove;
            _levelEndTrigger.OnPlayerReachEnd -= _game.FinishLevel;
        }
    }
}

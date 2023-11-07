using InputSystem;
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
            _playerModel = new PlayerModel(5);
            _playerMovement = new PlayerMovement(_playerRigidbody,_playerModel.Speed,5);
            _playerScaling = new PlayerScaling(_playerRigidbody.transform,0.2f);
            _player = new Player(_playerModel,_playerMovement,_playerScaling,_game);
            _playerCollisionDetector.Construct(_player);
            //InputSystem
            _inputListener.Constructor(_player);
        }
    }
}

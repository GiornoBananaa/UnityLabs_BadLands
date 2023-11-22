using Core;
using UnityEngine;
using Utils;

namespace LevelGenerationSystem
{
    public class LevelEndTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayerMask;

        private Game _game;
        
        public void Construct(Game game)
        {
            _game = game;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayersUtility.Contains(_playerLayerMask,other))
            {
                _game.FinishLevel();
            }
        }
    }
}

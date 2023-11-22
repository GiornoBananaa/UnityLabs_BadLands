using UISystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private SceneTransitionView _sceneTransitionView;
        private const string LEVEL_COUNT_KEY = "Level";
        
        public Game(SceneTransitionView sceneTransitionView)
        {
            _sceneTransitionView = sceneTransitionView;
        }
        
        public void LoseLevel()
        {
            _sceneTransitionView.TransitionFade(Restart);
        }
        
        public void FinishLevel()
        {
            PlayerPrefs.SetInt(LEVEL_COUNT_KEY, PlayerPrefs.GetInt(LEVEL_COUNT_KEY,1)+1);
            _sceneTransitionView.TransitionFade(Restart);
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

using DG.Tweening;
using UISystem;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private SceneTransitionView _sceneTransitionView;
        
        public Game(SceneTransitionView sceneTransitionView)
        {
            _sceneTransitionView = sceneTransitionView;
        }
        
        public void LoseLevel()
        {
            TweenCallback callback = _sceneTransitionView.TransitionFade();
            callback += RestartLevel;
        }
        
        public void WinLevel()
        {
            
        }
        
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

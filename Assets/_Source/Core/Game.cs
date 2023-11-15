using System;
using DG.Tweening;
using UISystem;
using UnityEngine;
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
            _sceneTransitionView.TransitionFade(RestartLevel);
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

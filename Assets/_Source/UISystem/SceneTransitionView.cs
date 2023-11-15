using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class SceneTransitionView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        private void Start()
        {
            _image.DOFade(0,1);
        }
        
        public void TransitionFade(Action action)
        {
            _image.DOFade(1, 1).OnComplete(() => action?.Invoke());
        }
    }
}

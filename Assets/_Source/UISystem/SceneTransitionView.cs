using Core;
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
        
        public TweenCallback TransitionFade()
        {
            return _image.DOFade(1,1).onComplete;
        }
    }
}

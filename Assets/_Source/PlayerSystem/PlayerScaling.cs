using DG.Tweening;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerScaling
    {
        private Transform _transform;

        private float _scaleModifier;

        public PlayerScaling(Transform transform, float scaleModifier)
        {
            _scaleModifier = scaleModifier;
            _transform = transform;
        }
        
        public void ChangeScale(bool scaleUp)
        {
            float modifier = scaleUp ? _scaleModifier : -_scaleModifier;
            _transform.DOScale(_transform.localScale + Vector3.one*modifier,1);
        }
    }
}

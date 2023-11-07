using System;
using Cinemachine;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace ObstacleSystem
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _duration;
        [SerializeField] private float _rotation;

        private void Start()
        {
            _rigidbody.DORotate(_rotation,_duration).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}

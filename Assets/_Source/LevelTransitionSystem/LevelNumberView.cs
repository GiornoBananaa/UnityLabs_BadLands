using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace LevelTransitionSystem
{
    public class LevelNumberView : MonoBehaviour
    {
        private const string LEVEL_COUNT_KEY = "Level";
        
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private float _fadeTime;
        [SerializeField] private float _textTime;

        private void Start()
        {
            _levelText.text = $"LEVEL {PlayerPrefs.GetInt(LEVEL_COUNT_KEY,1)}";
            StartCoroutine(LevelFade());
        }
        
        private IEnumerator LevelFade()
        {
            yield return new WaitForSeconds(1);
            _levelText.DOFade(1, _fadeTime);
            yield return new WaitForSeconds(_textTime);
            _levelText.DOFade(0, _fadeTime);
        }
    }
}

using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TypoGrapher
{
    /// <summary>
    /// Textのベースクラス
    /// </summary>
    public class TextItem : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _text;

        public void SetEnable(bool enable)
        {
            _text.enabled = enable;
        }

        public void Fade(bool enable, float duration, Action onComplete = null)
        {
            _text.DOKill();
            DOFadeActive(enable, duration).OnComplete(() => onComplete?.Invoke());
        }

        #region Tween
        
        public Tween DOFadeActive(bool active, float duration)
        {
            return DOFade(active ? 1f : 0f, duration);
        }

        public Tween DOFade(float endValue, float duration)
        {
            return _text.DOFade(endValue, duration);
        }

        #endregion
    }
}
